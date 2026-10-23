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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Colita col = new Colita();


        private void btnQueue_Click(object sender, EventArgs e)
        {
            col.enqueue(txtCod.Text, txtDescrip.Text, txtPrioridad.Text);
            txtCod.Text = "";
            txtDescrip.Text = "";
            txtPrioridad.Text = "";
            txtCod.Focus();
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            Nodo fuera = col.dequeue();
            if (fuera == null) MessageBox.Show("La cola esta vacias");
            else MessageBox.Show("Salio de cola:  " + fuera.Cod);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lstBox.Items.Clear();
            col.VerCola(lstBox);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Nodo frente = col.front();
            if (frente == null) MessageBox.Show("la cola esta vacia");
            else MessageBox.Show("El frente de la cola es: " + frente.Cod);
        }

        private void btnIrForm2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormImplementacionCola f = new FormImplementacionCola();
            f.Show();
        }
    }
}