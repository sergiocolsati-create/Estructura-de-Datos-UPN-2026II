namespace Semana05
{
    partial class Reloj
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.bttnStart = new System.Windows.Forms.Button();
            this.btnCronometro = new System.Windows.Forms.Button();
            this.btnTemporizador = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblHora.Location = new System.Drawing.Point(107, 184);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(279, 55);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "00:00:00:00";
            this.lblHora.Click += new System.EventHandler(this.lblHora_Click);
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(185, 316);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(100, 20);
            this.txtTiempo.TabIndex = 2;
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(196, 371);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(75, 23);
            this.bttnStart.TabIndex = 5;
            this.bttnStart.Text = "Iniciar";
            this.bttnStart.UseVisualStyleBackColor = true;
            this.bttnStart.Click += new System.EventHandler(this.bttnStart_Click);
            // 
            // btnCronometro
            // 
            this.btnCronometro.Location = new System.Drawing.Point(374, 313);
            this.btnCronometro.Name = "btnCronometro";
            this.btnCronometro.Size = new System.Drawing.Size(90, 23);
            this.btnCronometro.TabIndex = 6;
            this.btnCronometro.Text = "Cronometro";
            this.btnCronometro.UseVisualStyleBackColor = true;
            this.btnCronometro.Click += new System.EventHandler(this.btnCronometro_Click);
            // 
            // btnTemporizador
            // 
            this.btnTemporizador.Location = new System.Drawing.Point(374, 371);
            this.btnTemporizador.Name = "btnTemporizador";
            this.btnTemporizador.Size = new System.Drawing.Size(90, 23);
            this.btnTemporizador.TabIndex = 7;
            this.btnTemporizador.Text = "Temporizador";
            this.btnTemporizador.UseVisualStyleBackColor = true;
            this.btnTemporizador.Click += new System.EventHandler(this.btnTemporizador_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ingrese Tiempo en Segundos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Reloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(498, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTemporizador);
            this.Controls.Add(this.btnCronometro);
            this.Controls.Add(this.bttnStart);
            this.Controls.Add(this.txtTiempo);
            this.Controls.Add(this.lblHora);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Reloj";
            this.Text = "Reloj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.Button bttnStart;
        private System.Windows.Forms.Button btnCronometro;
        private System.Windows.Forms.Button btnTemporizador;
        private System.Windows.Forms.Label label1;
    }
}