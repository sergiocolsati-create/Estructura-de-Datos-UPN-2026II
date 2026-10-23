using System;
using System.Windows.Forms;

namespace Lab05
{
    public partial class FormImplementacionCola : Form
    {
        Colita col = new Colita();
        private const int CAPACIDAD_MAXIMA = 5; // Límite simulado por el form, no por la clase Colita

        public FormImplementacionCola()
        {
            InitializeComponent();
            ActualizarEstado();
        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            if (txtDato1.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese al menos el Dato 1 antes de encolar.");
                txtDato1.Focus();
                return;
            }

            if (YaExiste(txtDato1.Text, txtDato2.Text, txtDato3.Text))
            {
                MessageBox.Show("Ya existe un elemento con esos mismos tres datos en la cola. No se permiten duplicados.");
                return;
            }

            if (col.Contador() >= CAPACIDAD_MAXIMA)
            {
                MessageBox.Show("La cola alcanzó su capacidad máxima simulada (" +
                    CAPACIDAD_MAXIMA + " elementos). Desencole alguno antes de insertar otro.");
                return;
            }

            col.enqueue(txtDato1.Text, txtDato2.Text, txtDato3.Text);
            txtDato1.Text = "";
            txtDato2.Text = "";
            txtDato3.Text = "";
            txtDato1.Focus();

            ActualizarEstado();
        }

        // Recorre la cola actual (sin modificarla) y verifica si ya existe
        // un elemento con exactamente los mismos tres datos.
        private bool YaExiste(string dato1, string dato2, string dato3)
        {
            ListBox temporal = new ListBox();
            col.VerCola(temporal);

            string combinacionNueva = dato1 + " - " + dato2 + " - " + dato3;

            foreach (object item in temporal.Items)
            {
                if (item.ToString() == combinacionNueva)
                    return true;
            }
            return false;
        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            if (col.isEmpty())
            {
                MessageBox.Show("La cola está vacía, no hay nada que desencolar.");
                return;
            }

            Nodo fuera = col.dequeue();
            MessageBox.Show("Salió de la cola: " + fuera.Cod);
            ActualizarEstado();
        }

        private void btnFrente_Click(object sender, EventArgs e)
        {
            if (col.isEmpty())
            {
                MessageBox.Show("La cola está vacía, no hay un frente que consultar.");
                return;
            }

            Nodo frente = col.front();
            MessageBox.Show("El frente de la cola es: " + frente.Cod);
        }

        private void btnVacia_Click(object sender, EventArgs e)
        {
            MessageBox.Show(col.isEmpty() ? "La cola SÍ está vacía" : "La cola NO está vacía");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lstBox.Items.Clear();
            col.VerCola(lstBox);
        }

        private void ActualizarEstado()
        {
            lblCapacidad.Text = "Elementos en cola: " + col.Contador() + " / " + CAPACIDAD_MAXIMA;
            btnDesencolar.Enabled = !col.isEmpty();
            btnFrente.Enabled = !col.isEmpty();
            btnEncolar.Enabled = col.Contador() < CAPACIDAD_MAXIMA;
        }
    }
}