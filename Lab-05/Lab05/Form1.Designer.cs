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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prioridad";
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(107, 30);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(100, 20);
            this.txtCod.TabIndex = 3;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(107, 63);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(100, 20);
            this.txtDescrip.TabIndex = 4;
            // 
            // txtPrioridad
            // 
            this.txtPrioridad.Location = new System.Drawing.Point(107, 93);
            this.txtPrioridad.Name = "txtPrioridad";
            this.txtPrioridad.Size = new System.Drawing.Size(100, 20);
            this.txtPrioridad.TabIndex = 5;
            // 
            // btnQueue
            // 
            this.btnQueue.Location = new System.Drawing.Point(39, 160);
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(153, 23);
            this.btnQueue.TabIndex = 6;
            this.btnQueue.Text = "Encolar(Queue)";
            this.btnQueue.UseVisualStyleBackColor = true;
            this.btnQueue.Click += new System.EventHandler(this.btnQueue_Click);
            // 
            // btnDequeue
            // 
            this.btnDequeue.Location = new System.Drawing.Point(230, 160);
            this.btnDequeue.Name = "btnDequeue";
            this.btnDequeue.Size = new System.Drawing.Size(153, 23);
            this.btnDequeue.TabIndex = 7;
            this.btnDequeue.Text = "Desencolar(Queue)";
            this.btnDequeue.UseVisualStyleBackColor = true;
            this.btnDequeue.Click += new System.EventHandler(this.btnDequeue_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(39, 220);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(153, 23);
            this.btnListar.TabIndex = 8;
            this.btnListar.Text = "Mostrar Cola";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(230, 220);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(153, 23);
            this.btnVer.TabIndex = 9;
            this.btnVer.Text = "Consultar frente";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(425, 29);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(230, 394);
            this.lstBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 450);
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
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

