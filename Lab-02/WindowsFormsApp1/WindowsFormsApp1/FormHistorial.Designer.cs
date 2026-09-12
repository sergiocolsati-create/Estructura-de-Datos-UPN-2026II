using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class FormHistorial
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private TextBox txtPagina;
        private Button btnVisitar;
        private Button btnAtrás;
        private Button btnAdelante;
        private Label lblActual;
        private ListBox lstHistorial;

        private void InitializeComponent()
        {
            this.txtPagina = new System.Windows.Forms.TextBox();
            this.btnVisitar = new System.Windows.Forms.Button();
            this.btnAtrás = new System.Windows.Forms.Button();
            this.btnAdelante = new System.Windows.Forms.Button();
            this.lblActual = new System.Windows.Forms.Label();
            this.lstHistorial = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtPagina
            // 
            this.txtPagina.Location = new System.Drawing.Point(20, 20);
            this.txtPagina.Name = "txtPagina";
            this.txtPagina.Size = new System.Drawing.Size(100, 22);
            this.txtPagina.TabIndex = 0;
            // 
            // btnVisitar
            // 
            this.btnVisitar.Location = new System.Drawing.Point(130, 18);
            this.btnVisitar.Name = "btnVisitar";
            this.btnVisitar.Size = new System.Drawing.Size(110, 27);
            this.btnVisitar.TabIndex = 1;
            this.btnVisitar.Text = "Visitar página";
            this.btnVisitar.Click += new System.EventHandler(this.btnVisitar_Click);
            // 
            // btnAtrás
            // 
            this.btnAtrás.Location = new System.Drawing.Point(20, 55);
            this.btnAtrás.Name = "btnAtrás";
            this.btnAtrás.Size = new System.Drawing.Size(100, 27);
            this.btnAtrás.TabIndex = 2;
            this.btnAtrás.Text = "<< Atrás";
            this.btnAtrás.Click += new System.EventHandler(this.btnAtrás_Click);
            // 
            // btnAdelante
            // 
            this.btnAdelante.Location = new System.Drawing.Point(130, 55);
            this.btnAdelante.Name = "btnAdelante";
            this.btnAdelante.Size = new System.Drawing.Size(110, 27);
            this.btnAdelante.TabIndex = 3;
            this.btnAdelante.Text = "Adelante >>";
            this.btnAdelante.Click += new System.EventHandler(this.btnAdelante_Click);
            // 
            // lblActual
            // 
            this.lblActual.Location = new System.Drawing.Point(20, 95);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(300, 23);
            this.lblActual.TabIndex = 4;
            this.lblActual.Text = "Página actual: (ninguna)";
            // 
            // lstHistorial
            // 
            this.lstHistorial.ItemHeight = 16;
            this.lstHistorial.Location = new System.Drawing.Point(20, 125);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(220, 148);
            this.lstHistorial.TabIndex = 5;
            // 
            // FormHistorial
            // 
            this.ClientSize = new System.Drawing.Size(280, 300);
            this.Controls.Add(this.txtPagina);
            this.Controls.Add(this.btnVisitar);
            this.Controls.Add(this.btnAtrás);
            this.Controls.Add(this.btnAdelante);
            this.Controls.Add(this.lblActual);
            this.Controls.Add(this.lstHistorial);
            this.Name = "FormHistorial";
            this.Text = "Historial de Navegación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}