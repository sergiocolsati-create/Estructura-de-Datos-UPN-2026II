using System;
using System.Linq;
using System.Windows.Forms;

namespace Shalom
{
    // RASTREO DE ENVÍOS
    //   Buscar:   por guía (en el árbol) o por estado
    //   Detalle:  al hacer clic en un envío se ve su resumen y su historial (lista simple)
    //   Estado:   desde aquí solo se puede ENTREGAR o registrar una INCIDENCIA
    //   Reporte:  del envío seleccionado (.txt). Los reportes de muchos envíos están en Reportes.
    public partial class RastreoDeEnvíos : Form
    {
        private Envio envioSeleccionado;   // Envío elegido en la tabla
        private string guiaInicial = "";   // Guía que llega desde el panel principal

        public RastreoDeEnvíos()
        {
            InitializeComponent();

            lblUsuario.Text = Sistema.UsuarioNombres;
            lblSede.Text = Sistema.UsuarioSede;

            ConfigurarControles();
        }

        // Desde el rastreo rápido del panel: se abre buscando esa guía
        public RastreoDeEnvíos(string codigo) : this()
        {
            guiaInicial = codigo;
        }

        private void RastreoDeEnvíos_Load(object sender, EventArgs e)
        {
            txtGuia.Text = guiaInicial;
            Buscar();
        }

        // =========================================================
        //  1. CONFIGURACIÓN INICIAL
        // =========================================================

        private void ConfigurarControles()
        {
            // Estado: "Todos" + cada estado del enum (se muestran con nombre legible)
            cboEstado.Items.Add("Todos");
            foreach (EstadoEnvio estado in Enum.GetValues(typeof(EstadoEnvio)))
                cboEstado.Items.Add(estado);
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Format += ComboEstado_Format;
            cboEstado.SelectedIndex = 0;

            // Nuevo estado: solo ENTREGADO o INCIDENCIA. Los demás estados los cambian
            // sus propios formularios (cola, almacén, pila, ruta), así el paquete nunca
            // queda en una estructura que no corresponde a su estado.
            cboNuevoEstado.Items.Add(EstadoEnvio.Entregado);
            cboNuevoEstado.Items.Add(EstadoEnvio.Incidencia);
            cboNuevoEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNuevoEstado.Format += ComboEstado_Format;

            // Tablas de solo lectura
            dgvLista.AllowUserToAddRows = false;
            dgvLista.ReadOnly = true;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.ReadOnly = true;

            txtDetGuia.ReadOnly = true;
            txtDetCliente.ReadOnly = true;
            txtDetDestino.ReadOnly = true;
            txtDetVehiculo.ReadOnly = true;

            ConfigurarSugerenciasGuia();
        }

