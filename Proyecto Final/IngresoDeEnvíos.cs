using System;
using System.Linq;
using System.Windows.Forms;

namespace Shalom
{
    // INGRESO DE ENVÍOS (cola de recepción)
    // Se llenan los datos del remitente, del destinatario y del paquete.
    // Si todo es válido, Sistema lo guarda en SQL y lo pone al final de la COLA de recepción.
    // Desde aquí también se envía el primero de la cola (el frente) al almacén.
    public partial class Ingreso_de_envíos_Cola_de_Recepción : Form
    {
        // true cuando los datos del remitente / destinatario se cargaron desde la BD por su DNI
        private bool remitenteRegistrado = false;
        private bool destinatarioRegistrado = false;

        public Ingreso_de_envíos_Cola_de_Recepción()
        {
            InitializeComponent();

            lblUsuario.Text = Sistema.UsuarioNombres;
            lblSede.Text = Sistema.UsuarioSede;
            lblMonto.Text = "Pendiente de calcular";

            ConfigurarControles();
            ConfigurarValidaciones();
            ActualizarVista();
        }

        // =========================================================
        //  1. CONFIGURACIÓN INICIAL
        // =========================================================

        private void ConfigurarControles()
        {
            // Sedes: el ComboBox muestra el Nombre y guarda el objeto Sede completo
            cboOrigen.DisplayMember = "Nombre";
            cboDestino.DisplayMember = "Nombre";
            cboOrigen.Items.AddRange(Sistema.Sedes);
            cboDestino.Items.AddRange(Sistema.Sedes);

            // Tipo y pago: el ORDEN debe ser igual al del enum,
            // porque luego se convierte con (TipoPaquete)cboTipo.SelectedIndex
            cboTipo.Items.AddRange(new object[] { "Sobre", "Caja" });                              // enum TipoPaquete   { Sobre, Caja }
            cboPago.Items.AddRange(new object[] { "Pagado en origen", "Por cobrar en destino" });  // enum ModalidadPago { PagadoEnOrigen, PorCobrarEnDestino }

            // Ningún ComboBox deja escribir: solo elegir
            cboOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPago.DropDownStyle = ComboBoxStyle.DropDownList;

            // Grilla de solo lectura, sin la fila vacía (*) del final
            dgvRecepcion.AllowUserToAddRows = false;
            dgvRecepcion.ReadOnly = true;
            dgvRecepcion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Límites y filtros de teclado de cada campo (validación MIENTRAS se escribe)
        private void ConfigurarValidaciones()
        {
            txtDniRemitente.MaxLength = 8;
            txtDniDestinatario.MaxLength = 8;
            txtTel.MaxLength = 9;
            txtTelDestinatario.MaxLength = 9;
            txtRemitente.MaxLength = 100;
            txtDestinatario.MaxLength = 100;
            txtDetalle.MaxLength = 200;

            txtDniRemitente.KeyPress += SoloNumeros;
            txtDniDestinatario.KeyPress += SoloNumeros;
            txtTel.KeyPress += SoloNumeros;
            txtTelDestinatario.KeyPress += SoloNumeros;
            txtRemitente.KeyPress += SoloLetras;
            txtDestinatario.KeyPress += SoloLetras;
            txtPeso.KeyPress += SoloDecimal;

            // Al completar los 8 dígitos del DNI se buscan sus datos en la BD
            txtDniRemitente.TextChanged += (s, e) =>
                remitenteRegistrado = CargarPersonaPorDni(txtDniRemitente, txtRemitente, txtTel, remitenteRegistrado);

            txtDniDestinatario.TextChanged += (s, e) =>
                destinatarioRegistrado = CargarPersonaPorDni(txtDniDestinatario, txtDestinatario, txtTelDestinatario, destinatarioRegistrado);
        }

        // ---------- Filtros de teclado ----------

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;   // La tecla no se escribe
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
            bool esPuntoPermitido = e.KeyChar == '.' && !caja.Text.Contains(".");

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !esPuntoPermitido)
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

            // DNI incompleto o no registrado: si antes se cargó a otra persona, se borran sus datos
            if (estabaCargada)
            {
                txtNombre.Clear();
                txtTelefono.Clear();
            }
            txtNombre.ReadOnly = false;
            return false;
        }

