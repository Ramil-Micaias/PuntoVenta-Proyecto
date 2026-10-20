namespace Vista
{
    partial class FormOrdenReparacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblCu = new Label();
            lblTitulo = new Label();
            grpEquipo = new GroupBox();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            btnNuevoCliente = new Button();
            lblEquipo = new Label();
            cmbEquipo = new ComboBox();
            btnNuevoEquipo = new Button();
            lblRecepcion = new Label();
            lblTecnico = new Label();
            cmbTecnico = new ComboBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblPrometida = new Label();
            dtpPrometida = new DateTimePicker();
            grpDiagnostico = new GroupBox();
            lblFalla = new Label();
            txtFalla = new TextBox();
            lblDiagnostico = new Label();
            txtDiagnostico = new TextBox();
            lblPatron = new Label();
            txtPatron = new TextBox();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            tabDetalle = new TabControl();
            tabRepuestos = new TabPage();
            lblRepuesto = new Label();
            cmbRepuesto = new ComboBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            btnAgregarRepuesto = new Button();
            btnQuitarRepuesto = new Button();
            dgvRepuestos = new DataGridView();
            tabHistorial = new TabPage();
            dgvHistorial = new DataGridView();
            grpTotales = new GroupBox();
            lblManoObra = new Label();
            txtManoObra = new TextBox();
            lblRepuestosTitulo = new Label();
            lblRepuestosValor = new Label();
            lblTotalTitulo = new Label();
            lblTotalValor = new Label();
            lblAviso = new Label();
            btnGuardar = new Button();
            btnVolver = new Button();
            panelHeader.SuspendLayout();
            grpEquipo.SuspendLayout();
            grpDiagnostico.SuspendLayout();
            tabDetalle.SuspendLayout();
            tabRepuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            grpTotales.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblCu);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 56);
            panelHeader.TabIndex = 0;
            //
            // lblCu
            //
            lblCu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCu.AutoSize = true;
            lblCu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCu.ForeColor = Color.FromArgb(148, 163, 184);
            lblCu.Location = new Point(937, 18);
            lblCu.Name = "lblCu";
            lblCu.Size = new Size(44, 19);
            lblCu.TabIndex = 1;
            lblCu.Text = "CU05";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NUEVA ORDEN DE REPARACIÓN";
            //
            // grpEquipo
            //
            grpEquipo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpEquipo.Controls.Add(dtpPrometida);
            grpEquipo.Controls.Add(lblPrometida);
            grpEquipo.Controls.Add(cmbEstado);
            grpEquipo.Controls.Add(lblEstado);
            grpEquipo.Controls.Add(cmbTecnico);
            grpEquipo.Controls.Add(lblTecnico);
            grpEquipo.Controls.Add(lblRecepcion);
            grpEquipo.Controls.Add(btnNuevoEquipo);
            grpEquipo.Controls.Add(cmbEquipo);
            grpEquipo.Controls.Add(lblEquipo);
            grpEquipo.Controls.Add(btnNuevoCliente);
            grpEquipo.Controls.Add(cmbCliente);
            grpEquipo.Controls.Add(lblCliente);
            grpEquipo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpEquipo.ForeColor = Color.FromArgb(15, 23, 42);
            grpEquipo.Location = new Point(16, 66);
            grpEquipo.Name = "grpEquipo";
            grpEquipo.Size = new Size(968, 136);
            grpEquipo.TabIndex = 1;
            grpEquipo.TabStop = false;
            grpEquipo.Text = "Cliente, Equipo y Estado";
            //
            // lblCliente
            //
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCliente.ForeColor = Color.FromArgb(30, 41, 59);
            lblCliente.Location = new Point(16, 33);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(52, 17);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            //
            // cmbCliente
            //
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 9.5F);
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(100, 30);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(300, 25);
            cmbCliente.TabIndex = 1;
            //
            // btnNuevoCliente
            //
            btnNuevoCliente.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevoCliente.FlatAppearance.BorderSize = 0;
            btnNuevoCliente.FlatStyle = FlatStyle.Flat;
            btnNuevoCliente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevoCliente.ForeColor = Color.White;
            btnNuevoCliente.Location = new Point(408, 29);
            btnNuevoCliente.Name = "btnNuevoCliente";
            btnNuevoCliente.Size = new Size(90, 27);
            btnNuevoCliente.TabIndex = 2;
            btnNuevoCliente.Text = "+ Nuevo";
            btnNuevoCliente.UseVisualStyleBackColor = false;
            //
            // lblEquipo
            //
            lblEquipo.AutoSize = true;
            lblEquipo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEquipo.ForeColor = Color.FromArgb(30, 41, 59);
            lblEquipo.Location = new Point(16, 69);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.Size = new Size(51, 17);
            lblEquipo.TabIndex = 0;
            lblEquipo.Text = "Equipo:";
            //
            // cmbEquipo
            //
            cmbEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquipo.Font = new Font("Segoe UI", 9.5F);
            cmbEquipo.FormattingEnabled = true;
            cmbEquipo.Location = new Point(100, 66);
            cmbEquipo.Name = "cmbEquipo";
            cmbEquipo.Size = new Size(300, 25);
            cmbEquipo.TabIndex = 3;
            //
            // btnNuevoEquipo
            //
            btnNuevoEquipo.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevoEquipo.FlatAppearance.BorderSize = 0;
            btnNuevoEquipo.FlatStyle = FlatStyle.Flat;
            btnNuevoEquipo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevoEquipo.ForeColor = Color.White;
            btnNuevoEquipo.Location = new Point(408, 65);
            btnNuevoEquipo.Name = "btnNuevoEquipo";
            btnNuevoEquipo.Size = new Size(90, 27);
            btnNuevoEquipo.TabIndex = 4;
            btnNuevoEquipo.Text = "+ Nuevo";
            btnNuevoEquipo.UseVisualStyleBackColor = false;
            //
            // lblRecepcion
            //
            lblRecepcion.Font = new Font("Segoe UI", 9F);
            lblRecepcion.ForeColor = Color.FromArgb(71, 85, 105);
            lblRecepcion.Location = new Point(16, 104);
            lblRecepcion.Name = "lblRecepcion";
            lblRecepcion.Size = new Size(482, 20);
            lblRecepcion.TabIndex = 0;
            lblRecepcion.Text = "Recibe:";
            //
            // lblTecnico
            //
            lblTecnico.AutoSize = true;
            lblTecnico.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTecnico.ForeColor = Color.FromArgb(30, 41, 59);
            lblTecnico.Location = new Point(530, 33);
            lblTecnico.Name = "lblTecnico";
            lblTecnico.Size = new Size(58, 17);
            lblTecnico.TabIndex = 0;
            lblTecnico.Text = "Técnico:";
            //
            // cmbTecnico
            //
            cmbTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTecnico.Font = new Font("Segoe UI", 9.5F);
            cmbTecnico.FormattingEnabled = true;
            cmbTecnico.Location = new Point(640, 30);
            cmbTecnico.Name = "cmbTecnico";
            cmbTecnico.Size = new Size(310, 25);
            cmbTecnico.TabIndex = 5;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(30, 41, 59);
            lblEstado.Location = new Point(530, 69);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(51, 17);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado:";
            //
            // cmbEstado
            //
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 9.5F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(640, 66);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(310, 25);
            cmbEstado.TabIndex = 6;
            //
            // lblPrometida
            //
            lblPrometida.AutoSize = true;
            lblPrometida.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPrometida.ForeColor = Color.FromArgb(30, 41, 59);
            lblPrometida.Location = new Point(530, 105);
            lblPrometida.Name = "lblPrometida";
            lblPrometida.Size = new Size(108, 17);
            lblPrometida.TabIndex = 0;
            lblPrometida.Text = "Fecha prometida:";
            //
            // dtpPrometida
            //
            dtpPrometida.Font = new Font("Segoe UI", 9.5F);
            dtpPrometida.Format = DateTimePickerFormat.Short;
            dtpPrometida.Location = new Point(640, 101);
            dtpPrometida.Name = "dtpPrometida";
            dtpPrometida.ShowCheckBox = true;
            dtpPrometida.Size = new Size(160, 24);
            dtpPrometida.TabIndex = 7;
            //
            // grpDiagnostico
            //
            grpDiagnostico.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDiagnostico.Controls.Add(txtObservacion);
            grpDiagnostico.Controls.Add(lblObservacion);
            grpDiagnostico.Controls.Add(txtPatron);
            grpDiagnostico.Controls.Add(lblPatron);
            grpDiagnostico.Controls.Add(txtDiagnostico);
            grpDiagnostico.Controls.Add(lblDiagnostico);
            grpDiagnostico.Controls.Add(txtFalla);
            grpDiagnostico.Controls.Add(lblFalla);
            grpDiagnostico.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpDiagnostico.ForeColor = Color.FromArgb(15, 23, 42);
            grpDiagnostico.Location = new Point(16, 208);
            grpDiagnostico.Name = "grpDiagnostico";
            grpDiagnostico.Size = new Size(968, 150);
            grpDiagnostico.TabIndex = 2;
            grpDiagnostico.TabStop = false;
            grpDiagnostico.Text = "Falla y Diagnóstico";
            //
            // lblFalla
            //
            lblFalla.AutoSize = true;
            lblFalla.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblFalla.ForeColor = Color.FromArgb(30, 41, 59);
            lblFalla.Location = new Point(16, 26);
            lblFalla.Name = "lblFalla";
            lblFalla.Size = new Size(105, 17);
            lblFalla.TabIndex = 0;
            lblFalla.Text = "Falla declarada:";
            //
            // txtFalla
            //
            txtFalla.Font = new Font("Segoe UI", 9.5F);
            txtFalla.Location = new Point(16, 46);
            txtFalla.MaxLength = 500;
            txtFalla.Multiline = true;
            txtFalla.Name = "txtFalla";
            txtFalla.PlaceholderText = "Qué problema informa el cliente";
            txtFalla.Size = new Size(460, 50);
            txtFalla.TabIndex = 1;
            //
            // lblDiagnostico
            //
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDiagnostico.ForeColor = Color.FromArgb(30, 41, 59);
            lblDiagnostico.Location = new Point(492, 26);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(129, 17);
            lblDiagnostico.TabIndex = 0;
            lblDiagnostico.Text = "Diagnóstico técnico:";
            //
            // txtDiagnostico
            //
            txtDiagnostico.Font = new Font("Segoe UI", 9.5F);
            txtDiagnostico.Location = new Point(492, 46);
            txtDiagnostico.MaxLength = 500;
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.PlaceholderText = "Lo completa el técnico al revisar el equipo";
            txtDiagnostico.Size = new Size(458, 50);
            txtDiagnostico.TabIndex = 2;
            //
            // lblPatron
            //
            lblPatron.AutoSize = true;
            lblPatron.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPatron.ForeColor = Color.FromArgb(30, 41, 59);
            lblPatron.Location = new Point(16, 113);
            lblPatron.Name = "lblPatron";
            lblPatron.Size = new Size(97, 17);
            lblPatron.TabIndex = 0;
            lblPatron.Text = "Patrón / Clave:";
            //
            // txtPatron
            //
            txtPatron.Font = new Font("Segoe UI", 9.5F);
            txtPatron.Location = new Point(126, 110);
            txtPatron.MaxLength = 50;
            txtPatron.Name = "txtPatron";
            txtPatron.PlaceholderText = "Para desbloquear el equipo";
            txtPatron.Size = new Size(350, 24);
            txtPatron.TabIndex = 3;
            //
            // lblObservacion
            //
            lblObservacion.AutoSize = true;
            lblObservacion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblObservacion.ForeColor = Color.FromArgb(30, 41, 59);
            lblObservacion.Location = new Point(492, 113);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(85, 17);
            lblObservacion.TabIndex = 0;
            lblObservacion.Text = "Observación:";
            //
            // txtObservacion
            //
            txtObservacion.Font = new Font("Segoe UI", 9.5F);
            txtObservacion.Location = new Point(590, 110);
            txtObservacion.MaxLength = 255;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.PlaceholderText = "Comentario para el historial (opcional)";
            txtObservacion.Size = new Size(360, 24);
            txtObservacion.TabIndex = 4;
            //
            // tabDetalle
            //
            tabDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabDetalle.Controls.Add(tabRepuestos);
            tabDetalle.Controls.Add(tabHistorial);
            tabDetalle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tabDetalle.Location = new Point(16, 366);
            tabDetalle.Name = "tabDetalle";
            tabDetalle.SelectedIndex = 0;
            tabDetalle.Size = new Size(640, 290);
            tabDetalle.TabIndex = 3;
            //
            // tabRepuestos
            //
            tabRepuestos.BackColor = Color.FromArgb(241, 245, 249);
            tabRepuestos.Controls.Add(dgvRepuestos);
            tabRepuestos.Controls.Add(btnQuitarRepuesto);
            tabRepuestos.Controls.Add(btnAgregarRepuesto);
            tabRepuestos.Controls.Add(txtPrecio);
            tabRepuestos.Controls.Add(lblPrecio);
            tabRepuestos.Controls.Add(numCantidad);
            tabRepuestos.Controls.Add(lblCantidad);
            tabRepuestos.Controls.Add(cmbRepuesto);
            tabRepuestos.Controls.Add(lblRepuesto);
            tabRepuestos.Location = new Point(4, 26);
            tabRepuestos.Name = "tabRepuestos";
            tabRepuestos.Padding = new Padding(3);
            tabRepuestos.Size = new Size(632, 260);
            tabRepuestos.TabIndex = 0;
            tabRepuestos.Text = "Repuestos";
            //
            // lblRepuesto
            //
            lblRepuesto.AutoSize = true;
            lblRepuesto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRepuesto.ForeColor = Color.FromArgb(30, 41, 59);
            lblRepuesto.Location = new Point(10, 14);
            lblRepuesto.Name = "lblRepuesto";
            lblRepuesto.Size = new Size(66, 17);
            lblRepuesto.TabIndex = 0;
            lblRepuesto.Text = "Repuesto:";
            //
            // cmbRepuesto
            //
            cmbRepuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRepuesto.Font = new Font("Segoe UI", 9.5F);
            cmbRepuesto.FormattingEnabled = true;
            cmbRepuesto.Location = new Point(84, 10);
            cmbRepuesto.Name = "cmbRepuesto";
            cmbRepuesto.Size = new Size(330, 25);
            cmbRepuesto.TabIndex = 1;
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.FromArgb(30, 41, 59);
            lblCantidad.Location = new Point(428, 14);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(65, 17);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad:";
            //
            // numCantidad
            //
            numCantidad.Font = new Font("Segoe UI", 9.5F);
            numCantidad.Location = new Point(500, 11);
            numCantidad.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(70, 24);
            numCantidad.TabIndex = 2;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblPrecio
            //
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPrecio.ForeColor = Color.FromArgb(30, 41, 59);
            lblPrecio.Location = new Point(10, 51);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(49, 17);
            lblPrecio.TabIndex = 0;
            lblPrecio.Text = "Precio:";
            //
            // txtPrecio
            //
            txtPrecio.Font = new Font("Segoe UI", 9.5F);
            txtPrecio.Location = new Point(84, 48);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Precio por unidad";
            txtPrecio.Size = new Size(140, 24);
            txtPrecio.TabIndex = 3;
            //
            // btnAgregarRepuesto
            //
            btnAgregarRepuesto.BackColor = Color.FromArgb(37, 99, 235);
            btnAgregarRepuesto.FlatAppearance.BorderSize = 0;
            btnAgregarRepuesto.FlatStyle = FlatStyle.Flat;
            btnAgregarRepuesto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAgregarRepuesto.ForeColor = Color.White;
            btnAgregarRepuesto.Location = new Point(236, 46);
            btnAgregarRepuesto.Name = "btnAgregarRepuesto";
            btnAgregarRepuesto.Size = new Size(170, 28);
            btnAgregarRepuesto.TabIndex = 4;
            btnAgregarRepuesto.Text = "+ Agregar Repuesto";
            btnAgregarRepuesto.UseVisualStyleBackColor = false;
            //
            // btnQuitarRepuesto
            //
            btnQuitarRepuesto.BackColor = Color.FromArgb(239, 68, 68);
            btnQuitarRepuesto.FlatAppearance.BorderSize = 0;
            btnQuitarRepuesto.FlatStyle = FlatStyle.Flat;
            btnQuitarRepuesto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnQuitarRepuesto.ForeColor = Color.White;
            btnQuitarRepuesto.Location = new Point(416, 46);
            btnQuitarRepuesto.Name = "btnQuitarRepuesto";
            btnQuitarRepuesto.Size = new Size(170, 28);
            btnQuitarRepuesto.TabIndex = 5;
            btnQuitarRepuesto.Text = "Quitar Seleccionado";
            btnQuitarRepuesto.UseVisualStyleBackColor = false;
            //
            // dgvRepuestos
            //
            dgvRepuestos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Location = new Point(10, 84);
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.Size = new Size(612, 166);
            dgvRepuestos.TabIndex = 6;
            //
            // tabHistorial
            //
            tabHistorial.BackColor = Color.FromArgb(241, 245, 249);
            tabHistorial.Controls.Add(dgvHistorial);
            tabHistorial.Location = new Point(4, 26);
            tabHistorial.Name = "tabHistorial";
            tabHistorial.Padding = new Padding(10);
            tabHistorial.Size = new Size(632, 260);
            tabHistorial.TabIndex = 1;
            tabHistorial.Text = "Historial de estados";
            //
            // dgvHistorial
            //
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(10, 10);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.Size = new Size(612, 240);
            dgvHistorial.TabIndex = 0;
            //
            // grpTotales
            //
            grpTotales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpTotales.Controls.Add(btnVolver);
            grpTotales.Controls.Add(btnGuardar);
            grpTotales.Controls.Add(lblAviso);
            grpTotales.Controls.Add(lblTotalValor);
            grpTotales.Controls.Add(lblTotalTitulo);
            grpTotales.Controls.Add(lblRepuestosValor);
            grpTotales.Controls.Add(lblRepuestosTitulo);
            grpTotales.Controls.Add(txtManoObra);
            grpTotales.Controls.Add(lblManoObra);
            grpTotales.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpTotales.ForeColor = Color.FromArgb(15, 23, 42);
            grpTotales.Location = new Point(668, 366);
            grpTotales.Name = "grpTotales";
            grpTotales.Size = new Size(316, 290);
            grpTotales.TabIndex = 4;
            grpTotales.TabStop = false;
            grpTotales.Text = "Presupuesto";
            //
            // lblManoObra
            //
            lblManoObra.AutoSize = true;
            lblManoObra.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblManoObra.ForeColor = Color.FromArgb(30, 41, 59);
            lblManoObra.Location = new Point(16, 30);
            lblManoObra.Name = "lblManoObra";
            lblManoObra.Size = new Size(97, 17);
            lblManoObra.TabIndex = 0;
            lblManoObra.Text = "Mano de obra:";
            //
            // txtManoObra
            //
            txtManoObra.Font = new Font("Segoe UI", 9.5F);
            txtManoObra.Location = new Point(16, 50);
            txtManoObra.Name = "txtManoObra";
            txtManoObra.PlaceholderText = "Ej: 15000";
            txtManoObra.Size = new Size(284, 24);
            txtManoObra.TabIndex = 1;
            //
            // lblRepuestosTitulo
            //
            lblRepuestosTitulo.AutoSize = true;
            lblRepuestosTitulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRepuestosTitulo.ForeColor = Color.FromArgb(30, 41, 59);
            lblRepuestosTitulo.Location = new Point(16, 88);
            lblRepuestosTitulo.Name = "lblRepuestosTitulo";
            lblRepuestosTitulo.Size = new Size(71, 17);
            lblRepuestosTitulo.TabIndex = 0;
            lblRepuestosTitulo.Text = "Repuestos:";
            //
            // lblRepuestosValor
            //
            lblRepuestosValor.AutoSize = true;
            lblRepuestosValor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRepuestosValor.ForeColor = Color.FromArgb(15, 23, 42);
            lblRepuestosValor.Location = new Point(120, 87);
            lblRepuestosValor.Name = "lblRepuestosValor";
            lblRepuestosValor.Size = new Size(24, 19);
            lblRepuestosValor.TabIndex = 0;
            lblRepuestosValor.Text = "$0";
            //
            // lblTotalTitulo
            //
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalTitulo.Location = new Point(16, 118);
            lblTotalTitulo.Name = "lblTotalTitulo";
            lblTotalTitulo.Size = new Size(185, 21);
            lblTotalTitulo.TabIndex = 0;
            lblTotalTitulo.Text = "TOTAL PRESUPUESTO:";
            //
            // lblTotalValor
            //
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalValor.ForeColor = Color.FromArgb(16, 185, 129);
            lblTotalValor.Location = new Point(14, 140);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(46, 37);
            lblTotalValor.TabIndex = 0;
            lblTotalValor.Text = "$0";
            //
            // lblAviso
            //
            lblAviso.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAviso.ForeColor = Color.FromArgb(220, 38, 38);
            lblAviso.Location = new Point(16, 186);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(284, 46);
            lblAviso.TabIndex = 0;
            lblAviso.Text = "La orden está cerrada (entregada o cancelada) y ya no se puede modificar.";
            lblAviso.Visible = false;
            //
            // btnGuardar
            //
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(16, 196);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(284, 40);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "GUARDAR ORDEN";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(16, 244);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(284, 34);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // FormOrdenReparacion
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1000, 670);
            Controls.Add(grpTotales);
            Controls.Add(tabDetalle);
            Controls.Add(grpDiagnostico);
            Controls.Add(grpEquipo);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1016, 709);
            Name = "FormOrdenReparacion";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ApIBigStore - Orden de Reparación";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpEquipo.ResumeLayout(false);
            grpEquipo.PerformLayout();
            grpDiagnostico.ResumeLayout(false);
            grpDiagnostico.PerformLayout();
            tabDetalle.ResumeLayout(false);
            tabRepuestos.ResumeLayout(false);
            tabRepuestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            grpTotales.ResumeLayout(false);
            grpTotales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblCu;
        private Label lblTitulo;
        private GroupBox grpEquipo;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Button btnNuevoCliente;
        private Label lblEquipo;
        private ComboBox cmbEquipo;
        private Button btnNuevoEquipo;
        private Label lblRecepcion;
        private Label lblTecnico;
        private ComboBox cmbTecnico;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblPrometida;
        private DateTimePicker dtpPrometida;
        private GroupBox grpDiagnostico;
        private Label lblFalla;
        private TextBox txtFalla;
        private Label lblDiagnostico;
        private TextBox txtDiagnostico;
        private Label lblPatron;
        private TextBox txtPatron;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private TabControl tabDetalle;
        private TabPage tabRepuestos;
        private Label lblRepuesto;
        private ComboBox cmbRepuesto;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Button btnAgregarRepuesto;
        private Button btnQuitarRepuesto;
        private DataGridView dgvRepuestos;
        private TabPage tabHistorial;
        private DataGridView dgvHistorial;
        private GroupBox grpTotales;
        private Label lblManoObra;
        private TextBox txtManoObra;
        private Label lblRepuestosTitulo;
        private Label lblRepuestosValor;
        private Label lblTotalTitulo;
        private Label lblTotalValor;
        private Label lblAviso;
        private Button btnGuardar;
        private Button btnVolver;
    }
}
