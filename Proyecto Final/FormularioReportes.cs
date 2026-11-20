using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shalom
{
    public partial class FormularioReportes : Form
    {
        private FiltroReporte filtroActual;
        private List<Envio> resultadoActual;

        public FormularioReportes()
        {
            InitializeComponent();
            ConfigurarControles();

            cboPeriodo.SelectedIndexChanged += FiltroCambiado;
            dtpFecha.ValueChanged += FiltroCambiado;
            cboSeccion.SelectedIndexChanged += FiltroCambiado;
            cboOrigen.SelectedIndexChanged += FiltroCambiado;
            cboDestino.SelectedIndexChanged += FiltroCambiado;
        }

        // =========================================================
        //  CONFIGURACIÓN INICIAL
        // =========================================================
        private void ConfigurarControles()
        {
            // Periodo: el ORDEN debe ser igual al del enum
            // TipoPeriodo { Todo, Dia, Mes, Trimestre, Anio }
            cboPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriodo.Items.AddRange(new object[] { "Todo", "Día", "Mes", "Trimestre", "Año" });
            cboPeriodo.SelectedIndex = 2;   // Mes por defecto

            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Value = DateTime.Today;

            // Sección: "Todas" + una por cada estado, en el mismo orden del enum
            cboSeccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeccion.Items.Add("Todas");
            foreach (EstadoEnvio estado in Enum.GetValues(typeof(EstadoEnvio)))
                cboSeccion.Items.Add(Reportes.NombreSeccion(estado));
            cboSeccion.SelectedIndex = 0;

            // Sedes: "Todas" + las que se cargaron desde SQL
            cboOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrigen.Items.Add("Todas");
            cboDestino.Items.Add("Todas");
            foreach (Sede sede in Sistema.Sedes)
            {
                cboOrigen.Items.Add(sede.Nombre);
                cboDestino.Items.Add(sede.Nombre);
            }
            cboOrigen.SelectedIndex = 0;
            cboDestino.SelectedIndex = 0;

            // Tabla de vista previa
            dgvVistaPrevia.AllowUserToAddRows = false;
            dgvVistaPrevia.ReadOnly = true;
            dgvVistaPrevia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVistaPrevia.RowHeadersVisible = false;   // Quita la columna gris de la izquierda (más espacio)
            dgvVistaPrevia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cada columna recibe una parte del ancho (peso) y nunca baja de su mínimo,
            // así la guía y el estado siempre se leen completos.
            AgregarColumna("Guía", 26, 130, false);
            AgregarColumna("Registro", 16, 85, false);
            AgregarColumna("Ruta", 14, 80, false);
            AgregarColumna("Estado actual", 20, 115, false);
            AgregarColumna("Peso (kg)", 12, 75, true);
            AgregarColumna("Precio (S/)", 12, 80, true);

            HabilitarExportar(false);
            ActualizarRango();
        }

        // =========================================================
        //  LEER LO QUE ELIGIÓ EL USUARIO
        // =========================================================
        private FiltroReporte LeerFiltros()
        {
            FiltroReporte f = new FiltroReporte();

            f.Periodo = (TipoPeriodo)cboPeriodo.SelectedIndex;
            f.Fecha = dtpFecha.Value;

            // Posición 0 = "Todas"; las demás corren una posición respecto al enum
            if (cboSeccion.SelectedIndex == 0)
                f.Seccion = null;
            else
                f.Seccion = (EstadoEnvio)(cboSeccion.SelectedIndex - 1);

            f.SedeOrigen = SedeElegida(cboOrigen);
            f.SedeDestino = SedeElegida(cboDestino);

            return f;
        }

        // Muestra el rango de fechas exacto que se va a usar.
        private void ActualizarRango()
        {
            FiltroReporte f = LeerFiltros();
            dtpFecha.Enabled = f.Periodo != TipoPeriodo.Todo;
            lblRango.Text = Reportes.DescripcionPeriodo(f);
        }

        // Si cambian los filtros, la vista previa ya no corresponde:
        // se bloquea la exportación hasta volver a generar.
        private void FiltroCambiado(object sender, EventArgs e)
        {
            ActualizarRango();
            HabilitarExportar(false);
        }

        // =========================================================
        //  BOTONES
        // =========================================================
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            filtroActual = LeerFiltros();
            resultadoActual = Reportes.Filtrar(filtroActual);

            dgvVistaPrevia.Rows.Clear();
            foreach (Envio envio in resultadoActual)
            {
                dgvVistaPrevia.Rows.Add(
                    envio.Codigo,
                    envio.FechaRegistro.ToString("dd/MM/yyyy"),
                    Reportes.CodigoSede(envio.SedeOrigen) + " > " + Reportes.CodigoSede(envio.SedeDestino),
                    ArbolEnvios.NombreEstadoLegible(envio.Estado),
                    envio.PesoKg.ToString("0.00"),
                    envio.Precio.ToString("0.00"));
            }

            lblTotal.Text = "Envíos encontrados: " + resultadoActual.Count;
            HabilitarExportar(resultadoActual.Count > 0);
        }

        private void btnExportarTxt_Click(object sender, EventArgs e)
        {
            Reportes.GuardarConDialogo("Reporte_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt",
                Reportes.ReporteFiltrado(filtroActual, resultadoActual));
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            Reportes.GuardarConDialogo("Envios_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv",
                Reportes.ReporteCsv(resultadoActual));
        }

        private void HabilitarExportar(bool habilitar)
        {
            btnExportarTxt.Enabled = habilitar;
            btnExportarCSV.Enabled = habilitar;
        }

        private Sede SedeElegida(ComboBox combo)
        {
            if (combo.SelectedIndex == 0) return null;   // "Todas"
            return Sistema.Sedes[combo.SelectedIndex - 1];
        }

        // Crea una columna de la vista previa.
        //   peso:    parte del ancho que le toca (las columnas se reparten el espacio)
        //   minimo:  ancho mínimo en píxeles, para que el texto no se corte
        //   derecha: true para números (peso y precio se alinean a la derecha)
        private void AgregarColumna(string titulo, int peso, int minimo, bool derecha)
        {
            int indice = dgvVistaPrevia.Columns.Add(titulo, titulo);
            DataGridViewColumn columna = dgvVistaPrevia.Columns[indice];

            columna.FillWeight = peso;
            columna.MinimumWidth = minimo;

            if (derecha)
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}