        // =========================================================
        //  2. VALIDACIÓN ANTES DE REGISTRAR
        //  Devuelve "" si todo está bien; si no, el mensaje y en "campo"
        //  el control que hay que corregir.
        // =========================================================

        // ---------- Reglas de formato ----------

        private bool EsDniValido(string dni)
        {
            return dni.Length == 8 && dni.All(char.IsDigit);                           // 8 dígitos
        }

        private bool EsNombreValido(string nombre)
        {
            return nombre.Length >= 3 && nombre.All(c => char.IsLetter(c) || c == ' '); // Mínimo 3, solo letras
        }

        private bool EsTelefonoValido(string telefono)
        {
            return telefono.Length == 9 && telefono.All(char.IsDigit) && telefono[0] == '9';   // Celular peruano
        }

        // Revisa los datos de UNA persona. Se usa igual para el remitente y el destinatario.
        // quien = "remitente" o "destinatario" (solo para el mensaje)
        private string ValidarPersona(string quien, TextBox txtDni, TextBox txtNombre, TextBox txtTelefono, out Control campo)
        {
            string dni = txtDni.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            campo = txtDni;
            if (!EsDniValido(dni))
                return "El DNI del " + quien + " debe tener 8 dígitos.";

            campo = txtNombre;
            if (!EsNombreValido(txtNombre.Text.Trim()))
                return "Ingrese el nombre del " + quien + " (mínimo 3 letras, sin números).";

            campo = txtTelefono;
            if (!EsTelefonoValido(telefono))
                return "El teléfono del " + quien + " debe tener 9 dígitos y empezar con 9.";

            // El teléfono no puede ser de OTRA persona (consulta a la BD)
            string dueño = Sistema.TelefonoDeOtraPersona(telefono, dni);
            if (dueño != null)
                return "El teléfono " + telefono + " ya está registrado a nombre de " + dueño + ".";

            campo = null;
            return "";
        }

        private string ValidarFormulario(out Control campo)
        {
            // 1. Remitente y destinatario
            string error = ValidarPersona("remitente", txtDniRemitente, txtRemitente, txtTel, out campo);
            if (error != "") return error;

            error = ValidarPersona("destinatario", txtDniDestinatario, txtDestinatario, txtTelDestinatario, out campo);
            if (error != "") return error;

            // 2. Deben ser dos personas distintas
            campo = txtDniDestinatario;
            if (txtDniRemitente.Text.Trim() == txtDniDestinatario.Text.Trim())
                return "El remitente y el destinatario no pueden tener el mismo DNI.";

            campo = txtTelDestinatario;
            if (txtTel.Text.Trim() == txtTelDestinatario.Text.Trim())
                return "El remitente y el destinatario no pueden tener el mismo teléfono.";

            // 3. Paquete: el peso debe entrar al menos en el vehículo más grande
            campo = txtPeso;
            decimal peso;
            if (!decimal.TryParse(txtPeso.Text, out peso) || peso <= 0)
                return "Ingrese un peso válido mayor a 0. Ejemplo: 2.5";

            decimal capacidadMaxima = Sistema.Vehiculos.Length == 0 ? 0 : Sistema.Vehiculos.Max(v => v.CapacidadKg);
            if (capacidadMaxima > 0 && peso > capacidadMaxima)
                return "El peso supera la capacidad del vehículo más grande (" + capacidadMaxima.ToString("0") + " kg).";

            campo = txtDetalle;
            if (txtDetalle.Text.Trim() == "") return "Ingrese el detalle del contenido.";

            campo = cboTipo;
            if (cboTipo.SelectedIndex == -1) return "Seleccione el tipo de paquete.";

            // 4. Sedes y pago
            campo = cboOrigen;
            if (cboOrigen.SelectedIndex == -1) return "Seleccione la sede de origen.";

            campo = cboDestino;
            if (cboDestino.SelectedIndex == -1) return "Seleccione la sede de destino.";
            if (cboOrigen.SelectedItem == cboDestino.SelectedItem) return "La sede de origen y la de destino no pueden ser la misma.";

            campo = cboPago;
            if (cboPago.SelectedIndex == -1) return "Seleccione el método de pago.";

            campo = null;
            return "";
        }

