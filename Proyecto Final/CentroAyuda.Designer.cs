namespace Shalom
{
    partial class CentroAyuda
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSobre = new System.Windows.Forms.Label();
            this.lblEscribenos = new System.Windows.Forms.Label();
            this.lnkCorreoSoporte = new System.Windows.Forms.LinkLabel();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(198)))), ((int)(((byte)(207)))));
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(159, 474);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(198, 47);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver ";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(115, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 38);
            this.label4.TabIndex = 1;
            this.label4.Text = "CENTRO DE AYUDA";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 175);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(485, 88);
            this.lblDescripcion.TabIndex = 17;
            this.lblDescripcion.Text = "¿Tienes dudas o un problema con tu envío?\r\nContáctanos por correo y nuestro equip" +
    "o de soporte te ayudará a la brevedad";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSobre
            // 
            this.lblSobre.Font = new System.Drawing.Font("Segoe UI Symbol", 48F);
            this.lblSobre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.lblSobre.Location = new System.Drawing.Point(213, 263);
            this.lblSobre.Name = "lblSobre";
            this.lblSobre.Size = new System.Drawing.Size(91, 113);
            this.lblSobre.TabIndex = 18;
            this.lblSobre.Text = "✉";
            this.lblSobre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEscribenos
            // 
            this.lblEscribenos.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEscribenos.Location = new System.Drawing.Point(164, 355);
            this.lblEscribenos.Name = "lblEscribenos";
            this.lblEscribenos.Size = new System.Drawing.Size(188, 46);
            this.lblEscribenos.TabIndex = 19;
            this.lblEscribenos.Text = "Escríbenos a:";
            this.lblEscribenos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkCorreoSoporte
            // 
            this.lnkCorreoSoporte.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.lnkCorreoSoporte.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCorreoSoporte.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
            this.lnkCorreoSoporte.Location = new System.Drawing.Point(136, 401);
            this.lnkCorreoSoporte.Name = "lnkCorreoSoporte";
            this.lnkCorreoSoporte.Size = new System.Drawing.Size(244, 53);
            this.lnkCorreoSoporte.TabIndex = 20;
            this.lnkCorreoSoporte.TabStop = true;
            this.lnkCorreoSoporte.Text = "soporte@shalom.com";
            this.lnkCorreoSoporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCorreoSoporte.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
            this.lnkCorreoSoporte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCorreoSoporte_LinkClicked);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.pnlCabecera.Controls.Add(this.pictureBox1);
            this.pnlCabecera.Controls.Add(this.label4);
            this.pnlCabecera.Location = new System.Drawing.Point(-1, 1);
            this.pnlCabecera.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(524, 141);
            this.pnlCabecera.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(142, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 54);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CentroAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 565);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.lnkCorreoSoporte);
            this.Controls.Add(this.lblEscribenos);
            this.Controls.Add(this.lblSobre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnVolver);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CentroAyuda";
            this.Text = "CentroAyuda";
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblSobre;
        private System.Windows.Forms.Label lblEscribenos;
        private System.Windows.Forms.LinkLabel lnkCorreoSoporte;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}