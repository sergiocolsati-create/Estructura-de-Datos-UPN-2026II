using System;
using System.Windows.Forms;

namespace Shalom
{
    // CARGA DEL VEHÍCULO (pila)
    //   Apilar paquete:       el frente del ALMACÉN (cola) sube al tope de la PILA del vehículo
    //   Pasar tope a la ruta: el TOPE de la pila pasa al final de la lista de paradas
    //   Ver tope:             muestra el último paquete cargado sin sacarlo
    public partial class CargaDelVehículo : Form
    {
        private Vehiculo vehiculo;   // Vehículo elegido en el ComboBox

        // Desde el menú: se muestra el primer vehículo
        public CargaDelVehículo() : this(null)
        {
        }

        // Desde el panel o el almacén: se abre con ese vehículo ya elegido
        public CargaDelVehículo(Vehiculo vehiculoInicial)
        {
            InitializeComponent();

            lblUsuario.Text = Sistema.UsuarioNombres;
            lblSede.Text = Sistema.UsuarioSede;

            ConfigurarControles();

            // Elegir el vehículo dispara cboVehiculo_SelectedIndexChanged, que llena la pantalla
            if (vehiculoInicial != null)
                cboVehiculo.SelectedItem = vehiculoInicial;
            else if (cboVehiculo.Items.Count > 0)
                cboVehiculo.SelectedIndex = 0;
        }

        // =========================================================
        //  1. CONFIGURACIÓN Y PANTALLA
        // =========================================================

        private void ConfigurarControles()
        {
            // El ComboBox muestra la placa y guarda el objeto Vehiculo completo
            cboVehiculo.DisplayMember = "Placa";
            cboVehiculo.Items.AddRange(Sistema.Vehiculos);
            cboVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Datos de solo lectura: se llenan al elegir el vehículo
            txtConductor.ReadOnly = true;
            txtCapacidad.ReadOnly = true;
            txtCarga.ReadOnly = true;
            txtSiguiente.ReadOnly = true;
            txtSiguiente.TabStop = false;
        }

        private void cboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehiculo = cboVehiculo.SelectedItem as Vehiculo;
            ActualizarPantalla();
        }

        // Vuelve a mostrar el siguiente del almacén, la pila y la carga del vehículo
        private void ActualizarPantalla()
        {
            // Siguiente paquete del almacén (el que se apilaría)
            Envio siguiente = Sistema.Almacen.VerFrente();
            txtSiguiente.Text = siguiente == null
                ? "(almacén vacío)"
                : siguiente.Codigo + " | " + siguiente.PesoKg.ToString("0.00") + " kg";

            if (vehiculo == null)
                return;

            txtConductor.Text = vehiculo.Conductor;
            txtCapacidad.Text = vehiculo.CapacidadKg.ToString("0.00") + " kg";

            // Pila del vehículo (del tope a la base)
            vehiculo.Carga.Listar(lstPaquetes);
            lblContador.Text = vehiculo.Carga.Contar().ToString();

            Envio tope = vehiculo.Carga.VerTope();
            lblTope.Text = tope == null ? "Tope de la pila: (vacía)" : "Tope de la pila: " + tope.Codigo;

            // Carga total: pila + paradas, porque todo sigue dentro del vehículo
            decimal peso = Sistema.PesoEnVehiculo(vehiculo);
            int porcentaje = (int)(peso * 100 / vehiculo.CapacidadKg);

            txtCarga.Text = peso.ToString("0.00") + " kg";
            progressBar1.Value = Math.Min(porcentaje, 100);
            lblPorcentaje.Text = porcentaje + " %";
        }

        // =========================================================
        //  2. OPERACIONES DE LA PILA
        //  Los botones siempre están activos (así no se ponen oscuros):
        //  si no se puede, Sistema devuelve el motivo y se muestra.
        // =========================================================

        // PUSH: el frente del almacén sube al tope de la pila
        private void btnPush_Click(object sender, EventArgs e)
        {
            Envio siguiente = Sistema.Almacen.VerFrente();   // Se guarda para el mensaje

            if (EjecutarOperacion(() => Sistema.DespacharA(vehiculo), "Apilar paquete"))
                toolStripStatusLabel1.Text = "Apilado: " + siguiente.Codigo;
        }

        // POP: el tope de la pila pasa al final de la ruta
        private void btnPop_Click(object sender, EventArgs e)
        {
            Envio tope = vehiculo == null ? null : vehiculo.Carga.VerTope();   // Se guarda para el mensaje

            if (EjecutarOperacion(() => Sistema.EntregarTope(vehiculo), "Pasar tope a la ruta"))
                toolStripStatusLabel1.Text = "Pasado a la ruta: " + tope.Codigo;
        }

        // PEEK: solo mira el tope, no lo saca
        private void btnPeek_Click(object sender, EventArgs e)
        {
            Envio tope = vehiculo == null ? null : vehiculo.Carga.VerTope();
            if (tope == null)
            {
                MessageBox.Show("La pila está vacía.", "Ver tope");
                return;
            }

            MessageBox.Show("Guía: " + tope.Codigo +
                            "\nDestino: " + tope.SedeDestino.Nombre +
                            "\nPeso: " + tope.PesoKg + " kg",
                            "Tope de la pila");
        }

        // Ejecuta una operación de Sistema (guarda en SQL y mueve en memoria).
        // Si salió bien refresca la pantalla y devuelve true; si no, muestra el motivo.
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ActualizarPantalla();
            return true;
        }

        // =========================================================
        //  3. NAVEGACIÓN
        // =========================================================

        // Abre Asignación de rutas ENCIMA de esta ventana, con el mismo vehículo.
        // Al cerrarla se vuelve aquí y se refresca la pila.
        private void btnIrRutas_Click(object sender, EventArgs e)
        {
            using (AsignaciónDeRutas rutas = new AsignaciónDeRutas(vehiculo))
                rutas.ShowDialog(this);

            ActualizarPantalla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Card de la desarrolladora de este formulario
        private void lnkDesarrollador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TarjetaColaborador.Abrir("N00474619", this);   // Anshely Quezada
        }
    }
}