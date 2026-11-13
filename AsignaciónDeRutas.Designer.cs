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
            this.grpRutaVehiculo = new System.Windows.Forms.GroupBox();
            this.lblFlecha4 = new System.Windows.Forms.Label();
            this.lblFlecha3 = new System.Windows.Forms.Label();
            this.lblFlecha2 = new System.Windows.Forms.Label();
            this.lblFlecha1 = new System.Windows.Forms.Label();
            this.btnParada5 = new System.Windows.Forms.Button();
            this.btnParada4 = new System.Windows.Forms.Button();
            this.btnParada3 = new System.Windows.Forms.Button();
            this.btnParada2 = new System.Windows.Forms.Button();
            this.btnParada1 = new System.Windows.Forms.Button();
            this.lblCantidadParadas = new System.Windows.Forms.Label();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.lblTituloVehiculo = new System.Windows.Forms.Label();
            this.grpPaquetesPendientes = new System.Windows.Forms.GroupBox();
            this.lstPaquetesPendientes = new System.Windows.Forms.ListBox();
            this.btnAgregarAlFinal = new System.Windows.Forms.Button();
            this.grpParadasRuta = new System.Windows.Forms.GroupBox();
            this.btnVerResumenRuta = new System.Windows.Forms.Button();
            this.btnEliminarParada = new System.Windows.Forms.Button();
            this.btnInsertarDespues = new System.Windows.Forms.Button();
            this.dgvParadasRuta = new System.Windows.Forms.DataGridView();
            this.colOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.grpRutaVehiculo.SuspendLayout();
            this.grpPaquetesPendientes.SuspendLayout();
            this.grpParadasRuta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParadasRuta)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRutaVehiculo
            // 
            this.grpRutaVehiculo.BackColor = System.Drawing.Color.White;
            this.grpRutaVehiculo.Controls.Add(this.lblFlecha4);
            this.grpRutaVehiculo.Controls.Add(this.lblFlecha3);
            this.grpRutaVehiculo.Controls.Add(this.lblFlecha2);
            this.grpRutaVehiculo.Controls.Add(this.lblFlecha1);
            this.grpRutaVehiculo.Controls.Add(this.btnParada5);
            this.grpRutaVehiculo.Controls.Add(this.btnParada4);
            this.grpRutaVehiculo.Controls.Add(this.btnParada3);
            this.grpRutaVehiculo.Controls.Add(this.btnParada2);
            this.grpRutaVehiculo.Controls.Add(this.btnParada1);
            this.grpRutaVehiculo.Controls.Add(this.lblCantidadParadas);
            this.grpRutaVehiculo.Controls.Add(this.cboVehiculo);
            this.grpRutaVehiculo.Controls.Add(this.lblTituloVehiculo);
            this.grpRutaVehiculo.Font = new System.Drawing.Font("Myanmar Text", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRutaVehiculo.Location = new System.Drawing.Point(99, 123);
            this.grpRutaVehiculo.Margin = new System.Windows.Forms.Padding(4);
            this.grpRutaVehiculo.Name = "grpRutaVehiculo";
            this.grpRutaVehiculo.Padding = new System.Windows.Forms.Padding(4);
            this.grpRutaVehiculo.Size = new System.Drawing.Size(774, 244);
            this.grpRutaVehiculo.TabIndex = 0;
            this.grpRutaVehiculo.TabStop = false;
            this.grpRutaVehiculo.Text = "Ruta del vehículo";
            this.grpRutaVehiculo.Enter += new System.EventHandler(this.grpRutaVehiculo_Enter);
            // 
            // lblFlecha4
            // 
            this.lblFlecha4.AutoSize = true;
            this.lblFlecha4.Location = new System.Drawing.Point(540, 112);
            this.lblFlecha4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha4.Name = "lblFlecha4";
            this.lblFlecha4.Size = new System.Drawing.Size(22, 24);
            this.lblFlecha4.TabIndex = 11;
            this.lblFlecha4.Text = "→";
            // 
            // lblFlecha3
            // 
            this.lblFlecha3.AutoSize = true;
            this.lblFlecha3.Location = new System.Drawing.Point(411, 112);
            this.lblFlecha3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha3.Name = "lblFlecha3";
            this.lblFlecha3.Size = new System.Drawing.Size(22, 24);
            this.lblFlecha3.TabIndex = 10;
            this.lblFlecha3.Text = "→";
            // 
            // lblFlecha2
            // 
            this.lblFlecha2.AutoSize = true;
            this.lblFlecha2.Location = new System.Drawing.Point(277, 112);
            this.lblFlecha2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha2.Name = "lblFlecha2";
            this.lblFlecha2.Size = new System.Drawing.Size(22, 24);
            this.lblFlecha2.TabIndex = 9;
            this.lblFlecha2.Text = "→";
            // 
            // lblFlecha1
            // 
            this.lblFlecha1.AutoSize = true;
            this.lblFlecha1.Location = new System.Drawing.Point(144, 112);
            this.lblFlecha1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha1.Name = "lblFlecha1";
            this.lblFlecha1.Size = new System.Drawing.Size(22, 24);
            this.lblFlecha1.TabIndex = 8;
            this.lblFlecha1.Text = "→";
            // 
            // btnParada5
            // 
            this.btnParada5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParada5.Location = new System.Drawing.Point(583, 92);
            this.btnParada5.Margin = new System.Windows.Forms.Padding(4);
            this.btnParada5.Name = "btnParada5";
            this.btnParada5.Size = new System.Drawing.Size(87, 55);
            this.btnParada5.TabIndex = 7;
            this.btnParada5.Text = "cola P5.LP-140";
            this.btnParada5.UseVisualStyleBackColor = true;
            // 
            // btnParada4
            // 
            this.btnParada4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParada4.Location = new System.Drawing.Point(445, 92);
            this.btnParada4.Margin = new System.Windows.Forms.Padding(4);
            this.btnParada4.Name = "btnParada4";
            this.btnParada4.Size = new System.Drawing.Size(87, 55);
            this.btnParada4.TabIndex = 6;
            this.btnParada4.Text = "P4.LP-138";
            this.btnParada4.UseVisualStyleBackColor = true;
            // 
            // btnParada3
            // 
            this.btnParada3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParada3.Location = new System.Drawing.Point(316, 92);
            this.btnParada3.Margin = new System.Windows.Forms.Padding(4);
            this.btnParada3.Name = "btnParada3";
            this.btnParada3.Size = new System.Drawing.Size(87, 55);
            this.btnParada3.TabIndex = 5;
            this.btnParada3.Text = "P3.LP-135";
            this.btnParada3.UseVisualStyleBackColor = true;
            // 
            // btnParada2
            // 
            this.btnParada2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParada2.Location = new System.Drawing.Point(183, 92);
            this.btnParada2.Margin = new System.Windows.Forms.Padding(4);
            this.btnParada2.Name = "btnParada2";
            this.btnParada2.Size = new System.Drawing.Size(87, 55);
            this.btnParada2.TabIndex = 4;
            this.btnParada2.Text = "P2.LP-131";
            this.btnParada2.UseVisualStyleBackColor = true;
            // 
            // btnParada1
            // 
            this.btnParada1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParada1.Location = new System.Drawing.Point(36, 92);
            this.btnParada1.Margin = new System.Windows.Forms.Padding(4);
            this.btnParada1.Name = "btnParada1";
            this.btnParada1.Size = new System.Drawing.Size(100, 55);
            this.btnParada1.TabIndex = 3;
            this.btnParada1.Text = "cabeza P1.LP-123";
            this.btnParada1.UseVisualStyleBackColor = true;
            // 
            // lblCantidadParadas
            // 
            this.lblCantidadParadas.AutoSize = true;
            this.lblCantidadParadas.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadParadas.Location = new System.Drawing.Point(401, 33);
            this.lblCantidadParadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadParadas.Name = "lblCantidadParadas";
            this.lblCantidadParadas.Size = new System.Drawing.Size(73, 24);
            this.lblCantidadParadas.TabIndex = 2;
            this.lblCantidadParadas.Text = "Paradas: 5";
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(95, 30);
            this.cboVehiculo.Margin = new System.Windows.Forms.Padding(4);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(160, 32);
            this.cboVehiculo.TabIndex = 1;
            // 
            // lblTituloVehiculo
            // 
            this.lblTituloVehiculo.AutoSize = true;
            this.lblTituloVehiculo.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVehiculo.Location = new System.Drawing.Point(8, 33);
            this.lblTituloVehiculo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloVehiculo.Name = "lblTituloVehiculo";
            this.lblTituloVehiculo.Size = new System.Drawing.Size(64, 24);
            this.lblTituloVehiculo.TabIndex = 0;
            this.lblTituloVehiculo.Text = "Vehículo";
            // 
            // grpPaquetesPendientes
            // 
            this.grpPaquetesPendientes.BackColor = System.Drawing.Color.White;
            this.grpPaquetesPendientes.Controls.Add(this.lstPaquetesPendientes);
            this.grpPaquetesPendientes.Font = new System.Drawing.Font("Myanmar Text", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPaquetesPendientes.Location = new System.Drawing.Point(37, 375);
            this.grpPaquetesPendientes.Margin = new System.Windows.Forms.Padding(4);
            this.grpPaquetesPendientes.Name = "grpPaquetesPendientes";
            this.grpPaquetesPendientes.Padding = new System.Windows.Forms.Padding(4);
            this.grpPaquetesPendientes.Size = new System.Drawing.Size(267, 315);
            this.grpPaquetesPendientes.TabIndex = 1;
            this.grpPaquetesPendientes.TabStop = false;
            this.grpPaquetesPendientes.Text = "Paquetes por asignar";
            this.grpPaquetesPendientes.Enter += new System.EventHandler(this.grpPaquetesPendientes_Enter);
            // 
            // lstPaquetesPendientes
            // 
            this.lstPaquetesPendientes.Font = new System.Drawing.Font("Myanmar Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPaquetesPendientes.FormattingEnabled = true;
            this.lstPaquetesPendientes.ItemHeight = 27;
            this.lstPaquetesPendientes.Location = new System.Drawing.Point(8, 23);
            this.lstPaquetesPendientes.Margin = new System.Windows.Forms.Padding(4);
            this.lstPaquetesPendientes.Name = "lstPaquetesPendientes";
            this.lstPaquetesPendientes.Size = new System.Drawing.Size(259, 274);
            this.lstPaquetesPendientes.TabIndex = 0;
            // 
            // btnAgregarAlFinal
            // 
            this.btnAgregarAlFinal.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAgregarAlFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAgregarAlFinal.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAlFinal.Location = new System.Drawing.Point(64, 698);
            this.btnAgregarAlFinal.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarAlFinal.Name = "btnAgregarAlFinal";
            this.btnAgregarAlFinal.Size = new System.Drawing.Size(201, 46);
            this.btnAgregarAlFinal.TabIndex = 2;
            this.btnAgregarAlFinal.Text = "Agregar al final";
            this.btnAgregarAlFinal.UseVisualStyleBackColor = false;
            this.btnAgregarAlFinal.Click += new System.EventHandler(this.btnAgregarAlFinal_Click);
            // 
            // grpParadasRuta
            // 
            this.grpParadasRuta.BackColor = System.Drawing.Color.White;
            this.grpParadasRuta.Controls.Add(this.btnVerResumenRuta);
            this.grpParadasRuta.Controls.Add(this.btnEliminarParada);
            this.grpParadasRuta.Controls.Add(this.btnInsertarDespues);
            this.grpParadasRuta.Controls.Add(this.dgvParadasRuta);
            this.grpParadasRuta.Font = new System.Drawing.Font("Myanmar Text", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpParadasRuta.Location = new System.Drawing.Point(345, 375);
            this.grpParadasRuta.Margin = new System.Windows.Forms.Padding(4);
            this.grpParadasRuta.Name = "grpParadasRuta";
            this.grpParadasRuta.Padding = new System.Windows.Forms.Padding(4);
            this.grpParadasRuta.Size = new System.Drawing.Size(575, 353);
            this.grpParadasRuta.TabIndex = 3;
            this.grpParadasRuta.TabStop = false;
            this.grpParadasRuta.Text = "Paradas de la ruta";
            // 
            // btnVerResumenRuta
            // 
            this.btnVerResumenRuta.BackColor = System.Drawing.Color.White;
            this.btnVerResumenRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnVerResumenRuta.ForeColor = System.Drawing.Color.Black;
            this.btnVerResumenRuta.Location = new System.Drawing.Point(387, 307);
            this.btnVerResumenRuta.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerResumenRuta.Name = "btnVerResumenRuta";
            this.btnVerResumenRuta.Size = new System.Drawing.Size(167, 38);
            this.btnVerResumenRuta.TabIndex = 3;
            this.btnVerResumenRuta.Text = "Confirmar ruta";
            this.btnVerResumenRuta.UseVisualStyleBackColor = false;
            this.btnVerResumenRuta.Click += new System.EventHandler(this.btnVerResumenRuta_Click);
            // 
            // btnEliminarParada
            // 
            this.btnEliminarParada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnEliminarParada.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarParada.ForeColor = System.Drawing.Color.White;
            this.btnEliminarParada.Location = new System.Drawing.Point(199, 307);
            this.btnEliminarParada.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarParada.Name = "btnEliminarParada";
            this.btnEliminarParada.Size = new System.Drawing.Size(167, 38);
            this.btnEliminarParada.TabIndex = 2;
            this.btnEliminarParada.Text = "Eliminar parada ";
            this.btnEliminarParada.UseVisualStyleBackColor = false;
            this.btnEliminarParada.Click += new System.EventHandler(this.btnEliminarParada_Click);
            // 
            // btnInsertarDespues
            // 
            this.btnInsertarDespues.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnInsertarDespues.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnInsertarDespues.ForeColor = System.Drawing.Color.White;
            this.btnInsertarDespues.Location = new System.Drawing.Point(16, 307);
            this.btnInsertarDespues.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertarDespues.Name = "btnInsertarDespues";
            this.btnInsertarDespues.Size = new System.Drawing.Size(170, 38);
            this.btnInsertarDespues.TabIndex = 1;
            this.btnInsertarDespues.Text = "Insertar después";
            this.btnInsertarDespues.UseVisualStyleBackColor = false;
            this.btnInsertarDespues.Click += new System.EventHandler(this.btnInsertarDespues_Click);
            // 
            // dgvParadasRuta
            // 
            this.dgvParadasRuta.AllowUserToOrderColumns = true;
            this.dgvParadasRuta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParadasRuta.BackgroundColor = System.Drawing.Color.White;
            this.dgvParadasRuta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar Text", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParadasRuta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParadasRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParadasRuta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrden,
            this.colGuia,
            this.colDestino,
            this.colSiguiente});
            this.dgvParadasRuta.EnableHeadersVisualStyles = false;
            this.dgvParadasRuta.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.dgvParadasRuta.Location = new System.Drawing.Point(16, 23);
            this.dgvParadasRuta.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParadasRuta.Name = "dgvParadasRuta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar Text", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParadasRuta.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParadasRuta.RowHeadersWidth = 51;
            this.dgvParadasRuta.Size = new System.Drawing.Size(547, 218);
            this.dgvParadasRuta.TabIndex = 0;
            this.dgvParadasRuta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParadasRuta_CellContentClick);
            // 
            // colOrden
            // 
            this.colOrden.HeaderText = "Orden";
            this.colOrden.MinimumWidth = 6;
            this.colOrden.Name = "colOrden";
            // 
            // colGuia
            // 
            this.colGuia.HeaderText = "Guía";
            this.colGuia.MinimumWidth = 6;
            this.colGuia.Name = "colGuia";
            // 
            // colDestino
            // 
            this.colDestino.HeaderText = "Destino";
            this.colDestino.MinimumWidth = 6;
            this.colDestino.Name = "colDestino";
            // 
            // colSiguiente
            // 
            this.colSiguiente.HeaderText = "Siguiente";
            this.colSiguiente.MinimumWidth = 6;
            this.colSiguiente.Name = "colSiguiente";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.pnlCabecera.Controls.Add(this.label2);
            this.pnlCabecera.Controls.Add(this.label1);
            this.pnlCabecera.Controls.Add(this.picLogo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1054, 98);
            this.pnlCabecera.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(342, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gestión y ordenamiento de paradas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(332, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Asignación de Rutas";
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::Shalom.Properties.Resources.logo_shalom_cabecera;
            this.picLogo.Location = new System.Drawing.Point(37, 13);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(236, 62);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // AsignaciónDeRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1054, 789);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.grpParadasRuta);
            this.Controls.Add(this.btnAgregarAlFinal);
            this.Controls.Add(this.grpPaquetesPendientes);
            this.Controls.Add(this.grpRutaVehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 85);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AsignaciónDeRutas";
            this.Text = "Asignación De Rutas";
            this.Load += new System.EventHandler(this.AsignaciónDeRutas_Load);
            this.grpRutaVehiculo.ResumeLayout(false);
            this.grpRutaVehiculo.PerformLayout();
            this.grpPaquetesPendientes.ResumeLayout(false);
            this.grpParadasRuta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParadasRuta)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRutaVehiculo;
        private System.Windows.Forms.Label lblTituloVehiculo;
        private System.Windows.Forms.Button btnParada2;
        private System.Windows.Forms.Button btnParada1;
        private System.Windows.Forms.Label lblCantidadParadas;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.Label lblFlecha4;
        private System.Windows.Forms.Label lblFlecha3;
        private System.Windows.Forms.Label lblFlecha2;
        private System.Windows.Forms.Label lblFlecha1;
        private System.Windows.Forms.Button btnParada5;
        private System.Windows.Forms.Button btnParada4;
        private System.Windows.Forms.Button btnParada3;
        private System.Windows.Forms.GroupBox grpPaquetesPendientes;
        private System.Windows.Forms.ListBox lstPaquetesPendientes;
        private System.Windows.Forms.Button btnAgregarAlFinal;
        private System.Windows.Forms.GroupBox grpParadasRuta;
        private System.Windows.Forms.Button btnVerResumenRuta;
        private System.Windows.Forms.Button btnEliminarParada;
        private System.Windows.Forms.Button btnInsertarDespues;
        private System.Windows.Forms.DataGridView dgvParadasRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiguiente;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

