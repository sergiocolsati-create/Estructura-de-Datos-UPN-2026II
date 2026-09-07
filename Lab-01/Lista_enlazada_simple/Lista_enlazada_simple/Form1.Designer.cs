namespace Lista_enlazada_simple
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
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.
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
            this.components = new System.ComponentModel.Container();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCódigo = new System.Windows.Forms.Label();
            this.txtCódigo = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.txtDescripción = new System.Windows.Forms.TextBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnContar = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(77, 248);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(99, 23);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar ticket";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(426, 248);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar ticket";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // lblCódigo
            // 
            this.lblCódigo.AutoSize = true;
            this.lblCódigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblCódigo.Location = new System.Drawing.Point(75, 84);
            this.lblCódigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCódigo.Name = "lblCódigo";
            this.lblCódigo.Size = new System.Drawing.Size(40, 13);
            this.lblCódigo.TabIndex = 8;
            this.lblCódigo.Text = "Código";
            // 
            // txtCódigo
            // 
            this.txtCódigo.Location = new System.Drawing.Point(143, 79);
            this.txtCódigo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCódigo.Name = "txtCódigo";
            this.txtCódigo.Size = new System.Drawing.Size(76, 20);
            this.txtCódigo.TabIndex = 9;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblDescripción.Location = new System.Drawing.Point(75, 129);
            this.lblDescripción.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(63, 13);
            this.lblDescripción.TabIndex = 10;
            this.lblDescripción.Text = "Descripción";
            // 
            // txtDescripción
            // 
            this.txtDescripción.Location = new System.Drawing.Point(143, 127);
            this.txtDescripción.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.Size = new System.Drawing.Size(76, 20);
            this.txtDescripción.TabIndex = 11;
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblPrioridad.Location = new System.Drawing.Point(75, 170);
            this.lblPrioridad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(48, 13);
            this.lblPrioridad.TabIndex = 12;
            this.lblPrioridad.Text = "Prioridad";
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.cmbPrioridad.Location = new System.Drawing.Point(143, 170);
            this.cmbPrioridad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(102, 21);
            this.cmbPrioridad.TabIndex = 13;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(249, 248);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(99, 23);
            this.btnListar.TabIndex = 14;
            this.btnListar.Text = "Mostrar tickets";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(168, 311);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 23);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar ticket";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnContar
            // 
            this.btnContar.Location = new System.Drawing.Point(364, 311);
            this.btnContar.Name = "btnContar";
            this.btnContar.Size = new System.Drawing.Size(99, 23);
            this.btnContar.TabIndex = 16;
            this.btnContar.Text = "Contar tickets";
            this.btnContar.UseVisualStyleBackColor = true;
            this.btnContar.Click += new System.EventHandler(this.btnContar_Click_1);
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(96, 384);
            this.lstBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(421, 134);
            this.lstBox.TabIndex = 17;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(202, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = " MESA TECH - TICKETS ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(641, 555);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.btnContar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.txtDescripción);
            this.Controls.Add(this.lblDescripción);
            this.Controls.Add(this.txtCódigo);
            this.Controls.Add(this.lblCódigo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnRegistrar);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "MesaTech- Grupo02";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCódigo;
        private System.Windows.Forms.TextBox txtCódigo;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.TextBox txtDescripción;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnContar;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
    }
}

