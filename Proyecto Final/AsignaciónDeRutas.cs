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

        // "Paquetes por asignar" = la PILA del vehículo, del tope a la base.
        // Solo el tope puede pasar a la ruta (LIFO), por eso queda seleccionado.
        private void CargarPaquetesDisponibles()
        {
            listBox1.Items.Clear();
            if (vehiculoActual == null) return;

            Envio[] pila = vehiculoActual.Carga.ObtenerTodos();
            for (int i = 0; i < pila.Length; i++)
                listBox1.Items.Add(pila[i]);

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;   // El tope
        }

        // Revisa que el usuario haya elegido el tope de la pila
        private bool EsElTope()
        {
            Envio seleccionado = listBox1.SelectedItem as Envio;
            Envio tope = vehiculoActual.Carga.VerTope();

            if (tope == null)
            {
                MessageBox.Show("No hay paquetes por asignar en este vehículo.", "Rutas");
                return false;
            }
            if (seleccionado != tope)
            {
                MessageBox.Show("Solo puede asignarse el paquete del TOPE de la pila (" + tope.Codigo +
                                "): es el último que se cargó y el primero que sale (LIFO).",
                                "Rutas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox1.SelectedIndex = 0;
                return false;
            }
            return true;
        }

        // Ejecuta una operación de Sistema y muestra el error si lo hay
        private void Ejecutar(Func<string> operacion, string titulo)
        {
            try
            {
                string error = operacion();
                if (error != "")
                {
                    MessageBox.Show(error, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarPantalla();
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

        // ---------- Agregar al final: tope de la pila → última parada ----------
        private void button6_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null || !EsElTope()) return;
            Ejecutar(() => Sistema.AsignarTope(vehiculoActual, null), "Agregar al final");
        }

        // ---------- Insertar después: tope de la pila → después de la parada elegida ----------
        private void button7_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null) return;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione primero la parada de referencia en la tabla.");
                return;
            }
            if (!EsElTope()) return;

            string codigoReferencia = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Ejecutar(() => Sistema.AsignarTope(vehiculoActual, codigoReferencia), "Insertar después");
        }

        // ---------- Eliminar parada: sale de la ruta y vuelve al tope del vehículo ----------
        private void button8_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null) return;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la parada que quiere eliminar.");
                return;
            }

            string codigo = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Ejecutar(() => Sistema.QuitarParada(vehiculoActual, codigo), "Eliminar parada");
        }

        // ---------- Confirmar ruta: cada cambio ya se guardó; aquí solo se resume ----------
        private void button9_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null) return;

            if (vehiculoActual.Ruta.EstaVacia())
            {
                MessageBox.Show("La ruta está vacía.");
                return;
            }

            MessageBox.Show("Ruta de " + vehiculoActual.Placa + " guardada con " +
                            vehiculoActual.Ruta.ContarParadas() + " paradas.\n" +
                            "Paquetes aún en el vehículo: " + vehiculoActual.Carga.Contar(),
                            "Confirmar ruta");
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
