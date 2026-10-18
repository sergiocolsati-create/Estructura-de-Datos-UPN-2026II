using System;
using System.Windows.Forms;

namespace Shalom
{
    public partial class AsignaciónDeRutas : Form
    {
        private Vehiculo vehiculoActual;
        private Button[] botonesParada;
        private Label[] flechas;

        public AsignaciónDeRutas()
        {
            InitializeComponent();

            cboVehiculo.DisplayMember = "Placa";
            cboVehiculo.Items.AddRange(Sistema.Vehiculos);
            cboVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVehiculo.SelectedIndexChanged += cboVehiculo_SelectedIndexChanged;

            lstPaquetesPendientes.DisplayMember = "Codigo";

            dgvParadasRuta.AllowUserToAddRows = false;
            dgvParadasRuta.ReadOnly = true;
            dgvParadasRuta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParadasRuta.MultiSelect = false;

            botonesParada = new Button[]
            {
                btnParada1, btnParada2, btnParada3, btnParada4, btnParada5
            };

            flechas = new Label[]
            {
                lblFlecha1, lblFlecha2, lblFlecha3, lblFlecha4
            };
        }

        private void AsignaciónDeRutas_Load(object sender, EventArgs e)
        {
            if (cboVehiculo.Items.Count > 0)
                cboVehiculo.SelectedIndex = 0;
        }

        private void cboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehiculoActual = cboVehiculo.SelectedItem as Vehiculo;
            ActualizarPantalla();
        }

        private bool EsElPaqueteDelTope()
        {
            if (vehiculoActual == null)
                return false;

            Envio paqueteSeleccionado = lstPaquetesPendientes.SelectedItem as Envio;
            Envio paqueteDelTope = vehiculoActual.Carga.VerTope();

            if (paqueteDelTope == null)
            {
                MessageBox.Show("Este vehículo no tiene paquetes por asignar.");
                return false;
            }

            if (paqueteSeleccionado != paqueteDelTope)
            {
                MessageBox.Show(
                    "Solo puedes asignar el paquete que está en el tope de la carga.");

                lstPaquetesPendientes.SelectedIndex = 0;
                return false;
            }

            return true;
        }

        private string ObtenerGuiaSeleccionada()
        {
            if (dgvParadasRuta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una parada de la tabla.");
                return null;
            }

            object valor = dgvParadasRuta.SelectedRows[0].Cells["colGuia"].Value;

            if (valor == null)
            {
                MessageBox.Show("No se pudo obtener el número de guía.");
                return null;
            }

            return valor.ToString();
        }

        private void EjecutarOperacion(Func<string> operacion, string titulo)
        {
            try
            {
                string error = operacion();

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, titulo);
                    return;
                }

                ActualizarPantalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo completar la operación:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAgregarAlFinal_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null)
            {
                MessageBox.Show("Selecciona un vehículo.");
                return;
            }

            if (!EsElPaqueteDelTope())
                return;

            EjecutarOperacion(
                () => Sistema.AsignarTope(vehiculoActual, null),
                "Agregar al final");
        }

        private void btnInsertarDespues_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null)
            {
                MessageBox.Show("Selecciona un vehículo.");
                return;
            }

            string guiaReferencia = ObtenerGuiaSeleccionada();

            if (guiaReferencia == null || !EsElPaqueteDelTope())
                return;

            EjecutarOperacion(
                () => Sistema.AsignarTope(vehiculoActual, guiaReferencia),
                "Insertar después");
        }

        private void btnEliminarParada_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null)
            {
                MessageBox.Show("Selecciona un vehículo.");
                return;
            }

            string guia = ObtenerGuiaSeleccionada();

            if (guia == null)
                return;

            EjecutarOperacion(
                () => Sistema.QuitarParada(vehiculoActual, guia),
                "Eliminar parada");
        }

        private void btnVerResumenRuta_Click(object sender, EventArgs e)
        {
            if (vehiculoActual == null)
            {
                MessageBox.Show("Selecciona un vehículo.");
                return;
            }

            if (vehiculoActual.Ruta.EstaVacia())
            {
                MessageBox.Show("La ruta está vacía.");
                return;
            }

            MessageBox.Show(
                "Vehículo: " + vehiculoActual.Placa +
                "\nParadas: " + vehiculoActual.Ruta.ContarParadas() +
                "\nPaquetes que siguen en el vehículo: " +
                vehiculoActual.Carga.Contar(),
                "Resumen de ruta");
        }

        private void ActualizarPantalla()
        {
            if (vehiculoActual == null)
                return;

            vehiculoActual.Ruta.Mostrar(dgvParadasRuta);
            lblCantidadParadas.Text =
                "Paradas: " + vehiculoActual.Ruta.ContarParadas();

            lstPaquetesPendientes.Items.Clear();

            Envio[] paquetes = vehiculoActual.Carga.ObtenerTodos();

            for (int i = 0; i < paquetes.Length; i++)
                lstPaquetesPendientes.Items.Add(paquetes[i]);

            if (lstPaquetesPendientes.Items.Count > 0)
                lstPaquetesPendientes.SelectedIndex = 0;

            ActualizarCadenaDeParadas();
        }

        private void ActualizarCadenaDeParadas()
        {
            for (int i = 0; i < botonesParada.Length; i++)
                botonesParada[i].Visible = false;

            for (int i = 0; i < flechas.Length; i++)
                flechas[i].Visible = false;

            string[] paradas = vehiculoActual.Ruta.ObtenerTextos();
            int cantidadVisible = paradas.Length;

            if (cantidadVisible > botonesParada.Length)
                cantidadVisible = botonesParada.Length;

            for (int i = 0; i < cantidadVisible; i++)
            {
                botonesParada[i].Visible = true;
                botonesParada[i].Text = paradas[i];

                if (i > 0)
                    flechas[i - 1].Visible = true;
            }

            if (cantidadVisible > 0)
                botonesParada[0].Text = "Cabeza " + paradas[0];

            if (paradas.Length > botonesParada.Length)
            {
                botonesParada[botonesParada.Length - 1].Text =
                    "... (+" + (paradas.Length - botonesParada.Length + 1) + " más)";
            }
            else if (cantidadVisible > 1)
            {
                botonesParada[cantidadVisible - 1].Text =
                    "Cola " + paradas[cantidadVisible - 1];
            }
        }
    }
}
