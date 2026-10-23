using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    // Simulación: Cola de impresión (los documentos se imprimen en el orden en que se enviaron)
    public partial class Form2 : Form
    {
        Colita cola = new Colita();

        public Form2()
        {
            InitializeComponent();

            // Conectamos los botones con sus métodos
            btnEnviar.Click += btnEnviar_Click;
            btnImprimir.Click += btnImprimir_Click;
            btnVerSig.Click += btnVerSig_Click;
        }

        // Muestra la cola en el ListBox y el total de documentos en espera
        private void ActualizarLista()
        {
            lstBox.Items.Clear();
            cola.VerCola(lstBox);
            lblTotal.Text = "Documentos en espera: " + cola.Contador();
        }

        // Enviar a imprimir = enqueue
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "" || txtArchivo.Text == "" || txtPaginas.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            cola.enqueue(txtCod.Text, txtArchivo.Text, txtPaginas.Text);
            txtCod.Text = "";
            txtArchivo.Text = "";
            txtPaginas.Text = "";
            txtCod.Focus();

            ActualizarLista();
        }

        // Imprimir siguiente = dequeue
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Nodo doc = cola.dequeue();
            if (doc == null)
            {
                MessageBox.Show("No hay documentos en espera");
                lblImprimiendo.Text = "Imprimiendo: nadie";
            }
            else
            {
                lblImprimiendo.Text = "Imprimiendo: " + doc.Cod + " - " + doc.Descripcion
                                      + " (" + doc.Prioridad + " paginas)";
            }

            ActualizarLista();
        }

        // Ver siguiente = front
        private void btnVerSig_Click(object sender, EventArgs e)
        {
            Nodo frente = cola.front();
            if (frente == null) MessageBox.Show("No hay documentos en espera");
            else MessageBox.Show("El siguiente en imprimirse es: " + frente.Cod + " - " + frente.Descripcion);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}