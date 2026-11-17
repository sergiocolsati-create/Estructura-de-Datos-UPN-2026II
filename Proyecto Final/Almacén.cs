using System;
using System.Windows.Forms;

namespace Shalom
{
    // ALMACÉN (cola del almacén)
    //   Almacenar:         el frente de la cola de RECEPCIÓN pasa al final de la cola del ALMACÉN
    //   Despachar primero: el frente de la cola del ALMACÉN se apila en el vehículo elegido
    //   Ver frente:        muestra el más antiguo del almacén sin sacarlo
    public partial class Almacén : Form
    {
        public Almacén()
        {
            InitializeComponent();

            lblUsuario.Text = Sistema.UsuarioNombres;
            lblSede.Text = Sistema.UsuarioSede;

            ConfigurarControles();
            ActualizarVista();
        }

        // =========================================================
        //  1. CONFIGURACIÓN INICIAL
        // =========================================================

        private void ConfigurarControles()
        {
            // El ComboBox muestra la placa y guarda el objeto Vehiculo completo
            cboVehiculo.DisplayMember = "Placa";
            cboVehiculo.Items.AddRange(Sistema.Vehiculos);
            cboVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Grilla de solo lectura (las columnas las crea ColaEnvios.Mostrar)
            dgvAlmacen.AllowUserToAddRows = false;
            dgvAlmacen.ReadOnly = true;
            dgvAlmacen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // =========================================================
        //  2. PANTALLA
        // =========================================================

        // Grilla del almacén, ocupación y siguiente envío de la cola de recepción
        private void ActualizarVista()
        {
            Sistema.Almacen.Mostrar(dgvAlmacen);

            int cantidad = Sistema.Almacen.Cantidad;
            int capacidad = Sistema.Almacen.Capacidad;
            int porcentaje = capacidad == 0 ? 0 : cantidad * 100 / capacidad;

            lblOcupacion.Text = cantidad + " de " + capacidad + " (" + porcentaje + "%)";
            pbarOcupacion.Value = Math.Min(porcentaje, 100);

            Envio siguiente = Sistema.Recepcion.VerFrente();
            lblSiguiente.Text = "Siguiente en la cola: " + (siguiente == null ? "-----" : siguiente.Codigo);
        }

        // =========================================================
        //  3. BOTONES
        //  Siempre activos (así no se ponen oscuros): si no se puede,
        //  Sistema devuelve el motivo y se muestra.
        // =========================================================

        // RECEPCIÓN → ALMACÉN
        private void btnAlmacenar_Click(object sender, EventArgs e)
        {
            if (EjecutarOperacion(() => Sistema.EnviarAAlmacen(), "Almacenar"))
                ActualizarVista();
        }

        // ALMACÉN → PILA DEL VEHÍCULO.
        // Si salió bien, abre la carga de ese vehículo encima; al cerrarla se vuelve aquí.
        private void btnDespacho_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = cboVehiculo.SelectedItem as Vehiculo;

            if (!EjecutarOperacion(() => Sistema.DespacharA(vehiculo), "Despachar"))
                return;

            ActualizarVista();

            using (CargaDelVehículo carga = new CargaDelVehículo(vehiculo))
                carga.ShowDialog(this);

            ActualizarVista();
        }

        // Muestra el más antiguo del almacén sin sacarlo (PEEK)
        private void btnFrente_Click(object sender, EventArgs e)
        {
            Envio frente = Sistema.Almacen.VerFrente();
            if (frente == null)
            {
                MessageBox.Show("El almacén está vacío.", "Ver frente");
                return;
            }

            MessageBox.Show("Guía: " + frente.Codigo +
                            "\nRemitente: " + frente.Remitente.Nombres +
                            "\nDestino: " + frente.SedeDestino.Nombre +
                            "\nPeso: " + frente.PesoKg + " kg" +
                            "\nIngreso: " + frente.FechaActualizacion.ToString("dd/MM/yyyy HH:mm"),
                            "Frente del almacén");
        }

        // Ejecuta una operación de Sistema (que guarda en SQL y mueve en memoria).
        // Devuelve true si salió bien; si no, muestra el motivo o el error de SQL.
        private bool EjecutarOperacion(Func<string> operacion, string titulo)
        {
            try
            {
                string error = operacion();
                if (error != "")
                {
                    MessageBox.Show(error, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =========================================================
        //  4. DESARROLLADOR DEL FORMULARIO
        // =========================================================

        private void lnkDesarrollador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TarjetaColaborador.Abrir("N00525394", this);   // Sergio Colán
        }
    }
}