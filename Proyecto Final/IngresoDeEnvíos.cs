using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    public partial class Ingreso_de_envíos_Cola_de_Recepción : Form
    {
        public Ingreso_de_envíos_Cola_de_Recepción()
        {
            InitializeComponent();
            lblMonto.Text = "Pendiente de calcular";
            ConfigurarControles();
            ActualizarVista();
        }
        private void ConfigurarControles()
        {
            // ComboBox de sedes: muestran el Nombre y guardan el objeto Sede completo
            cboOrigen.DisplayMember = "Nombre";
            cboDestino.DisplayMember = "Nombre";
            cboOrigen.Items.AddRange(Sistema.Sedes);
            cboDestino.Items.AddRange(Sistema.Sedes);
            cboOrigen.DropDownStyle = ComboBoxStyle.DropDownList;    // No se puede escribir
            cboDestino.DropDownStyle = ComboBoxStyle.DropDownList;


            // Tipo y modalidad de pago: el ORDEN debe ser igual al del enum,
            // porque luego se convierte con (TipoPaquete)cboTipo.SelectedIndex
            cboTipo.Items.AddRange(new object[] { "Sobre", "Caja" });                          // enum TipoPaquete  { Sobre, Caja }
            cboPago.Items.AddRange(new object[] { "Pagado en origen", "Por cobrar en destino" }); // enum ModalidadPago { PagadoEnOrigen, PorCobrarEnDestino }
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPago.DropDownStyle = ComboBoxStyle.DropDownList;

            // Grilla de solo lectura, sin la fila vacía (*) del final
            dgvRecepcion.AllowUserToAddRows = false;
            dgvRecepcion.ReadOnly = true;
            dgvRecepcion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            // 1. Convertir el peso sin que el programa se caiga
            decimal peso;
            if (!decimal.TryParse(txtPeso.Text, out peso))
            {
                MessageBox.Show("Ingrese un peso válido. Ejemplo: 2.5", "Peso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Armar el objeto Envio con los datos del formulario
            Envio envio = new Envio();
            envio.SedeOrigen = cboOrigen.SelectedItem as Sede;
            envio.SedeDestino = cboDestino.SelectedItem as Sede;
            envio.PesoKg = peso;
            envio.Descripcion = txtDetalle.Text.Trim();
            envio.Tipo=(TipoPaquete)cboTipo.SelectedIndex;
            envio.ModalidadPago=(ModalidadPago)cboPago.SelectedIndex;

            envio.Remitente = new Persona();
            envio.Remitente.TipoDocumento = "DNI";
            envio.Remitente.Nombres = txtRemitente.Text.Trim();
            envio.Remitente.NumeroDocumento = txtDniRemitente.Text.Trim();
            envio.Remitente.Telefono = txtTel.Text.Trim();

            envio.Destinatario = new Persona();
            envio.Destinatario.TipoDocumento = "DNI";
            envio.Destinatario.Nombres = txtDestinatario.Text.Trim();
            envio.Destinatario.NumeroDocumento = txtDniDestinatario.Text.Trim();
            envio.Destinatario.Telefono = txtTelDestinatario.Text.Trim();

            // 3. Validar (la regla vive en la clase Envio, no en el formulario)
            string error = envio.Validar();
            if (error != "")
            {
                MessageBox.Show(error, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // 5. Guardar: SQL asigna el Id → se genera la guía → historial → cola y árbol
            try
            {
                // Buscar la tarifa del origen y destino seleccionados.
                Tarifa tarifa = Sistema.BuscarTarifa(
                    envio.SedeOrigen.Id,
                    envio.SedeDestino.Id);

                if (tarifa == null)
                {
                    MessageBox.Show(
                        "No hay tarifa registrada para el trayecto:\n" +
                        envio.SedeOrigen.Nombre + " → " +
                        envio.SedeDestino.Nombre);

                    return;
                }

                // Calcular el precio antes de guardar el envío.
                envio.CalcularPrecio(
                    tarifa.PrecioBase,
                    tarifa.PrecioPorKg);

                Sistema.RegistrarEnvio(envio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar el envío:\n" + ex.Message);

                return;
            }

            // 6. Mostrar resultado
            txtGuia.Text = envio.Codigo;
            lblMonto.Text = "S/ " + envio.Precio.ToString("0.00");
            MessageBox.Show("Guía: " + envio.Codigo + "\nClave de recojo: " + envio.ClaveSeguridad +
                            "\nPrecio: S/ " + envio.Precio.ToString("0.00"),
                            "Envío registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            ActualizarVista();

        }

        private void btnVerfrente_Click(object sender, EventArgs e)
        {
            Envio frente = Sistema.Recepcion.VerFrente();
            if (frente == null)
            {
                MessageBox.Show("La cola de recepción está vacía.", "Ver frente");
                return;
            }

            MessageBox.Show("Guía: " + frente.Codigo +
                            "\nRemitente: " + frente.Remitente.Nombres +
                            "\nDestino: " + frente.SedeDestino.Nombre +
                            "\nPeso: " + frente.PesoKg + " kg",
                            "Frente de la cola");

        }

        private void btnEnvAlm_Click(object sender, EventArgs e)
        {
            Envio frente = Sistema.Recepcion.VerFrente();   // Para el mensaje final

            try
            {
                // Desencola de recepción, encola en almacén y lo guarda en SQL
                string error = Sistema.EnviarAAlmacen();
                if (error != "")
                {
                    MessageBox.Show(error, "Enviar a almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActualizarVista();
            MessageBox.Show(frente.Codigo + " fue enviado al almacén.", "Enviar a almacén");

            new Almacén().Show();
        }
        private void ActualizarVista()
        {
            Sistema.Recepcion.Mostrar(dgvRecepcion);
            lblContar.Text = Sistema.Recepcion.Cantidad.ToString();

            Envio frente = Sistema.Recepcion.VerFrente();
            lblMostrar.Text = frente == null ? "-----" : frente.Codigo;
        }
        private void LimpiarCampos()
        {
            txtRemitente.Clear();
            txtDniRemitente.Clear();
            txtTel.Clear();
            txtDestinatario.Clear();
            txtDniDestinatario.Clear();
            txtTelDestinatario.Clear();
            txtPeso.Clear();
            txtDetalle.Clear();
            cboOrigen.SelectedIndex = -1;
            cboDestino.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            cboPago.SelectedIndex = -1;
            txtRemitente.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ingreso_de_envíos_Cola_de_Recepción_Load(object sender, EventArgs e)
        {

        }
    }
}
