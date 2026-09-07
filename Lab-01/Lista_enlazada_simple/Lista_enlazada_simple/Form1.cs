using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista_enlazada_simple
{
    public partial class Form1 : Form
    {
        Lista l = new Lista();// Creamos un objeto de tipo Lista, será la lista enlazada que usará todo el formulario

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string código = txtCódigo.Text; // Guardamos lo que el usuario escribió en el textbox del código
            string descripción = txtDescripción.Text;// Guardamos lo que el usuario escribió en el textbox de la descripción
            string prioridad = cmbPrioridad.Text;// Guardamos la opción seleccionada en el combobox de prioridad
            if (string.IsNullOrWhiteSpace(código) || string.IsNullOrWhiteSpace(descripción) || string.IsNullOrWhiteSpace(prioridad))// Validamos que ningún campo esté vacío antes de continuar
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            if (l.BuscarNodo(código)) // Verificamos que el código no exista ya en la lista, para evitar duplicados
            {
                MessageBox.Show("El código ya está registrado");
            }
            l.InsertarNodo(código, descripción, prioridad);// Si todo está bien, insertamos el nuevo nodo en la lista

            MessageBox.Show("Ticket registrado");
            // Limpiamos el formulario listo para un nuevo registro
            txtCódigo.Clear();
            txtDescripción.Clear();
            cmbPrioridad.SelectedIndex = -1;

            txtCódigo.Focus();// Devolvemos el foco al primer campo para agilizar el siguiente registro

            btnListar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (l.ContarNodos() == 0)// Cuenta si la lista tiene nodos, si no tiene, envia message box
            {
                MessageBox.Show("No hay tickets registrados");

            }
            string código = txtCódigo.Text;
            if (string.IsNullOrWhiteSpace(código))// Si no se ha ingresado un codigo, tambien envia message box
            {
                MessageBox.Show("Digita un codigo!");

            }
            bool respuesta = l.eliminarNodo(código);// Le pedimos a la lista que intente eliminar ese nodo
            if (respuesta == true)
            {
                MessageBox.Show("Nodo eliminado!");// Si devolvió true, se elimino el nodo
            }
            else
            {
                MessageBox.Show("Nodo no encontrado!");// Sino devuelve, nodo no encontrado
            }
            btnListar_Click(sender, e);// lista nuevamente
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                lstBox.Items.Clear();// Limpia el lstBox

                if (l.ContarNodos() == 0)
                {
                    MessageBox.Show("No hay tickets registrados");// Si no hay tickets, el sistema avisa que no hay registros
                    return;
                }

                l.VerLista(lstBox);// Nos muestra la lista
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al listar los tickets: ");
            }
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string cod = txtCódigo.Text;// declaramos "cod" para que reciba el valor ingresado en txCódigo
            if (string.IsNullOrWhiteSpace(cod))// Verificamos que el valor no sea nulo.
            {
                MessageBox.Show("Ingrese el código");
                return;
            }
            lstBox.Items.Clear();// Limpiamos el ListBox antes de mostrar el resultado de la búsqueda

            bool encontrado = l.ListarBusqueda(cod, lstBox);// Buscamos el código y, si existe, lo mostramos en el ListBox

            if (encontrado)
            {
                MessageBox.Show("Ticket encontrado!");
            }
            else
            {
                MessageBox.Show("Ticket no encontrado!");
            }
        }
        private void btnContar_Click_1(object sender, EventArgs e)
        {
            int contador = l.ContarNodos();// Pedimos a la lista que cuente cuántos nodos tiene

            if (contador == 0)
            {
                MessageBox.Show("No hay tickets registrados");
                return;
            }
            else
            {
                MessageBox.Show("Contador de tickets: " + contador);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}