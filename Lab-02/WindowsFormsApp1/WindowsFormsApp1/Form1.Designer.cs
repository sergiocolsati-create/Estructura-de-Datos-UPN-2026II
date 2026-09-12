namespace WindowsFormsApp1
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
            this.lstBox = new System.Windows.Forms.ListBox();
            this.btn_agregarInicio = new System.Windows.Forms.Button();
            this.btn_verLista = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_contar = new System.Windows.Forms.Button();
            this.btn_imprimirAdelante = new System.Windows.Forms.Button();
            this.btn_agregarFinal = new System.Windows.Forms.Button();
            this.btn_imprimirAtras = new System.Windows.Forms.Button();
            this.txtNuevo = new System.Windows.Forms.TextBox();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.ItemHeight = 16;
            this.lstBox.Location = new System.Drawing.Point(70, 70);
            this.lstBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(128, 308);
            this.lstBox.TabIndex = 0;
            // 
            // btn_agregarInicio
            // 
            this.btn_agregarInicio.Location = new System.Drawing.Point(272, 244);
            this.btn_agregarInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_agregarInicio.Name = "btn_agregarInicio";
            this.btn_agregarInicio.Size = new System.Drawing.Size(152, 54);
            this.btn_agregarInicio.TabIndex = 1;
            this.btn_agregarInicio.Text = "Agregar al Inicio";
            this.btn_agregarInicio.UseVisualStyleBackColor = true;
            this.btn_agregarInicio.Click += new System.EventHandler(this.btn_agregarInicio_Click);
            // 
            // btn_verLista
            // 
            this.btn_verLista.Location = new System.Drawing.Point(272, 161);
            this.btn_verLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_verLista.Name = "btn_verLista";
            this.btn_verLista.Size = new System.Drawing.Size(152, 54);
            this.btn_verLista.TabIndex = 2;
            this.btn_verLista.Text = "Ver Lista";
            this.btn_verLista.UseVisualStyleBackColor = true;
            this.btn_verLista.Click += new System.EventHandler(this.btn_verLista_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(446, 161);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(152, 55);
            this.btn_buscar.TabIndex = 3;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(446, 244);
            this.btn_modificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(150, 53);
            this.btn_modificar.TabIndex = 4;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_contar
            // 
            this.btn_contar.Location = new System.Drawing.Point(624, 161);
            this.btn_contar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_contar.Name = "btn_contar";
            this.btn_contar.Size = new System.Drawing.Size(152, 55);
            this.btn_contar.TabIndex = 5;
            this.btn_contar.Text = "Contar";
            this.btn_contar.UseVisualStyleBackColor = true;
            this.btn_contar.Click += new System.EventHandler(this.btn_contar_Click);
            // 
            // btn_imprimirAdelante
            // 
            this.btn_imprimirAdelante.Location = new System.Drawing.Point(624, 324);
            this.btn_imprimirAdelante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_imprimirAdelante.Name = "btn_imprimirAdelante";
            this.btn_imprimirAdelante.Size = new System.Drawing.Size(152, 54);
            this.btn_imprimirAdelante.TabIndex = 6;
            this.btn_imprimirAdelante.Text = "Imprimir Adelante";
            this.btn_imprimirAdelante.UseVisualStyleBackColor = true;
            this.btn_imprimirAdelante.Click += new System.EventHandler(this.btn_imprimirAdelante_Click);
            // 
            // btn_agregarFinal
            // 
            this.btn_agregarFinal.Location = new System.Drawing.Point(624, 244);
            this.btn_agregarFinal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_agregarFinal.Name = "btn_agregarFinal";
            this.btn_agregarFinal.Size = new System.Drawing.Size(152, 50);
            this.btn_agregarFinal.TabIndex = 7;
            this.btn_agregarFinal.Text = "Agregar al final";
            this.btn_agregarFinal.UseVisualStyleBackColor = true;
            this.btn_agregarFinal.Click += new System.EventHandler(this.btn_agregarFinal_Click);
            // 
            // btn_imprimirAtras
            // 
            this.btn_imprimirAtras.Location = new System.Drawing.Point(272, 324);
            this.btn_imprimirAtras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_imprimirAtras.Name = "btn_imprimirAtras";
            this.btn_imprimirAtras.Size = new System.Drawing.Size(152, 50);
            this.btn_imprimirAtras.TabIndex = 8;
            this.btn_imprimirAtras.Text = "Imprimir Atrás";
            this.btn_imprimirAtras.UseVisualStyleBackColor = true;
            this.btn_imprimirAtras.Click += new System.EventHandler(this.btn_imprimirAtras_Click);
            // 
            // txtNuevo
            // 
            this.txtNuevo.Location = new System.Drawing.Point(376, 70);
            this.txtNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNuevo.Name = "txtNuevo";
            this.txtNuevo.Size = new System.Drawing.Size(113, 22);
            this.txtNuevo.TabIndex = 9;
            // 
            // txtModifica
            // 
            this.txtModifica.Location = new System.Drawing.Point(551, 70);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(114, 22);
            this.txtModifica.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nuevo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Modifica";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(448, 323);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 53);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(82, 404);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(115, 34);
            this.btnHistorial.TabIndex = 14;
            this.btnHistorial.Text = "Ir a Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 495);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModifica);
            this.Controls.Add(this.txtNuevo);
            this.Controls.Add(this.btn_imprimirAtras);
            this.Controls.Add(this.btn_agregarFinal);
            this.Controls.Add(this.btn_imprimirAdelante);
            this.Controls.Add(this.btn_contar);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btn_verLista);
            this.Controls.Add(this.btn_agregarInicio);
            this.Controls.Add(this.lstBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Button btn_agregarInicio;
        private System.Windows.Forms.Button btn_verLista;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button btn_contar;
        private System.Windows.Forms.Button btn_imprimirAdelante;
        private System.Windows.Forms.Button btn_agregarFinal;
        private System.Windows.Forms.Button btn_imprimirAtras;
        private System.Windows.Forms.TextBox txtNuevo;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnHistorial;
    }
}

