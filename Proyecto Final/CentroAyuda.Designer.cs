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
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSobre = new System.Windows.Forms.Label();
            this.lblEscribenos = new System.Windows.Forms.Label();
            this.lnkCorreoSoporte = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 29F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(479, 77);
            this.label2.TabIndex = 2;
            this.label2.Text = "Centro de ayuda";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(198)))), ((int)(((byte)(207)))));
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(284, 631);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(167, 46);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver ";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.AccessibleName = "Correo electrónico";
            this.txtCorreo.Location = new System.Drawing.Point(71, 206);
            this.txtCorreo.MaxLength = 254;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(564, 26);
            this.txtCorreo.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(0)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 124);
            this.panel1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "SHALOM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 29F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(479, 77);
            this.label4.TabIndex = 1;
            this.label4.Text = "Centro de ayuda";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(31)))), ((int)(((byte)(67)))));
            this.lblTitulo.Location = new System.Drawing.Point(57, 136);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(617, 77);
            this.lblTitulo.TabIndex = 16;
            this.lblTitulo.Text = "Soporte";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblDescripcion.Location = new System.Drawing.Point(76, 258);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(600, 86);
            this.lblDescripcion.TabIndex = 17;
            this.lblDescripcion.Text = "¿Tienes dudas o un problema con tu envío?\r\nContáctanos por correo y nuestro equip" +
    "o de soporte te ayudará a la brevedad.";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSobre
            // 
            this.lblSobre.Font = new System.Drawing.Font("Segoe UI Symbol", 48F);
            this.lblSobre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.lblSobre.Location = new System.Drawing.Point(311, 344);
            this.lblSobre.Name = "lblSobre";
            this.lblSobre.Size = new System.Drawing.Size(126, 117);
            this.lblSobre.TabIndex = 18;
            this.lblSobre.Text = "✉";
            this.lblSobre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEscribenos
            // 
            this.lblEscribenos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEscribenos.Location = new System.Drawing.Point(74, 460);
            this.lblEscribenos.Name = "lblEscribenos";
            this.lblEscribenos.Size = new System.Drawing.Size(600, 57);
            this.lblEscribenos.TabIndex = 19;
            this.lblEscribenos.Text = "Escríbenos a:";
            this.lblEscribenos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkCorreoSoporte
            // 
            this.lnkCorreoSoporte.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.lnkCorreoSoporte.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lnkCorreoSoporte.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
            this.lnkCorreoSoporte.Location = new System.Drawing.Point(72, 517);
            this.lnkCorreoSoporte.Name = "lnkCorreoSoporte";
            this.lnkCorreoSoporte.Size = new System.Drawing.Size(604, 87);
            this.lnkCorreoSoporte.TabIndex = 20;
            this.lnkCorreoSoporte.TabStop = true;
            this.lnkCorreoSoporte.Text = "soporte@shalom.com";
            this.lnkCorreoSoporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCorreoSoporte.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
            this.lnkCorreoSoporte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCorreoSoporte_LinkClicked);
            // 
            // CentroAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 744);
            this.Controls.Add(this.lnkCorreoSoporte);
            this.Controls.Add(this.lblEscribenos);
            this.Controls.Add(this.lblSobre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Name = "CentroAyuda";
            this.Text = "CentroAyuda";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblSobre;
        private System.Windows.Forms.Label lblEscribenos;
        private System.Windows.Forms.LinkLabel lnkCorreoSoporte;
    }
}