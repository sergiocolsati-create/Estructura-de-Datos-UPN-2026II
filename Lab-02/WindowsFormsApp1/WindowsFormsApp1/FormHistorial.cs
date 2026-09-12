using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class FormHistorial : Form
    {


        public FormHistorial()
        {
            InitializeComponent();
        }
        ListaDoble_Nav H = new ListaDoble_Nav();// definimos la listadoble "H"

        private void btnVisitar_Click(object sender, EventArgs e)// Boton equivalente a insertar o insertar al final
        {
            try
            {
                H.visitar(txtPagina.Text);// agrega el url ingresado
                lblActual.Text = "Página actual: " + txtPagina.Text;// actualiza el label
                webB.Navigate(txtPagina.Text);// muestra en el Webbrowser el url ingresado
                txtPagina.Text = "";// limpia el textbox
                txtPagina.Focus();// vuelva a colocar el marcador en textbox
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar una direccion web");

            }

            H.listar(lstHistorial);// list automaticamente el historial

        }

        private void btnAtrás_Click(object sender, EventArgs e)
        {
            try
            {
                string url = H.Ante();// definimos url como el resultado de H.ante()
                txtPagina.Text = url;//-- lamamos a txtpagina y le asignamos el valor de url
                lblActual.Text = "Página actual: " + url;// actualizamos lbl
                webB.Navigate(url);// actualizamos webbrowser
            }
            catch (Exception)
            {
                MessageBox.Show("No hay historial disponible.");

            }

        }

        private void btnAdelante_Click(object sender, EventArgs e)// misma logica que el boton atras, solo que con la funcion adelante
        {
            try
            {
                string url = H.Sgte();
                txtPagina.Text = url;
                lblActual.Text = "Página actual: " + url;
                webB.Navigate(url);
            }
            catch (Exception)
            {
                MessageBox.Show("No hay historial disponible.");
            }

        }

        private void btnClean_Click(object sender, EventArgs e)// eliminacion de nodos
        {
            try
            {
                H.delete(txtPagina.Text);
                string url = H.Ante(); // nos movemos al anterior tras borrar
                txtPagina.Text = url;
                lblActual.Text = "Página actual: " + url;
                webB.Navigate(url);
            }
            catch (Exception)
            {

                MessageBox.Show("No se ha seleccionado que eliminar");
            }
            H.listar(lstHistorial);
        }
    }
}