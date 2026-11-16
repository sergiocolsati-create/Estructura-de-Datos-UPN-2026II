namespace Shalom
{
    partial class AsignaciónDeRutas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpVehiculo = new System.Windows.Forms.GroupBox();
            this.pbCarga = new System.Windows.Forms.ProgressBar();
            this.lblCarga = new System.Windows.Forms.Label();
            this.lblConductor = new System.Windows.Forms.Label();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.grpPorAsignar = new System.Windows.Forms.GroupBox();
            this.btnInsertarDespues = new System.Windows.Forms.Button();
            this.btnAgregarAlFinal = new System.Windows.Forms.Button();
            this.lstPorAsignar = new System.Windows.Forms.ListBox();
            this.lblTope = new System.Windows.Forms.Label();
            this.grpParadas = new System.Windows.Forms.GroupBox();
            this.btnQuitarParada = new System.Windows.Forms.Button();
            this.dgvParadas = new System.Windows.Forms.DataGridView();
            this.colOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblParadas = new System.Windows.Forms.Label();
            this.grpMapa = new System.Windows.Forms.GroupBox();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpVehiculo.SuspendLayout();
            this.grpPorAsignar.SuspendLayout();
            this.grpParadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParadas)).BeginInit();
            this.grpMapa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.pnlCabecera.Controls.Add(this.pictureBox1);
            this.pnlCabecera.Controls.Add(this.lblSubtitulo);
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1573, 86);
            this.pnlCabecera.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Shalom.Properties.Resources.logo_shalom_cabecera;
            this.pictureBox1.Location = new System.Drawing.Point(69, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 54);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(328, 52);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(332, 23);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Del vehículo (pila) a las paradas de la ruta ";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(323, 13);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(276, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Asignación de Rutas";
            // 
            // grpVehiculo
            // 
            this.grpVehiculo.BackColor = System.Drawing.Color.White;
            this.grpVehiculo.Controls.Add(this.pbCarga);
            this.grpVehiculo.Controls.Add(this.lblCarga);
            this.grpVehiculo.Controls.Add(this.lblConductor);
            this.grpVehiculo.Controls.Add(this.cboVehiculo);
            this.grpVehiculo.Controls.Add(this.lblVehiculo);
            this.grpVehiculo.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVehiculo.ForeColor = System.Drawing.Color.Black;
            this.grpVehiculo.Location = new System.Drawing.Point(27, 105);
            this.grpVehiculo.Margin = new System.Windows.Forms.Padding(4);
            this.grpVehiculo.Name = "grpVehiculo";
            this.grpVehiculo.Padding = new System.Windows.Forms.Padding(4);
            this.grpVehiculo.Size = new System.Drawing.Size(400, 178);
            this.grpVehiculo.TabIndex = 1;
            this.grpVehiculo.TabStop = false;
            this.grpVehiculo.Text = "Vehículo";
            // 
            // pbCarga
            // 
            this.pbCarga.Location = new System.Drawing.Point(20, 142);
            this.pbCarga.Margin = new System.Windows.Forms.Padding(4);
            this.pbCarga.Name = "pbCarga";
            this.pbCarga.Size = new System.Drawing.Size(360, 15);
            this.pbCarga.TabIndex = 4;
            // 
            // lblCarga
            // 
            this.lblCarga.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblCarga.Location = new System.Drawing.Point(16, 108);
            this.lblCarga.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(367, 25);
            this.lblCarga.TabIndex = 3;
            this.lblCarga.Text = "Carga: -";
            // 
            // lblConductor
            // 
            this.lblConductor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblConductor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblConductor.Location = new System.Drawing.Point(16, 79);
            this.lblConductor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConductor.Name = "lblConductor";
            this.lblConductor.Size = new System.Drawing.Size(367, 25);
            this.lblConductor.TabIndex = 2;
            this.lblConductor.Text = "Conductor: -";
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehiculo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(107, 34);
            this.cboVehiculo.Margin = new System.Windows.Forms.Padding(4);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(272, 29);
            this.cboVehiculo.TabIndex = 1;
            this.cboVehiculo.SelectedIndexChanged += new System.EventHandler(this.cboVehiculo_SelectedIndexChanged);
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblVehiculo.Location = new System.Drawing.Point(16, 38);
            this.lblVehiculo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(54, 23);
            this.lblVehiculo.TabIndex = 0;
            this.lblVehiculo.Text = "Placa:";
            // 
            // grpPorAsignar
            // 
            this.grpPorAsignar.BackColor = System.Drawing.Color.White;
            this.grpPorAsignar.Controls.Add(this.btnInsertarDespues);
            this.grpPorAsignar.Controls.Add(this.btnAgregarAlFinal);
            this.grpPorAsignar.Controls.Add(this.lstPorAsignar);
            this.grpPorAsignar.Controls.Add(this.lblTope);
            this.grpPorAsignar.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPorAsignar.ForeColor = System.Drawing.Color.Black;
            this.grpPorAsignar.Location = new System.Drawing.Point(27, 295);
            this.grpPorAsignar.Margin = new System.Windows.Forms.Padding(4);
            this.grpPorAsignar.Name = "grpPorAsignar";
            this.grpPorAsignar.Padding = new System.Windows.Forms.Padding(4);
            this.grpPorAsignar.Size = new System.Drawing.Size(400, 542);
            this.grpPorAsignar.TabIndex = 2;
            this.grpPorAsignar.TabStop = false;
            this.grpPorAsignar.Text = "Paquetes por asignar (pila)";
            // 
            // btnInsertarDespues
            // 
            this.btnInsertarDespues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnInsertarDespues.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertarDespues.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnInsertarDespues.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInsertarDespues.ForeColor = System.Drawing.Color.White;
            this.btnInsertarDespues.Location = new System.Drawing.Point(42, 470);
            this.btnInsertarDespues.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertarDespues.Name = "btnInsertarDespues";
            this.btnInsertarDespues.Size = new System.Drawing.Size(299, 60);
            this.btnInsertarDespues.TabIndex = 3;
            this.btnInsertarDespues.Text = "Insertar después de la parada seleccionada";
            this.btnInsertarDespues.UseVisualStyleBackColor = false;
            this.btnInsertarDespues.Click += new System.EventHandler(this.btnInsertarDespues_Click);
            // 
            // btnAgregarAlFinal
            // 
            this.btnAgregarAlFinal.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAgregarAlFinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarAlFinal.FlatAppearance.BorderSize = 0;
            this.btnAgregarAlFinal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAgregarAlFinal.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAlFinal.Location = new System.Drawing.Point(42, 406);
            this.btnAgregarAlFinal.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarAlFinal.Name = "btnAgregarAlFinal";
            this.btnAgregarAlFinal.Size = new System.Drawing.Size(299, 56);
            this.btnAgregarAlFinal.TabIndex = 2;
            this.btnAgregarAlFinal.Text = "Agregar al final de la ruta";
            this.btnAgregarAlFinal.UseVisualStyleBackColor = false;
            this.btnAgregarAlFinal.Click += new System.EventHandler(this.btnAgregarAlFinal_Click);
            // 
            // lstPorAsignar
            // 
            this.lstPorAsignar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPorAsignar.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lstPorAsignar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lstPorAsignar.FormattingEnabled = true;
            this.lstPorAsignar.ItemHeight = 19;
            this.lstPorAsignar.Location = new System.Drawing.Point(20, 86);
            this.lstPorAsignar.Margin = new System.Windows.Forms.Padding(4);
            this.lstPorAsignar.Name = "lstPorAsignar";
            this.lstPorAsignar.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstPorAsignar.Size = new System.Drawing.Size(359, 306);
            this.lstPorAsignar.TabIndex = 1;
            // 
            // lblTope
            // 
            this.lblTope.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTope.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTope.Location = new System.Drawing.Point(16, 34);
            this.lblTope.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTope.Name = "lblTope";
            this.lblTope.Size = new System.Drawing.Size(367, 44);
            this.lblTope.TabIndex = 0;
            this.lblTope.Text = "Siguiente en salir (tope): -";
            // 
            // grpParadas
            // 
            this.grpParadas.BackColor = System.Drawing.Color.White;
            this.grpParadas.Controls.Add(this.btnQuitarParada);
            this.grpParadas.Controls.Add(this.dgvParadas);
            this.grpParadas.Controls.Add(this.lblParadas);
            this.grpParadas.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpParadas.ForeColor = System.Drawing.Color.Black;
            this.grpParadas.Location = new System.Drawing.Point(447, 105);
            this.grpParadas.Margin = new System.Windows.Forms.Padding(4);
            this.grpParadas.Name = "grpParadas";
            this.grpParadas.Padding = new System.Windows.Forms.Padding(4);
            this.grpParadas.Size = new System.Drawing.Size(573, 732);
            this.grpParadas.TabIndex = 3;
            this.grpParadas.TabStop = false;
            this.grpParadas.Text = "Paradas de la ruta ";
            // 
            // btnQuitarParada
            // 
            this.btnQuitarParada.BackColor = System.Drawing.Color.White;
            this.btnQuitarParada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarParada.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnQuitarParada.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQuitarParada.ForeColor = System.Drawing.Color.Black;
            this.btnQuitarParada.Location = new System.Drawing.Point(94, 669);
            this.btnQuitarParada.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuitarParada.Name = "btnQuitarParada";
            this.btnQuitarParada.Size = new System.Drawing.Size(408, 42);
            this.btnQuitarParada.TabIndex = 2;
            this.btnQuitarParada.Text = "Quitar parada (vuelve al tope del vehículo)";
            this.btnQuitarParada.UseVisualStyleBackColor = false;
            this.btnQuitarParada.Click += new System.EventHandler(this.btnQuitarParada_Click);
            // 
            // dgvParadas
            // 
            this.dgvParadas.AllowUserToAddRows = false;
            this.dgvParadas.AllowUserToDeleteRows = false;
            this.dgvParadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvParadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParadas.BackgroundColor = System.Drawing.Color.White;
            this.dgvParadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvParadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvParadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvParadas.ColumnHeadersHeight = 32;
            this.dgvParadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvParadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrden,
            this.colGuia,
            this.colDestino,
            this.colDestinatario,
            this.colPeso});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParadas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParadas.EnableHeadersVisualStyles = false;
            this.dgvParadas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvParadas.Location = new System.Drawing.Point(20, 96);
            this.dgvParadas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParadas.MultiSelect = false;
            this.dgvParadas.Name = "dgvParadas";
            this.dgvParadas.ReadOnly = true;
            this.dgvParadas.RowHeadersVisible = false;
            this.dgvParadas.RowHeadersWidth = 51;
            this.dgvParadas.RowTemplate.Height = 28;
            this.dgvParadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParadas.Size = new System.Drawing.Size(533, 560);
            this.dgvParadas.TabIndex = 1;
            this.dgvParadas.SelectionChanged += new System.EventHandler(this.dgvParadas_SelectionChanged);
            // 
            // colOrden
            // 
            this.colOrden.FillWeight = 35F;
            this.colOrden.HeaderText = "N°";
            this.colOrden.MinimumWidth = 6;
            this.colOrden.Name = "colOrden";
            this.colOrden.ReadOnly = true;
            // 
            // colGuia
            // 
            this.colGuia.FillWeight = 110F;
            this.colGuia.HeaderText = "Guía";
            this.colGuia.MinimumWidth = 6;
            this.colGuia.Name = "colGuia";
            this.colGuia.ReadOnly = true;
            // 
            // colDestino
            // 
            this.colDestino.FillWeight = 90F;
            this.colDestino.HeaderText = "Destino";
            this.colDestino.MinimumWidth = 6;
            this.colDestino.Name = "colDestino";
            this.colDestino.ReadOnly = true;
            // 
            // colDestinatario
            // 
            this.colDestinatario.HeaderText = "Destinatario";
            this.colDestinatario.MinimumWidth = 6;
            this.colDestinatario.Name = "colDestinatario";
            this.colDestinatario.ReadOnly = true;
            // 
            // colPeso
            // 
            this.colPeso.FillWeight = 50F;
            this.colPeso.HeaderText = "Kg";
            this.colPeso.MinimumWidth = 6;
            this.colPeso.Name = "colPeso";
            this.colPeso.ReadOnly = true;
            // 
            // lblParadas
            // 
            this.lblParadas.AutoSize = true;
            this.lblParadas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblParadas.Location = new System.Drawing.Point(16, 40);
            this.lblParadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParadas.Name = "lblParadas";
            this.lblParadas.Size = new System.Drawing.Size(87, 23);
            this.lblParadas.TabIndex = 0;
            this.lblParadas.Text = "Paradas: 0";
            this.lblParadas.Click += new System.EventHandler(this.lblParadas_Click);
            // 
            // grpMapa
            // 
            this.grpMapa.BackColor = System.Drawing.Color.White;
            this.grpMapa.Controls.Add(this.lblLeyenda);
            this.grpMapa.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMapa.ForeColor = System.Drawing.Color.Black;
            this.grpMapa.Location = new System.Drawing.Point(1040, 105);
            this.grpMapa.Margin = new System.Windows.Forms.Padding(4);
            this.grpMapa.Name = "grpMapa";
            this.grpMapa.Padding = new System.Windows.Forms.Padding(4);
            this.grpMapa.Size = new System.Drawing.Size(507, 732);
            this.grpMapa.TabIndex = 4;
            this.grpMapa.TabStop = false;
            this.grpMapa.Text = "Mapa de la ruta";
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblLeyenda.ForeColor = System.Drawing.Color.Gray;
            this.lblLeyenda.Location = new System.Drawing.Point(16, 677);
            this.lblLeyenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(473, 43);
            this.lblLeyenda.TabIndex = 1;
            this.lblLeyenda.Text = "Verde: salida   Rojo: paradas   Azul: parada seleccionada.\r\nArrastre para mover, " +
    "rueda para zoom. Mapa © OpenStreetMap.";
            // 
            // AsignaciónDeRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1573, 862);
            this.Controls.Add(this.grpMapa);
            this.Controls.Add(this.grpParadas);
            this.Controls.Add(this.grpPorAsignar);
            this.Controls.Add(this.grpVehiculo);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AsignaciónDeRutas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Rutas";
            this.Load += new System.EventHandler(this.AsignaciónDeRutas_Load);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpVehiculo.ResumeLayout(false);
            this.grpVehiculo.PerformLayout();
            this.grpPorAsignar.ResumeLayout(false);
            this.grpParadas.ResumeLayout(false);
            this.grpParadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParadas)).EndInit();
            this.grpMapa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpVehiculo;
        private System.Windows.Forms.ProgressBar pbCarga;
        private System.Windows.Forms.Label lblCarga;
        private System.Windows.Forms.Label lblConductor;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.GroupBox grpPorAsignar;
        private System.Windows.Forms.Button btnInsertarDespues;
        private System.Windows.Forms.Button btnAgregarAlFinal;
        private System.Windows.Forms.ListBox lstPorAsignar;
        private System.Windows.Forms.Label lblTope;
        private System.Windows.Forms.GroupBox grpParadas;
        private System.Windows.Forms.Button btnQuitarParada;
        private System.Windows.Forms.DataGridView dgvParadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeso;
        private System.Windows.Forms.Label lblParadas;
        private System.Windows.Forms.GroupBox grpMapa;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}