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
    public partial class RastreoDeEnvíos : Form
    {
        private Envio envioSeleccionado;
        private string guiaInicial = "";

        public RastreoDeEnvíos()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button4.Click += button4_Click;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            // El Designer ya conecta CellContentClick; usamos solo CellClick.
            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;

            // CellClick responde al clic en cualquier parte de la fila (CellContentClick solo sobre el texto)
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        public RastreoDeEnvíos(string codigo) : this()
        {
            guiaInicial = codigo;
        }

        private void RastreoDeEnvíos_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Todos");
            comboBox1.Items.Add(EstadoEnvio.Registrado);
            comboBox1.Items.Add(EstadoEnvio.EnPreparacion);
            comboBox1.Items.Add(EstadoEnvio.EnTransito);
            comboBox1.Items.Add(EstadoEnvio.EnReparto);
            comboBox1.Items.Add(EstadoEnvio.Entregado);
            comboBox1.Items.Add(EstadoEnvio.Incidencia);


            // Desde Rastreo solo se puede ENTREGAR o registrar una INCIDENCIA.
            // Los demás estados los cambian sus formularios (cola, almacén, pila, ruta),
            // así el paquete nunca queda en una estructura que no corresponde a su estado.
            comboBox3.Items.Add(EstadoEnvio.Entregado);
            comboBox3.Items.Add(EstadoEnvio.Incidencia);
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            ConfigurarSugerenciasGuia();

            comboBox1.FormattingEnabled = true;
            comboBox1.Format += ComboEstado_Format;
            comboBox3.FormattingEnabled = true;
            comboBox3.Format += ComboEstado_Format;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;

            MostrarTodos();
            if (!string.IsNullOrWhiteSpace(guiaInicial))
            {
                textBox1.Text = guiaInicial;
                button1_Click(this, EventArgs.Empty);
            }
        }

        private void ComboEstado_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is EstadoEnvio estado)
                e.Value = ArbolEnvios.NombreEstadoLegible(estado);
            else
                e.Value = e.ListItem.ToString(); // "Todos" se queda igual
        }

        private void ConfigurarSugerenciasGuia()
        {
            List<Envio> todos = Sistema.Registro.ObtenerTodos();
            todos.Sort((a, b) => b.Id.CompareTo(a.Id));

            AutoCompleteStringCollection sugerencias = new AutoCompleteStringCollection();
            int max = Math.Min(todos.Count, 5);
            for (int i = 0; i < max; i++)
                sugerencias.Add(todos[i].Codigo);

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = sugerencias;
        }

        // Si hay texto en "N° de guía", busca ese envío exacto (árbol).
        // Si no, aplica el filtro de Estado a la lista completa.
        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text.Trim().ToUpperInvariant();

            LimpiarDetalle();
            dataGridView1.Rows.Clear();

            if (codigo != "")
            {
                Envio envio = Sistema.Registro.Buscar(codigo);
                if (envio == null)
                {
                    MessageBox.Show("No existe un envío con ese código.");
                    return;
                }

                dataGridView1.Rows.Clear();
                ArbolEnvios.AgregarFila(dataGridView1, envio);

                MostrarDetalle(envio);
                return;
            }

            if (comboBox1.SelectedIndex <= 0)
            {
                Sistema.Registro.Mostrar(dataGridView1, null);   // "Todos"
            }
            else
            {
                EstadoEnvio filtro = (EstadoEnvio)comboBox1.SelectedItem;
                Sistema.Registro.Mostrar(dataGridView1, filtro);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            LimpiarDetalle();
            MostrarTodos();
        }

        // Al hacer clic en una fila de la tabla, muestra el detalle y el historial de ese envío.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string codigo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Envio envio = Sistema.Registro.Buscar(codigo);
            if (envio == null) return;

            MostrarDetalle(envio);
        }

        // ---------- Actualizar estado: Entregado o Incidencia (se guarda en SQL) ----------
        private void button4_Click(object sender, EventArgs e)
        {
            if (envioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione un envío de la lista.");
                return;
            }

            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nuevo estado.");
                return;
            }

            EstadoEnvio nuevoEstado = (EstadoEnvio)comboBox3.SelectedItem;
            string observacion = textBox6.Text.Trim();

            try
            {
                string error = nuevoEstado == EstadoEnvio.Entregado
                    ? Sistema.MarcarEntregado(envioSeleccionado, observacion)
                    : Sistema.RegistrarIncidencia(envioSeleccionado, observacion);

                if (error != "")
                {
                    MessageBox.Show(error, "Actualizar estado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cambio en la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MostrarDetalle(envioSeleccionado);
            MostrarTodos();
            textBox6.Text = "";
            MessageBox.Show(nuevoEstado == EstadoEnvio.Entregado
                ? "Envío " + envioSeleccionado.Codigo + " entregado."
                : "Incidencia registrada en " + envioSeleccionado.Codigo + ".", "Actualizar estado");
        }

        private void MostrarTodos()
        {
            Sistema.Registro.Mostrar(dataGridView1, null);
        }

        private void MostrarDetalle(Envio envio)
        {
            envioSeleccionado = envio;

            string cliente = ArbolEnvios.NombreCliente(envio);
            string destino = ArbolEnvios.NombreDestino(envio);

            string placa = "(sin asignar)";
            if (envio.PlacaVehiculo != null) placa = envio.PlacaVehiculo;

            textBox2.Text = envio.Codigo;
            textBox3.Text = cliente;
            textBox4.Text = destino;
            textBox5.Text = placa;

            envio.Historial.Mostrar(dataGridView2);
            MostrarResumen(envio);          // ← Llena el ListBox con todo el recorrido
        }

        private void LimpiarDetalle()
        {
            envioSeleccionado = null;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dataGridView2.Rows.Clear();
            MostrarResumen(null);           // ← Vacía el ListBox
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Todo lo que ha pasado con el envío, una línea por ítem
        private void MostrarResumen(Envio envio)
        {
            lstResumen.Items.Clear();
            if (envio == null) return;

            string origen = envio.SedeOrigen != null ? envio.SedeOrigen.Nombre : "(sin origen)";
            string destino = envio.SedeDestino != null ? envio.SedeDestino.Nombre : "(sin destino)";
            string remitente = envio.Remitente != null
                ? envio.Remitente.Nombres + " / " + envio.Remitente.NumeroDocumento
                : "(sin remitente)";
            string destinatario = envio.Destinatario != null
                ? envio.Destinatario.Nombres + " / " + envio.Destinatario.NumeroDocumento
                : "(sin destinatario)";

            lstResumen.Items.Add("Origen: " + origen);
            lstResumen.Items.Add("Destino: " + destino);
            lstResumen.Items.Add("Remitente: " + remitente);
            lstResumen.Items.Add("Destinatario: " + destinatario);
            lstResumen.Items.Add("Paquete: " + envio.Tipo + ", " + envio.PesoKg + " kg / " + envio.Descripcion);
            lstResumen.Items.Add("Pago: " + NombrePago(envio.ModalidadPago) + " / S/ " + envio.Precio.ToString("0.00"));
            lstResumen.Items.Add("Vehículo: " + (envio.PlacaVehiculo ?? "-"));
            lstResumen.Items.Add("Clave de entrega: " + envio.ClaveSeguridad);
            lstResumen.Items.Add("");
            lstResumen.Items.Add("Recorrido:");

            // ObtenerTexto() devuelve una línea por evento; se separan para agregarlas como ítems
            string[] eventos = envio.Historial.ObtenerTexto()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            lstResumen.Items.AddRange(eventos);
        }

        private string NombrePago(ModalidadPago pago)
        {
            switch (pago)
            {
                case ModalidadPago.PagadoEnOrigen: return "Pagado en origen";
                case ModalidadPago.PorCobrarEnDestino: return "Por cobrar en destino";
                default: return pago.ToString();
            }
        }

        private void lstResumen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}