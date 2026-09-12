using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListaDoble l=new ListaDoble();

        private void btn_agregarInicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.agregarAlInicio(int.Parse(txtNuevo.Text)))
                {
                    MessageBox.Show("Valor agregado al final correctamente.");

                    txtNuevo.Text = "";
                    txtNuevo.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un número válido.");
                txtNuevo.Focus();
            }
        }

        private void btn_agregarFinal_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.agregarAlFinal(int.Parse(txtNuevo.Text)))
                {
                    MessageBox.Show("Valor agregado al final correctamente.");

                    txtNuevo.Text = "";
                    txtNuevo.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un número válido.");
                txtNuevo.Focus();
            }
        }

        private void btn_verLista_Click(object sender, EventArgs e)
        {
            if (!l.verLista(lstBox))
            {
                MessageBox.Show("La lista está vacía.");
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.buscarElemento(int.Parse(txtNuevo.Text)))
                {
                    MessageBox.Show("Valor encontrado.");
                }
                else
                {
                    MessageBox.Show("El valor no existe en la lista.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un número válido.");
                txtNuevo.Focus();
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            l.modificar(int.Parse(txtNuevo.Text), int.Parse(txtModifica.Text));
        }

        private void btn_contar_Click(object sender, EventArgs e)
        {
            l.contador();
        }

        private void btn_imprimirAdelante_Click(object sender, EventArgs e)
        {
            l.imprimirAdelante(lstBox);

            if (lstBox.Items.Count == 0)
            {
                MessageBox.Show("La lista está vacía.");
            }
        }

        private void btn_imprimirAtras_Click(object sender, EventArgs e)
        {
            l.imprimirAtras(lstBox);

            if (lstBox.Items.Count == 0)
            {
                MessageBox.Show("La lista está vacía.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.eliminar(int.Parse(txtNuevo.Text)))
                {
                    MessageBox.Show("Valor eliminado correctamente.");
                    l.imprimirAdelante(lstBox); 
                    txtNuevo.Text = "";
                    txtNuevo.Focus();
                }
                else
                {
                    MessageBox.Show("El valor no existe en la lista.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un número válido.");
                txtNuevo.Focus();
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            new FormHistorial().Show();
        }
    }
}