        // =========================================================
        //  3. REGISTRAR EN COLA
        // =========================================================

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            // 1. Validar (algunas reglas consultan la BD, por eso el try)
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

            // 2. Armar el envío con los datos ya validados
            Envio envio = new Envio();
            envio.SedeOrigen = cboOrigen.SelectedItem as Sede;
            envio.SedeDestino = cboDestino.SelectedItem as Sede;
            envio.PesoKg = decimal.Parse(txtPeso.Text);
            envio.Descripcion = txtDetalle.Text.Trim();
            envio.Tipo = (TipoPaquete)cboTipo.SelectedIndex;
            envio.ModalidadPago = (ModalidadPago)cboPago.SelectedIndex;
            envio.Remitente = CrearPersona(txtDniRemitente, txtRemitente, txtTel);
            envio.Destinatario = CrearPersona(txtDniDestinatario, txtDestinatario, txtTelDestinatario);

            // 3. Tarifa y precio, y guardar: SQL asigna el Id → guía → historial → cola y árbol
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

            // 4. Mostrar el resultado y dejar el formulario listo para otro envío
            txtGuia.Text = envio.Codigo;
            lblMonto.Text = "S/ " + envio.Precio.ToString("0.00");
            MessageBox.Show("Guía: " + envio.Codigo +
                            "\nClave de recojo: " + envio.ClaveSeguridad +
                            "\nPrecio: S/ " + envio.Precio.ToString("0.00"),
                            "Envío registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            ActualizarVista();
        }

        // Arma una Persona con lo escrito en sus tres cajas (se usa para remitente y destinatario)
        private Persona CrearPersona(TextBox txtDni, TextBox txtNombre, TextBox txtTelefono)
        {
            Persona persona = new Persona();
            persona.TipoDocumento = "DNI";
            persona.NumeroDocumento = txtDni.Text.Trim();
            persona.Nombres = txtNombre.Text.Trim();
            persona.Telefono = txtTelefono.Text.Trim();
            return persona;
        }

        // =========================================================
        //  4. COLA DE RECEPCIÓN
        // =========================================================

        // Muestra el primero de la cola sin sacarlo (PEEK)
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

        // Saca el frente de la cola de recepción y lo pone al final de la cola del almacén
        private void btnEnvAlm_Click(object sender, EventArgs e)
        {
            Envio frente = Sistema.Recepcion.VerFrente();   // Se guarda para el mensaje final

            try
            {
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
        }

        // Abre Almacén ENCIMA de este formulario (ShowDialog): al cerrarlo se vuelve aquí
        // sin perder lo que se estaba llenando, y se refresca la cola.
        private void btnIrAlmacen_Click(object sender, EventArgs e)
        {
            using (Almacén almacen = new Almacén())
                almacen.ShowDialog(this);

            ActualizarVista();
        }

        // Grilla, cantidad en cola y guía del frente
        private void ActualizarVista()
        {
            Sistema.Recepcion.Mostrar(dgvRecepcion);
            lblContar.Text = Sistema.Recepcion.Cantidad.ToString();

            Envio frente = Sistema.Recepcion.VerFrente();
            lblMostrar.Text = frente == null ? "-----" : frente.Codigo;
        }

        // Deja el formulario en blanco para el siguiente envío
        private void LimpiarCampos()
        {
            // Al vaciar los DNI se desbloquean los nombres (ver CargarPersonaPorDni)
            txtDniRemitente.Clear();
            txtDniDestinatario.Clear();
            txtRemitente.Clear();
            txtTel.Clear();
            txtDestinatario.Clear();
            txtTelDestinatario.Clear();

            txtPeso.Clear();
            txtDetalle.Clear();
            cboOrigen.SelectedIndex = -1;
            cboDestino.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            cboPago.SelectedIndex = -1;

            txtDniRemitente.Focus();   // Se empieza por el DNI
        }

        // =========================================================
        //  5. DESARROLLADOR DEL FORMULARIO
        // =========================================================

        private void lnkDesarrollador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TarjetaColaborador.Abrir("N00525394", this);   // Sergio Colán
        }
    }
}