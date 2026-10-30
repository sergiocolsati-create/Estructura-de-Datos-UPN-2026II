using System;
using System.Windows.Forms;

namespace Lab06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArbolBinBusq arbol = new ArbolBinBusq();

        // Insertar
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int dato = int.Parse(textBox1.Text);

                if (arbol.buscar(dato))
                    MessageBox.Show("Solo se deben ingresar datos no registrados.");
                else
                {
                    arbol.insertar(dato);
                    MessageBox.Show("Se insertó: " + dato);
                }

                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar un número entero válido.");
            }
        }

        // Eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int dato = int.Parse(textBox1.Text);

                if (arbol.eliminar(dato))
                {
                    MessageBox.Show("Valor eliminado.");

                    listBox1.Items.Clear();
                    arbol.InOrden(listBox1);
                }
                else
                    MessageBox.Show("El valor no está en el árbol.");

                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar un número entero válido.");
            }
        }

        // Buscar
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int dato = int.Parse(textBox1.Text);

                if (arbol.buscar(dato))
                    MessageBox.Show("Valor encontrado.");
                else
                    MessageBox.Show("El valor no está en el árbol.");
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar un número entero válido.");
            }
        }

        // InOrden (boton "InOrden")
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (arbol.Contador() == 0)
                MessageBox.Show("El árbol está vacío.");
            else
                arbol.InOrden(listBox1);
        }

        // Contador
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El árbol tiene " + arbol.Contador() + " nodos.");
        }

        // PreOrden
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (arbol.Contador() == 0)
                MessageBox.Show("El árbol está vacío.");
            else
                arbol.PreOrden(listBox1);
        }

        // PostOrden
        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (arbol.Contador() == 0)
                MessageBox.Show("El árbol está vacío.");
            else
                arbol.PostOrden(listBox1);
        }
    }
}