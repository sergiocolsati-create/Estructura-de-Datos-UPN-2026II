using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Shalom
{
    // FORMULARIO: ASIGNACIÓN DE RUTAS
    // Aquí se decide en qué orden un vehículo entrega sus paquetes.
    //
    //  - Los paquetes cargados en el vehículo están en una PILA (último en entrar, primero en salir).
    //  - Las paradas de reparto están en una LISTA DOBLEMENTE ENLAZADA (cada parada conoce
    //    a la anterior y a la siguiente, por eso se puede insertar en medio).
    //
    // El formulario solo MUESTRA datos y llama a Sistema; las reglas están en Sistema.
    public partial class AsignaciónDeRutas : Form
    {
        // Color de la marca, para la línea de la ruta
        private readonly Color rojo = Color.FromArgb(232, 38, 43);

        // Control del mapa (se crea por código en CrearMapa)
        private GMapControl mapa;

        // Vehículo elegido en el ComboBox (con él se trabaja en toda la pantalla)
        private Vehiculo vehiculoActual;

        public AsignaciónDeRutas()
        {
            InitializeComponent();   // Crea los controles dibujados en el diseñador

            // El ComboBox guarda el objeto Vehiculo completo, pero muestra solo su placa
            cboVehiculo.DisplayMember = "Placa";
            cboVehiculo.Items.AddRange(Sistema.Vehiculos);

            CrearMapa();
        }

        // Al abrir el formulario se selecciona el primer vehículo
        // (eso dispara cboVehiculo_SelectedIndexChanged y se llena la pantalla)
        private void AsignaciónDeRutas_Load(object sender, EventArgs e)
        {
            if (cboVehiculo.Items.Count > 0)
                cboVehiculo.SelectedIndex = 0;
        }

        // Cada vez que se cambia de vehículo se vuelve a mostrar todo
        private void cboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehiculoActual = cboVehiculo.SelectedItem as Vehiculo;
            ActualizarPantalla();
        }

        // =========================================================
        //  BOTONES
        //  Todos trabajan con el TOPE de la pila: por ser una pila,
        //  es el único paquete que se puede sacar. Por eso el usuario
        //  no tiene que seleccionarlo.
        // =========================================================

        // Saca el tope de la pila y lo pone como ÚLTIMA parada de la ruta
        private void btnAgregarAlFinal_Click(object sender, EventArgs e)
        {
            EjecutarOperacion(() => Sistema.AsignarTope(vehiculoActual, null), "Agregar al final");
        }

        // Saca el tope de la pila y lo pone JUSTO DESPUÉS de la parada elegida en la tabla
        private void btnInsertarDespues_Click(object sender, EventArgs e)
        {
            string guia = GuiaSeleccionada();
            if (guia == null)
            {
                MessageBox.Show("Seleccione en la tabla la parada después de la cual va el paquete.",
                                "Insertar después");
                return;
            }

            EjecutarOperacion(() => Sistema.AsignarTope(vehiculoActual, guia), "Insertar después");
        }

        // Quita la parada elegida de la ruta; el paquete vuelve al tope de la pila
        private void btnQuitarParada_Click(object sender, EventArgs e)
        {
            string guia = GuiaSeleccionada();
            if (guia == null)
            {
                MessageBox.Show("Seleccione en la tabla la parada que desea quitar.", "Quitar parada");
                return;
            }

            EjecutarOperacion(() => Sistema.QuitarParada(vehiculoActual, guia), "Quitar parada");
        }

        // Método común para los tres botones, así no se repite el mismo try/catch.
        // Recibe la operación a ejecutar (una función de Sistema que devuelve un texto):
        //   ""        → todo salió bien, se refresca la pantalla
        //   "mensaje" → no se pudo, se muestra el motivo
        //   excepción → falló la base de datos
        private void EjecutarOperacion(Func<string> operacion, string titulo)
        {
            try
            {
                string error = operacion();
                if (error != "")
                {
                    MessageBox.Show(error, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ActualizarPantalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Devuelve el número de guía de la fila seleccionada en la tabla, o null si no hay ninguna
        private string GuiaSeleccionada()
        {
            if (dgvParadas.CurrentRow == null)
                return null;

            return dgvParadas.CurrentRow.Cells[colGuia.Index].Value.ToString();
        }

        // =========================================================
        //  PANTALLA
        //  Lee las estructuras del vehículo y las muestra.
        // =========================================================

        // Vuelve a pintar toda la pantalla con los datos actuales del vehículo
        private void ActualizarPantalla()
        {
            if (vehiculoActual == null)
                return;

            MostrarVehiculo();      // Conductor y carga
            MostrarPorAsignar();    // Pila
            MostrarParadas();       // Lista enlazada

            // Cada botón solo se habilita cuando tiene sentido usarlo
            bool hayTope = vehiculoActual.Carga.VerTope() != null;    // ¿Queda algo en la pila?
            bool hayParadas = !vehiculoActual.Ruta.EstaVacia();       // ¿La ruta tiene paradas?

            btnAgregarAlFinal.Enabled = hayTope;
            btnInsertarDespues.Enabled = hayTope && hayParadas;   // Necesita una parada de referencia
            btnQuitarParada.Enabled = hayParadas;

            MostrarMapa();     // Ruta del vehículo sobre el mapa
            EncuadrarMapa();   // Zoom para que se vean todas las paradas
        }

        // Muestra el conductor y cuánto peso lleva el vehículo (pila + paradas)
        private void MostrarVehiculo()
        {
            decimal peso = Sistema.PesoEnVehiculo(vehiculoActual);
            int porcentaje = (int)(peso * 100 / vehiculoActual.CapacidadKg);

            lblConductor.Text = "Conductor: " + vehiculoActual.Conductor;
            lblCarga.Text = "Carga: " + peso.ToString("0.##") + " de " +
                            vehiculoActual.CapacidadKg.ToString("0.##") + " kg (" + porcentaje + "%)";
            pbCarga.Value = Math.Min(porcentaje, 100);   // La barra no acepta más de 100
        }

        // Muestra la PILA del vehículo. El primero de la lista es el tope (el que sale primero),
        // marcado con ▶ para que se vea cuál es el siguiente en asignarse.
        private void MostrarPorAsignar()
        {
            lstPorAsignar.Items.Clear();

            Envio[] paquetes = vehiculoActual.Carga.ObtenerTodos();   // [0] = tope
            for (int i = 0; i < paquetes.Length; i++)
            {
                string marca = i == 0 ? "▶ " : "   ";
                lstPorAsignar.Items.Add(marca + paquetes[i].Codigo + "  →  " + paquetes[i].SedeDestino.Nombre);
            }

            Envio tope = vehiculoActual.Carga.VerTope();
            lblTope.Text = tope == null
                ? "No hay paquetes por asignar."
                : "Siguiente en salir (tope): " + tope.Codigo;
        }

        // Muestra la LISTA ENLAZADA de paradas en la tabla, en el orden de la ruta
        private void MostrarParadas()
        {
            dgvParadas.Rows.Clear();

            Envio[] paradas = vehiculoActual.Ruta.ObtenerEnvios();   // Recorre la lista de inicio a fin
            for (int i = 0; i < paradas.Length; i++)
            {
                dgvParadas.Rows.Add(i + 1, paradas[i].Codigo, paradas[i].SedeDestino.Nombre,
                                    paradas[i].Destinatario.Nombres, paradas[i].PesoKg);
            }

            lblParadas.Text = "Paradas: " + paradas.Length;
        }

        // Al elegir otra fila en la tabla se redibuja el mapa para resaltar esa parada en azul
        private void dgvParadas_SelectionChanged(object sender, EventArgs e)
        {
            if (vehiculoActual != null)
                MostrarMapa();
        }

        // =========================================================
        //  MAPA (GMap.NET + OpenStreetMap)
        //  Mapa real, gratuito y sin API key. Necesita internet;
        //  las partes del mapa ya vistas se guardan en caché.
        //  Se dibuja en una "capa" (overlay) encima del mapa:
        //    - una línea con el recorrido de la lista enlazada
        //    - un marcador por cada ciudad donde hay paradas
        // =========================================================

        // Capa donde se dibujan la ruta y los marcadores del vehículo actual
        private readonly GMapOverlay capaRuta = new GMapOverlay("ruta");

        // Crea el control del mapa por código y lo pone dentro del grupo "Mapa de la ruta"
        private void CrearMapa()
        {
            GMapProvider.UserAgent = "Shalom-UPN";              // OpenStreetMap pide que cada programa se identifique
            GMaps.Instance.Mode = AccessMode.ServerAndCache;    // Descarga y guarda en caché lo que ya se vio

            mapa = new GMapControl();
            mapa.MapProvider = GMapProviders.OpenStreetMap;     // Mapa gratuito
            mapa.Location = new Point(15, 25);
            mapa.Size = new Size(350, 520);
            mapa.MinZoom = 4;
            mapa.MaxZoom = 17;
            mapa.Zoom = 5;
            mapa.Position = new PointLatLng(-9.5, -75.0);       // Centro del Perú
            mapa.DragButton = MouseButtons.Left;                // Se arrastra con el clic izquierdo
            mapa.ShowCenter = false;                            // Quita la cruz roja del centro

            mapa.Overlays.Add(capaRuta);
            grpMapa.Controls.Add(mapa);
        }

        // Coordenadas reales (latitud, longitud) de cada sede según su código.
        // Si aparece una sede nueva sin coordenadas, devuelve vacío y no se dibuja.
        private PointLatLng UbicacionDe(Sede sede)
        {
            switch (sede.Codigo)
            {
                case "LIM": return new PointLatLng(-12.0464, -77.0428);
                case "ARE": return new PointLatLng(-16.4090, -71.5375);
                case "TRU": return new PointLatLng(-8.1116, -79.0288);
                case "CUS": return new PointLatLng(-13.5320, -71.9675);
                default: return PointLatLng.Empty;
            }
        }

        // Vuelve a dibujar la ruta del vehículo actual sobre el mapa
        private void MostrarMapa()
        {
            capaRuta.Markers.Clear();
            capaRuta.Routes.Clear();

            Envio[] paradas = vehiculoActual.Ruta.ObtenerEnvios();   // Recorre la lista enlazada en orden
            if (paradas.Length == 0)
                return;

            // 1. Línea del recorrido: salida → parada 1 → parada 2 → ...
            //    La salida es la sede de origen de la primera parada.
            PointLatLng salida = UbicacionDe(paradas[0].SedeOrigen);
            List<PointLatLng> recorrido = new List<PointLatLng>();
            if (!salida.IsEmpty)
                recorrido.Add(salida);

            for (int i = 0; i < paradas.Length; i++)
            {
                PointLatLng destino = UbicacionDe(paradas[i].SedeDestino);
                bool repetido = recorrido.Count > 0 && recorrido[recorrido.Count - 1] == destino;

                if (!destino.IsEmpty && !repetido)   // Dos paradas seguidas en la misma ciudad = un solo punto
                    recorrido.Add(destino);
            }

            GMapRoute linea = new GMapRoute(recorrido, "Recorrido");
            linea.Stroke = new Pen(rojo, 3);
            capaRuta.Routes.Add(linea);

            // 2. Marcador verde en la salida
            if (!salida.IsEmpty)
                AgregarMarcador(salida, GMarkerGoogleType.green, "Salida: " + paradas[0].SedeOrigen.Nombre);

            // 3. Un marcador por ciudad, con los números de parada que le tocan
            //    (ej. "Arequipa – paradas 1, 3"). Azul si incluye la parada seleccionada en la tabla.
            string seleccionada = GuiaSeleccionada();
            List<string> ciudades = new List<string>();                          // Códigos de sede, en orden de aparición
            Dictionary<string, string> numeros = new Dictionary<string, string>(); // Código de sede → "1, 3"
            Dictionary<string, bool> resaltar = new Dictionary<string, bool>();    // Código de sede → ¿tiene la seleccionada?

            for (int i = 0; i < paradas.Length; i++)
            {
                string ciudad = paradas[i].SedeDestino.Codigo;

                if (!numeros.ContainsKey(ciudad))
                {
                    ciudades.Add(ciudad);
                    numeros[ciudad] = (i + 1).ToString();
                    resaltar[ciudad] = false;
                }
                else
                {
                    numeros[ciudad] += ", " + (i + 1);
                }

                if (paradas[i].Codigo == seleccionada)
                    resaltar[ciudad] = true;
            }

            foreach (string ciudad in ciudades)
            {
                Sede sede = BuscarSedeDeParada(paradas, ciudad);
                PointLatLng lugar = UbicacionDe(sede);
                if (lugar.IsEmpty)
                    continue;

                GMarkerGoogleType color = resaltar[ciudad] ? GMarkerGoogleType.blue : GMarkerGoogleType.red;
                AgregarMarcador(lugar, color, sede.Ciudad + " – parada(s) " + numeros[ciudad]);
            }
        }

        // Pone un marcador con un texto que se ve siempre
        private void AgregarMarcador(PointLatLng lugar, GMarkerGoogleType color, string texto)
        {
            GMarkerGoogle marcador = new GMarkerGoogle(lugar, color);
            marcador.ToolTipText = texto;
            marcador.ToolTipMode = MarkerTooltipMode.Always;
            capaRuta.Markers.Add(marcador);
        }

        // Devuelve la sede de destino que tiene ese código (se busca entre las paradas)
        private Sede BuscarSedeDeParada(Envio[] paradas, string codigoSede)
        {
            for (int i = 0; i < paradas.Length; i++)
            {
                if (paradas[i].SedeDestino.Codigo == codigoSede)
                    return paradas[i].SedeDestino;
            }

            return null;
        }

        // Acerca o aleja el mapa para que se vean todos los marcadores de la ruta
        private void EncuadrarMapa()
        {
            if (capaRuta.Markers.Count == 0)
            {
                mapa.Position = new PointLatLng(-9.5, -75.0);   // Sin paradas: todo el Perú
                mapa.Zoom = 5;
                return;
            }

            mapa.ZoomAndCenterMarkers(capaRuta.Id);
            if (mapa.Zoom > 12)
                mapa.Zoom = 12;   // Si todo está en una sola ciudad, no acercar demasiado
        }
    }
}