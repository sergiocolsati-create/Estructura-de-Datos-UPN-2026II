namespace Semana05
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
            this.bttnListar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevo = new System.Windows.Forms.TextBox();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.bttnAddfirtst = new System.Windows.Forms.Button();
            this.bttnAddLast = new System.Windows.Forms.Button();
            this.bttnSearch = new System.Windows.Forms.Button();
            this.bttnEdit = new System.Windows.Forms.Button();
            this.bttnDelete = new System.Windows.Forms.Button();
            this.btnReloj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(33, 103);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(91, 199);
            this.lstBox.TabIndex = 0;
            // 
            // bttnListar
            // 
            this.bttnListar.Location = new System.Drawing.Point(36, 38);
            this.bttnListar.Name = "bttnListar";
            this.bttnListar.Size = new System.Drawing.Size(87, 30);
            this.bttnListar.TabIndex = 1;
            this.bttnListar.Text = "Ver Lista";
            this.bttnListar.UseVisualStyleBackColor = true;
            this.bttnListar.Click += new System.EventHandler(this.bttnListar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nuevo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modificar";
            // 
            // txtNuevo
            // 
            this.txtNuevo.Location = new System.Drawing.Point(215, 49);
            this.txtNuevo.Name = "txtNuevo";
            this.txtNuevo.Size = new System.Drawing.Size(117, 20);
            this.txtNuevo.TabIndex = 4;
            // 
            // txtModifica
            // 
            this.txtModifica.Location = new System.Drawing.Point(365, 48);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(117, 20);
            this.txtModifica.TabIndex = 5;
            // 
            // bttnAddfirtst
            // 
            this.bttnAddfirtst.Location = new System.Drawing.Point(215, 103);
            this.bttnAddfirtst.Name = "bttnAddfirtst";
            this.bttnAddfirtst.Size = new System.Drawing.Size(87, 30);
            this.bttnAddfirtst.TabIndex = 6;
            this.bttnAddfirtst.Text = "Al Inicio";
            this.bttnAddfirtst.UseVisualStyleBackColor = true;
            this.bttnAddfirtst.Click += new System.EventHandler(this.bttnAddfirtst_Click);
            // 
            // bttnAddLast
            // 
            this.bttnAddLast.Location = new System.Drawing.Point(215, 154);
            this.bttnAddLast.Name = "bttnAddLast";
            this.bttnAddLast.Size = new System.Drawing.Size(87, 30);
            this.bttnAddLast.TabIndex = 7;
            this.bttnAddLast.Text = "Al Final";
            this.bttnAddLast.UseVisualStyleBackColor = true;
            this.bttnAddLast.Click += new System.EventHandler(this.bttnAddLast_Click);
            // 
            // bttnSearch
            // 
            this.bttnSearch.Location = new System.Drawing.Point(217, 208);
            this.bttnSearch.Name = "bttnSearch";
            this.bttnSearch.Size = new System.Drawing.Size(84, 28);
            this.bttnSearch.TabIndex = 8;
            this.bttnSearch.Text = "Buscar";
            this.bttnSearch.UseVisualStyleBackColor = true;
            this.bttnSearch.Click += new System.EventHandler(this.bttnSearch_Click);
            // 
            // bttnEdit
            // 
            this.bttnEdit.Location = new System.Drawing.Point(215, 258);
            this.bttnEdit.Name = "bttnEdit";
            this.bttnEdit.Size = new System.Drawing.Size(84, 28);
            this.bttnEdit.TabIndex = 9;
            this.bttnEdit.Text = "Modificar";
            this.bttnEdit.UseVisualStyleBackColor = true;
            this.bttnEdit.Click += new System.EventHandler(this.button1_Click);
            // 
            // bttnDelete
            // 
            this.bttnDelete.Location = new System.Drawing.Point(215, 310);
            this.bttnDelete.Name = "bttnDelete";
            this.bttnDelete.Size = new System.Drawing.Size(80, 28);
            this.bttnDelete.TabIndex = 10;
            this.bttnDelete.Text = "Eliminar";
            this.bttnDelete.UseVisualStyleBackColor = true;
            this.bttnDelete.Click += new System.EventHandler(this.bttnDelete_Click);
            // 
            // btnReloj
            // 
            this.btnReloj.Location = new System.Drawing.Point(41, 387);
            this.btnReloj.Name = "btnReloj";
            this.btnReloj.Size = new System.Drawing.Size(111, 26);
            this.btnReloj.TabIndex = 11;
            this.btnReloj.Text = "Ver Hora";
            this.btnReloj.UseVisualStyleBackColor = true;
            this.btnReloj.Click += new System.EventHandler(this.btnReloj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.Controls.Add(this.btnReloj);
            this.Controls.Add(this.bttnDelete);
            this.Controls.Add(this.bttnEdit);
            this.Controls.Add(this.bttnSearch);
            this.Controls.Add(this.bttnAddLast);
            this.Controls.Add(this.bttnAddfirtst);
            this.Controls.Add(this.txtModifica);
            this.Controls.Add(this.txtNuevo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnListar);
            this.Controls.Add(this.lstBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Button bttnListar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNuevo;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.Button bttnAddfirtst;
        private System.Windows.Forms.Button bttnAddLast;
        private System.Windows.Forms.Button bttnSearch;
        private System.Windows.Forms.Button bttnEdit;
        private System.Windows.Forms.Button bttnDelete;
        private System.Windows.Forms.Button btnReloj;
    }
}

