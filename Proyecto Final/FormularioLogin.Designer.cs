namespace Shalom
{
    partial class FormularioLogin
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
            this.panelMarca = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblPieMarca = new System.Windows.Forms.Label();
            this.lblLema = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panelLinea = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnMostrarClave = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnColaboradores = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.panelMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMarca
            // 
            this.panelMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.panelMarca.Controls.Add(this.picLogo);
            this.panelMarca.Controls.Add(this.lblPieMarca);
            this.panelMarca.Controls.Add(this.lblLema);
            this.panelMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMarca.Location = new System.Drawing.Point(0, 0);
            this.panelMarca.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panelMarca.Name = "panelMarca";
            this.panelMarca.Size = new System.Drawing.Size(421, 596);
            this.panelMarca.TabIndex = 11;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(84, 174);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(258, 68);
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // lblPieMarca
            // 
            this.lblPieMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPieMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.lblPieMarca.Location = new System.Drawing.Point(40, 500);
            this.lblPieMarca.Name = "lblPieMarca";
            this.lblPieMarca.Size = new System.Drawing.Size(353, 30);
            this.lblPieMarca.TabIndex = 2;
            this.lblPieMarca.Text = "RASTREO  •  LOGÍSTICA  •  CONFIANZA";
            this.lblPieMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLema
            // 
            this.lblLema.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLema.ForeColor = System.Drawing.Color.White;
            this.lblLema.Location = new System.Drawing.Point(66, 261);
            this.lblLema.Name = "lblLema";
            this.lblLema.Size = new System.Drawing.Size(276, 114);
            this.lblLema.TabIndex = 1;
            this.lblLema.Text = "Gestiona el recorrido de cada envío";
            this.lblLema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblBienvenida.Location = new System.Drawing.Point(450, 39);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(470, 81);
            this.lblBienvenida.TabIndex = 12;
            this.lblBienvenida.Text = "Bienvenido";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLinea
            // 
            this.panelLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.panelLinea.Location = new System.Drawing.Point(614, 122);
            this.panelLinea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLinea.Name = "panelLinea";
            this.panelLinea.Size = new System.Drawing.Size(114, 12);
            this.panelLinea.TabIndex = 13;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblUsuario.Location = new System.Drawing.Point(458, 188);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(89, 30);
            this.lblUsuario.TabIndex = 14;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtUsuario.Location = new System.Drawing.Point(464, 222);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuario.MaxLength = 40;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(450, 42);
            this.txtUsuario.TabIndex = 15;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblContrasena.Location = new System.Drawing.Point(458, 278);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(125, 30);
            this.lblContrasena.TabIndex = 16;
            this.lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtContrasena.Location = new System.Drawing.Point(464, 312);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContrasena.MaxLength = 60;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(395, 42);
            this.txtContrasena.TabIndex = 17;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnMostrarClave
            // 
            this.btnMostrarClave.BackColor = System.Drawing.Color.White;
            this.btnMostrarClave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(158)))), ((int)(((byte)(164)))));
            this.btnMostrarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarClave.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarClave.Location = new System.Drawing.Point(880, 312);
            this.btnMostrarClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMostrarClave.Name = "btnMostrarClave";
            this.btnMostrarClave.Size = new System.Drawing.Size(60, 45);
            this.btnMostrarClave.TabIndex = 18;
            this.btnMostrarClave.Text = "Ver";
            this.btnMostrarClave.UseVisualStyleBackColor = false;
            this.btnMostrarClave.Click += new System.EventHandler(this.btnMostrarClave_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(534, 396);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(291, 70);
            this.btnIngresar.TabIndex = 19;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnColaboradores
            // 
            this.btnColaboradores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnColaboradores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(158)))), ((int)(((byte)(164)))));
            this.btnColaboradores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColaboradores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.btnColaboradores.Location = new System.Drawing.Point(717, 511);
            this.btnColaboradores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnColaboradores.Name = "btnColaboradores";
            this.btnColaboradores.Size = new System.Drawing.Size(225, 55);
            this.btnColaboradores.TabIndex = 21;
            this.btnColaboradores.Text = "Ver colaboradores";
            this.btnColaboradores.UseVisualStyleBackColor = false;
            this.btnColaboradores.Click += new System.EventHandler(this.btnColaboradores_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnAyuda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(158)))), ((int)(((byte)(164)))));
            this.btnAyuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.btnAyuda.Location = new System.Drawing.Point(453, 511);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(225, 55);
            this.btnAyuda.TabIndex = 22;
            this.btnAyuda.Text = "Centro de ayuda";
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // FormularioLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(965, 596);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.panelMarca);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.panelLinea);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnMostrarClave);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnColaboradores);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FormularioLogin";
            this.Text = "FormularioLogin";
            this.panelMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMarca;
        private System.Windows.Forms.Label lblPieMarca;
        private System.Windows.Forms.Label lblLema;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel panelLinea;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnMostrarClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnColaboradores;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnAyuda;
    }
}