        // Muestra "En tránsito" en lugar de "EnTransito" en los ComboBox de estado
        private void ComboEstado_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is EstadoEnvio estado)
                e.Value = ArbolEnvios.NombreEstadoLegible(estado);
        }

        // Al escribir la guía, sugiere las 5 más recientes
        private void ConfigurarSugerenciasGuia()
        {
            AutoCompleteStringCollection sugerencias = new AutoCompleteStringCollection();
            foreach (Envio envio in Sistema.Registro.ObtenerTodos().OrderByDescending(x => x.Id).Take(5))
                sugerencias.Add(envio.Codigo);

            txtGuia.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtGuia.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtGuia.AutoCompleteCustomSource = sugerencias;
        }

        // =========================================================
        //  2. BUSCAR
        // =========================================================

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtGuia.Text = "";
            cboEstado.SelectedIndex = 0;
            Buscar();
        }

        // Con guía: la busca en el ÁRBOL y muestra su detalle.
        // Sin guía: muestra todos los envíos del estado elegido ("Todos" = sin filtro).
        private void Buscar()
        {
            LimpiarDetalle();

            string guia = txtGuia.Text.Trim().ToUpperInvariant();
            if (guia != "")
            {
                dgvLista.Rows.Clear();
                Envio envio = Sistema.Registro.Buscar(guia);
                if (envio == null)
                {
                    MessageBox.Show("No existe un envío con la guía " + guia + ".", "Buscar");
                    return;
                }

                ArbolEnvios.AgregarFila(dgvLista, envio);
                MostrarDetalle(envio);
                return;
            }

            EstadoEnvio? estado = cboEstado.SelectedItem is EstadoEnvio elegido ? elegido : (EstadoEnvio?)null;
            Sistema.Registro.Mostrar(dgvLista, estado);
        }

        // =========================================================
        //  3. DETALLE DEL ENVÍO
        // =========================================================

        // Clic en cualquier parte de una fila: muestra su detalle e historial
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // Clic en el encabezado

            string codigo = dgvLista.Rows[e.RowIndex].Cells[0].Value.ToString();
            Envio envio = Sistema.Registro.Buscar(codigo);
            if (envio != null)
                MostrarDetalle(envio);
        }

        private void MostrarDetalle(Envio envio)
        {
            envioSeleccionado = envio;

            txtDetGuia.Text = envio.Codigo;
            txtDetCliente.Text = ArbolEnvios.NombreCliente(envio);
            txtDetDestino.Text = ArbolEnvios.NombreDestino(envio);
            txtDetVehiculo.Text = envio.PlacaVehiculo ?? "(sin asignar)";

            envio.Historial.Mostrar(dgvHistorial);   // Lista simple de eventos
            MostrarResumen(envio);
        }

        private void LimpiarDetalle()
        {
            envioSeleccionado = null;
            txtDetGuia.Text = "";
            txtDetCliente.Text = "";
            txtDetDestino.Text = "";
            txtDetVehiculo.Text = "";
            dgvHistorial.Rows.Clear();
            lstResumen.Items.Clear();
        }

        // Todo lo que se sabe del envío, una línea por ítem, y al final su recorrido
        private void MostrarResumen(Envio envio)
        {
            lstResumen.Items.Clear();

            lstResumen.Items.Add("Origen: " + Reportes.NombreSede(envio.SedeOrigen));
            lstResumen.Items.Add("Destino: " + Reportes.NombreSede(envio.SedeDestino));
            lstResumen.Items.Add("Remitente: " + Reportes.DatosPersona(envio.Remitente));
            lstResumen.Items.Add("Destinatario: " + Reportes.DatosPersona(envio.Destinatario));
            lstResumen.Items.Add("Paquete: " + envio.Tipo + ", " + envio.PesoKg + " kg / " + envio.Descripcion);
            lstResumen.Items.Add("Pago: " + Reportes.NombrePago(envio.ModalidadPago) + " / S/ " + envio.Precio.ToString("0.00"));
            lstResumen.Items.Add("Vehículo: " + (envio.PlacaVehiculo ?? "-"));
            lstResumen.Items.Add("Clave de entrega: " + envio.ClaveSeguridad);
            lstResumen.Items.Add("");
            lstResumen.Items.Add("Recorrido:");

            // ObtenerTexto() devuelve una línea por evento; cada una pasa a ser un ítem
            string[] eventos = envio.Historial.ObtenerTexto()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            lstResumen.Items.AddRange(eventos);
        }

        // =========================================================
        //  4. ACTUALIZAR ESTADO (Entregado o Incidencia, se guarda en SQL)
        // =========================================================

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            if (envioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione un envío de la lista.");
                return;
            }
            if (cboNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nuevo estado.");
                return;
            }

            Envio envio = envioSeleccionado;   // Se guarda: Buscar() limpia la selección
            EstadoEnvio nuevoEstado = (EstadoEnvio)cboNuevoEstado.SelectedItem;
            string observacion = txtObservacion.Text.Trim();

            try
            {
                string error = nuevoEstado == EstadoEnvio.Entregado
                    ? Sistema.MarcarEntregado(envio, observacion)
                    : Sistema.RegistrarIncidencia(envio, observacion);

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

            // Se refresca la tabla con la misma búsqueda y se vuelve a mostrar el envío
            Buscar();
            MostrarDetalle(envio);
            txtObservacion.Text = "";

            MessageBox.Show(nuevoEstado == EstadoEnvio.Entregado
                ? "Envío " + envio.Codigo + " entregado."
                : "Incidencia registrada en " + envio.Codigo + ".", "Actualizar estado");
        }

        // =========================================================
        //  5. REPORTE DEL ENVÍO SELECCIONADO
        // =========================================================

        private void btnReporteEnvio_Click(object sender, EventArgs e)
        {
            if (envioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un envío de la lista.");
                return;
            }
            Reportes.GuardarConDialogo("Reporte_" + envioSeleccionado.Codigo + ".txt",
                Reportes.ReporteEnvio(envioSeleccionado));
        }

        // Abre Reportes ENCIMA de Rastreo (filtros por periodo, sección y sedes).
        // Al cerrarlo se vuelve aquí.
        private void btnIrReportes_Click(object sender, EventArgs e)
        {
            using (FormularioReportes reportes = new FormularioReportes())
                reportes.ShowDialog(this);
        }

        // =========================================================
        //  6. DESARROLLADORA DEL FORMULARIO
        // =========================================================

        private void lnkDesarrollador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TarjetaColaborador.Abrir("N00469214", this);   // Yanela Acori
        }
    }
}