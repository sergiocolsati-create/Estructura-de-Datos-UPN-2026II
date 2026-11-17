using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Shalom
{
    partial class RastreoYLogística
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.miIngreso = new System.Windows.Forms.ToolStripMenuItem();
            this.miAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.miCarga = new System.Windows.Forms.ToolStripMenuItem();
            this.miRutas = new System.Windows.Forms.ToolStripMenuItem();
            this.miRastreo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOperaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSesion = new System.Windows.Forms.ToolStripStatusLabel();
            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.grpResumen = new System.Windows.Forms.GroupBox();
            this.pnlEntregados = new System.Windows.Forms.Panel();
            this.lblTituloEntregados = new System.Windows.Forms.Label();
            this.lblIconoEntregados = new System.Windows.Forms.Label();
            this.lblEntregados = new System.Windows.Forms.Label();
            this.pnlRuta = new System.Windows.Forms.Panel();
            this.lblTituloRuta = new System.Windows.Forms.Label();
            this.lblIconoRuta = new System.Windows.Forms.Label();
            this.lblEnRuta = new System.Windows.Forms.Label();
            this.pnlAlmacen = new System.Windows.Forms.Panel();
            this.lblTituloAlmacen = new System.Windows.Forms.Label();
            this.lblIconoAlmacen = new System.Windows.Forms.Label();
            this.lblEnAlmacen = new System.Windows.Forms.Label();
            this.pnlCola = new System.Windows.Forms.Panel();
            this.lblTituloCola = new System.Windows.Forms.Label();
            this.lblIconoCola = new System.Windows.Forms.Label();
            this.lblEnCola = new System.Windows.Forms.Label();
            this.grpRastreo = new System.Windows.Forms.GroupBox();
            this.txtGuia = new System.Windows.Forms.TextBox();
            this.btnBuscarEnvio = new System.Windows.Forms.Button();
            this.lnkRastreoCompleto = new System.Windows.Forms.LinkLabel();
            this.lblTituloGuia = new System.Windows.Forms.Label();
            this.grpVehiculos = new System.Windows.Forms.GroupBox();
            this.dgvVehiculos = new System.Windows.Forms.DataGridView();
            this.colPlaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaquetes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnkPendientesRuta = new System.Windows.Forms.LinkLabel();
            this.btnVerCarga = new System.Windows.Forms.Button();
            this.lblSeleccionado = new System.Windows.Forms.Label();
            this.lblTituloSeleccionado = new System.Windows.Forms.Label();
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRastreo = new System.Windows.Forms.Button();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSede = new System.Windows.Forms.Label();
            this.lnkDesarrollador = new System.Windows.Forms.LinkLabel();
            this.lblIconoUsuario = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.barraEstado.SuspendLayout();
            this.grpResumen.SuspendLayout();
            this.pnlEntregados.SuspendLayout();
            this.pnlRuta.SuspendLayout();
            this.pnlAlmacen.SuspendLayout();
            this.pnlCola.SuspendLayout();
            this.grpRastreo.SuspendLayout();
            this.grpVehiculos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
            this.pnlNavegacion.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // miIngreso
            // 
            this.miIngreso.Name = "miIngreso";
            this.miIngreso.Size = new System.Drawing.Size(227, 26);
            this.miIngreso.Text = "Ingreso de envíos";
            this.miIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // miAlmacen
            // 
            this.miAlmacen.Name = "miAlmacen";
            this.miAlmacen.Size = new System.Drawing.Size(227, 26);
            this.miAlmacen.Text = "Almacén";
            this.miAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // miCarga
            // 
            this.miCarga.Name = "miCarga";
            this.miCarga.Size = new System.Drawing.Size(227, 26);
            this.miCarga.Text = "Carga de vehículos";
            this.miCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // miRutas
            // 
            this.miRutas.Name = "miRutas";
            this.miRutas.Size = new System.Drawing.Size(227, 26);
            this.miRutas.Text = "Asignación de rutas";
            this.miRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // miRastreo
            // 
            this.miRastreo.Name = "miRastreo";
            this.miRastreo.Size = new System.Drawing.Size(227, 26);
            this.miRastreo.Text = "Rastreo de envíos";
            this.miRastreo.Click += new System.EventHandler(this.btnRastreo_Click);
            // 
            // menuOperaciones
            // 
            this.menuOperaciones.BackColor = System.Drawing.Color.White;
            this.menuOperaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miIngreso,
            this.miAlmacen,
            this.miCarga,
            this.miRutas,
            this.miRastreo});
            this.menuOperaciones.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOperaciones.Name = "menuOperaciones";
            this.menuOperaciones.Size = new System.Drawing.Size(108, 24);
            this.menuOperaciones.Text = "Operaciones";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOperaciones});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 70);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Padding = new System.Windows.Forms.Padding(14, 8, 0, 8);
            this.menuPrincipal.Size = new System.Drawing.Size(1241, 40);
            this.menuPrincipal.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(1220, 20);
            this.lblEstado.Spring = true;
            this.lblEstado.Text = "Listo";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSesion
            // 
            this.lblSesion.Name = "lblSesion";
            this.lblSesion.Size = new System.Drawing.Size(0, 20);
            this.lblSesion.Visible = false;
            // 
            // barraEstado
            // 
            this.barraEstado.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado,
            this.lblSesion});
            this.barraEstado.Location = new System.Drawing.Point(0, 774);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.barraEstado.Size = new System.Drawing.Size(1241, 26);
            this.barraEstado.SizingGrip = false;
            this.barraEstado.TabIndex = 2;
            // 
            // grpResumen
            // 
            this.grpResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResumen.BackColor = System.Drawing.Color.White;
            this.grpResumen.Controls.Add(this.pnlEntregados);
            this.grpResumen.Controls.Add(this.pnlRuta);
            this.grpResumen.Controls.Add(this.pnlAlmacen);
            this.grpResumen.Controls.Add(this.pnlCola);
            this.grpResumen.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResumen.Location = new System.Drawing.Point(238, 108);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Size = new System.Drawing.Size(972, 116);
            this.grpResumen.TabIndex = 4;
            this.grpResumen.TabStop = false;
            this.grpResumen.Text = "Resumen de envíos";
            // 
            // pnlEntregados
            // 
            this.pnlEntregados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.pnlEntregados.Controls.Add(this.lblIconoEntregados);
            this.pnlEntregados.Controls.Add(this.lblTituloEntregados);
            this.pnlEntregados.Controls.Add(this.lblEntregados);
            this.pnlEntregados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEntregados.Location = new System.Drawing.Point(750, 29);
            this.pnlEntregados.Name = "pnlEntregados";
            this.pnlEntregados.Size = new System.Drawing.Size(180, 75);
            this.pnlEntregados.TabIndex = 5;
            // 
            // lblIconoEntregados
            // 
            this.lblIconoEntregados.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIconoEntregados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblIconoEntregados.Location = new System.Drawing.Point(8, 14);
            this.lblIconoEntregados.Name = "lblIconoEntregados";
            this.lblIconoEntregados.Size = new System.Drawing.Size(46, 46);
            this.lblIconoEntregados.Text = "✔";
            this.lblIconoEntregados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloEntregados
            // 
            this.lblTituloEntregados.AutoSize = true;
            this.lblTituloEntregados.Location = new System.Drawing.Point(62, 44);
            this.lblTituloEntregados.Name = "lblTituloEntregados";
            this.lblTituloEntregados.Size = new System.Drawing.Size(79, 20);
            this.lblTituloEntregados.TabIndex = 4;
            this.lblTituloEntregados.Text = "Entregados";
            // 
            // lblEntregados
            // 
            this.lblEntregados.AutoSize = true;
            this.lblEntregados.Location = new System.Drawing.Point(60, 6);
            this.lblEntregados.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEntregados.Name = "lblEntregados";
            this.lblEntregados.Size = new System.Drawing.Size(17, 20);
            this.lblEntregados.TabIndex = 0;
            this.lblEntregados.Text = "0";
            // 
            // pnlRuta
            // 
            this.pnlRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.pnlRuta.Controls.Add(this.lblIconoRuta);
            this.pnlRuta.Controls.Add(this.lblTituloRuta);
            this.pnlRuta.Controls.Add(this.lblEnRuta);
            this.pnlRuta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRuta.Location = new System.Drawing.Point(520, 29);
            this.pnlRuta.Name = "pnlRuta";
            this.pnlRuta.Size = new System.Drawing.Size(180, 75);
            this.pnlRuta.TabIndex = 5;
            // 
            // lblIconoRuta
            // 
            this.lblIconoRuta.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIconoRuta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.lblIconoRuta.Location = new System.Drawing.Point(8, 14);
            this.lblIconoRuta.Name = "lblIconoRuta";
            this.lblIconoRuta.Size = new System.Drawing.Size(46, 46);
            this.lblIconoRuta.Text = "🚚";
            this.lblIconoRuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloRuta
            // 
            this.lblTituloRuta.AutoSize = true;
            this.lblTituloRuta.Location = new System.Drawing.Point(62, 44);
            this.lblTituloRuta.Name = "lblTituloRuta";
            this.lblTituloRuta.Size = new System.Drawing.Size(54, 20);
            this.lblTituloRuta.TabIndex = 3;
            this.lblTituloRuta.Text = "En ruta";
            // 
            // lblEnRuta
            // 
            this.lblEnRuta.AutoSize = true;
            this.lblEnRuta.Location = new System.Drawing.Point(60, 6);
            this.lblEnRuta.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEnRuta.Name = "lblEnRuta";
            this.lblEnRuta.Size = new System.Drawing.Size(17, 20);
            this.lblEnRuta.TabIndex = 0;
            this.lblEnRuta.Text = "0";
            // 
            // pnlAlmacen
            // 
            this.pnlAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.pnlAlmacen.Controls.Add(this.lblIconoAlmacen);
            this.pnlAlmacen.Controls.Add(this.lblTituloAlmacen);
            this.pnlAlmacen.Controls.Add(this.lblEnAlmacen);
            this.pnlAlmacen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAlmacen.Location = new System.Drawing.Point(290, 29);
            this.pnlAlmacen.Name = "pnlAlmacen";
            this.pnlAlmacen.Size = new System.Drawing.Size(180, 75);
            this.pnlAlmacen.TabIndex = 5;
            // 
            // lblIconoAlmacen
            // 
            this.lblIconoAlmacen.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIconoAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblIconoAlmacen.Location = new System.Drawing.Point(8, 14);
            this.lblIconoAlmacen.Name = "lblIconoAlmacen";
            this.lblIconoAlmacen.Size = new System.Drawing.Size(46, 46);
            this.lblIconoAlmacen.Text = "📦";
            this.lblIconoAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloAlmacen
            // 
            this.lblTituloAlmacen.AutoSize = true;
            this.lblTituloAlmacen.Location = new System.Drawing.Point(62, 44);
            this.lblTituloAlmacen.Name = "lblTituloAlmacen";
            this.lblTituloAlmacen.Size = new System.Drawing.Size(83, 20);
            this.lblTituloAlmacen.TabIndex = 2;
            this.lblTituloAlmacen.Text = "En almacén";
            // 
            // lblEnAlmacen
            // 
            this.lblEnAlmacen.AutoSize = true;
            this.lblEnAlmacen.Location = new System.Drawing.Point(60, 6);
            this.lblEnAlmacen.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEnAlmacen.Name = "lblEnAlmacen";
            this.lblEnAlmacen.Size = new System.Drawing.Size(17, 20);
            this.lblEnAlmacen.TabIndex = 0;
            this.lblEnAlmacen.Text = "0";
            // 
            // pnlCola
            // 
            this.pnlCola.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.pnlCola.Controls.Add(this.lblIconoCola);
            this.pnlCola.Controls.Add(this.lblTituloCola);
            this.pnlCola.Controls.Add(this.lblEnCola);
            this.pnlCola.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCola.Location = new System.Drawing.Point(60, 29);
            this.pnlCola.Name = "pnlCola";
            this.pnlCola.Size = new System.Drawing.Size(180, 75);
            this.pnlCola.TabIndex = 4;
            // 
            // lblIconoCola
            // 
            this.lblIconoCola.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIconoCola.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblIconoCola.Location = new System.Drawing.Point(8, 14);
            this.lblIconoCola.Name = "lblIconoCola";
            this.lblIconoCola.Size = new System.Drawing.Size(46, 46);
            this.lblIconoCola.Text = "📥";
            this.lblIconoCola.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloCola
            // 
            this.lblTituloCola.AutoSize = true;
            this.lblTituloCola.Location = new System.Drawing.Point(62, 44);
            this.lblTituloCola.Name = "lblTituloCola";
            this.lblTituloCola.Size = new System.Drawing.Size(55, 20);
            this.lblTituloCola.TabIndex = 1;
            this.lblTituloCola.Text = "En cola";
            // 
            // lblEnCola
            // 
            this.lblEnCola.AutoSize = true;
            this.lblEnCola.Location = new System.Drawing.Point(60, 6);
            this.lblEnCola.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEnCola.Name = "lblEnCola";
            this.lblEnCola.Size = new System.Drawing.Size(17, 20);
            this.lblEnCola.TabIndex = 0;
            this.lblEnCola.Text = "0";
            // 
            // grpRastreo
            // 
            this.grpRastreo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRastreo.BackColor = System.Drawing.Color.White;
            this.grpRastreo.Controls.Add(this.txtGuia);
            this.grpRastreo.Controls.Add(this.btnBuscarEnvio);
            this.grpRastreo.Controls.Add(this.lnkRastreoCompleto);
            this.grpRastreo.Controls.Add(this.lblTituloGuia);
            this.grpRastreo.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRastreo.Location = new System.Drawing.Point(238, 230);
            this.grpRastreo.Name = "grpRastreo";
            this.grpRastreo.Size = new System.Drawing.Size(972, 98);
            this.grpRastreo.TabIndex = 5;
            this.grpRastreo.TabStop = false;
            this.grpRastreo.Text = "Rastreo rápido";
            // 
            // txtGuia
            // 
            this.txtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGuia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuia.Location = new System.Drawing.Point(138, 36);
            this.txtGuia.Name = "txtGuia";
            this.txtGuia.Size = new System.Drawing.Size(160, 27);
            this.txtGuia.TabIndex = 6;
            // 
            // btnBuscarEnvio
            // 
            this.btnBuscarEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnBuscarEnvio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarEnvio.ForeColor = System.Drawing.Color.White;
            this.btnBuscarEnvio.Location = new System.Drawing.Point(331, 34);
            this.btnBuscarEnvio.Name = "btnBuscarEnvio";
            this.btnBuscarEnvio.Size = new System.Drawing.Size(189, 37);
            this.btnBuscarEnvio.TabIndex = 5;
            this.btnBuscarEnvio.Text = "Buscar envío";
            this.btnBuscarEnvio.UseVisualStyleBackColor = false;
            this.btnBuscarEnvio.Click += new System.EventHandler(this.btnBuscarEnvio_Click);
            // 
            // lnkRastreoCompleto
            // 
            this.lnkRastreoCompleto.AutoSize = true;
            this.lnkRastreoCompleto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRastreoCompleto.Location = new System.Drawing.Point(49, 63);
            this.lnkRastreoCompleto.Name = "lnkRastreoCompleto";
            this.lnkRastreoCompleto.Size = new System.Drawing.Size(160, 20);
            this.lnkRastreoCompleto.TabIndex = 5;
            this.lnkRastreoCompleto.TabStop = true;
            this.lnkRastreoCompleto.Text = "Abrir rastreo completo";
            this.lnkRastreoCompleto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRastreoCompleto_LinkClicked);
            // 
            // lblTituloGuia
            // 
            this.lblTituloGuia.AutoSize = true;
            this.lblTituloGuia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGuia.Location = new System.Drawing.Point(49, 36);
            this.lblTituloGuia.Name = "lblTituloGuia";
            this.lblTituloGuia.Size = new System.Drawing.Size(83, 20);
            this.lblTituloGuia.TabIndex = 0;
            this.lblTituloGuia.Text = "N° de guía:";
            // 
            // grpVehiculos
            // 
            this.grpVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVehiculos.BackColor = System.Drawing.Color.White;
            this.grpVehiculos.Controls.Add(this.dgvVehiculos);
            this.grpVehiculos.Controls.Add(this.lnkPendientesRuta);
            this.grpVehiculos.Controls.Add(this.btnVerCarga);
            this.grpVehiculos.Controls.Add(this.lblSeleccionado);
            this.grpVehiculos.Controls.Add(this.lblTituloSeleccionado);
            this.grpVehiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVehiculos.Location = new System.Drawing.Point(238, 334);
            this.grpVehiculos.Name = "grpVehiculos";
            this.grpVehiculos.Size = new System.Drawing.Size(972, 441);
            this.grpVehiculos.TabIndex = 6;
            this.grpVehiculos.TabStop = false;
            this.grpVehiculos.Text = "Vehículos y carga";
            // 
            // dgvVehiculos
            // 
            this.dgvVehiculos.AllowUserToAddRows = false;
            this.dgvVehiculos.AllowUserToDeleteRows = false;
            this.dgvVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehiculos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVehiculos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlaca,
            this.colEstado,
            this.colPaquetes,
            this.colCarga});
            this.dgvVehiculos.Location = new System.Drawing.Point(18, 28);
            this.dgvVehiculos.MultiSelect = false;
            this.dgvVehiculos.Name = "dgvVehiculos";
            this.dgvVehiculos.ReadOnly = true;
            this.dgvVehiculos.RowHeadersVisible = false;
            this.dgvVehiculos.RowHeadersWidth = 51;
            this.dgvVehiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehiculos.Size = new System.Drawing.Size(948, 345);
            this.dgvVehiculos.TabIndex = 5;
            this.dgvVehiculos.SelectionChanged += new System.EventHandler(this.dgvVehiculos_SelectionChanged);
            // 
            // colPlaca
            // 
            this.colPlaca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlaca.FillWeight = 18F;
            this.colPlaca.HeaderText = "Placa";
            this.colPlaca.MinimumWidth = 6;
            this.colPlaca.Name = "colPlaca";
            this.colPlaca.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEstado.FillWeight = 18F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colPaquetes
            // 
            this.colPaquetes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPaquetes.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPaquetes.FillWeight = 32F;
            this.colPaquetes.HeaderText = "Paquetes";
            this.colPaquetes.MinimumWidth = 6;
            this.colPaquetes.Name = "colPaquetes";
            this.colPaquetes.ReadOnly = true;
            // 
            // colCarga
            // 
            this.colCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCarga.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCarga.FillWeight = 32F;
            this.colCarga.HeaderText = "Carga";
            this.colCarga.MinimumWidth = 6;
            this.colCarga.Name = "colCarga";
            this.colCarga.ReadOnly = true;
            // 
            // lnkPendientesRuta
            // 
            this.lnkPendientesRuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkPendientesRuta.AutoSize = true;
            this.lnkPendientesRuta.Location = new System.Drawing.Point(229, 400);
            this.lnkPendientesRuta.Name = "lnkPendientesRuta";
            this.lnkPendientesRuta.Size = new System.Drawing.Size(164, 16);
            this.lnkPendientesRuta.TabIndex = 4;
            this.lnkPendientesRuta.TabStop = true;
            this.lnkPendientesRuta.Text = "Ver pendientes de ruta";
            this.lnkPendientesRuta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPendientesRuta_LinkClicked);
            // 
            // btnVerCarga
            // 
            this.btnVerCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerCarga.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnVerCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCarga.ForeColor = System.Drawing.Color.White;
            this.btnVerCarga.Location = new System.Drawing.Point(20, 383);
            this.btnVerCarga.Name = "btnVerCarga";
            this.btnVerCarga.Size = new System.Drawing.Size(189, 51);
            this.btnVerCarga.TabIndex = 2;
            this.btnVerCarga.Text = "Ver carga del vehículo";
            this.btnVerCarga.UseVisualStyleBackColor = false;
            this.btnVerCarga.Click += new System.EventHandler(this.btnVerCarga_Click);
            // 
            // lblSeleccionado
            // 
            this.lblSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeleccionado.AutoSize = true;
            this.lblSeleccionado.Location = new System.Drawing.Point(891, 404);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(12, 16);
            this.lblSeleccionado.TabIndex = 1;
            this.lblSeleccionado.Text = "-";
            // 
            // lblTituloSeleccionado
            // 
            this.lblTituloSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloSeleccionado.AutoSize = true;
            this.lblTituloSeleccionado.Location = new System.Drawing.Point(772, 404);
            this.lblTituloSeleccionado.Name = "lblTituloSeleccionado";
            this.lblTituloSeleccionado.Size = new System.Drawing.Size(71, 16);
            this.lblTituloSeleccionado.TabIndex = 0;
            this.lblTituloSeleccionado.Text = "Vehículo:";
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(58)))));
            this.pnlNavegacion.Controls.Add(this.btnAyuda);
            this.pnlNavegacion.Controls.Add(this.btnSalir);
            this.pnlNavegacion.Controls.Add(this.btnReportes);
            this.pnlNavegacion.Controls.Add(this.label5);
            this.pnlNavegacion.Controls.Add(this.label4);
            this.pnlNavegacion.Controls.Add(this.label3);
            this.pnlNavegacion.Controls.Add(this.btnRastreo);
            this.pnlNavegacion.Controls.Add(this.btnRutas);
            this.pnlNavegacion.Controls.Add(this.btnCarga);
            this.pnlNavegacion.Controls.Add(this.btnAlmacen);
            this.pnlNavegacion.Controls.Add(this.btnActualizar);
            this.pnlNavegacion.Controls.Add(this.btnIngreso);
            this.pnlNavegacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavegacion.Location = new System.Drawing.Point(0, 110);
            this.pnlNavegacion.Name = "pnlNavegacion";
            this.pnlNavegacion.Size = new System.Drawing.Size(220, 664);
            this.pnlNavegacion.TabIndex = 7;
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnAyuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnAyuda.Location = new System.Drawing.Point(12, 563);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAyuda.Size = new System.Drawing.Size(196, 38);
            this.btnAyuda.TabIndex = 11;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnSalir.Location = new System.Drawing.Point(12, 607);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(196, 38);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnReportes.Location = new System.Drawing.Point(16, 441);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(196, 38);
            this.btnReportes.TabIndex = 9;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.label5.Location = new System.Drawing.Point(13, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "CONSULTAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "PROCESOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "GENERAL";
            // 
            // btnRastreo
            // 
            this.btnRastreo.FlatAppearance.BorderSize = 0;
            this.btnRastreo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnRastreo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnRastreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRastreo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRastreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnRastreo.Location = new System.Drawing.Point(16, 397);
            this.btnRastreo.Name = "btnRastreo";
            this.btnRastreo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnRastreo.Size = new System.Drawing.Size(196, 38);
            this.btnRastreo.TabIndex = 5;
            this.btnRastreo.Text = "Rastreo de envíos";
            this.btnRastreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRastreo.UseVisualStyleBackColor = false;
            this.btnRastreo.Click += new System.EventHandler(this.btnRastreo_Click);
            // 
            // btnRutas
            // 
            this.btnRutas.FlatAppearance.BorderSize = 0;
            this.btnRutas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnRutas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRutas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnRutas.Location = new System.Drawing.Point(16, 295);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnRutas.Size = new System.Drawing.Size(196, 38);
            this.btnRutas.TabIndex = 4;
            this.btnRutas.Text = "Asignación de rutas";
            this.btnRutas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRutas.UseVisualStyleBackColor = false;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // btnCarga
            // 
            this.btnCarga.FlatAppearance.BorderSize = 0;
            this.btnCarga.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnCarga.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarga.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnCarga.Location = new System.Drawing.Point(14, 251);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCarga.Size = new System.Drawing.Size(196, 38);
            this.btnCarga.TabIndex = 3;
            this.btnCarga.Text = "Carga de Vehículos";
            this.btnCarga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarga.UseVisualStyleBackColor = false;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.FlatAppearance.BorderSize = 0;
            this.btnAlmacen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnAlmacen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlmacen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnAlmacen.Location = new System.Drawing.Point(16, 207);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAlmacen.Size = new System.Drawing.Size(196, 38);
            this.btnAlmacen.TabIndex = 2;
            this.btnAlmacen.Text = "Almacén";
            this.btnAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlmacen.UseVisualStyleBackColor = false;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnActualizar.Location = new System.Drawing.Point(15, 64);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnActualizar.Size = new System.Drawing.Size(196, 38);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar panel";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.FlatAppearance.BorderSize = 0;
            this.btnIngreso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.btnIngreso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngreso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.btnIngreso.Location = new System.Drawing.Point(16, 163);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnIngreso.Size = new System.Drawing.Size(196, 38);
            this.btnIngreso.TabIndex = 0;
            this.btnIngreso.Text = "Ingreso de envíos";
            this.btnIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.pnlCabecera.Controls.Add(this.lblIconoUsuario);
            this.pnlCabecera.Controls.Add(this.lnkDesarrollador);
            this.pnlCabecera.Controls.Add(this.lblSede);
            this.pnlCabecera.Controls.Add(this.lblUsuario);
            this.pnlCabecera.Controls.Add(this.label2);
            this.pnlCabecera.Controls.Add(this.label1);
            this.pnlCabecera.Controls.Add(this.picLogo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1241, 70);
            this.pnlCabecera.TabIndex = 8;
            // 
            // lblUsuario  (nombre del usuario conectado)
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(852, 4);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(320, 24);
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSede  (sede del usuario conectado)
            // 
            this.lblSede.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSede.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(218)))));
            this.lblSede.Location = new System.Drawing.Point(852, 28);
            this.lblSede.Name = "lblSede";
            this.lblSede.Size = new System.Drawing.Size(320, 20);
            this.lblSede.Text = "Sede";
            this.lblSede.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkDesarrollador
            // 
            this.lnkDesarrollador.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkDesarrollador.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lnkDesarrollador.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDesarrollador.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(218)))));
            this.lnkDesarrollador.Location = new System.Drawing.Point(852, 48);
            this.lnkDesarrollador.Name = "lnkDesarrollador";
            this.lnkDesarrollador.Size = new System.Drawing.Size(320, 20);
            this.lnkDesarrollador.TabStop = true;
            this.lnkDesarrollador.Text = "Formulario de: Alfonso David Moscoso";
            this.lnkDesarrollador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkDesarrollador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDesarrollador_LinkClicked);
            // 
            // lblIconoUsuario
            // 
            this.lblIconoUsuario.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblIconoUsuario.ForeColor = System.Drawing.Color.White;
            this.lblIconoUsuario.Location = new System.Drawing.Point(1180, 10);
            this.lblIconoUsuario.Name = "lblIconoUsuario";
            this.lblIconoUsuario.Size = new System.Drawing.Size(50, 50);
            this.lblIconoUsuario.Text = "👤";
            this.lblIconoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(268, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sistema de Seguimiento y Trazabilidad de envíos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rastreo y Logística";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Shalom.Properties.Resources.logo_shalom_cabecera;
            this.picLogo.Location = new System.Drawing.Point(12, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(231, 50);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // RastreoYLogística
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1241, 800);
            this.Controls.Add(this.pnlNavegacion);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.grpVehiculos);
            this.Controls.Add(this.grpRastreo);
            this.Controls.Add(this.grpResumen);
            this.Controls.Add(this.barraEstado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(892, 621);
            this.Name = "RastreoYLogística";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rastreo y logística";
            this.Load += new System.EventHandler(this.RastreoYLogística_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
            this.grpResumen.ResumeLayout(false);
            this.pnlEntregados.ResumeLayout(false);
            this.pnlEntregados.PerformLayout();
            this.pnlRuta.ResumeLayout(false);
            this.pnlRuta.PerformLayout();
            this.pnlAlmacen.ResumeLayout(false);
            this.pnlAlmacen.PerformLayout();
            this.pnlCola.ResumeLayout(false);
            this.pnlCola.PerformLayout();
            this.grpRastreo.ResumeLayout(false);
            this.grpRastreo.PerformLayout();
            this.grpVehiculos.ResumeLayout(false);
            this.grpVehiculos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
            this.pnlNavegacion.ResumeLayout(false);
            this.pnlNavegacion.PerformLayout();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ToolStripMenuItem miIngreso;
        private ToolStripMenuItem miAlmacen;
        private ToolStripMenuItem miCarga;
        private ToolStripMenuItem miRutas;
        private ToolStripMenuItem miRastreo;
        private ToolStripMenuItem menuOperaciones;
        private MenuStrip menuPrincipal;
        private ToolStripStatusLabel lblEstado;
        private ToolStripStatusLabel lblSesion;
        private StatusStrip barraEstado;
        private GroupBox grpResumen;
        private GroupBox grpRastreo;
        private GroupBox grpVehiculos;
        private Label lblTituloGuia;
        private Label lblTituloSeleccionado;
        private TextBox txtGuia;
        private Button btnBuscarEnvio;
        private LinkLabel lnkRastreoCompleto;
        private DataGridView dgvVehiculos;
        private LinkLabel lnkPendientesRuta;
        private Button btnVerCarga;
        private Label lblSeleccionado;
        private DataGridViewTextBoxColumn colPlaca;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colPaquetes;
        private DataGridViewTextBoxColumn colCarga;
        private Label lblEnCola;
        private Panel pnlNavegacion;
        private Button btnRutas;
        private Button btnCarga;
        private Button btnAlmacen;
        private Button btnActualizar;
        private Button btnIngreso;
        private Panel pnlEntregados;
        private Label lblTituloEntregados;
        private Label lblIconoEntregados;
        private Label lblEntregados;
        private Panel pnlRuta;
        private Label lblTituloRuta;
        private Label lblIconoRuta;
        private Label lblEnRuta;
        private Panel pnlAlmacen;
        private Label lblTituloAlmacen;
        private Label lblIconoAlmacen;
        private Label lblEnAlmacen;
        private Panel pnlCola;
        private Label lblTituloCola;
        private Label lblIconoCola;
        private Button btnRastreo;
        private Panel pnlCabecera;
        private PictureBox picLogo;
        private Label lblUsuario;
        private Label lblSede;
        private LinkLabel lnkDesarrollador;
        private Label lblIconoUsuario;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnReportes;
        private Button btnSalir;
        private Button btnAyuda;
    }
}