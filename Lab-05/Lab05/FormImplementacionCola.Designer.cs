namespace Lab05
{
    partial class FormImplementacionCola
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

        private void InitializeComponent()
        {
            this.btnListar = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.txtDato1 = new System.Windows.Forms.TextBox();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.txtDato2 = new System.Windows.Forms.TextBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.txtDato3 = new System.Windows.Forms.TextBox();
            this.btnFrente = new System.Windows.Forms.Button();
            this.btnEncolar = new System.Windows.Forms.Button();
            this.btnDesencolar = new System.Windows.Forms.Button();
            this.btnVacia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // btnListar
            //
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnListar.Location = new System.Drawing.Point(40, 60);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(140, 40);
            this.btnListar.Text = "Ver listado";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            //
            // lstBox
            //
            this.lstBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(40, 115);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(220, 280);
            //
            // lblCapacidad
            //
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblCapacidad.Location = new System.Drawing.Point(40, 20);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Text = "Elementos en cola: 0 / 5";
            //
            // lblNuevo
            //
            this.lblNuevo.AutoSize = true;
            this.lblNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNuevo.Location = new System.Drawing.Point(330, 30);
            this.lblNuevo.Name = "lblNuevo";
            this.lblNuevo.Text = "Nuevo elemento";
            //
            // lblCod
            //
            this.lblCod.AutoSize = true;
            this.lblCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblCod.Location = new System.Drawing.Point(330, 65);
            this.lblCod.Name = "lblCod";
            this.lblCod.Text = "Dato 1:";
            //
            // txtDato1
            //
            this.txtDato1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtDato1.Location = new System.Drawing.Point(420, 62);
            this.txtDato1.Name = "txtDato1";
            this.txtDato1.Size = new System.Drawing.Size(140, 23);
            //
            // lblDescrip
            //
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblDescrip.Location = new System.Drawing.Point(330, 100);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Text = "Dato 2:";
            //
            // txtDato2
            //
            this.txtDato2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtDato2.Location = new System.Drawing.Point(420, 97);
            this.txtDato2.Name = "txtDato2";
            this.txtDato2.Size = new System.Drawing.Size(140, 23);
            //
            // lblPrioridad
            //
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblPrioridad.Location = new System.Drawing.Point(330, 135);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Text = "Dato 3:";
            //
            // txtDato3
            //
            this.txtDato3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtDato3.Location = new System.Drawing.Point(420, 132);
            this.txtDato3.Name = "txtDato3";
            this.txtDato3.Size = new System.Drawing.Size(140, 23);
            //
            // btnEncolar
            //
            this.btnEncolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnEncolar.Location = new System.Drawing.Point(330, 190);
            this.btnEncolar.Name = "btnEncolar";
            this.btnEncolar.Size = new System.Drawing.Size(140, 45);
            this.btnEncolar.Text = "Encolar (enqueue)";
            this.btnEncolar.UseVisualStyleBackColor = true;
            this.btnEncolar.Click += new System.EventHandler(this.btnEncolar_Click);
            //
            // btnDesencolar
            //
            this.btnDesencolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnDesencolar.Location = new System.Drawing.Point(480, 190);
            this.btnDesencolar.Name = "btnDesencolar";
            this.btnDesencolar.Size = new System.Drawing.Size(140, 45);
            this.btnDesencolar.Text = "Desencolar (dequeue)";
            this.btnDesencolar.UseVisualStyleBackColor = true;
            this.btnDesencolar.Click += new System.EventHandler(this.btnDesencolar_Click);
            //
            // btnFrente
            //
            this.btnFrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnFrente.Location = new System.Drawing.Point(330, 245);
            this.btnFrente.Name = "btnFrente";
            this.btnFrente.Size = new System.Drawing.Size(140, 45);
            this.btnFrente.Text = "Frente (front)";
            this.btnFrente.UseVisualStyleBackColor = true;
            this.btnFrente.Click += new System.EventHandler(this.btnFrente_Click);
            //
            // btnVacia
            //
            this.btnVacia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnVacia.Location = new System.Drawing.Point(480, 245);
            this.btnVacia.Name = "btnVacia";
            this.btnVacia.Size = new System.Drawing.Size(140, 45);
            this.btnVacia.Text = "¿Vacía? (isEmpty)";
            this.btnVacia.UseVisualStyleBackColor = true;
            this.btnVacia.Click += new System.EventHandler(this.btnVacia_Click);
            //
            // FormImplementacionCola
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 450);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.lblNuevo);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.txtDato1);
            this.Controls.Add(this.lblDescrip);
            this.Controls.Add(this.txtDato2);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.txtDato3);
            this.Controls.Add(this.btnEncolar);
            this.Controls.Add(this.btnDesencolar);
            this.Controls.Add(this.btnFrente);
            this.Controls.Add(this.btnVacia);
            this.Name = "FormImplementacionCola";
            this.Text = "Implementación de la Cola";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.TextBox txtDato1;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.TextBox txtDato2;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.TextBox txtDato3;
        private System.Windows.Forms.Button btnFrente;
        private System.Windows.Forms.Button btnEncolar;
        private System.Windows.Forms.Button btnDesencolar;
        private System.Windows.Forms.Button btnVacia;
    }
}