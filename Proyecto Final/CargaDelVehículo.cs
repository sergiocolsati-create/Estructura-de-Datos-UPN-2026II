using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    public partial class CargaDelVehículo : Form
    {
        // Vehículo que se está cargando en esta ventana.
        private Vehiculo vehiculo;
        // Desde el menú: sin vehículo elegido
        public CargaDelVehículo() : this(null)
        {
        }

        public CargaDelVehículo(Vehiculo vehiculoInicial)
        {
            InitializeComponent();

            btnPop.Click += btnPop_Click;
            btnPeek.Click += btnPeek_Click;
            btnCerrar.Click += btnCerrar_Click;
            cboVehiculo.SelectedIndexChanged += cboVehiculo_SelectedIndexChanged;

            ConfigurarControles();

            if (vehiculoInicial != null)
                cboVehiculo.SelectedItem = vehiculoInicial;   // Dispara SelectedIndexChanged
            else if (cboVehiculo.Items.Count > 0)
                cboVehiculo.SelectedIndex = 0;
        }

        private void CargaDelVehículo_Load(object sender, EventArgs e)
        {

        }
        private void ConfigurarControles()
        {
            // Desplegable con los vehículos disponibles
            cboVehiculo.DisplayMember = "Placa";
            cboVehiculo.Items.AddRange(Sistema.Vehiculos);
            cboVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Datos de solo lectura: se llenan solos al elegir el vehículo
            txtConductor.ReadOnly = true;
            txtCapacidad.ReadOnly = true;
            txtCarga.ReadOnly = true;
            textBox1.ReadOnly = true;       // Muestra el siguiente paquete del almacén
            textBox1.TabStop = false;
        }


        private void cboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehiculo = cboVehiculo.SelectedItem as Vehiculo;
            if (vehiculo == null) return;

            txtConductor.Text = vehiculo.Conductor;
            txtCapacidad.Text = vehiculo.CapacidadKg.ToString("0.00") + " kg";
            ActualizarPantalla();
        }

        // Apilar: busca el código escrito en textBox1 dentro del registro general
        // de envíos y, si existe, lo sube a la pila del vehículo.
        private void btnPush_Click(object sender, EventArgs e)
        {

            Envio siguiente = Sistema.Almacen.VerFrente();   // Para el mensaje

            try
            {
                string error = Sistema.DespacharA(vehiculo);  // Desencola del almacén, apila y guarda en SQL
                if (error != "")
                {
                    MessageBox.Show(error, "Apilar paquete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            toolStripStatusLabel1.Text = "Apilado: " + siguiente.Codigo;
            ActualizarPantalla();

        }

        // Desapilar: saca el paquete del tope (el último que entró).
        private void btnPop_Click(object sender, EventArgs e)
        {
            Envio tope = vehiculo == null ? null : vehiculo.Carga.VerTope();   // Para el mensaje

            try
            {
                string error = Sistema.EntregarTope(vehiculo);
                if (error != "")
                {
                    MessageBox.Show(error, "Entregar tope", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            toolStripStatusLabel1.Text = "Entregado a la ruta: " + tope.Codigo;
            ActualizarPantalla();
        }

        // Peek: solo consulta el tope, no lo retira.
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Vuelve a pintar el ListBox, la barra de progreso y las etiquetas.
        private void ActualizarPantalla()
        {
            Envio siguiente = Sistema.Almacen.VerFrente();
            textBox1.Text = siguiente == null
                ? "(almacén vacío)"
                : siguiente.Codigo + " | " + siguiente.PesoKg.ToString("0.00") + " kg";
            btnPush.Enabled = siguiente != null && vehiculo != null;

            if (vehiculo == null) return;

            vehiculo.Carga.Listar(lstPaquetes);

            txtCarga.Text = vehiculo.Carga.PesoActual.ToString("0.00") + " kg";
            lblContador.Text = vehiculo.Carga.Contar().ToString();

            int porcentaje = (int)(vehiculo.Carga.PesoActual * 100 / vehiculo.Carga.CapacidadKg);
            if (porcentaje > 100) porcentaje = 100;
            if (porcentaje < 0) porcentaje = 0;
            progressBar1.Value = porcentaje;

            Envio tope = vehiculo.Carga.VerTope();
            lblTope.Text = tope == null ? "Tope de la pila: (vacía)" : "Tope de la pila: " + tope.Codigo;
            btnPop.Enabled = tope != null;
            btnPeek.Enabled = tope != null;
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {

        }

        private void lblContador_Click(object sender, EventArgs e)
        {
            lblContador.Text = vehiculo.Carga.Contar().ToString();
        }
    }
}