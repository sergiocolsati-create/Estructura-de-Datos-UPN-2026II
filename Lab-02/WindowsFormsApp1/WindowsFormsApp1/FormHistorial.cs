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
    public partial class FormHistorial : Form
    {
        private ListaDoble historial = new ListaDoble();
        private int indiceActual = -1;

        public FormHistorial()
        {
            InitializeComponent();
        }

        private void btnVisitar_Click(object sender, EventArgs e)
        {
            int numeroPagina;
            if (!int.TryParse(txtPagina.Text, out numeroPagina))
            {
                MessageBox.Show("Ingresa un número de página válido.");
                return;
            }

            if (historial.agregarAlFinal(numeroPagina))
            {
                historial.imprimirAdelante(lstHistorial);
                indiceActual = lstHistorial.Items.Count - 1;
                MostrarActual();
                txtPagina.Text = "";
                txtPagina.Focus();
            }
        }

        private void btnAtrás_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0)
            {
                indiceActual--;
                MostrarActual();
            }
            else
            {
                MessageBox.Show("No hay páginas anteriores en el historial.");
            }
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            if (indiceActual >= 0 && indiceActual < lstHistorial.Items.Count - 1)
            {
                indiceActual++;
                MostrarActual();
            }
            else
            {
                MessageBox.Show("No hay páginas siguientes en el historial.");
            }
        }

        private void MostrarActual()
        {
            if (indiceActual >= 0 && indiceActual < lstHistorial.Items.Count)
            {
                lblActual.Text = "Página actual: " + lstHistorial.Items[indiceActual];
                lstHistorial.SelectedIndex = indiceActual;
            }
        }
    }
}