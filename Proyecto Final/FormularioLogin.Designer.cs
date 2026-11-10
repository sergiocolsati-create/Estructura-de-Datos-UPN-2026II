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
            this.lblPieMarca = new System.Windows.Forms.Label();
            this.lblLema = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panelLinea = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnMostrarClave = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnInstrucciones = new System.Windows.Forms.Button();
            this.btnColaboradores = new System.Windows.Forms.Button();
            this.panelMarca.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMarca
            // 
            this.panelMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.panelMarca.Controls.Add(this.lblPieMarca);
            this.panelMarca.Controls.Add(this.lblLema);
            this.panelMarca.Controls.Add(this.lblMarca);
            this.panelMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMarca.Location = new System.Drawing.Point(0, 0);
            this.panelMarca.Name = "panelMarca";
            this.panelMarca.Size = new System.Drawing.Size(530, 646);
            this.panelMarca.TabIndex = 11;
            // 
            // lblPieMarca
            // 
            this.lblPieMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPieMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.lblPieMarca.Location = new System.Drawing.Point(32, 535);
            this.lblPieMarca.Name = "lblPieMarca";
            this.lblPieMarca.Size = new System.Drawing.Size(470, 30);
            this.lblPieMarca.TabIndex = 2;
            this.lblPieMarca.Text = "RASTREO  •  LOGÍSTICA  •  CONFIANZA";
            this.lblPieMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLema
            // 
            this.lblLema.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.lblLema.ForeColor = System.Drawing.Color.White;
            this.lblLema.Location = new System.Drawing.Point(29, 297);
            this.lblLema.Name = "lblLema";
            this.lblLema.Size = new System.Drawing.Size(474, 78);
            this.lblLema.TabIndex = 1;
            this.lblLema.Text = "Gestiona el recorrido de cada envío.";
            this.lblLema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarca
            // 
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 43F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(38, 153);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(450, 100);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "SHALOM";
            this.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblBienvenida.Location = new System.Drawing.Point(562, 90);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(470, 70);
            this.lblBienvenida.TabIndex = 12;
            this.lblBienvenida.Text = "Bienvenido";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLinea
            // 
            this.panelLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.panelLinea.Location = new System.Drawing.Point(749, 163);
            this.panelLinea.Name = "panelLinea";
            this.panelLinea.Size = new System.Drawing.Size(80, 5);
            this.panelLinea.TabIndex = 13;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblUsuario.Location = new System.Drawing.Point(562, 203);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(102, 32);
            this.lblUsuario.TabIndex = 14;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtUsuario.Location = new System.Drawing.Point(568, 238);
            this.txtUsuario.MaxLength = 40;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(450, 42);
            this.txtUsuario.TabIndex = 15;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblContrasena.Location = new System.Drawing.Point(562, 292);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(143, 32);
            this.lblContrasena.TabIndex = 16;
            this.lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtContrasena.Location = new System.Drawing.Point(568, 327);
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
            this.btnMostrarClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMostrarClave.Location = new System.Drawing.Point(973, 327);
            this.btnMostrarClave.Name = "btnMostrarClave";
            this.btnMostrarClave.Size = new System.Drawing.Size(92, 42);
            this.btnMostrarClave.TabIndex = 18;
            this.btnMostrarClave.Text = "Ver";
            this.btnMostrarClave.UseVisualStyleBackColor = false;
            this.btnMostrarClave.Click += new System.EventHandler(this.btnMostrarClave_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(568, 415);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(455, 57);
            this.btnIngresar.TabIndex = 19;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnInstrucciones
            // 
            this.btnInstrucciones.BackColor = System.Drawing.Color.White;
            this.btnInstrucciones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(158)))), ((int)(((byte)(164)))));
            this.btnInstrucciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstrucciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInstrucciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.btnInstrucciones.Location = new System.Drawing.Point(551, 517);
            this.btnInstrucciones.Name = "btnInstrucciones";
            this.btnInstrucciones.Size = new System.Drawing.Size(225, 48);
            this.btnInstrucciones.TabIndex = 20;
            this.btnInstrucciones.Text = "¿Qué es este sistema?";
            this.btnInstrucciones.UseVisualStyleBackColor = false;
            // 
            // btnColaboradores
            // 
            this.btnColaboradores.BackColor = System.Drawing.Color.White;
            this.btnColaboradores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(158)))), ((int)(((byte)(164)))));
            this.btnColaboradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColaboradores.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnColaboradores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.btnColaboradores.Location = new System.Drawing.Point(830, 517);
            this.btnColaboradores.Name = "btnColaboradores";
            this.btnColaboradores.Size = new System.Drawing.Size(225, 48);
            this.btnColaboradores.TabIndex = 21;
            this.btnColaboradores.Text = "Ver colaboradores";
            this.btnColaboradores.UseVisualStyleBackColor = false;
            // 
            // FormularioLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 646);
            this.Controls.Add(this.panelMarca);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.panelLinea);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnMostrarClave);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnInstrucciones);
            this.Controls.Add(this.btnColaboradores);
            this.Name = "FormularioLogin";
            this.Text = "FormularioLogin";
            this.panelMarca.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMarca;
        private System.Windows.Forms.Label lblPieMarca;
        private System.Windows.Forms.Label lblLema;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel panelLinea;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnMostrarClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnInstrucciones;
        private System.Windows.Forms.Button btnColaboradores;
    }
}