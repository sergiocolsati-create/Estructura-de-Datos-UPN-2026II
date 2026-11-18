namespace Shalom
{
    partial class RastreoDeEnvíos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnIrReportes = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSede = new System.Windows.Forms.Label();
            this.lnkDesarrollador = new System.Windows.Forms.LinkLabel();
            this.lblIconoUsuario = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGuia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpEnvios = new System.Windows.Forms.GroupBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.btnReporteEnvio = new System.Windows.Forms.Button();
            this.lstResumen = new System.Windows.Forms.ListBox();
            this.txtDetVehiculo = new System.Windows.Forms.TextBox();
            this.txtDetDestino = new System.Windows.Forms.TextBox();
            this.txtDetCliente = new System.Windows.Forms.TextBox();
            this.txtDetGuia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpHistorial = new System.Windows.Forms.GroupBox();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpActualizar = new System.Windows.Forms.GroupBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.cboNuevoEstado = new System.Windows.Forms.ComboBox();
            this.btnActualizarEstado = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grpFiltros.SuspendLayout();
            this.grpEnvios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.grpDetalle.SuspendLayout();
            this.grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.grpActualizar.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFiltros
            // 
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.btnIrReportes);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.cboEstado);
            this.grpFiltros.Controls.Add(this.label2);
            this.grpFiltros.Controls.Add(this.txtGuia);
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(9, 64);
            this.grpFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFiltros.Size = new System.Drawing.Size(1080, 53);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Buscar envío";
            // 
            // lblUsuario  (usuario conectado)
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(740, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(300, 19);
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSede  (sede del usuario conectado)
            // 
            this.lblSede.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSede.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(218)))));
            this.lblSede.Location = new System.Drawing.Point(740, 22);
            this.lblSede.Name = "lblSede";
            this.lblSede.Size = new System.Drawing.Size(300, 16);
            this.lblSede.Text = "Sede";
            this.lblSede.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkDesarrollador
            // 
            this.lnkDesarrollador.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkDesarrollador.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lnkDesarrollador.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDesarrollador.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(218)))));
            this.lnkDesarrollador.Location = new System.Drawing.Point(740, 38);
            this.lnkDesarrollador.Name = "lnkDesarrollador";
            this.lnkDesarrollador.Size = new System.Drawing.Size(300, 16);
            this.lnkDesarrollador.TabStop = true;
            this.lnkDesarrollador.Text = "Formulario de: Yanela Acori";
            this.lnkDesarrollador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkDesarrollador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDesarrollador_LinkClicked);
            // 
            // lblIconoUsuario
            // 
            this.lblIconoUsuario.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIconoUsuario.ForeColor = System.Drawing.Color.White;
            this.lblIconoUsuario.Location = new System.Drawing.Point(1046, 6);
            this.lblIconoUsuario.Name = "lblIconoUsuario";
            this.lblIconoUsuario.Size = new System.Drawing.Size(46, 46);
            this.lblIconoUsuario.Text = "👤";
            this.lblIconoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIrReportes  (abre Reportes encima; al cerrarlo se vuelve aquí)
            // 
            this.btnIrReportes.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnIrReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIrReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrReportes.ForeColor = System.Drawing.Color.White;
            this.btnIrReportes.Location = new System.Drawing.Point(900, 18);
            this.btnIrReportes.Name = "btnIrReportes";
            this.btnIrReportes.Size = new System.Drawing.Size(170, 25);
            this.btnIrReportes.Text = "Reportes detallados →";
            this.btnIrReportes.UseVisualStyleBackColor = false;
            this.btnIrReportes.Click += new System.EventHandler(this.btnIrReportes_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(516, 18);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 26);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscar.Location = new System.Drawing.Point(420, 18);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 26);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(275, 21);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(130, 21);
            this.cboEstado.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estado:";
            // 
            // txtGuia
            // 
            this.txtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuia.Location = new System.Drawing.Point(80, 22);
            this.txtGuia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGuia.Name = "txtGuia";
            this.txtGuia.Size = new System.Drawing.Size(130, 19);
            this.txtGuia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° de guía:";
            // 
            // grpEnvios
            // 
            this.grpEnvios.BackColor = System.Drawing.Color.White;
            this.grpEnvios.Controls.Add(this.dgvLista);
            this.grpEnvios.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEnvios.Location = new System.Drawing.Point(9, 123);
            this.grpEnvios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpEnvios.Name = "grpEnvios";
            this.grpEnvios.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpEnvios.Size = new System.Drawing.Size(1080, 202);
            this.grpEnvios.TabIndex = 5;
            this.grpEnvios.TabStop = false;
            this.grpEnvios.Text = "Envíos";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToResizeColumns = false;
            this.dgvLista.AllowUserToResizeRows = false;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvLista.EnableHeadersVisualStyles = false;
            this.dgvLista.Location = new System.Drawing.Point(10, 20);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowHeadersWidth = 30;
            this.dgvLista.RowTemplate.Height = 24;
            this.dgvLista.Size = new System.Drawing.Size(1060, 172);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Guía";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cliente";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Destino";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Estado";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Actualización";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // grpDetalle
            // 
            this.grpDetalle.BackColor = System.Drawing.Color.White;
            this.grpDetalle.Controls.Add(this.btnReporteEnvio);
            this.grpDetalle.Controls.Add(this.lstResumen);
            this.grpDetalle.Controls.Add(this.txtDetVehiculo);
            this.grpDetalle.Controls.Add(this.txtDetDestino);
            this.grpDetalle.Controls.Add(this.txtDetCliente);
            this.grpDetalle.Controls.Add(this.txtDetGuia);
            this.grpDetalle.Controls.Add(this.label6);
            this.grpDetalle.Controls.Add(this.label5);
            this.grpDetalle.Controls.Add(this.label4);
            this.grpDetalle.Controls.Add(this.label3);
            this.grpDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetalle.Location = new System.Drawing.Point(9, 331);
            this.grpDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDetalle.Size = new System.Drawing.Size(530, 319);
            this.grpDetalle.TabIndex = 6;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Detalle del envío";
            // 
            // btnReporteEnvio
            // 
            this.btnReporteEnvio.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnReporteEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEnvio.ForeColor = System.Drawing.Color.White;
            this.btnReporteEnvio.Location = new System.Drawing.Point(198, 272);
            this.btnReporteEnvio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReporteEnvio.Name = "btnReporteEnvio";
            this.btnReporteEnvio.Size = new System.Drawing.Size(133, 34);
            this.btnReporteEnvio.TabIndex = 1;
            this.btnReporteEnvio.Text = "Exportar reporte (.txt)";
            this.btnReporteEnvio.UseVisualStyleBackColor = false;
            this.btnReporteEnvio.Click += new System.EventHandler(this.btnReporteEnvio_Click);
            // 
            // lstResumen
            // 
            this.lstResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResumen.FormattingEnabled = true;
            this.lstResumen.Location = new System.Drawing.Point(14, 120);
            this.lstResumen.Name = "lstResumen";
            this.lstResumen.Size = new System.Drawing.Size(500, 147);
            this.lstResumen.TabIndex = 9;
            // 
            // txtDetVehiculo
            // 
            this.txtDetVehiculo.BackColor = System.Drawing.Color.White;
            this.txtDetVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetVehiculo.Location = new System.Drawing.Point(102, 89);
            this.txtDetVehiculo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDetVehiculo.Name = "txtDetVehiculo";
            this.txtDetVehiculo.Size = new System.Drawing.Size(410, 19);
            this.txtDetVehiculo.TabIndex = 8;
            // 
            // txtDetDestino
            // 
            this.txtDetDestino.BackColor = System.Drawing.Color.White;
            this.txtDetDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetDestino.Location = new System.Drawing.Point(102, 65);
            this.txtDetDestino.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDetDestino.Name = "txtDetDestino";
            this.txtDetDestino.Size = new System.Drawing.Size(410, 19);
            this.txtDetDestino.TabIndex = 7;
            // 
            // txtDetCliente
            // 
            this.txtDetCliente.BackColor = System.Drawing.Color.White;
            this.txtDetCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetCliente.Location = new System.Drawing.Point(102, 43);
            this.txtDetCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDetCliente.Name = "txtDetCliente";
            this.txtDetCliente.Size = new System.Drawing.Size(410, 19);
            this.txtDetCliente.TabIndex = 6;
            // 
            // txtDetGuia
            // 
            this.txtDetGuia.BackColor = System.Drawing.Color.White;
            this.txtDetGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetGuia.Location = new System.Drawing.Point(102, 20);
            this.txtDetGuia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDetGuia.Name = "txtDetGuia";
            this.txtDetGuia.Size = new System.Drawing.Size(410, 19);
            this.txtDetGuia.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Vehículo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Destino:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Guía:";
            // 
            // grpHistorial
            // 
            this.grpHistorial.BackColor = System.Drawing.Color.White;
            this.grpHistorial.Controls.Add(this.dgvHistorial);
            this.grpHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHistorial.Location = new System.Drawing.Point(550, 331);
            this.grpHistorial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpHistorial.Name = "grpHistorial";
            this.grpHistorial.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpHistorial.Size = new System.Drawing.Size(539, 319);
            this.grpHistorial.TabIndex = 7;
            this.grpHistorial.TabStop = false;
            this.grpHistorial.Text = "Historial de seguimiento";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToResizeColumns = false;
            this.dgvHistorial.AllowUserToResizeRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvHistorial.EnableHeadersVisualStyles = false;
            this.dgvHistorial.Location = new System.Drawing.Point(8, 17);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 70;
            this.dgvHistorial.RowTemplate.Height = 24;
            this.dgvHistorial.Size = new System.Drawing.Size(522, 290);
            this.dgvHistorial.TabIndex = 1;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Fecha";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Estado";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Ubicación";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // grpActualizar
            // 
            this.grpActualizar.BackColor = System.Drawing.Color.White;
            this.grpActualizar.Controls.Add(this.txtObservacion);
            this.grpActualizar.Controls.Add(this.cboNuevoEstado);
            this.grpActualizar.Controls.Add(this.btnActualizarEstado);
            this.grpActualizar.Controls.Add(this.label7);
            this.grpActualizar.Controls.Add(this.label8);
            this.grpActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpActualizar.Location = new System.Drawing.Point(9, 657);
            this.grpActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpActualizar.Name = "grpActualizar";
            this.grpActualizar.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpActualizar.Size = new System.Drawing.Size(1080, 53);
            this.grpActualizar.TabIndex = 5;
            this.grpActualizar.TabStop = false;
            this.grpActualizar.Text = "Actualizar estado del envío: ";
            // 
            // txtObservacion
            // 
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(243, 23);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(213, 19);
            this.txtObservacion.TabIndex = 5;
            // 
            // cboNuevoEstado
            // 
            this.cboNuevoEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNuevoEstado.FormattingEnabled = true;
            this.cboNuevoEstado.Location = new System.Drawing.Point(80, 23);
            this.cboNuevoEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboNuevoEstado.Name = "cboNuevoEstado";
            this.cboNuevoEstado.Size = new System.Drawing.Size(85, 21);
            this.cboNuevoEstado.TabIndex = 5;
            // 
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.BackColor = System.Drawing.Color.White;
            this.btnActualizarEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarEstado.ForeColor = System.Drawing.Color.Black;
            this.btnActualizarEstado.Location = new System.Drawing.Point(470, 23);
            this.btnActualizarEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(100, 20);
            this.btnActualizarEstado.TabIndex = 3;
            this.btnActualizarEstado.Text = "Actualizar estado";
            this.btnActualizarEstado.UseVisualStyleBackColor = false;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(173, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Observación:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nuevo estado:";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.pnlCabecera.Controls.Add(this.lblIconoUsuario);
            this.pnlCabecera.Controls.Add(this.lnkDesarrollador);
            this.pnlCabecera.Controls.Add(this.lblSede);
            this.pnlCabecera.Controls.Add(this.lblUsuario);
            this.pnlCabecera.Controls.Add(this.picLogo);
            this.pnlCabecera.Controls.Add(this.label9);
            this.pnlCabecera.Controls.Add(this.label10);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1100, 57);
            this.pnlCabecera.TabIndex = 9;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Shalom.Properties.Resources.logo_shalom_cabecera;
            this.picLogo.Location = new System.Drawing.Point(34, 7);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(172, 44);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(212, 31);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Sistema de Seguimiento y Trazabilidad de envíos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(210, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 25);
            this.label10.TabIndex = 1;
            this.label10.Text = "Rastreo de Envíos";
            // 
            // RastreoDeEnvíos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 722);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.grpActualizar);
            this.Controls.Add(this.grpHistorial);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.grpEnvios);
            this.Controls.Add(this.grpFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RastreoDeEnvíos";
            this.Text = "Rastreo De Envíos ";
            this.Load += new System.EventHandler(this.RastreoDeEnvíos_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.grpEnvios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            this.grpHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.grpActualizar.ResumeLayout(false);
            this.grpActualizar.PerformLayout();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGuia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.GroupBox grpEnvios;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.TextBox txtDetVehiculo;
        private System.Windows.Forms.TextBox txtDetDestino;
        private System.Windows.Forms.TextBox txtDetCliente;
        private System.Windows.Forms.TextBox txtDetGuia;
        private System.Windows.Forms.GroupBox grpActualizar;
        private System.Windows.Forms.Button btnActualizarEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.ComboBox cboNuevoEstado;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ListBox lstResumen;
        private System.Windows.Forms.Button btnReporteEnvio;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnIrReportes;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSede;
        private System.Windows.Forms.LinkLabel lnkDesarrollador;
        private System.Windows.Forms.Label lblIconoUsuario;
    }
}