using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pila<int> p = new Pila<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = int.Parse(textBox1.Text);

                if (valor < 0)
                {
                    MessageBox.Show("No ingrese números negativos");
                }
                else
                {
                    p.push(valor);
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un número entero válido");
                textBox1.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p.pop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p.isEmpty()) MessageBox.Show("La pila está vacía");
            else MessageBox.Show("El top es: " + p.Top());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p.isEmpty())
            {
                MessageBox.Show("La pila está vacía");
            }
            else
            {
                MessageBox.Show("La pila tiene elementos");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p.clear();
            listBox1.Items.Clear();
            MessageBox.Show("La pila se ha vaciado");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            p.listar(listBox1);
        }

       
        private void button7_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            new Evaluacion_de_Expresiones().Show();
        }
    }
}
