using Shalom;
using System;
using System.Windows.Forms;

namespace Shalom
{
    public partial class RastreoYLogística : Form
    {
        public RastreoYLogística()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Ingreso_de_envíos_Cola_de_Recepción().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new AsignaciónDeRutas().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Almacén().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new CargaDelVehículo().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new RastreoDeEnvíos().Show();
        }


        private void RastreoYLogística_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Cargar desde SQL Server las sedes,
                // personas, vehículos, envíos e historial.
                Sistema.CargarDatosSQL();

                // 2. Actualizar los contadores del panel principal.
                label4.Text = Sistema.Registro
                    .Contar(EstadoEnvio.Registrado).ToString();

                label5.Text = Sistema.Registro
                    .Contar(EstadoEnvio.EnPreparacion).ToString();

                label6.Text = Sistema.Registro
                    .Contar(EstadoEnvio.EnReparto).ToString();

                label7.Text = Sistema.Registro
                    .Contar(EstadoEnvio.Entregado).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos de Shalom desde SQL Server.\n\n"
                    + ex.Message,
                    "Error al cargar datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



    }
}
