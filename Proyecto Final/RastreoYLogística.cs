using System;
using System.Windows.Forms;

namespace Shalom
{
    public partial class RastreoYLogística : Form
    {
        public RastreoYLogística()
        {
            InitializeComponent();
        }

        private void RastreoYLogística_Load(object sender, EventArgs e)
        {
            // Program.cs ya cargó SQL. Aquí mostramos los objetos compartidos.
            ActualizarPanel();
        }

        private void ActualizarPanel()
        {
            lblEnCola.Text = Sistema.Registro.Contar(EstadoEnvio.Registrado).ToString();
            lblEnAlmacen.Text = Sistema.Registro.Contar(EstadoEnvio.EnPreparacion).ToString();
            lblEntregados.Text = Sistema.Registro.Contar(EstadoEnvio.Entregado).ToString();

            int enTransito = Sistema.Registro.Contar(EstadoEnvio.EnTransito);
            int enReparto = Sistema.Registro.Contar(EstadoEnvio.EnReparto);
            lblEnRuta.Text = (enTransito + enReparto).ToString();

            MostrarVehiculos();
            lblEstado.Text = "Vista actualizada: " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void MostrarVehiculos()
        {
            Vehiculo anterior = ObtenerVehiculoSeleccionado();
            dgvVehiculos.Rows.Clear();

            foreach (Vehiculo vehiculo in Sistema.Vehiculos)
            {
                int pendientes = vehiculo.Carga.Contar();
                int enReparto = vehiculo.Ruta.ContarParadas();
                string estado = "Disponible";

                if (enReparto > 0)
                    estado = "En ruta";
                else if (pendientes > 0)
                    estado = "Cargando";

                decimal peso = CalcularPesoTotal(vehiculo);
                int porcentaje = 0;
                if (vehiculo.CapacidadKg > 0)
                    porcentaje = (int)(peso / vehiculo.CapacidadKg * 100);

                string paquetes = "Por asignar: " + pendientes +
                                  " | En reparto: " + enReparto;
                string carga = peso.ToString("0.00") + " / " +
                               vehiculo.CapacidadKg.ToString("0.00") +
                               " kg (" + porcentaje + "%)";

                int fila = dgvVehiculos.Rows.Add(vehiculo.Placa, estado, paquetes, carga);
                // La fila guarda el vehículo al que corresponde, aunque se ordene la tabla.
                dgvVehiculos.Rows[fila].Tag = vehiculo;
            }

            dgvVehiculos.ClearSelection();
            if (anterior != null)
            {
                foreach (DataGridViewRow fila in dgvVehiculos.Rows)
                {
                    Vehiculo vehiculo = fila.Tag as Vehiculo;
                    if (vehiculo != null && vehiculo.Placa == anterior.Placa)
                    {
                        fila.Selected = true;
                        break;
                    }
                }
            }
            ActualizarSeleccion();
        }

        private decimal CalcularPesoTotal(Vehiculo vehiculo)
        {
            // En este proyecto, los paquetes en ruta siguen físicamente en el vehículo.
            decimal peso = vehiculo.Carga.PesoActual;
            foreach (Envio envio in vehiculo.Ruta.ObtenerEnvios())
                peso += envio.PesoKg;
            return peso;
        }

        private Vehiculo ObtenerVehiculoSeleccionado()
        {
            if (dgvVehiculos.SelectedRows.Count == 0)
                return null;
            return dgvVehiculos.SelectedRows[0].Tag as Vehiculo;
        }

        private void ActualizarSeleccion()
        {
            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            lblSeleccionado.Text = vehiculo == null ? "-" : vehiculo.Placa;
            btnVerCarga.Enabled = vehiculo != null;
            lnkPendientesRuta.Enabled = vehiculo != null;
        }

        private void dgvVehiculos_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarSeleccion();
        }

        private void AbrirFormulario(Form formulario)
        {
            using (formulario)
            {
                formulario.ShowDialog(this);
            }
            ActualizarPanel();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPanel();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Ingreso_de_envíos_Cola_de_Recepción());
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Almacén());
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CargaDelVehículo());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AsignaciónDeRutas());
        }

        private void btnRastreo_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new RastreoDeEnvíos());
        }

        private void btnVerCarga_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo == null)
            {
                MessageBox.Show("Seleccione un vehículo en la tabla.");
                return;
            }
            AbrirFormulario(new CargaDelVehículo(vehiculo));
        }

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

        private void lnkPendientesRuta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo == null)
                return;

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

        private void miSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Registrar el envío.\n2. Enviarlo al almacén.\n" +
                "3. Cargarlo en un vehículo.\n4. Asignarlo a la ruta.\n" +
                "5. Registrar la entrega desde Rastreo.\n\n" +
                "El resumen cuenta todos los envíos por su estado actual.", "Ayuda");
        }
    }
}
