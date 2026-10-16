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
            this.menuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.miSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOperaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSesion = new System.Windows.Forms.ToolStripStatusLabel();
            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.grpResumen = new System.Windows.Forms.GroupBox();
            this.pnlEntregados = new System.Windows.Forms.Panel();
            this.lblTituloEntregados = new System.Windows.Forms.Label();
            this.lblEntregados = new System.Windows.Forms.Label();
            this.pnlRuta = new System.Windows.Forms.Panel();
            this.lblTituloRuta = new System.Windows.Forms.Label();
            this.lblEnRuta = new System.Windows.Forms.Label();
            this.pnlAlmacen = new System.Windows.Forms.Panel();
            this.lblTituloAlmacen = new System.Windows.Forms.Label();
            this.lblEnAlmacen = new System.Windows.Forms.Label();
            this.pnlCola = new System.Windows.Forms.Panel();
            this.lblTituloCola = new System.Windows.Forms.Label();
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
            this.btnRastreo = new System.Windows.Forms.Button();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // miIngreso
            // 
            this.miIngreso.Name = "miIngreso";
            this.miIngreso.Size = new System.Drawing.Size(178, 22);
            this.miIngreso.Text = "Ingreso de envíos";
            this.miIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // miAlmacen
            // 
            this.miAlmacen.Name = "miAlmacen";
            this.miAlmacen.Size = new System.Drawing.Size(178, 22);
            this.miAlmacen.Text = "Almacén";
            this.miAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // miCarga
            // 
            this.miCarga.Name = "miCarga";
            this.miCarga.Size = new System.Drawing.Size(178, 22);
            this.miCarga.Text = "Carga de vehículos";
            this.miCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // miRutas
            // 
            this.miRutas.Name = "miRutas";
            this.miRutas.Size = new System.Drawing.Size(178, 22);
            this.miRutas.Text = "Asignación de rutas";
            this.miRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // miRastreo
            // 
            this.miRastreo.Name = "miRastreo";
            this.miRastreo.Size = new System.Drawing.Size(178, 22);
            this.miRastreo.Text = "Rastreo de envíos";
            this.miRastreo.Click += new System.EventHandler(this.btnRastreo_Click);
            // 
            // menuArchivo
            // 
            this.menuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSalir});
            this.menuArchivo.Name = "menuArchivo";
            this.menuArchivo.Size = new System.Drawing.Size(60, 19);
            this.menuArchivo.Text = "Archivo";
            // 
            // miSalir
            // 
            this.miSalir.Name = "miSalir";
            this.miSalir.Size = new System.Drawing.Size(96, 22);
            this.miSalir.Text = "Salir";
            this.miSalir.Click += new System.EventHandler(this.miSalir_Click);
            // 
            // menuOperaciones
            // 
            this.menuOperaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miIngreso,
            this.miAlmacen,
            this.miCarga,
            this.miRutas,
            this.miRastreo});
            this.menuOperaciones.Name = "menuOperaciones";
            this.menuOperaciones.Size = new System.Drawing.Size(85, 19);
            this.menuOperaciones.Text = "Operaciones";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArchivo,
            this.menuOperaciones,
            this.menuAyuda});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Padding = new System.Windows.Forms.Padding(14, 8, 0, 8);
            this.menuPrincipal.Size = new System.Drawing.Size(876, 35);
            this.menuPrincipal.TabIndex = 3;
            // 
            // menuAyuda
            // 
            this.menuAyuda.Name = "menuAyuda";
            this.menuAyuda.Size = new System.Drawing.Size(53, 19);
            this.menuAyuda.Text = "Ayuda";
            this.menuAyuda.Click += new System.EventHandler(this.menuAyuda_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(855, 17);
            this.lblEstado.Spring = true;
            this.lblEstado.Text = "Listo";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSesion
            // 
            this.lblSesion.Name = "lblSesion";
            this.lblSesion.Size = new System.Drawing.Size(0, 17);
            this.lblSesion.Visible = false;
            // 
            // barraEstado
            // 
            this.barraEstado.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado,
            this.lblSesion});
            this.barraEstado.Location = new System.Drawing.Point(0, 560);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.barraEstado.Size = new System.Drawing.Size(876, 22);
            this.barraEstado.SizingGrip = false;
            this.barraEstado.TabIndex = 2;
            // 
            // grpResumen
            // 
            this.grpResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResumen.Controls.Add(this.pnlEntregados);
            this.grpResumen.Controls.Add(this.pnlRuta);
            this.grpResumen.Controls.Add(this.pnlAlmacen);
            this.grpResumen.Controls.Add(this.pnlCola);
            this.grpResumen.Location = new System.Drawing.Point(238, 50);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Size = new System.Drawing.Size(579, 135);
            this.grpResumen.TabIndex = 4;
            this.grpResumen.TabStop = false;
            this.grpResumen.Text = "Resumen de envíos";
            // 
            // pnlEntregados
            // 
            this.pnlEntregados.BackColor = System.Drawing.Color.White;
            this.pnlEntregados.Controls.Add(this.lblTituloEntregados);
            this.pnlEntregados.Controls.Add(this.lblEntregados);
            this.pnlEntregados.Location = new System.Drawing.Point(439, 29);
            this.pnlEntregados.Name = "pnlEntregados";
            this.pnlEntregados.Size = new System.Drawing.Size(97, 75);
            this.pnlEntregados.TabIndex = 5;
            // 
            // lblTituloEntregados
            // 
            this.lblTituloEntregados.AutoSize = true;
            this.lblTituloEntregados.Location = new System.Drawing.Point(10, 44);
            this.lblTituloEntregados.Name = "lblTituloEntregados";
            this.lblTituloEntregados.Size = new System.Drawing.Size(66, 15);
            this.lblTituloEntregados.TabIndex = 4;
            this.lblTituloEntregados.Text = "Entregados";
            // 
            // lblEntregados
            // 
            this.lblEntregados.AutoSize = true;
            this.lblEntregados.Location = new System.Drawing.Point(39, 16);
            this.lblEntregados.Name = "lblEntregados";
            this.lblEntregados.Size = new System.Drawing.Size(13, 15);
            this.lblEntregados.TabIndex = 0;
            this.lblEntregados.Text = "0";
            // 
            // pnlRuta
            // 
            this.pnlRuta.BackColor = System.Drawing.Color.White;
            this.pnlRuta.Controls.Add(this.lblTituloRuta);
            this.pnlRuta.Controls.Add(this.lblEnRuta);
            this.pnlRuta.Location = new System.Drawing.Point(308, 29);
            this.pnlRuta.Name = "pnlRuta";
            this.pnlRuta.Size = new System.Drawing.Size(82, 75);
            this.pnlRuta.TabIndex = 5;
            // 
            // lblTituloRuta
            // 
            this.lblTituloRuta.AutoSize = true;
            this.lblTituloRuta.Location = new System.Drawing.Point(18, 44);
            this.lblTituloRuta.Name = "lblTituloRuta";
            this.lblTituloRuta.Size = new System.Drawing.Size(44, 15);
            this.lblTituloRuta.TabIndex = 3;
            this.lblTituloRuta.Text = "En ruta";
            // 
            // lblEnRuta
            // 
            this.lblEnRuta.AutoSize = true;
            this.lblEnRuta.Location = new System.Drawing.Point(32, 16);
            this.lblEnRuta.Name = "lblEnRuta";
            this.lblEnRuta.Size = new System.Drawing.Size(13, 15);
            this.lblEnRuta.TabIndex = 0;
            this.lblEnRuta.Text = "0";
            // 
            // pnlAlmacen
            // 
            this.pnlAlmacen.BackColor = System.Drawing.Color.White;
            this.pnlAlmacen.Controls.Add(this.lblTituloAlmacen);
            this.pnlAlmacen.Controls.Add(this.lblEnAlmacen);
            this.pnlAlmacen.Location = new System.Drawing.Point(170, 29);
            this.pnlAlmacen.Name = "pnlAlmacen";
            this.pnlAlmacen.Size = new System.Drawing.Size(89, 75);
            this.pnlAlmacen.TabIndex = 5;
            // 
            // lblTituloAlmacen
            // 
            this.lblTituloAlmacen.AutoSize = true;
            this.lblTituloAlmacen.Location = new System.Drawing.Point(1, 44);
            this.lblTituloAlmacen.Name = "lblTituloAlmacen";
            this.lblTituloAlmacen.Size = new System.Drawing.Size(68, 15);
            this.lblTituloAlmacen.TabIndex = 2;
            this.lblTituloAlmacen.Text = "En almacén";
            // 
            // lblEnAlmacen
            // 
            this.lblEnAlmacen.AutoSize = true;
            this.lblEnAlmacen.Location = new System.Drawing.Point(32, 16);
            this.lblEnAlmacen.Name = "lblEnAlmacen";
            this.lblEnAlmacen.Size = new System.Drawing.Size(13, 15);
            this.lblEnAlmacen.TabIndex = 0;
            this.lblEnAlmacen.Text = "0";
            // 
            // pnlCola
            // 
            this.pnlCola.BackColor = System.Drawing.Color.White;
            this.pnlCola.Controls.Add(this.lblTituloCola);
            this.pnlCola.Controls.Add(this.lblEnCola);
            this.pnlCola.Location = new System.Drawing.Point(39, 29);
            this.pnlCola.Name = "pnlCola";
            this.pnlCola.Size = new System.Drawing.Size(82, 75);
            this.pnlCola.TabIndex = 4;
            // 
            // lblTituloCola
            // 
            this.lblTituloCola.AutoSize = true;
            this.lblTituloCola.Location = new System.Drawing.Point(11, 44);
            this.lblTituloCola.Name = "lblTituloCola";
            this.lblTituloCola.Size = new System.Drawing.Size(45, 15);
            this.lblTituloCola.TabIndex = 1;
            this.lblTituloCola.Text = "En cola";
            // 
            // lblEnCola
            // 
            this.lblEnCola.AutoSize = true;
            this.lblEnCola.Location = new System.Drawing.Point(28, 16);
            this.lblEnCola.Name = "lblEnCola";
            this.lblEnCola.Size = new System.Drawing.Size(13, 15);
            this.lblEnCola.TabIndex = 0;
            this.lblEnCola.Text = "0";
            // 
            // grpRastreo
            // 
            this.grpRastreo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRastreo.Controls.Add(this.txtGuia);
            this.grpRastreo.Controls.Add(this.btnBuscarEnvio);
            this.grpRastreo.Controls.Add(this.lnkRastreoCompleto);
            this.grpRastreo.Controls.Add(this.lblTituloGuia);
            this.grpRastreo.Location = new System.Drawing.Point(238, 191);
            this.grpRastreo.Name = "grpRastreo";
            this.grpRastreo.Size = new System.Drawing.Size(579, 98);
            this.grpRastreo.TabIndex = 5;
            this.grpRastreo.TabStop = false;
            this.grpRastreo.Text = "Rastreo rápido";
            // 
            // txtGuia
            // 
            this.txtGuia.Location = new System.Drawing.Point(138, 36);
            this.txtGuia.Name = "txtGuia";
            this.txtGuia.Size = new System.Drawing.Size(160, 23);
            this.txtGuia.TabIndex = 6;
            // 
            // btnBuscarEnvio
            // 
            this.btnBuscarEnvio.Location = new System.Drawing.Point(331, 36);
            this.btnBuscarEnvio.Name = "btnBuscarEnvio";
            this.btnBuscarEnvio.Size = new System.Drawing.Size(189, 27);
            this.btnBuscarEnvio.TabIndex = 5;
            this.btnBuscarEnvio.Text = "Buscar envío";
            this.btnBuscarEnvio.UseVisualStyleBackColor = true;
            this.btnBuscarEnvio.Click += new System.EventHandler(this.btnBuscarEnvio_Click);
            // 
            // lnkRastreoCompleto
            // 
            this.lnkRastreoCompleto.AutoSize = true;
            this.lnkRastreoCompleto.Location = new System.Drawing.Point(49, 63);
            this.lnkRastreoCompleto.Name = "lnkRastreoCompleto";
            this.lnkRastreoCompleto.Size = new System.Drawing.Size(126, 15);
            this.lnkRastreoCompleto.TabIndex = 5;
            this.lnkRastreoCompleto.TabStop = true;
            this.lnkRastreoCompleto.Text = "Abrir rastreo completo";
            this.lnkRastreoCompleto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRastreoCompleto_LinkClicked);
            // 
            // lblTituloGuia
            // 
            this.lblTituloGuia.AutoSize = true;
            this.lblTituloGuia.Location = new System.Drawing.Point(49, 36);
            this.lblTituloGuia.Name = "lblTituloGuia";
            this.lblTituloGuia.Size = new System.Drawing.Size(66, 15);
            this.lblTituloGuia.TabIndex = 0;
            this.lblTituloGuia.Text = "N° de guía:";
            // 
            // grpVehiculos
            // 
            this.grpVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVehiculos.Controls.Add(this.dgvVehiculos);
            this.grpVehiculos.Controls.Add(this.lnkPendientesRuta);
            this.grpVehiculos.Controls.Add(this.btnVerCarga);
            this.grpVehiculos.Controls.Add(this.lblSeleccionado);
            this.grpVehiculos.Controls.Add(this.lblTituloSeleccionado);
            this.grpVehiculos.Location = new System.Drawing.Point(238, 301);
            this.grpVehiculos.Name = "grpVehiculos";
            this.grpVehiculos.Size = new System.Drawing.Size(607, 239);
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
            this.dgvVehiculos.Size = new System.Drawing.Size(583, 143);
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
            this.lnkPendientesRuta.Location = new System.Drawing.Point(225, 181);
            this.lnkPendientesRuta.Name = "lnkPendientesRuta";
            this.lnkPendientesRuta.Size = new System.Drawing.Size(124, 15);
            this.lnkPendientesRuta.TabIndex = 4;
            this.lnkPendientesRuta.TabStop = true;
            this.lnkPendientesRuta.Text = "Ver pendientes de ruta";
            this.lnkPendientesRuta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPendientesRuta_LinkClicked);
            // 
            // btnVerCarga
            // 
            this.btnVerCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerCarga.Location = new System.Drawing.Point(18, 177);
            this.btnVerCarga.Name = "btnVerCarga";
            this.btnVerCarga.Size = new System.Drawing.Size(189, 33);
            this.btnVerCarga.TabIndex = 2;
            this.btnVerCarga.Text = "Ver carga del vehículo";
            this.btnVerCarga.UseVisualStyleBackColor = true;
            this.btnVerCarga.Click += new System.EventHandler(this.btnVerCarga_Click);
            // 
            // lblSeleccionado
            // 
            this.lblSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeleccionado.AutoSize = true;
            this.lblSeleccionado.Location = new System.Drawing.Point(531, 211);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(12, 15);
            this.lblSeleccionado.TabIndex = 1;
            this.lblSeleccionado.Text = "-";
            // 
            // lblTituloSeleccionado
            // 
            this.lblTituloSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloSeleccionado.AutoSize = true;
            this.lblTituloSeleccionado.Location = new System.Drawing.Point(412, 211);
            this.lblTituloSeleccionado.Name = "lblTituloSeleccionado";
            this.lblTituloSeleccionado.Size = new System.Drawing.Size(55, 15);
            this.lblTituloSeleccionado.TabIndex = 0;
            this.lblTituloSeleccionado.Text = "Vehículo:";
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.Controls.Add(this.btnRastreo);
            this.pnlNavegacion.Controls.Add(this.btnRutas);
            this.pnlNavegacion.Controls.Add(this.btnCarga);
            this.pnlNavegacion.Controls.Add(this.btnAlmacen);
            this.pnlNavegacion.Controls.Add(this.btnActualizar);
            this.pnlNavegacion.Controls.Add(this.btnIngreso);
            this.pnlNavegacion.Location = new System.Drawing.Point(16, 49);
            this.pnlNavegacion.Name = "pnlNavegacion";
            this.pnlNavegacion.Size = new System.Drawing.Size(193, 484);
            this.pnlNavegacion.TabIndex = 7;
            // 
            // btnRastreo
            // 
            this.btnRastreo.Location = new System.Drawing.Point(18, 400);
            this.btnRastreo.Name = "btnRastreo";
            this.btnRastreo.Size = new System.Drawing.Size(142, 53);
            this.btnRastreo.TabIndex = 5;
            this.btnRastreo.Text = "Rastreo de envíos";
            this.btnRastreo.UseVisualStyleBackColor = true;
            this.btnRastreo.Click += new System.EventHandler(this.btnRastreo_Click);
            // 
            // btnRutas
            // 
            this.btnRutas.Location = new System.Drawing.Point(18, 326);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(142, 53);
            this.btnRutas.TabIndex = 4;
            this.btnRutas.Text = "Asignación de rutas";
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(18, 252);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(142, 53);
            this.btnCarga.TabIndex = 3;
            this.btnCarga.Text = "Carga de Vehículos";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.Location = new System.Drawing.Point(18, 178);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(142, 53);
            this.btnAlmacen.TabIndex = 2;
            this.btnAlmacen.Text = "Almacén";
            this.btnAlmacen.UseVisualStyleBackColor = true;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(18, 30);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(142, 53);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar panel";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.Location = new System.Drawing.Point(18, 104);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(142, 53);
            this.btnIngreso.TabIndex = 0;
            this.btnIngreso.Text = "Ingreso de envíos";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // RastreoYLogística
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(876, 582);
            this.Controls.Add(this.pnlNavegacion);
            this.Controls.Add(this.grpVehiculos);
            this.Controls.Add(this.grpRastreo);
            this.Controls.Add(this.grpResumen);
            this.Controls.Add(this.barraEstado);
            this.Controls.Add(this.menuPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ToolStripMenuItem miIngreso;
        private ToolStripMenuItem miAlmacen;
        private ToolStripMenuItem miCarga;
        private ToolStripMenuItem miRutas;
        private ToolStripMenuItem miRastreo;
        private ToolStripMenuItem menuArchivo;
        private ToolStripMenuItem miSalir;
        private ToolStripMenuItem menuOperaciones;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem menuAyuda;
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
        private Label lblEntregados;
        private Panel pnlRuta;
        private Label lblTituloRuta;
        private Label lblEnRuta;
        private Panel pnlAlmacen;
        private Label lblTituloAlmacen;
        private Label lblEnAlmacen;
        private Panel pnlCola;
        private Label lblTituloCola;
        private Button btnRastreo;
    }
}
