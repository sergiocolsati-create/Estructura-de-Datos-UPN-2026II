namespace Shalom
{
    partial class TarjetaColaborador
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lnkLinkedIn = new System.Windows.Forms.LinkLabel();
            this.lnkGitHub = new System.Windows.Forms.LinkLabel();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.White;
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(128, 26);
            this.picFoto.Margin = new System.Windows.Forms.Padding(4);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(146, 135);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 10;
            this.picFoto.TabStop = false;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.pnlCabecera.Controls.Add(this.lblMarca);
            this.pnlCabecera.Location = new System.Drawing.Point(-1, -5);
            this.pnlCabecera.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(404, 101);
            this.pnlCabecera.TabIndex = 11;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(13, 12);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(96, 28);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "SHALOM";
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(1, 173);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(400, 31);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRol
            // 
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lblRol.Location = new System.Drawing.Point(1, 207);
            this.lblRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(400, 27);
            this.lblRol.TabIndex = 13;
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.lblCodigo.Location = new System.Drawing.Point(1, 247);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(400, 25);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarrera
            // 
            this.lblCarrera.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCarrera.ForeColor = System.Drawing.Color.DimGray;
            this.lblCarrera.Location = new System.Drawing.Point(1, 274);
            this.lblCarrera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(400, 25);
            this.lblCarrera.TabIndex = 15;
            this.lblCarrera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurso
            // 
            this.lblCurso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCurso.ForeColor = System.Drawing.Color.DimGray;
            this.lblCurso.Location = new System.Drawing.Point(1, 301);
            this.lblCurso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(400, 25);
            this.lblCurso.TabIndex = 16;
            this.lblCurso.Text = "Estructura de datos - UPN";
            this.lblCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkLinkedIn
            // 
            this.lnkLinkedIn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkLinkedIn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lnkLinkedIn.Location = new System.Drawing.Point(1, 340);
            this.lnkLinkedIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkLinkedIn.Name = "lnkLinkedIn";
            this.lnkLinkedIn.Size = new System.Drawing.Size(400, 25);
            this.lnkLinkedIn.TabIndex = 17;
            this.lnkLinkedIn.TabStop = true;
            this.lnkLinkedIn.Text = "LinkedIn";
            this.lnkLinkedIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkGitHub
            // 
            this.lnkGitHub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkGitHub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lnkGitHub.Location = new System.Drawing.Point(1, 367);
            this.lnkGitHub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkGitHub.Name = "lnkGitHub";
            this.lnkGitHub.Size = new System.Drawing.Size(400, 25);
            this.lnkGitHub.TabIndex = 18;
            this.lnkGitHub.TabStop = true;
            this.lnkGitHub.Text = "GitHub";
            this.lnkGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGitHub_LinkClicked_1);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(128, 413);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(147, 39);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // TarjetaColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblCarrera);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.lnkLinkedIn);
            this.Controls.Add(this.lnkGitHub);
            this.Controls.Add(this.btnCerrar);
            this.Name = "TarjetaColaborador";
            this.Size = new System.Drawing.Size(402, 472);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.LinkLabel lnkLinkedIn;
        private System.Windows.Forms.LinkLabel lnkGitHub;
        private System.Windows.Forms.Button btnCerrar;
    }
}
