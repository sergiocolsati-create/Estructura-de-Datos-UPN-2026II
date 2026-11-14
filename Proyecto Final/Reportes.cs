using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Linq;

namespace Shalom
{
    public class FiltroReporte
    {
        public TipoPeriodo Periodo { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoEnvio? Seccion { get; set; }
        public Sede SedeOrigen { get; set; }
        public Sede SedeDestino { get; set; }
    }
    public static class Reportes
    {
        public static string ReporteEnvio(Envio envio)
        {
            StringBuilder sb = new StringBuilder();
            string linea = new string('=', 55);

            sb.AppendLine(linea);
            sb.AppendLine("SHALOM - REPORTE DE ENVÍO");
            sb.AppendLine("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine(linea);
            sb.AppendLine();

            sb.AppendLine("Guía:               " + envio.Codigo);
            sb.AppendLine("Estado actual:      " + ArbolEnvios.NombreEstadoLegible(envio.Estado));
            sb.AppendLine("Fecha de registro:  " + envio.FechaRegistro.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine("Última actualiz.:   " + envio.FechaActualizacion.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine();

            sb.AppendLine("--- ORIGEN Y DESTINO ---");
            sb.AppendLine("Origen:        " + NombreSede(envio.SedeOrigen));
            sb.AppendLine("Destino:       " + NombreSede(envio.SedeDestino));
            sb.AppendLine("Remitente:     " + DatosPersona(envio.Remitente));
            sb.AppendLine("Destinatario:  " + DatosPersona(envio.Destinatario));
            sb.AppendLine();

            sb.AppendLine("--- PAQUETE ---");
            sb.AppendLine("Tipo:          " + envio.Tipo);
            sb.AppendLine("Peso:          " + envio.PesoKg.ToString("0.00") + " kg");
            sb.AppendLine("Descripción:   " + envio.Descripcion);
            sb.AppendLine("Vehículo:      " + (envio.PlacaVehiculo ?? "(sin asignar)"));
            sb.AppendLine();

            sb.AppendLine("--- COBRO ---");
            sb.AppendLine("Precio:        S/ " + envio.Precio.ToString("0.00"));
            sb.AppendLine("Modalidad:     " + NombrePago(envio.ModalidadPago));
            sb.AppendLine();

            sb.AppendLine("--- HISTORIAL DE SEGUIMIENTO ---");
            string historial = envio.Historial.ObtenerTexto();
            sb.AppendLine(historial == "" ? "(sin movimientos registrados)" : historial);

            sb.AppendLine(linea);
            return sb.ToString();
        }

        // ------ Guardar en archivo de texto ------
        public static void GuardarConDialogo(string nombreSugerido, string contenido)
        {
            string extension = Path.GetExtension(nombreSugerido);   // ".txt" o ".csv"

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.FileName = nombreSugerido;
                dialogo.Filter = "Archivo " + extension + "|*" + extension;
                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    File.WriteAllText(dialogo.FileName, contenido, Encoding.UTF8);
                    MessageBox.Show("Archivo guardado en:\n" + dialogo.FileName, "Listo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar (¿está abierto en otro programa?):\n" + ex.Message, "Error");
                }
            }
        }

        // ------ Filtros ------
        public static DateTime InicioPeriodo(FiltroReporte f)
        {
            DateTime d = f.Fecha.Date;   

            switch (f.Periodo)
            {
                case TipoPeriodo.Dia:
                    return d;
                case TipoPeriodo.Mes:
                    return new DateTime(d.Year, d.Month, 1);
                case TipoPeriodo.Trimestre:
                    int mesInicial = ((d.Month - 1) / 3) * 3 + 1; 
                    return new DateTime(d.Year, mesInicial, 1);
                case TipoPeriodo.Anio:
                    return new DateTime(d.Year, 1, 1);
                default:
                    return DateTime.MinValue;   
            }
        }

        // Primer instante DESPUÉS del periodo (el límite que no se incluye).
        public static DateTime FinPeriodo(FiltroReporte f)
        {
            DateTime inicio = InicioPeriodo(f);

            switch (f.Periodo)
            {
                case TipoPeriodo.Dia: return inicio.AddDays(1);
                case TipoPeriodo.Mes: return inicio.AddMonths(1);
                case TipoPeriodo.Trimestre: return inicio.AddMonths(3);
                case TipoPeriodo.Anio: return inicio.AddYears(1);
                default: return DateTime.MaxValue;
            }
        }

        // Recorre todos los envíos del árbol y devuelve los que cumplen los filtros.
        public static List<Envio> Filtrar(FiltroReporte f)
        {
            DateTime desde = InicioPeriodo(f);
            DateTime hasta = FinPeriodo(f);
            bool revisarHistorial = f.Periodo != TipoPeriodo.Todo || f.Seccion != null;

            return Sistema.Registro.ObtenerTodos()
                .Where(e => MismaSede(f.SedeOrigen, e.SedeOrigen)
                         && MismaSede(f.SedeDestino, e.SedeDestino)
                         && (!revisarHistorial || e.Historial.TieneEvento(f.Seccion, desde, hasta)))
                .ToList();
        }

        // true si se eligió "Todas" o si la sede del envío es la elegida.
        private static bool MismaSede(Sede elegida, Sede delEnvio)
        {
            return elegida == null || elegida.Id == delEnvio?.Id;
        }

        // ---------- Reporte por filtros ----------
        public static string ReporteFiltrado(FiltroReporte f, List<Envio> envios)
        {
            StringBuilder sb = new StringBuilder();
            string linea = new string('=', 78);
            string guiones = new string('-', 78);

            // 1. Encabezado
            sb.AppendLine(linea);
            sb.AppendLine("SHALOM - REPORTE DE ENVÍOS");
            sb.AppendLine("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine(linea);
            sb.AppendLine();

            // 2. Filtros aplicados
            sb.AppendLine("FILTROS APLICADOS");
            sb.AppendLine("  Periodo:       " + DescripcionPeriodo(f));
            sb.AppendLine("  Sección:       " + NombreSeccion(f.Seccion));
            sb.AppendLine("  Sede origen:   " + (f.SedeOrigen?.Nombre ?? "Todas"));
            sb.AppendLine("  Sede destino:  " + (f.SedeDestino?.Nombre ?? "Todas"));
            sb.AppendLine();

            if (envios.Count == 0)
            {
                sb.AppendLine("No se encontraron envíos con los filtros seleccionados.");
                sb.AppendLine(linea);
                return sb.ToString();
            }

            // 3. Resumen
            decimal pesoTotal = envios.Sum(e => e.PesoKg);
            decimal montoTotal = envios.Sum(e => e.Precio);
            decimal pagado = envios.Where(e => e.ModalidadPago == ModalidadPago.PagadoEnOrigen).Sum(e => e.Precio);
            decimal porCobrar = montoTotal - pagado;

            sb.AppendLine("RESUMEN");
            sb.AppendLine("  Total de envíos:         " + envios.Count);
            sb.AppendLine("  Peso total:              " + pesoTotal.ToString("0.00") + " kg");
            sb.AppendLine("  Monto total:             S/ " + montoTotal.ToString("0.00"));
            sb.AppendLine("    Pagado en origen:      S/ " + pagado.ToString("0.00"));
            sb.AppendLine("    Por cobrar en destino: S/ " + porCobrar.ToString("0.00"));
            sb.AppendLine();
            sb.AppendLine("  Envíos según su estado actual:");

            foreach (EstadoEnvio estado in Enum.GetValues(typeof(EstadoEnvio)))
            {
                int cantidad = envios.Count(e => e.Estado == estado);
                if (cantidad > 0)
                    sb.AppendLine("    " + ArbolEnvios.NombreEstadoLegible(estado).PadRight(18) + cantidad);
            }

            // 4. Detalle: una fila por envío, en columnas alineadas
            sb.AppendLine();
            sb.AppendLine("DETALLE");
            sb.AppendLine(guiones);
            sb.AppendLine(
                "Guía".PadRight(17) +
                "Registro".PadRight(12) +
                "Ruta".PadRight(12) +
                "Estado actual".PadRight(16) +
                "Peso kg".PadLeft(9) +
                "Precio S/".PadLeft(12));
            sb.AppendLine(guiones);

            foreach (Envio e in envios)
            {
                string ruta = CodigoSede(e.SedeOrigen) + " > " + CodigoSede(e.SedeDestino);

                sb.AppendLine(
                    e.Codigo.PadRight(17) +
                    e.FechaRegistro.ToString("dd/MM/yyyy").PadRight(12) +
                    ruta.PadRight(12) +
                    ArbolEnvios.NombreEstadoLegible(e.Estado).PadRight(16) +
                    e.PesoKg.ToString("0.00").PadLeft(9) +
                    e.Precio.ToString("0.00").PadLeft(12));
            }

            sb.AppendLine(guiones);
            sb.AppendLine(linea);
            return sb.ToString();
        }

        // ---------- CSV para Excel / Power BI: una fila por envío ----------
        public static string ReporteCsv(List<Envio> envios)
        {
            StringBuilder sb = new StringBuilder();
            string sep = CultureInfo.CurrentCulture.TextInfo.ListSeparator;   // "," o ";" según la PC
            sb.AppendLine("Guia,FechaRegistro,Origen,Destino,Remitente,Destinatario,Tipo,PesoKg,PrecioSoles,ModalidadPago,EstadoActual,Vehiculo,UltimaActualizacion".Replace(",", sep));

            foreach (Envio e in envios)
            {
                string[] campos =
                {
            e.Codigo,
            e.FechaRegistro.ToString("yyyy-MM-dd HH:mm"),
            NombreSede(e.SedeOrigen),
            NombreSede(e.SedeDestino),
            e.Remitente?.Nombres ?? "",
            e.Destinatario?.Nombres ?? "",
            e.Tipo.ToString(),
            e.PesoKg.ToString("0.00"),
            e.Precio.ToString("0.00"),
            NombrePago(e.ModalidadPago),
            ArbolEnvios.NombreEstadoLegible(e.Estado),
            e.PlacaVehiculo ?? "",
            e.FechaActualizacion.ToString("yyyy-MM-dd HH:mm")
        };

                // Cada dato entre comillas, por si alguno trae una coma adentro
                for (int i = 0; i < campos.Length; i++)
                    campos[i] = "\"" + campos[i].Replace("\"", "\"\"") + "\"";

                sb.AppendLine(string.Join(sep, campos));
            }
            return sb.ToString();
        }

        // Nombre de cada sección según el estado del envío. null = "Todas".
        public static string NombreSeccion(EstadoEnvio? seccion)
        {
            if (seccion == null) return "Todas";

            switch (seccion.Value)
            {
                case EstadoEnvio.Registrado: return "Ingreso de envíos";
                case EstadoEnvio.EnPreparacion: return "Almacén";
                case EstadoEnvio.EnTransito: return "Carga del vehículo";
                case EstadoEnvio.EnReparto: return "Rutas de reparto";
                case EstadoEnvio.Entregado: return "Entregas";
                case EstadoEnvio.Incidencia: return "Incidencias";
                default: return seccion.Value.ToString();
            }
        }

        // Texto legible del periodo, por ejemplo: "Trimestre 4 de 2026 (del 01/10/2026 al 31/12/2026)"
        public static string DescripcionPeriodo(FiltroReporte f)
        {
            if (f.Periodo == TipoPeriodo.Todo)
                return "Todo el historial";

            DateTime inicio = InicioPeriodo(f);
            DateTime ultimoDia = FinPeriodo(f).AddDays(-1);
            CultureInfo peru = new CultureInfo("es-PE");

            string rango = " (del " + inicio.ToString("dd/MM/yyyy") +
                           " al " + ultimoDia.ToString("dd/MM/yyyy") + ")";

            switch (f.Periodo)
            {
                case TipoPeriodo.Dia:
                    return "Día " + inicio.ToString("dd/MM/yyyy");
                case TipoPeriodo.Mes:
                    return "Mes de " + inicio.ToString("MMMM 'de' yyyy", peru) + rango;
                case TipoPeriodo.Trimestre:
                    int numero = (inicio.Month - 1) / 3 + 1;
                    return "Trimestre " + numero + " de " + inicio.Year + rango;
                case TipoPeriodo.Anio:
                    return "Año " + inicio.Year + rango;
                default:
                    return "";
            }
        }

        public static string CodigoSede(Sede sede)
        {
            return sede?.Codigo ?? "---";
        }


        // ------ Ayudantes ------
        public static string NombrePago(ModalidadPago pago)
        {
            switch (pago)
            {
                case ModalidadPago.PagadoEnOrigen: return "Pagado en origen";
                case ModalidadPago.PorCobrarEnDestino: return "Por cobrar en destino";
                default: return pago.ToString();
            }
            
        }

        public static string NombreSede(Sede sede)
        {
            return sede?.Nombre ?? "(sin datos)";
        }

        public static string DatosPersona(Persona p)
        {
            if (p == null) return "(sin datos)";
            
            string texto = p.Nombres + " - " + p.TipoDocumento + ": " + p.NumeroDocumento;
            if (!string.IsNullOrWhiteSpace(p.Telefono))
            {
                texto += " - Tel: " + p.Telefono;
            }
            return texto;
        }
    }
}
