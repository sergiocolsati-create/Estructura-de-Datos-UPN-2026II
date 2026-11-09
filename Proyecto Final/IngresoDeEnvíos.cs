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
        // true cuando los datos del remitente / destinatario se cargaron desde la BD por su DNI
        private bool remitenteRegistrado = false;
        private bool destinatarioRegistrado = false;

        public Ingreso_de_envíos_Cola_de_Recepción()
        {
            InitializeComponent();
            lblMonto.Text = "Pendiente de calcular";
            ConfigurarControles();
            ConfigurarValidaciones();
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
            cboTipo.Items.AddRange(new object[] { "Sobre", "Caja" });                              // enum TipoPaquete  { Sobre, Caja }
            cboPago.Items.AddRange(new object[] { "Pagado en origen", "Por cobrar en destino" });  // enum ModalidadPago { PagadoEnOrigen, PorCobrarEnDestino }
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPago.DropDownStyle = ComboBoxStyle.DropDownList;

            // Grilla de solo lectura, sin la fila vacía (*) del final
            dgvRecepcion.AllowUserToAddRows = false;
            dgvRecepcion.ReadOnly = true;
            dgvRecepcion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // =========================================================
        //  VALIDACIONES MIENTRAS SE ESCRIBE
        // =========================================================
        private void ConfigurarValidaciones()
        {
            // Largo máximo de cada campo
            txtDniRemitente.MaxLength = 8;
            txtDniDestinatario.MaxLength = 8;
            txtTel.MaxLength = 9;
            txtTelDestinatario.MaxLength = 9;
            txtRemitente.MaxLength = 100;
            txtDestinatario.MaxLength = 100;
            txtDetalle.MaxLength = 200;

            // Qué teclas acepta cada campo
            txtDniRemitente.KeyPress += SoloNumeros;
            txtDniDestinatario.KeyPress += SoloNumeros;
            txtTel.KeyPress += SoloNumeros;
            txtTelDestinatario.KeyPress += SoloNumeros;
            txtRemitente.KeyPress += SoloLetras;
            txtDestinatario.KeyPress += SoloLetras;
            txtPeso.KeyPress += SoloDecimal;

            // Al completar los 8 dígitos del DNI se buscan los datos en la BD
            txtDniRemitente.TextChanged += (s, e) =>
                remitenteRegistrado = CargarPersonaPorDni(txtDniRemitente, txtRemitente, txtTel, remitenteRegistrado);

            txtDniDestinatario.TextChanged += (s, e) =>
                destinatarioRegistrado = CargarPersonaPorDni(txtDniDestinatario, txtDestinatario, txtTelDestinatario, destinatarioRegistrado);
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        // Dígitos y un solo punto decimal
        private void SoloDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox caja = (TextBox)sender;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' && !caja.Text.Contains("."))
                return;

            e.Handled = true;
        }

        // Si el DNI ya está registrado, llena nombre y teléfono con los datos de la BD.
        // El nombre queda bloqueado (pertenece a ese DNI); el teléfono se puede actualizar.
        // Devuelve true si se cargó una persona registrada.
        private bool CargarPersonaPorDni(TextBox txtDni, TextBox txtNombre, TextBox txtTelefono, bool estabaCargada)
        {
            string dni = txtDni.Text.Trim();

            if (EsDniValido(dni))
            {
                Persona persona;
                try
                {
                    persona = Sistema.BuscarPersonaPorDni(dni);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo consultar el DNI:\n" + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (persona != null)
                {
                    txtNombre.Text = persona.Nombres;
                    txtTelefono.Text = persona.Telefono;
                    txtNombre.ReadOnly = true;
                    txtTelefono.Focus();
                    return true;
                }
            }

            // DNI incompleto o no registrado: si antes se habían cargado datos de otra persona, se borran
            if (estabaCargada)
            {
                txtNombre.Clear();
                txtTelefono.Clear();
            }
            txtNombre.ReadOnly = false;
            return false;
        }

        // ---------- Reglas de formato ----------

        // Al menos 3 caracteres, solo letras y espacios
        private bool EsNombreValido(string nombre)
        {
            if (nombre.Length < 3)
                return false;

            foreach (char c in nombre)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        // Exactamente 8 dígitos
        private bool EsDniValido(string dni)
        {
            return dni.Length == 8 && dni.All(char.IsDigit);
        }

        // Exactamente 9 dígitos y empieza con 9 (celular en Perú)
        private bool EsTelefonoValido(string telefono)
        {
            return telefono.Length == 9 && telefono.All(char.IsDigit) && telefono[0] == '9';
        }

        // =========================================================
        //  VALIDACIÓN COMPLETA ANTES DE REGISTRAR
        //  Devuelve "" si todo está bien; si no, el mensaje y el campo a corregir.
        // =========================================================
        private string ValidarFormulario(out Control campo)
        {
            string nomRem = txtRemitente.Text.Trim();
            string dniRem = txtDniRemitente.Text.Trim();
            string telRem = txtTel.Text.Trim();
            string nomDes = txtDestinatario.Text.Trim();
            string dniDes = txtDniDestinatario.Text.Trim();
            string telDes = txtTelDestinatario.Text.Trim();

            // Remitente
            campo = txtDniRemitente;
            if (!EsDniValido(dniRem)) return "El DNI del remitente debe tener 8 dígitos.";
            campo = txtRemitente;
            if (!EsNombreValido(nomRem)) return "Ingrese el nombre del remitente (mínimo 3 letras, sin números).";
           
            campo = txtTel;
            if (!EsTelefonoValido(telRem)) return "El teléfono del remitente debe tener 9 dígitos y empezar con 9.";

            // Destinatario
            campo = txtDniDestinatario;
            if (!EsDniValido(dniDes)) return "El DNI del destinatario debe tener 8 dígitos.";
            campo = txtDestinatario;
            if (!EsNombreValido(nomDes)) return "Ingrese el nombre del destinatario (mínimo 3 letras, sin números).";
            
            campo = txtTelDestinatario;
            if (!EsTelefonoValido(telDes)) return "El teléfono del destinatario debe tener 9 dígitos y empezar con 9.";

            // Remitente y destinatario deben ser personas distintas
            campo = txtDniDestinatario;
            if (dniRem == dniDes) return "El remitente y el destinatario no pueden tener el mismo DNI.";
            campo = txtTelDestinatario;
            if (telRem == telDes) return "El remitente y el destinatario no pueden tener el mismo teléfono.";

            // Paquete
            campo = txtPeso;
            decimal peso;
            if (!decimal.TryParse(txtPeso.Text, out peso) || peso <= 0)
                return "Ingrese un peso válido mayor a 0. Ejemplo: 2.5";

            decimal maxCapacidad = 0;
            foreach (Vehiculo v in Sistema.Vehiculos)
                if (v.CapacidadKg > maxCapacidad) maxCapacidad = v.CapacidadKg;
            if (maxCapacidad > 0 && peso > maxCapacidad)
                return "El peso supera la capacidad del vehículo más grande (" + maxCapacidad.ToString("0") + " kg).";

            campo = txtDetalle;
            if (txtDetalle.Text.Trim() == "") return "Ingrese el detalle del contenido.";

            campo = cboTipo;
            if (cboTipo.SelectedIndex == -1) return "Seleccione el tipo de paquete.";

            // Sedes y pago
            campo = cboOrigen;
            if (cboOrigen.SelectedIndex == -1) return "Seleccione la sede de origen.";
            campo = cboDestino;
            if (cboDestino.SelectedIndex == -1) return "Seleccione la sede de destino.";
            if (cboOrigen.SelectedItem == cboDestino.SelectedItem) return "La sede de origen y la de destino no pueden ser la misma.";
            campo = cboPago;
            if (cboPago.SelectedIndex == -1) return "Seleccione el método de pago.";

            // Teléfonos que ya pertenecen a OTRA persona (consulta a la BD)
            string dueño = Sistema.TelefonoDeOtraPersona(telRem, dniRem);
            campo = txtTel;
            if (dueño != null) return "El teléfono " + telRem + " ya está registrado a nombre de " + dueño + ".";

            dueño = Sistema.TelefonoDeOtraPersona(telDes, dniDes);
            campo = txtTelDestinatario;
            if (dueño != null) return "El teléfono " + telDes + " ya está registrado a nombre de " + dueño + ".";

            campo = null;
            return "";
        }

        // =========================================================
        //  REGISTRAR EN COLA
        // =========================================================
        private void btnEncolar_Click(object sender, EventArgs e)
        {
            // 1. Validar el formulario
            string error;
            Control campo;
            try
            {
                error = ValidarFormulario(out campo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron validar los datos en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (error != "")
            {
                MessageBox.Show(error, "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (campo != null)
                {
                    campo.Focus();
                    if (campo is TextBox) ((TextBox)campo).SelectAll();
                }
                return;
            }

            // 2. Armar el objeto Envio con los datos del formulario (ya validados)
            Envio envio = new Envio();
            envio.SedeOrigen = cboOrigen.SelectedItem as Sede;
            envio.SedeDestino = cboDestino.SelectedItem as Sede;
            envio.PesoKg = decimal.Parse(txtPeso.Text);
            envio.Descripcion = txtDetalle.Text.Trim();
            envio.Tipo = (TipoPaquete)cboTipo.SelectedIndex;
            envio.ModalidadPago = (ModalidadPago)cboPago.SelectedIndex;

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

            // 3. Reglas propias del envío (clase Envio)
            error = envio.Validar();
            if (error != "")
            {
                MessageBox.Show(error, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Tarifa, precio y guardado: SQL asigna el Id → guía → historial → cola y árbol
            try
            {
                Tarifa tarifa = Sistema.BuscarTarifa(envio.SedeOrigen.Id, envio.SedeDestino.Id);

                if (tarifa == null)
                {
                    MessageBox.Show("No hay tarifa registrada para el trayecto:\n" +
                                    envio.SedeOrigen.Nombre + " → " + envio.SedeDestino.Nombre,
                                    "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                envio.CalcularPrecio(tarifa.PrecioBase, tarifa.PrecioPorKg);
                Sistema.RegistrarEnvio(envio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el envío:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Mostrar resultado
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
            // Primero los DNI: al vaciarlos se desbloquean los nombres
            txtDniRemitente.Clear();
            txtDniDestinatario.Clear();
            txtRemitente.Clear();
            txtTel.Clear();
            txtDestinatario.Clear();
            txtTelDestinatario.Clear();
            txtRemitente.ReadOnly = false;
            txtDestinatario.ReadOnly = false;
            remitenteRegistrado = false;
            destinatarioRegistrado = false;

            txtPeso.Clear();
            txtDetalle.Clear();
            cboOrigen.SelectedIndex = -1;
            cboDestino.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            cboPago.SelectedIndex = -1;
            txtRemitente.Focus();
        }

        // Eventos conectados en el diseñador (se dejan vacíos)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Ingreso_de_envíos_Cola_de_Recepción_Load(object sender, EventArgs e) { }

        private void lnkDesarrollador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DevSer().ShowDialog(this);
        }

        private void txtDniRemitente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}