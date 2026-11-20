namespace Shalom
{
    partial class FormularioReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PeriodoTxt = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.FechaTxt = new System.Windows.Forms.Label();
            this.lblRango = new System.Windows.Forms.Label();
            this.SeccionTxt = new System.Windows.Forms.Label();
            this.cboSeccion = new System.Windows.Forms.ComboBox();
            this.OrigenTxt = new System.Windows.Forms.Label();
            this.DestinoTxt = new System.Windows.Forms.Label();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvVistaPrevia = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnExportarTxt = new System.Windows.Forms.Button();
            this.btnExportarCSV = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaPrevia)).BeginInit();
            this.SuspendLayout();
            // 
            // PeriodoTxt
            // 
            this.PeriodoTxt.AutoSize = true;
            this.PeriodoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodoTxt.Location = new System.Drawing.Point(33, 34);
            this.PeriodoTxt.Name = "PeriodoTxt";
            this.PeriodoTxt.Size = new System.Drawing.Size(58, 16);
            this.PeriodoTxt.TabIndex = 1;
            this.PeriodoTxt.Text = "Período:";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(129, 31);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(140, 24);
            this.cboPeriodo.TabIndex = 2;
            // 
            // FechaTxt
            // 
            this.FechaTxt.AutoSize = true;
            this.FechaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaTxt.Location = new System.Drawing.Point(33, 74);
            this.FechaTxt.Name = "FechaTxt";
            this.FechaTxt.Size = new System.Drawing.Size(48, 16);
            this.FechaTxt.TabIndex = 3;
            this.FechaTxt.Text = "Fecha:";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRango.Location = new System.Drawing.Point(33, 115);
            this.lblRango.MaximumSize = new System.Drawing.Size(260, 0);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(11, 16);
            this.lblRango.TabIndex = 5;
            this.lblRango.Text = "-";
            // 
            // SeccionTxt
            // 
            this.SeccionTxt.AutoSize = true;
            this.SeccionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeccionTxt.Location = new System.Drawing.Point(32, 165);
            this.SeccionTxt.Name = "SeccionTxt";
            this.SeccionTxt.Size = new System.Drawing.Size(59, 16);
            this.SeccionTxt.TabIndex = 6;
            this.SeccionTxt.Text = "Sección:";
            // 
            // cboSeccion
            // 
            this.cboSeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeccion.FormattingEnabled = true;
            this.cboSeccion.Location = new System.Drawing.Point(129, 162);
            this.cboSeccion.Name = "cboSeccion";
            this.cboSeccion.Size = new System.Drawing.Size(140, 24);
            this.cboSeccion.TabIndex = 7;
            // 
            // OrigenTxt
            // 
            this.OrigenTxt.AutoSize = true;
            this.OrigenTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrigenTxt.Location = new System.Drawing.Point(32, 213);
            this.OrigenTxt.Name = "OrigenTxt";
            this.OrigenTxt.Size = new System.Drawing.Size(84, 16);
            this.OrigenTxt.TabIndex = 8;
            this.OrigenTxt.Text = "Sede origen:";
            // 
            // DestinoTxt
            // 
            this.DestinoTxt.AutoSize = true;
            this.DestinoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinoTxt.Location = new System.Drawing.Point(32, 262);
            this.DestinoTxt.Name = "DestinoTxt";
            this.DestinoTxt.Size = new System.Drawing.Size(90, 16);
            this.DestinoTxt.TabIndex = 9;
            this.DestinoTxt.Text = "Sede destino:";
            // 
            // cboOrigen
            // 
            this.cboOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(129, 210);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(139, 24);
            this.cboOrigen.TabIndex = 10;
            // 
            // cboDestino
            // 
            this.cboDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(128, 259);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(140, 24);
            this.cboDestino.TabIndex = 11;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(57, 322);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(191, 51);
            this.btnGenerar.TabIndex = 12;
            this.btnGenerar.Text = "Generar vista previa";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.PeriodoTxt);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.cboPeriodo);
            this.groupBox1.Controls.Add(this.cboDestino);
            this.groupBox1.Controls.Add(this.FechaTxt);
            this.groupBox1.Controls.Add(this.DestinoTxt);
            this.groupBox1.Controls.Add(this.cboOrigen);
            this.groupBox1.Controls.Add(this.lblRango);
            this.groupBox1.Controls.Add(this.OrigenTxt);
            this.groupBox1.Controls.Add(this.SeccionTxt);
            this.groupBox1.Controls.Add(this.cboSeccion);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 400);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(129, 74);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(140, 22);
            this.dtpFecha.TabIndex = 13;
            // 
            // dgvVistaPrevia
            // 
            this.dgvVistaPrevia.AllowUserToResizeRows = false;
            this.dgvVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVistaPrevia.BackgroundColor = System.Drawing.Color.White;
            this.dgvVistaPrevia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaPrevia.Location = new System.Drawing.Point(366, 24);
            this.dgvVistaPrevia.Name = "dgvVistaPrevia";
            this.dgvVistaPrevia.RowHeadersWidth = 51;
            this.dgvVistaPrevia.RowTemplate.Height = 24;
            this.dgvVistaPrevia.Size = new System.Drawing.Size(720, 496);
            this.dgvVistaPrevia.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(36, 441);
            this.lblTotal.MaximumSize = new System.Drawing.Size(260, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(160, 16);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Envíos encontrados: 0";
            // 
            // btnExportarTxt
            // 
            this.btnExportarTxt.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnExportarTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarTxt.ForeColor = System.Drawing.Color.White;
            this.btnExportarTxt.Location = new System.Drawing.Point(39, 473);
            this.btnExportarTxt.Name = "btnExportarTxt";
            this.btnExportarTxt.Size = new System.Drawing.Size(140, 47);
            this.btnExportarTxt.TabIndex = 13;
            this.btnExportarTxt.Text = "Exportar TXT";
            this.btnExportarTxt.UseVisualStyleBackColor = false;
            this.btnExportarTxt.Click += new System.EventHandler(this.btnExportarTxt_Click);
            // 
            // btnExportarCSV
            // 
            this.btnExportarCSV.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportarCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportarCSV.Location = new System.Drawing.Point(199, 473);
            this.btnExportarCSV.Name = "btnExportarCSV";
            this.btnExportarCSV.Size = new System.Drawing.Size(123, 47);
            this.btnExportarCSV.TabIndex = 16;
            this.btnExportarCSV.Text = "Exportar CSV";
            this.btnExportarCSV.UseVisualStyleBackColor = false;
            this.btnExportarCSV.Click += new System.EventHandler(this.btnExportarCSV_Click);
            // 
            // FormularioReportes
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1110, 553);
            this.Controls.Add(this.btnExportarCSV);
            this.Controls.Add(this.btnExportarTxt);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvVistaPrevia);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1128, 600);
            this.Name = "FormularioReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaPrevia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PeriodoTxt;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label FechaTxt;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.Label SeccionTxt;
        private System.Windows.Forms.ComboBox cboSeccion;
        private System.Windows.Forms.Label OrigenTxt;
        private System.Windows.Forms.Label DestinoTxt;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvVistaPrevia;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExportarTxt;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnExportarCSV;
    }
}