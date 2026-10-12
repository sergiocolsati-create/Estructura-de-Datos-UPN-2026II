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
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            // Cada vez que se vuelve al panel (desde otro formulario) se refresca
            this.Activated += (s, e) => ActualizarPanel();
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
                // Una sola vez: SQL Server → estructuras en memoria
                Sistema.CargarDatosSQL();
                ActualizarPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Shalom desde SQL Server.\n\n" + ex.Message,
                                "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        // ---------- Resumen del día + tabla de vehículos ----------
        private void ActualizarPanel()
        {
            // Contadores: se cuentan recorriendo el ÁRBOL (registro general)
            label4.Text = Sistema.Registro.Contar(EstadoEnvio.Registrado).ToString();       // En cola
            label5.Text = Sistema.Registro.Contar(EstadoEnvio.EnPreparacion).ToString();    // En almacén
            label6.Text = (Sistema.Registro.Contar(EstadoEnvio.EnTransito) +
                           Sistema.Registro.Contar(EstadoEnvio.EnReparto)).ToString();      // En ruta (pila + ruta)
            label7.Text = Sistema.Registro.Contar(EstadoEnvio.Entregado).ToString();        // Entregados

            MostrarVehiculos();
        }
        // Columnas del diseñador: Placa, Estado, Paq., Carga
        private void MostrarVehiculos()
        {
            string placaSeleccionada = PlacaSeleccionada();   // Para no perder la selección al refrescar
            dataGridView1.Rows.Clear();

            for (int i = 0; i < Sistema.Vehiculos.Length; i++)
            {
                Vehiculo v = Sistema.Vehiculos[i];

                int enPila = v.Carga.Contar();
                int enRuta = v.Ruta.ContarParadas();

                string estado;
                if (enRuta > 0) estado = "En ruta";
                else if (enPila > 0) estado = "Cargando";
                else estado = "Disponible";

                string carga = v.Carga.PesoActual.ToString("0.00") + " / " +
                               v.CapacidadKg.ToString("0") + " kg (" + v.PorcentajeCarga() + "%)";

                int fila = dataGridView1.Rows.Add(v.Placa, estado, enPila + " + " + enRuta + " en ruta", carga);

                if (v.Placa == placaSeleccionada)
                    dataGridView1.Rows[fila].Selected = true;
            }
        }
        private string PlacaSeleccionada()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            object valor = dataGridView1.SelectedRows[0].Cells[0].Value;
            return valor == null ? null : valor.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string placa = PlacaSeleccionada();
            lblSeleccionado.Text = placa ?? "-";
        }

        // ---------- "Ver carga del vehículo" (debajo de la tabla) ----------
        // Conéctalo en Propiedades → Eventos → Click del botón
        private void btnVerCarga_Click(object sender, EventArgs e)
        {
            Vehiculo v = Sistema.BuscarVehiculoPorPlaca(PlacaSeleccionada());
            if (v == null)
            {
                MessageBox.Show("Seleccione un vehículo en la tabla.", "Ver carga");
                return;
            }
            new CargaDelVehículo(v).ShowDialog();
            ActualizarPanel();
        }
    }
}
