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
            this.grpRutaVehiculo.SuspendLayout();
            this.grpPaquetesPendientes.SuspendLayout();
            this.grpParadasRuta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParadasRuta)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRutaVehiculo
            // 
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
            this.grpRutaVehiculo.Location = new System.Drawing.Point(29, 30);
            this.grpRutaVehiculo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpRutaVehiculo.Name = "grpRutaVehiculo";
            this.grpRutaVehiculo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpRutaVehiculo.Size = new System.Drawing.Size(892, 244);
            this.grpRutaVehiculo.TabIndex = 0;
            this.grpRutaVehiculo.TabStop = false;
            this.grpRutaVehiculo.Text = "Ruta del vehículo";
            // 
            // lblFlecha4
            // 
            this.lblFlecha4.AutoSize = true;
            this.lblFlecha4.Location = new System.Drawing.Point(540, 112);
            this.lblFlecha4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha4.Name = "lblFlecha4";
            this.lblFlecha4.Size = new System.Drawing.Size(20, 16);
            this.lblFlecha4.TabIndex = 11;
            this.lblFlecha4.Text = "→";
            // 
            // lblFlecha3
            // 
            this.lblFlecha3.AutoSize = true;
            this.lblFlecha3.Location = new System.Drawing.Point(411, 112);
            this.lblFlecha3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha3.Name = "lblFlecha3";
            this.lblFlecha3.Size = new System.Drawing.Size(20, 16);
            this.lblFlecha3.TabIndex = 10;
            this.lblFlecha3.Text = "→";
            // 
            // lblFlecha2
            // 
            this.lblFlecha2.AutoSize = true;
            this.lblFlecha2.Location = new System.Drawing.Point(277, 112);
            this.lblFlecha2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha2.Name = "lblFlecha2";
            this.lblFlecha2.Size = new System.Drawing.Size(20, 16);
            this.lblFlecha2.TabIndex = 9;
            this.lblFlecha2.Text = "→";
            // 
            // lblFlecha1
            // 
            this.lblFlecha1.AutoSize = true;
            this.lblFlecha1.Location = new System.Drawing.Point(144, 112);
            this.lblFlecha1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlecha1.Name = "lblFlecha1";
            this.lblFlecha1.Size = new System.Drawing.Size(20, 16);
            this.lblFlecha1.TabIndex = 8;
            this.lblFlecha1.Text = "→";
            // 
            // btnParada5
            // 
            this.btnParada5.Location = new System.Drawing.Point(583, 92);
            this.btnParada5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnParada5.Name = "btnParada5";
            this.btnParada5.Size = new System.Drawing.Size(87, 55);
            this.btnParada5.TabIndex = 7;
            this.btnParada5.Text = "cola P5.LP-140";
            this.btnParada5.UseVisualStyleBackColor = true;
            // 
            // btnParada4
            // 
            this.btnParada4.Location = new System.Drawing.Point(445, 92);
            this.btnParada4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnParada4.Name = "btnParada4";
            this.btnParada4.Size = new System.Drawing.Size(87, 55);
            this.btnParada4.TabIndex = 6;
            this.btnParada4.Text = "P4.LP-138";
            this.btnParada4.UseVisualStyleBackColor = true;
            // 
            // btnParada3
            // 
            this.btnParada3.Location = new System.Drawing.Point(316, 92);
            this.btnParada3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnParada3.Name = "btnParada3";
            this.btnParada3.Size = new System.Drawing.Size(87, 55);
            this.btnParada3.TabIndex = 5;
            this.btnParada3.Text = "P3.LP-135";
            this.btnParada3.UseVisualStyleBackColor = true;
            // 
            // btnParada2
            // 
            this.btnParada2.Location = new System.Drawing.Point(183, 92);
            this.btnParada2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnParada2.Name = "btnParada2";
            this.btnParada2.Size = new System.Drawing.Size(87, 55);
            this.btnParada2.TabIndex = 4;
            this.btnParada2.Text = "P2.LP-131";
            this.btnParada2.UseVisualStyleBackColor = true;
            // 
            // btnParada1
            // 
            this.btnParada1.Location = new System.Drawing.Point(36, 92);
            this.btnParada1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnParada1.Name = "btnParada1";
            this.btnParada1.Size = new System.Drawing.Size(100, 55);
            this.btnParada1.TabIndex = 3;
            this.btnParada1.Text = "cabeza P1.LP-123";
            this.btnParada1.UseVisualStyleBackColor = true;
            // 
            // lblCantidadParadas
            // 
            this.lblCantidadParadas.AutoSize = true;
            this.lblCantidadParadas.Location = new System.Drawing.Point(401, 33);
            this.lblCantidadParadas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadParadas.Name = "lblCantidadParadas";
            this.lblCantidadParadas.Size = new System.Drawing.Size(72, 16);
            this.lblCantidadParadas.TabIndex = 2;
            this.lblCantidadParadas.Text = "Paradas: 5";
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(95, 30);
            this.cboVehiculo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(160, 24);
            this.cboVehiculo.TabIndex = 1;
            // 
            // lblTituloVehiculo
            // 
            this.lblTituloVehiculo.AutoSize = true;
            this.lblTituloVehiculo.Location = new System.Drawing.Point(8, 33);
            this.lblTituloVehiculo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloVehiculo.Name = "lblTituloVehiculo";
            this.lblTituloVehiculo.Size = new System.Drawing.Size(59, 16);
            this.lblTituloVehiculo.TabIndex = 0;
            this.lblTituloVehiculo.Text = "Vehículo";
            // 
            // grpPaquetesPendientes
            // 
            this.grpPaquetesPendientes.Controls.Add(this.lstPaquetesPendientes);
            this.grpPaquetesPendientes.Location = new System.Drawing.Point(37, 300);
            this.grpPaquetesPendientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPaquetesPendientes.Name = "grpPaquetesPendientes";
            this.grpPaquetesPendientes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPaquetesPendientes.Size = new System.Drawing.Size(267, 265);
            this.grpPaquetesPendientes.TabIndex = 1;
            this.grpPaquetesPendientes.TabStop = false;
            this.grpPaquetesPendientes.Text = "Paquetes por asignar";
            // 
            // lstPaquetesPendientes
            // 
            this.lstPaquetesPendientes.FormattingEnabled = true;
            this.lstPaquetesPendientes.ItemHeight = 16;
            this.lstPaquetesPendientes.Location = new System.Drawing.Point(8, 23);
            this.lstPaquetesPendientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstPaquetesPendientes.Name = "lstPaquetesPendientes";
            this.lstPaquetesPendientes.Size = new System.Drawing.Size(237, 212);
            this.lstPaquetesPendientes.TabIndex = 0;
            // 
            // btnAgregarAlFinal
            // 
            this.btnAgregarAlFinal.Location = new System.Drawing.Point(83, 572);
            this.btnAgregarAlFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarAlFinal.Name = "btnAgregarAlFinal";
            this.btnAgregarAlFinal.Size = new System.Drawing.Size(201, 30);
            this.btnAgregarAlFinal.TabIndex = 2;
            this.btnAgregarAlFinal.Text = "Agregar al final";
            this.btnAgregarAlFinal.UseVisualStyleBackColor = true;
            this.btnAgregarAlFinal.Click += new System.EventHandler(this.btnAgregarAlFinal_Click);
            // 
            // grpParadasRuta
            // 
            this.grpParadasRuta.Controls.Add(this.btnVerResumenRuta);
            this.grpParadasRuta.Controls.Add(this.btnEliminarParada);
            this.grpParadasRuta.Controls.Add(this.btnInsertarDespues);
            this.grpParadasRuta.Controls.Add(this.dgvParadasRuta);
            this.grpParadasRuta.Location = new System.Drawing.Point(365, 300);
            this.grpParadasRuta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpParadasRuta.Name = "grpParadasRuta";
            this.grpParadasRuta.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpParadasRuta.Size = new System.Drawing.Size(555, 368);
            this.grpParadasRuta.TabIndex = 3;
            this.grpParadasRuta.TabStop = false;
            this.grpParadasRuta.Text = "Paradas de la ruta";
            // 
            // btnVerResumenRuta
            // 
            this.btnVerResumenRuta.Location = new System.Drawing.Point(300, 297);
            this.btnVerResumenRuta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVerResumenRuta.Name = "btnVerResumenRuta";
            this.btnVerResumenRuta.Size = new System.Drawing.Size(160, 28);
            this.btnVerResumenRuta.TabIndex = 3;
            this.btnVerResumenRuta.Text = "Confirmar ruta";
            this.btnVerResumenRuta.UseVisualStyleBackColor = true;
            this.btnVerResumenRuta.Click += new System.EventHandler(this.btnVerResumenRuta_Click);
            // 
            // btnEliminarParada
            // 
            this.btnEliminarParada.Location = new System.Drawing.Point(8, 297);
            this.btnEliminarParada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarParada.Name = "btnEliminarParada";
            this.btnEliminarParada.Size = new System.Drawing.Size(263, 28);
            this.btnEliminarParada.TabIndex = 2;
            this.btnEliminarParada.Text = "Eliminar parada ";
            this.btnEliminarParada.UseVisualStyleBackColor = true;
            this.btnEliminarParada.Click += new System.EventHandler(this.btnEliminarParada_Click);
            // 
            // btnInsertarDespues
            // 
            this.btnInsertarDespues.Location = new System.Drawing.Point(8, 249);
            this.btnInsertarDespues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsertarDespues.Name = "btnInsertarDespues";
            this.btnInsertarDespues.Size = new System.Drawing.Size(263, 28);
            this.btnInsertarDespues.TabIndex = 1;
            this.btnInsertarDespues.Text = "Insertar después";
            this.btnInsertarDespues.UseVisualStyleBackColor = true;
            this.btnInsertarDespues.Click += new System.EventHandler(this.btnInsertarDespues_Click);
            // 
            // dgvParadasRuta
            // 
            this.dgvParadasRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParadasRuta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrden,
            this.colGuia,
            this.colDestino,
            this.colSiguiente});
            this.dgvParadasRuta.GridColor = System.Drawing.Color.White;
            this.dgvParadasRuta.Location = new System.Drawing.Point(8, 23);
            this.dgvParadasRuta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvParadasRuta.Name = "dgvParadasRuta";
            this.dgvParadasRuta.RowHeadersWidth = 51;
            this.dgvParadasRuta.Size = new System.Drawing.Size(547, 218);
            this.dgvParadasRuta.TabIndex = 0;
            // 
            // colOrden
            // 
            this.colOrden.HeaderText = "Orden";
            this.colOrden.MinimumWidth = 6;
            this.colOrden.Name = "colOrden";
            this.colOrden.Width = 125;
            // 
            // colGuia
            // 
            this.colGuia.HeaderText = "Guía";
            this.colGuia.MinimumWidth = 6;
            this.colGuia.Name = "colGuia";
            this.colGuia.Width = 125;
            // 
            // colDestino
            // 
            this.colDestino.HeaderText = "Destino";
            this.colDestino.MinimumWidth = 6;
            this.colDestino.Name = "colDestino";
            this.colDestino.Width = 125;
            // 
            // colSiguiente
            // 
            this.colSiguiente.HeaderText = "Siguiente";
            this.colSiguiente.MinimumWidth = 6;
            this.colSiguiente.Name = "colSiguiente";
            this.colSiguiente.Width = 125;
            // 
            // AsignaciónDeRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 729);
            this.Controls.Add(this.grpParadasRuta);
            this.Controls.Add(this.btnAgregarAlFinal);
            this.Controls.Add(this.grpPaquetesPendientes);
            this.Controls.Add(this.grpRutaVehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}

