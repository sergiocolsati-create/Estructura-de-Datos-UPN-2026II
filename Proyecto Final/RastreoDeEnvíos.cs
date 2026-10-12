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
    public partial class RastreoDeEnvíos : Form
    {
        private Envio envioSeleccionado;

        public RastreoDeEnvíos()
        {
            InitializeComponent();

            this.Load += RastreoDeEnvíos_Load;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button4.Click += button4_Click;
        }

        private void RastreoDeEnvíos_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Todos");
            comboBox1.Items.Add(EstadoEnvio.Registrado);
            comboBox1.Items.Add(EstadoEnvio.EnPreparacion);
            comboBox1.Items.Add(EstadoEnvio.EnTransito);
            comboBox1.Items.Add(EstadoEnvio.EnReparto);
            comboBox1.Items.Add(EstadoEnvio.Entregado);
            comboBox1.Items.Add(EstadoEnvio.Incidencia);
           

            comboBox3.Items.Add(EstadoEnvio.Registrado);
            comboBox3.Items.Add(EstadoEnvio.EnPreparacion);
            comboBox3.Items.Add(EstadoEnvio.EnTransito);
            comboBox3.Items.Add(EstadoEnvio.EnReparto);
            comboBox3.Items.Add(EstadoEnvio.Entregado);
            comboBox3.Items.Add(EstadoEnvio.Incidencia);
           

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;

            MostrarTodos();
        }

        // Si hay texto en "N° de guía", busca ese envío exacto (árbol).
        // Si no, aplica el filtro de Estado a la lista completa.
        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text.Trim();

            if (codigo != "")
            {
                Envio envio = Sistema.Registro.Buscar(codigo);
                if (envio == null)
                {
                    MessageBox.Show("No existe un envío con ese código.");
                    return;
                }

                string cliente = "";
                if (envio.Remitente != null) cliente = envio.Remitente.Nombres;

                string destino = "";
                if (envio.SedeDestino != null) destino = envio.SedeDestino.Nombre;

                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(envio.Codigo, cliente, destino, envio.Estado,
                    envio.FechaActualizacion.ToString("dd/MM/yyyy HH:mm"));

                MostrarDetalle(envio);
                return;
            }

            if (comboBox1.SelectedIndex <= 0)
            {
                Sistema.Registro.Mostrar(dataGridView1, null);   // "Todos"
            }
            else
            {
                EstadoEnvio filtro = (EstadoEnvio)comboBox1.SelectedItem;
                Sistema.Registro.Mostrar(dataGridView1, filtro);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            LimpiarDetalle();
            MostrarTodos();
        }

        // Al hacer clic en una fila de la tabla, muestra el detalle y el historial de ese envío.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string codigo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Envio envio = Sistema.Registro.Buscar(codigo);
            if (envio == null) return;

            MostrarDetalle(envio);
        }

        // Cambia el estado del envío seleccionado (botón "Actualizar estado").
        private void button4_Click(object sender, EventArgs e)
        {
            if (envioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione un envío de la lista.");
                return;
            }

            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nuevo estado.");
                return;
            }

            EstadoEnvio nuevoEstado = (EstadoEnvio)comboBox3.SelectedItem;
            envioSeleccionado.CambiarEstado(nuevoEstado, "Rastreo", textBox6.Text);

            MostrarDetalle(envioSeleccionado);
            MostrarTodos();
            textBox6.Text = "";
            MessageBox.Show("Estado actualizado a " + nuevoEstado + ".");
        }

        private void MostrarTodos()
        {
            Sistema.Registro.Mostrar(dataGridView1, null);
        }

        private void MostrarDetalle(Envio envio)
        {
            envioSeleccionado = envio;

            string cliente = "";
            if (envio.Remitente != null) cliente = envio.Remitente.Nombres;

            string destino = "";
            if (envio.SedeDestino != null) destino = envio.SedeDestino.Nombre;

            string placa = "(sin asignar)";
            if (envio.PlacaVehiculo != null) placa = envio.PlacaVehiculo;

            textBox2.Text = envio.Codigo;
            textBox3.Text = cliente;
            textBox4.Text = destino;
            textBox5.Text = placa;

            envio.Historial.Mostrar(dataGridView2);
        }

        private void LimpiarDetalle()
        {
            envioSeleccionado = null;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dataGridView2.Rows.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}