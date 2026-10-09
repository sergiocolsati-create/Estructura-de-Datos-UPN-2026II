namespace lab4
{
    partial class Evaluacion_de_Expresiones
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpresion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lstEval = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.Label();
            this.txtRess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Evaluador Matematico";
            // 
            // txtExpresion
            // 
            this.txtExpresion.Location = new System.Drawing.Point(94, 87);
            this.txtExpresion.Name = "txtExpresion";
            this.txtExpresion.Size = new System.Drawing.Size(228, 20);
            this.txtExpresion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expresión:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(351, 85);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Evaluar";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lstEval
            // 
            this.lstEval.FormattingEnabled = true;
            this.lstEval.Location = new System.Drawing.Point(30, 217);
            this.lstEval.Name = "lstEval";
            this.lstEval.Size = new System.Drawing.Size(395, 238);
            this.lstEval.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notación Postfija:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resultado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pasos del Algoritmo:";
            // 
            // txtNota
            // 
            this.txtNota.AutoSize = true;
            this.txtNota.Location = new System.Drawing.Point(124, 127);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(0, 13);
            this.txtNota.TabIndex = 8;
            // 
            // txtRess
            // 
            this.txtRess.AutoSize = true;
            this.txtRess.Location = new System.Drawing.Point(92, 154);
            this.txtRess.Name = "txtRess";
            this.txtRess.Size = new System.Drawing.Size(0, 13);
            this.txtRess.TabIndex = 9;
            // 
            // Evaluacion_de_Expresiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 489);
            this.Controls.Add(this.txtRess);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstEval);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExpresion);
            this.Controls.Add(this.label1);
            this.Name = "Evaluacion_de_Expresiones";
            this.Text = "Evaluacion_de_Expresiones";
            this.Load += new System.EventHandler(this.Evaluacion_de_Expresiones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpresion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListBox lstEval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtNota;
        private System.Windows.Forms.Label txtRess;
    }
}