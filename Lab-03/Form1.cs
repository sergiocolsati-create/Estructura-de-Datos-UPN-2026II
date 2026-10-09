using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Listaenlazadacircular l = new Listaenlazadacircular();
        private void bttnListar_Click(object sender, EventArgs e)
        {
            lstBox.Items.Clear();
            l.listar(lstBox);


        }

        private void bttnAddfirtst_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.search(int.Parse(txtNuevo.Text))) MessageBox.Show("El valor ingresado ya existe en la lista");
                else l.insertarinicio(int.Parse(txtNuevo.Text));
                txtNuevo.Text = "";
                txtNuevo.Focus();

            }
            catch (Exception)
            {

                MessageBox.Show("No puede ingresar valores nulos");
            }
            lstBox.Items.Clear();
            l.listar(lstBox);

        }

        private void bttnAddLast_Click(object sender, EventArgs e)
        {

            try
            {
                if (l.search(int.Parse(txtNuevo.Text))) MessageBox.Show("El valor ingresado ya existe en la lista");
                else l.insertarfinal(int.Parse(txtNuevo.Text));
                txtNuevo.Text = "";
                txtNuevo.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("No puede ingresar valores nulos");
            }
            lstBox.Items.Clear();
            l.listar(lstBox);
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.search(int.Parse(txtNuevo.Text)))
                    MessageBox.Show("Valor Encontrado")
                    ;

            }
            catch (Exception)
            {

                MessageBox.Show("Debe ingresar un valor valido");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.search(int.Parse(txtModifica.Text))) MessageBox.Show("El valor ingresado ya existe en la lista");
                else l.edit(int.Parse(txtNuevo.Text), int.Parse(txtModifica.Text));
                txtNuevo.Text = "";
                txtModifica.Text = "";
                txtNuevo.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar un valor valido");

            }
            lstBox.Items.Clear();
            l.listar(lstBox);
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (l.search(int.Parse(txtNuevo.Text))) {
                    l.delete(int.Parse(txtNuevo.Text));
                }
                    
                else MessageBox.Show("El valor ingresado no existe en la lista");
            }
            catch (Exception)
            {

                MessageBox.Show("Debe ingresar un valor valido");
            }
            lstBox.Items.Clear();
            l.listar(lstBox);



        }

        private void btnReloj_Click(object sender, EventArgs e)
        {
            Reloj reloj= new Reloj();
            reloj.ShowDialog();
        }
    }
}
