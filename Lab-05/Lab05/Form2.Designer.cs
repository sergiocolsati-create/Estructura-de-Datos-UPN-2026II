namespace Lab05
{
    partial class Form2
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCod = new System.Windows.Forms.TextBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.txtPaginas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnVerSig = new System.Windows.Forms.Button();
            this.lblImprimiendo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(155, 144);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(100, 22);
            this.txtCod.TabIndex = 0;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(155, 90);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(100, 22);
            this.txtArchivo.TabIndex = 1;
            // 
            // txtPaginas
            // 
            this.txtPaginas.Location = new System.Drawing.Point(155, 202);
            this.txtPaginas.Name = "txtPaginas";
            this.txtPaginas.Size = new System.Drawing.Size(100, 22);
            this.txtPaginas.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "N° documento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Archivo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "N° páginas:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(39, 358);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(121, 47);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir siguiente";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnVerSig
            // 
            this.btnVerSig.Location = new System.Drawing.Point(39, 411);
            this.btnVerSig.Name = "btnVerSig";
            this.btnVerSig.Size = new System.Drawing.Size(122, 47);
            this.btnVerSig.TabIndex = 9;
            this.btnVerSig.Text = "Ver siguiente";
            this.btnVerSig.UseVisualStyleBackColor = true;
            // 
            // lblImprimiendo
            // 
            this.lblImprimiendo.AutoSize = true;
            this.lblImprimiendo.Location = new System.Drawing.Point(328, 336);
            this.lblImprimiendo.Name = "lblImprimiendo";
            this.lblImprimiendo.Size = new System.Drawing.Size(84, 16);
            this.lblImprimiendo.TabIndex = 10;
            this.lblImprimiendo.Text = "Imprimiendo:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(328, 426);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 16);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Documentos en espera:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(40, 306);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(121, 46);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar a imprimir";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.ItemHeight = 16;
            this.lstBox.Location = new System.Drawing.Point(332, 28);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(262, 276);
            this.lstBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "COLA DE IMPRESIÓN";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 515);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblImprimiendo);
            this.Controls.Add(this.btnVerSig);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaginas);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.txtCod);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.TextBox txtPaginas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnVerSig;
        private System.Windows.Forms.Label lblImprimiendo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Label label1;
    }
}