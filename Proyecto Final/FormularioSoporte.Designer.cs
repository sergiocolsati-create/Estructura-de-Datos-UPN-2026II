namespace SoporteShalom
{
    partial class FormularioSoporte
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Panel pnlTarjeta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblSobre;
        private System.Windows.Forms.Label lblEscribenos;
        private System.Windows.Forms.LinkLabel lnkCorreoSoporte;
        private System.Windows.Forms.Button btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.pnlTarjeta = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSobre = new System.Windows.Forms.Label();
            this.lblEscribenos = new System.Windows.Forms.Label();
            this.lnkCorreoSoporte = new System.Windows.Forms.LinkLabel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.pnlEncabezado.Controls.Add(this.lblMarca);
            this.pnlEncabezado.Controls.Add(this.lblSeparador);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(900, 112);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Arial", 27F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(58, 28);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(260, 61);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "SHALOM";
            // 
            // lblSeparador
            // 
            this.lblSeparador.BackColor = System.Drawing.Color.White;
            this.lblSeparador.Location = new System.Drawing.Point(331, 22);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(2, 68);
            this.lblSeparador.TabIndex = 1;
            // 
            // pnlTarjeta
            // 
            this.pnlTarjeta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlTarjeta.BackColor = System.Drawing.Color.White;
            this.pnlTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTarjeta.Controls.Add(this.lblTitulo);
            this.pnlTarjeta.Controls.Add(this.lblDescripcion);
            this.pnlTarjeta.Controls.Add(this.lblSobre);
            this.pnlTarjeta.Controls.Add(this.lblEscribenos);
            this.pnlTarjeta.Controls.Add(this.lnkCorreoSoporte);
            this.pnlTarjeta.Controls.Add(this.btnVolver);
            this.pnlTarjeta.Location = new System.Drawing.Point(105, 118);
            this.pnlTarjeta.Name = "pnlTarjeta";
            this.pnlTarjeta.Size = new System.Drawing.Size(690, 550);
            this.pnlTarjeta.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(31)))), ((int)(((byte)(67)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(648, 77);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Soporte";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblDescripcion.Location = new System.Drawing.Point(44, 104);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(600, 86);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "¿Tienes dudas o un problema con tu envío?\r\nContáctanos por correo y nuestro equip" +
    "o de soporte te ayudará a la brevedad.";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSobre
            // 
            this.lblSobre.Font = new System.Drawing.Font("Segoe UI Symbol", 48F);
            this.lblSobre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.lblSobre.Location = new System.Drawing.Point(281, 190);
            this.lblSobre.Name = "lblSobre";
            this.lblSobre.Size = new System.Drawing.Size(126, 117);
            this.lblSobre.TabIndex = 2;
            this.lblSobre.Text = "✉";
            this.lblSobre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEscribenos
            // 
            this.lblEscribenos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEscribenos.Location = new System.Drawing.Point(46, 297);
            this.lblEscribenos.Name = "lblEscribenos";
            this.lblEscribenos.Size = new System.Drawing.Size(600, 57);
            this.lblEscribenos.TabIndex = 3;
            this.lblEscribenos.Text = "Escríbenos a:";
            this.lblEscribenos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkCorreoSoporte
            // 
            this.lnkCorreoSoporte.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.lnkCorreoSoporte.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lnkCorreoSoporte.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
            this.lnkCorreoSoporte.Location = new System.Drawing.Point(42, 354);
            this.lnkCorreoSoporte.Name = "lnkCorreoSoporte";
            this.lnkCorreoSoporte.Size = new System.Drawing.Size(604, 87);
            this.lnkCorreoSoporte.TabIndex = 4;
            this.lnkCorreoSoporte.TabStop = true;
            this.lnkCorreoSoporte.Text = "soporte@shalom.com";
            this.lnkCorreoSoporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCorreoSoporte.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
            this.lnkCorreoSoporte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCorreoSoporte_LinkClicked);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(230, 477);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(212, 38);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormularioSoporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(900, 680);
            this.Controls.Add(this.pnlTarjeta);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 650);
            this.Name = "FormularioSoporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SHALOM – Rastreo y Envíos";
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlTarjeta.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}