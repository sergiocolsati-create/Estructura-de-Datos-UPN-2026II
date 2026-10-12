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
    public partial class Almacén : Form
    {
        public Almacén()
        {
            InitializeComponent();
            ConfigurarControles();
            ActualizarVista();
        }
        private void ConfigurarControles()
        {
            cboVehiculo.DisplayMember = "Placa";
            cboVehiculo.Items.AddRange(Sistema.Vehiculos);
            cboVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = cboVehiculo.SelectedItem as Vehiculo;

            try
            {
                string error = Sistema.DespacharA(vehiculo);   // Guarda en SQL y mueve en memoria
                if (error != "")
                {
                    MessageBox.Show(error, "Despachar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActualizarVista();

            // Abre la carga de ESE vehículo. ShowDialog: al cerrarla se vuelve aquí
            new CargaDelVehículo(vehiculo).ShowDialog();
            ActualizarVista();

        }

        private void btnAlmacenar_Click(object sender, EventArgs e)
        {
            try
            {
                string error = Sistema.EnviarAAlmacen();       // Guarda en SQL y mueve en memoria
                if (error != "")
                {
                    MessageBox.Show(error, "Almacenar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActualizarVista();

        }

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
        private void ActualizarVista()
        {
            Sistema.Almacen.Mostrar(dataGridView1);

            // Ocupación: label2 = cantidad, label4 = capacidad, label5 = porcentaje
            int cantidad = Sistema.Almacen.Cantidad;
            int capacidad = Sistema.Almacen.Capacidad;
            int porcentaje = capacidad == 0 ? 0 : cantidad * 100 / capacidad;

            label2.Text = cantidad.ToString();
            label4.Text = capacidad.ToString();
            label5.Text = porcentaje + "%";
            pbarOcupacion.Value = porcentaje;

            Envio siguiente = Sistema.Recepcion.VerFrente();
            label8.Text = "Siguiente en la cola: " + (siguiente == null ? "-----" : siguiente.Codigo);
            btnAlmacenar.Enabled = siguiente != null;
        }

        private void Almacén_Load(object sender, EventArgs e)
        {

        }
    }
}
