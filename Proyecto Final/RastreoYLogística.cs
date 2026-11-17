using System;
using System.Windows.Forms;

namespace Shalom
{
    // PANEL PRINCIPAL (primera ventana después del login)
    // Muestra el resumen de envíos, el rastreo rápido y los vehículos,
    // y desde el menú de la izquierda se abren los demás formularios.
    public partial class RastreoYLogística : Form
    {
        public RastreoYLogística()
        {
            InitializeComponent();
        }

        private void RastreoYLogística_Load(object sender, EventArgs e)
        {
            // Program.cs ya cargó SQL y el login guardó al usuario
            lblUsuario.Text = Sistema.UsuarioNombres == "" ? "Sin sesión" : Sistema.UsuarioNombres;
            lblSede.Text = Sistema.UsuarioSede;

            ActualizarPanel();
        }

        // =========================================================
        //  DATOS DEL PANEL
        // =========================================================

        // Vuelve a leer las estructuras y refresca el resumen y la tabla
        private void ActualizarPanel()
        {
            // El árbol tiene TODOS los envíos: se cuentan por estado
            lblEnCola.Text = Sistema.Registro.Contar(EstadoEnvio.Registrado).ToString();
            lblEnAlmacen.Text = Sistema.Registro.Contar(EstadoEnvio.EnPreparacion).ToString();
            lblEntregados.Text = Sistema.Registro.Contar(EstadoEnvio.Entregado).ToString();

            int enTransito = Sistema.Registro.Contar(EstadoEnvio.EnTransito);
            int enReparto = Sistema.Registro.Contar(EstadoEnvio.EnReparto);
            lblEnRuta.Text = (enTransito + enReparto).ToString();

            MostrarVehiculos();
            lblEstado.Text = "Vista actualizada: " + DateTime.Now.ToString("HH:mm:ss");
        }

        // Una fila por vehículo. Si había uno seleccionado, se vuelve a seleccionar.
        private void MostrarVehiculos()
        {
            Vehiculo anterior = ObtenerVehiculoSeleccionado();
            dgvVehiculos.Rows.Clear();

            foreach (Vehiculo vehiculo in Sistema.Vehiculos)
            {
                int pendientes = vehiculo.Carga.Contar();          // Pila
                int enReparto = vehiculo.Ruta.ContarParadas();     // Lista de paradas

                string estado = "Disponible";
                if (enReparto > 0)
                    estado = "En ruta";
                else if (pendientes > 0)
                    estado = "Cargando";

                decimal peso = Sistema.PesoEnVehiculo(vehiculo);  // Pila + paradas
                int porcentaje = (int)(peso / vehiculo.CapacidadKg * 100);

                string paquetes = "Por asignar: " + pendientes + " | En reparto: " + enReparto;
                string carga = peso.ToString("0.00") + " / " + vehiculo.CapacidadKg.ToString("0.00") +
                               " kg (" + porcentaje + "%)";

                int fila = dgvVehiculos.Rows.Add(vehiculo.Placa, estado, paquetes, carga);
                dgvVehiculos.Rows[fila].Tag = vehiculo;   // La fila recuerda su vehículo

                if (anterior != null && vehiculo.Placa == anterior.Placa)
                    dgvVehiculos.Rows[fila].Selected = true;
            }

            if (anterior == null)
                dgvVehiculos.ClearSelection();

            MostrarSeleccion();
        }

        // =========================================================
        //  VEHÍCULO SELECCIONADO
        // =========================================================

        private Vehiculo ObtenerVehiculoSeleccionado()
        {
            if (dgvVehiculos.SelectedRows.Count == 0)
                return null;
            return dgvVehiculos.SelectedRows[0].Tag as Vehiculo;
        }

        private void MostrarSeleccion()
        {
            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            lblSeleccionado.Text = vehiculo == null ? "-" : vehiculo.Placa;
        }

        private void dgvVehiculos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccion();
        }

        // El botón siempre está activo (así no se pone oscuro); si no hay selección, avisa
        private void btnVerCarga_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo == null)
            {
                MessageBox.Show("Seleccione un vehículo en la tabla.", "Ver carga");
                return;
            }
            AbrirFormulario(new CargaDelVehículo(vehiculo));
        }

        // Muestra la pila del vehículo: paquetes que aún no tienen parada
        private void lnkPendientesRuta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo == null)
            {
                MessageBox.Show("Seleccione un vehículo en la tabla.", "Pendientes de ruta");
                return;
            }

            Envio[] paquetes = vehiculo.Carga.ObtenerTodos();
            if (paquetes.Length == 0)
            {
                MessageBox.Show("No hay paquetes pendientes de asignar a la ruta.\n" +
                    "En reparto: " + vehiculo.Ruta.ContarParadas(), vehiculo.Placa);
                return;
            }

            string texto = "Del tope a la base:\n";
            foreach (Envio paquete in paquetes)
                texto += "\n" + paquete.Codigo + " - " + paquete.PesoKg.ToString("0.00") + " kg";
            MessageBox.Show(texto, "Pendientes de ruta - " + vehiculo.Placa);
        }

        // =========================================================
        //  RASTREO RÁPIDO
        // =========================================================

        private void btnBuscarEnvio_Click(object sender, EventArgs e)
        {
            string guia = txtGuia.Text.Trim().ToUpperInvariant();
            if (guia == "")
            {
                MessageBox.Show("Ingrese el número de guía.");
                txtGuia.Focus();
                return;
            }
            if (Sistema.Registro.Buscar(guia) == null)
            {
                MessageBox.Show("No existe un envío con esa guía.");
                return;
            }
            AbrirFormulario(new RastreoDeEnvíos(guia));
        }

        private void lnkRastreoCompleto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGuia.Text))
                AbrirFormulario(new RastreoDeEnvíos());
            else
                btnBuscarEnvio_Click(sender, EventArgs.Empty);
        }

        // =========================================================
        //  NAVEGACIÓN (menú de la izquierda y menú Operaciones)
        //  Se oculta el panel, se abre el formulario y al cerrarlo
        //  vuelve el panel con los datos actualizados.
        // =========================================================

        private void AbrirFormulario(Form formulario)
        {
            using (formulario)
            {
                Hide();
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog(this);
            }
            Show();
            ActualizarPanel();
        }

        private void btnActualizar_Click(object sender, EventArgs e) { ActualizarPanel(); }
        private void btnIngreso_Click(object sender, EventArgs e) { AbrirFormulario(new Ingreso_de_envíos_Cola_de_Recepción()); }
        private void btnAlmacen_Click(object sender, EventArgs e) { AbrirFormulario(new Almacén()); }
        private void btnCarga_Click(object sender, EventArgs e) { AbrirFormulario(new CargaDelVehículo()); }
        private void btnRutas_Click(object sender, EventArgs e) { AbrirFormulario(new AsignaciónDeRutas()); }
        private void btnRastreo_Click(object sender, EventArgs e) { AbrirFormulario(new RastreoDeEnvíos()); }
        private void btnReportes_Click(object sender, EventArgs e) { AbrirFormulario(new FormularioReportes()); }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Registrar el envío.\n2. Enviarlo al almacén.\n" +
                "3. Cargarlo en un vehículo.\n4. Asignarlo a la ruta.\n" +
                "5. Registrar la entrega desde Rastreo.\n\n" +
                "El resumen cuenta todos los envíos por su estado actual.", "Ayuda");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
                Application.Restart();   // Vuelve al login
        }

        // Card del desarrollador de este formulario
        private void lnkDesarrollador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TarjetaColaborador.Abrir("N00574312", this);   // Alfonso David Moscoso
        }
    }
}