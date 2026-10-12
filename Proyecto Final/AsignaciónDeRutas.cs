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
    public partial class AsignaciónDeRutas : Form
    {
        private Vehiculo vehiculoActual;
        private Button[] botonesCadena;
        private Label[] flechas;

        public AsignaciónDeRutas()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "Placa";
            comboBox1.Items.AddRange(Sistema.Vehiculos);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            listBox1.DisplayMember = "Codigo";

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            botonesCadena = new Button[] { button1, button2, button3, button4, button5 };
            flechas = new Label[] { label3, label4, label5, label6 };

      
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            button7.Click += button7_Click;   // Insertar después
            button8.Click += button8_Click;   // Eliminar parada
            button9.Click += button9_Click;   // Confirmar ruta
        }

       
        private void AsignaciónDeRutas_Load_1(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehiculoActual = comboBox1.SelectedItem as Vehiculo;
            ActualizarPantalla();
        }

        private void CargarPaquetesDisponibles()
        {
            listBox1.Items.Clear();
            if (vehiculoActual == null) return;

            Envio[] todos = vehiculoActual.Carga.ObtenerTodos();
            for (int i = 0; i < todos.Length; i++)
            {
                if (!vehiculoActual.Ruta.Contiene(todos[i].Codigo))
                    listBox1.Items.Add(todos[i]);
            }
        }

        private void ActualizarCadena()
        {
            for (int i = 0; i < botonesCadena.Length; i++)
                botonesCadena[i].Visible = false;
            for (int i = 0; i < flechas.Length; i++)
                flechas[i].Visible = false;

            if (vehiculoActual == null) return;

            string[] textos = vehiculoActual.Ruta.ObtenerTextos();
            if (textos.Length == 0) return;

            int mostrar = textos.Length;
            bool hayMas = false;
            if (mostrar > botonesCadena.Length)
            {
                hayMas = true;
                mostrar = botonesCadena.Length;
            }

            for (int i = 0; i < mostrar; i++)
            {
                botonesCadena[i].Visible = true;
                botonesCadena[i].Text = textos[i];

                if (i > 0)
                    flechas[i - 1].Visible = true;
            }

            botonesCadena[0].Text = "cabeza " + textos[0];

            if (hayMas)
                botonesCadena[mostrar - 1].Text = "... (+" + (textos.Length - mostrar + 1) + " más)";
            else if (mostrar > 1)
                botonesCadena[mostrar - 1].Text = "cola " + textos[mostrar - 1];
        }

        private void button1_Click(object sender, EventArgs e) { MostrarDetalleParada(0); }
        private void button2_Click(object sender, EventArgs e) { MostrarDetalleParada(1); }
        private void button3_Click(object sender, EventArgs e) { MostrarDetalleParada(2); }
        private void button4_Click(object sender, EventArgs e) { MostrarDetalleParada(3); }
        private void button5_Click(object sender, EventArgs e) { MostrarDetalleParada(4); }

        private void MostrarDetalleParada(int posicion)
        {
            if (vehiculoActual == null) return;

            string[] textos = vehiculoActual.Ruta.ObtenerTextos();
            if (posicion >= textos.Length) return;

            MessageBox.Show("Parada: " + textos[posicion], "Detalle de parada");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null) return;

            Envio seleccionado = listBox1.SelectedItem as Envio;
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un paquete de la lista.");
                return;
            }

            vehiculoActual.Ruta.AgregarAlFinal(seleccionado);
            ActualizarPantalla();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null) return;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione primero la parada de referencia en la tabla.");
                return;
            }

            Envio seleccionado = listBox1.SelectedItem as Envio;
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un paquete de la lista.");
                return;
            }

            string codigoReferencia = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            if (vehiculoActual.Ruta.InsertarDespues(codigoReferencia, seleccionado))
                ActualizarPantalla();
            else
                MessageBox.Show("No se pudo insertar la parada.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null) return;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la parada que quiere eliminar.");
                return;
            }

            string codigo = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            vehiculoActual.Ruta.EliminarParada(codigo);
            ActualizarPantalla();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null) return;

            if (vehiculoActual.Ruta.EstaVacia())
            {
                MessageBox.Show("La ruta está vacía.");
                return;
            }

            vehiculoActual.Ruta.CambiarEstadoTodas(EstadoEnvio.EnReparto, "En reparto", "Ruta confirmada");
            MessageBox.Show("Ruta confirmada: " + vehiculoActual.Ruta.ContarParadas() + " paradas.");
            ActualizarPantalla();
        }

        private void ActualizarPantalla()
        {
            if (vehiculoActual == null) return;

            vehiculoActual.Ruta.Mostrar(dataGridView1);
            label2.Text = "Paradas: " + vehiculoActual.Ruta.ContarParadas();
            CargarPaquetesDisponibles();
            ActualizarCadena();
        }
    }
}