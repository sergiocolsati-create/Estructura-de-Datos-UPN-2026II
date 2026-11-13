using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shalom
{
    public partial class FormularioReportes : Form
    {
        // Lo último que se generó. Al exportar se usa esto,
        // así el archivo siempre coincide con la vista previa.
        private FiltroReporte filtroActual;
        private List<Envio> resultadoActual;

        public FormularioReportes()
        {
            InitializeComponent();
            ConfigurarControles();

            // Los eventos se conectan DESPUÉS de llenar los combos.
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
            dgvVistaPrevia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVistaPrevia.Columns.Add("colGuia", "Guía");
            dgvVistaPrevia.Columns.Add("colRegistro", "Registro");
            dgvVistaPrevia.Columns.Add("colRuta", "Ruta");
            dgvVistaPrevia.Columns.Add("colEstado", "Estado actual");
            dgvVistaPrevia.Columns.Add("colPeso", "Peso (kg)");
            dgvVistaPrevia.Columns.Add("colPrecio", "Precio (S/)");

            btnExportarTxt.Enabled = false;   // Se activa al generar
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

            if (cboOrigen.SelectedIndex == 0)
                f.SedeOrigen = null;
            else
                f.SedeOrigen = Sistema.Sedes[cboOrigen.SelectedIndex - 1];

            if (cboDestino.SelectedIndex == 0)
                f.SedeDestino = null;
            else
                f.SedeDestino = Sistema.Sedes[cboDestino.SelectedIndex - 1];

            return f;
        }

        // Muestra el rango de fechas exacto que se va a usar.
        private void ActualizarRango()
        {
            FiltroReporte f = LeerFiltros();
            dtpFecha.Enabled = f.Periodo != TipoPeriodo.Todo;   // "Todo" no necesita fecha
            lblRango.Text = Reportes.DescripcionPeriodo(f);
        }

        // Si cambian los filtros, la vista previa ya no corresponde:
        // se bloquea la exportación hasta volver a generar.
        private void FiltroCambiado(object sender, EventArgs e)
        {
            ActualizarRango();
            btnExportarTxt.Enabled = false;
            lblTotal.Text = "Filtros cambiados: presione \"Generar vista previa\".";
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
            btnExportarTxt.Enabled = resultadoActual.Count > 0;
        }

        private void btnExportarTxt_Click(object sender, EventArgs e)
        {
            if (resultadoActual == null)
                return;

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Guardar reporte";
                dialogo.Filter = "Archivo de texto (*.txt)|*.txt";
                dialogo.FileName = "Reporte_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    string contenido = Reportes.ReporteFiltrado(filtroActual, resultadoActual);
                    Reportes.GuardarTxt(dialogo.FileName, contenido);

                    MessageBox.Show("Reporte guardado en:\n" + dialogo.FileName,
                        "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el reporte:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}