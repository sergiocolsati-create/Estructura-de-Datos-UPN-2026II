namespace Lab05
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtPrioridad = new System.Windows.Forms.TextBox();
            this.btnQueue = new System.Windows.Forms.Button();
            this.btnDequeue = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.btnIrForm2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.Location = new System.Drawing.Point(47, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label2.Location = new System.Drawing.Point(50, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(50, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prioridad";
            // 
            // txtCod
            // 
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtCod.Location = new System.Drawing.Point(142, 125);
            this.txtCod.Margin = new System.Windows.Forms.Padding(4);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(132, 23);
            this.txtCod.TabIndex = 3;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtDescrip.Location = new System.Drawing.Point(142, 166);
            this.txtDescrip.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(132, 23);
            this.txtDescrip.TabIndex = 4;
            // 
            // txtPrioridad
            // 
            this.txtPrioridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtPrioridad.Location = new System.Drawing.Point(142, 202);
            this.txtPrioridad.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrioridad.Name = "txtPrioridad";
            this.txtPrioridad.Size = new System.Drawing.Size(132, 23);
            this.txtPrioridad.TabIndex = 5;
            // 
            // btnQueue
            // 
            this.btnQueue.Location = new System.Drawing.Point(49, 355);
            this.btnQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(152, 57);
            this.btnQueue.TabIndex = 6;
            this.btnQueue.Text = "Encolar(Queue)";
            this.btnQueue.UseVisualStyleBackColor = true;
            this.btnQueue.Click += new System.EventHandler(this.btnQueue_Click);
            // 
            // btnDequeue
            // 
            this.btnDequeue.Location = new System.Drawing.Point(49, 420);
            this.btnDequeue.Margin = new System.Windows.Forms.Padding(4);
            this.btnDequeue.Name = "btnDequeue";
            this.btnDequeue.Size = new System.Drawing.Size(152, 57);
            this.btnDequeue.TabIndex = 7;
            this.btnDequeue.Text = "Desencolar(Queue)";
            this.btnDequeue.UseVisualStyleBackColor = true;
            this.btnDequeue.Click += new System.EventHandler(this.btnDequeue_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(49, 290);
            this.btnListar.Margin = new System.Windows.Forms.Padding(4);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(152, 57);
            this.btnListar.TabIndex = 8;
            this.btnListar.Text = "Mostrar Cola";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(49, 485);
            this.btnVer.Margin = new System.Windows.Forms.Padding(4);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(152, 57);
            this.btnVer.TabIndex = 9;
            this.btnVer.Text = "Consultar frente";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.ItemHeight = 16;
            this.lstBox.Location = new System.Drawing.Point(351, 90);
            this.lstBox.Margin = new System.Windows.Forms.Padding(4);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(305, 356);
            this.lstBox.TabIndex = 10;
            // 
            // btnIrForm2
            // 
            this.btnIrForm2.Location = new System.Drawing.Point(520, 485);
            this.btnIrForm2.Margin = new System.Windows.Forms.Padding(4);
            this.btnIrForm2.Name = "btnIrForm2";
            this.btnIrForm2.Size = new System.Drawing.Size(136, 57);
            this.btnIrForm2.TabIndex = 11;
            this.btnIrForm2.Text = "Ir a Cola de Impresión";
            this.btnIrForm2.UseVisualStyleBackColor = true;
            this.btnIrForm2.Click += new System.EventHandler(this.btnIrForm2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(43, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cola de Atención al Cliente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 485);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 57);
            this.button1.TabIndex = 15;
            this.button1.Text = "Ir a Implementación de la cola";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 571);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnIrForm2);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnDequeue);
            this.Controls.Add(this.btnQueue);
            this.Controls.Add(this.txtPrioridad);
            this.Controls.Add(this.txtDescrip);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtPrioridad;
        private System.Windows.Forms.Button btnQueue;
        private System.Windows.Forms.Button btnDequeue;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Button btnIrForm2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

