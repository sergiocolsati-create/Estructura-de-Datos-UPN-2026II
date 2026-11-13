using System;
using System.IO;
using System.Text;

namespace Shalom
{
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
        public static void GuardarTxt(string ruta, string contenido)
        {
            File.WriteAllText(ruta, contenido, Encoding.UTF8);
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
            return sede == null ? "(sin datos)" : sede.Nombre;
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
