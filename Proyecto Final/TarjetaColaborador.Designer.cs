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
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblMarca = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.lnkLinkedIn = new System.Windows.Forms.LinkLabel();
            this.lnkGitHub = new System.Windows.Forms.LinkLabel();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.pnlCabecera.Controls.Add(this.lnkGitHub);
            this.pnlCabecera.Controls.Add(this.lnkLinkedIn);
            this.pnlCabecera.Controls.Add(this.lblCarrera);
            this.pnlCabecera.Controls.Add(this.lblCodigo);
            this.pnlCabecera.Controls.Add(this.lblRol);
            this.pnlCabecera.Controls.Add(this.lblNombre);
            this.pnlCabecera.Controls.Add(this.picFoto);
            this.pnlCabecera.Controls.Add(this.lblMarca);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(248, 40);
            this.pnlCabecera.TabIndex = 0;
            // 
            // lblMarca
            // 
            this.lblMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(0, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(248, 40);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "SHALOM";
            this.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picfoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.Gainsboro;
            this.picFoto.Location = new System.Drawing.Point(75, 50);
            this.picFoto.Name = "picfoto";
            this.picFoto.Size = new System.Drawing.Size(100, 100);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 1;
            this.picFoto.TabStop = false;
            // 
            // label1
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(10, 158);
            this.lblNombre.Name = "label1";
            this.lblNombre.Size = new System.Drawing.Size(230, 40);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "label1";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRol
            // 
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lblRol.Location = new System.Drawing.Point(10, 200);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(230, 20);
            this.lblRol.TabIndex = 3;
            this.lblRol.Text = "label2";
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(10, 222);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(230, 20);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "label2";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarrera
            // 
            this.lblCarrera.Location = new System.Drawing.Point(10, 244);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(230, 20);
            this.lblCarrera.TabIndex = 5;
            this.lblCarrera.Text = "label2";
            this.lblCarrera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkLinkedIn
            // 
            this.lnkLinkedIn.AutoSize = true;
            this.lnkLinkedIn.Location = new System.Drawing.Point(60, 296);
            this.lnkLinkedIn.Name = "lnkLinkedIn";
            this.lnkLinkedIn.Size = new System.Drawing.Size(57, 16);
            this.lnkLinkedIn.TabIndex = 6;
            this.lnkLinkedIn.TabStop = true;
            this.lnkLinkedIn.Text = "LinkedIn";
            // 
            // lnkGitHub
            // 
            this.lnkGitHub.AutoSize = true;
            this.lnkGitHub.Location = new System.Drawing.Point(145, 296);
            this.lnkGitHub.Name = "lnkGitHub";
            this.lnkGitHub.Size = new System.Drawing.Size(48, 16);
            this.lnkGitHub.TabIndex = 7;
            this.lnkGitHub.TabStop = true;
            this.lnkGitHub.Text = "GitHub";
            // 
            // TarjetaColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlCabecera);
            this.Name = "TarjetaColaborador";
            this.Size = new System.Drawing.Size(248, 328);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.LinkLabel lnkGitHub;
        private System.Windows.Forms.LinkLabel lnkLinkedIn;
    }
}
