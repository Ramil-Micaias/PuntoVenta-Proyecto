namespace Vista
{
    partial class FormProductos
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
            panelIdioma = new Panel();
            lblIdioma = new Label();
            cmbIdioma = new ComboBox();
            tabProductoCategoria = new TabControl();
            tabPage1 = new TabPage();
            lblCatalogoExistencia = new Label();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvProductos = new DataGridView();
            grpDetalleProducto = new GroupBox();
            flpAcciones = new FlowLayoutPanel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEstadoProducto = new Button();
            btnConfirmar = new Button();
            btnCancelarEdicion = new Button();
            btnVolverMenu = new Button();
            lblCategorias = new Label();
            lblResultadoProducto = new Label();
            cmbCategoria = new ComboBox();
            lblProveedor = new Label();
            cmbProveedor = new ComboBox();
            lblNombreProducto = new Label();
            txtNombreProducto = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecioVenta = new Label();
            txtPrecioVenta = new TextBox();
            lblStockActual = new Label();
            txtStockActual = new TextBox();
            lblStockMinimo = new Label();
            txtStockMinimo = new TextBox();
            tabPage2 = new TabPage();
            lblListadoCategoria = new Label();
            lblResultadoCategoria = new Label();
            dgvCategorias = new DataGridView();
            grpGestionCategoria = new GroupBox();
            lblNombreCategoria = new Label();
            txtNombreCategoria = new TextBox();
            flpAccionesCategoria = new FlowLayoutPanel();
            btnNuevaCategoria = new Button();
            btnGuardarCategoria = new Button();
            btnModificarCategoria = new Button();
            btnConfirmarCategoria = new Button();
            btnCancelarCategoria = new Button();
            btnEliminarCategoria = new Button();
            btnVolverCategoria = new Button();
            panelIdioma.SuspendLayout();
            tabProductoCategoria.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            grpDetalleProducto.SuspendLayout();
            flpAcciones.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            grpGestionCategoria.SuspendLayout();
            flpAccionesCategoria.SuspendLayout();
            SuspendLayout();
            //
            // panelIdioma
            //
            panelIdioma.BackColor = Color.FromArgb(241, 245, 249);
            panelIdioma.Controls.Add(lblIdioma);
            panelIdioma.Controls.Add(cmbIdioma);
            panelIdioma.Dock = DockStyle.Top;
            panelIdioma.Location = new Point(0, 0);
            panelIdioma.Name = "panelIdioma";
            panelIdioma.Size = new Size(900, 36);
            panelIdioma.TabIndex = 1;
            //
            // lblIdioma
            //
            lblIdioma.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdioma.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblIdioma.ForeColor = Color.FromArgb(30, 41, 59);
            lblIdioma.Location = new Point(618, 6);
            lblIdioma.Name = "lblIdioma";
            lblIdioma.Size = new Size(124, 25);
            lblIdioma.TabIndex = 0;
            lblIdioma.Text = "Idioma:";
            lblIdioma.TextAlign = ContentAlignment.MiddleRight;
            //
            // cmbIdioma
            //
            cmbIdioma.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdioma.Font = new Font("Segoe UI", 9.5F);
            cmbIdioma.FormattingEnabled = true;
            cmbIdioma.Location = new Point(748, 6);
            cmbIdioma.Name = "cmbIdioma";
            cmbIdioma.Size = new Size(140, 25);
            cmbIdioma.TabIndex = 1;
            //
            // tabProductoCategoria
            //
            tabProductoCategoria.Controls.Add(tabPage1);
            tabProductoCategoria.Controls.Add(tabPage2);
            tabProductoCategoria.Dock = DockStyle.Fill;
            tabProductoCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tabProductoCategoria.Location = new Point(0, 0);
            tabProductoCategoria.Name = "tabProductoCategoria";
            tabProductoCategoria.SelectedIndex = 0;
            tabProductoCategoria.Size = new Size(900, 590);
            tabProductoCategoria.TabIndex = 0;
            //
            // tabPage1
            //
            tabPage1.BackColor = Color.FromArgb(241, 245, 249);
            tabPage1.Controls.Add(grpDetalleProducto);
            tabPage1.Controls.Add(dgvProductos);
            tabPage1.Controls.Add(txtBuscar);
            tabPage1.Controls.Add(lblBuscar);
            tabPage1.Controls.Add(lblCatalogoExistencia);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(892, 560);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Productos";
            //
            // lblCatalogoExistencia
            //
            lblCatalogoExistencia.AutoSize = true;
            lblCatalogoExistencia.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCatalogoExistencia.ForeColor = Color.FromArgb(15, 23, 42);
            lblCatalogoExistencia.Location = new Point(12, 10);
            lblCatalogoExistencia.Name = "lblCatalogoExistencia";
            lblCatalogoExistencia.Size = new Size(225, 25);
            lblCatalogoExistencia.TabIndex = 0;
            lblCatalogoExistencia.Text = "Catálogo de Existencias";
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscar.Location = new Point(12, 52);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(50, 17);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(72, 49);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre del producto o categoría";
            txtBuscar.Size = new Size(808, 24);
            txtBuscar.TabIndex = 2;
            //
            // dgvProductos
            //
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 84);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(868, 216);
            dgvProductos.TabIndex = 3;
            dgvProductos.CellClick += dgvProductos_CellClick;
            //
            // grpDetalleProducto
            //
            grpDetalleProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalleProducto.Controls.Add(lblResultadoProducto);
            grpDetalleProducto.Controls.Add(flpAcciones);
            grpDetalleProducto.Controls.Add(btnVolverMenu);
            grpDetalleProducto.Controls.Add(txtStockMinimo);
            grpDetalleProducto.Controls.Add(lblStockMinimo);
            grpDetalleProducto.Controls.Add(txtStockActual);
            grpDetalleProducto.Controls.Add(lblStockActual);
            grpDetalleProducto.Controls.Add(txtPrecioVenta);
            grpDetalleProducto.Controls.Add(lblPrecioVenta);
            grpDetalleProducto.Controls.Add(txtDescripcion);
            grpDetalleProducto.Controls.Add(lblDescripcion);
            grpDetalleProducto.Controls.Add(txtNombreProducto);
            grpDetalleProducto.Controls.Add(lblNombreProducto);
            grpDetalleProducto.Controls.Add(cmbCategoria);
            grpDetalleProducto.Controls.Add(lblCategorias);
            grpDetalleProducto.Controls.Add(lblProveedor);
            grpDetalleProducto.Controls.Add(cmbProveedor);
            grpDetalleProducto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpDetalleProducto.ForeColor = Color.FromArgb(15, 23, 42);
            grpDetalleProducto.Location = new Point(12, 310);
            grpDetalleProducto.Name = "grpDetalleProducto";
            grpDetalleProducto.Size = new Size(868, 236);
            grpDetalleProducto.TabIndex = 4;
            grpDetalleProducto.TabStop = false;
            grpDetalleProducto.Text = "Detalle del Producto";
            //
            // flpAcciones
            //
            flpAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAcciones.Controls.Add(btnNuevo);
            flpAcciones.Controls.Add(btnGuardar);
            flpAcciones.Controls.Add(btnModificar);
            flpAcciones.Controls.Add(btnConfirmar);
            flpAcciones.Controls.Add(btnCancelarEdicion);
            flpAcciones.Controls.Add(btnEstadoProducto);
            flpAcciones.FlowDirection = FlowDirection.TopDown;
            flpAcciones.Location = new Point(706, 22);
            flpAcciones.Name = "flpAcciones";
            flpAcciones.Size = new Size(150, 120);
            flpAcciones.TabIndex = 10;
            flpAcciones.WrapContents = false;
            //
            // btnNuevo
            //
            btnNuevo.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Margin = new Padding(0, 0, 0, 6);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(146, 32);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Agregar";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Margin = new Padding(0, 0, 0, 6);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(146, 32);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnModificar
            //
            btnModificar.BackColor = Color.FromArgb(37, 99, 235);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Margin = new Padding(0, 0, 0, 6);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(146, 32);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            //
            // btnEstadoProducto
            //
            btnEstadoProducto.BackColor = Color.FromArgb(239, 68, 68);
            btnEstadoProducto.FlatAppearance.BorderSize = 0;
            btnEstadoProducto.FlatStyle = FlatStyle.Flat;
            btnEstadoProducto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEstadoProducto.ForeColor = Color.White;
            btnEstadoProducto.Margin = new Padding(0, 0, 0, 6);
            btnEstadoProducto.Name = "btnEstadoProducto";
            btnEstadoProducto.Size = new Size(146, 32);
            btnEstadoProducto.TabIndex = 5;
            btnEstadoProducto.Text = "Inactivar";
            btnEstadoProducto.UseVisualStyleBackColor = false;
            btnEstadoProducto.Click += btnEstadoProducto_Click;
            //
            // btnConfirmar
            //
            btnConfirmar.BackColor = Color.FromArgb(16, 185, 129);
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Margin = new Padding(0, 0, 0, 6);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(146, 32);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // btnCancelarEdicion
            //
            btnCancelarEdicion.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelarEdicion.FlatAppearance.BorderSize = 0;
            btnCancelarEdicion.FlatStyle = FlatStyle.Flat;
            btnCancelarEdicion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelarEdicion.ForeColor = Color.White;
            btnCancelarEdicion.Margin = new Padding(0, 0, 0, 6);
            btnCancelarEdicion.Name = "btnCancelarEdicion";
            btnCancelarEdicion.Size = new Size(146, 32);
            btnCancelarEdicion.TabIndex = 4;
            btnCancelarEdicion.Text = "Cancelar";
            btnCancelarEdicion.UseVisualStyleBackColor = false;
            btnCancelarEdicion.Click += btnCancelarEdicion_Click;
            //
            // btnVolverMenu
            //
            btnVolverMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolverMenu.BackColor = Color.FromArgb(100, 116, 139);
            btnVolverMenu.FlatAppearance.BorderSize = 0;
            btnVolverMenu.FlatStyle = FlatStyle.Flat;
            btnVolverMenu.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolverMenu.ForeColor = Color.White;
            btnVolverMenu.Location = new Point(706, 188);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(146, 32);
            btnVolverMenu.TabIndex = 11;
            btnVolverMenu.Text = "Volver";
            btnVolverMenu.UseVisualStyleBackColor = false;
            btnVolverMenu.Click += btnVolverMenu_Click;
            //
            // lblCategorias
            //
            lblCategorias.AutoSize = true;
            lblCategorias.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCategorias.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategorias.Location = new Point(20, 33);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(70, 17);
            lblCategorias.TabIndex = 0;
            lblCategorias.Text = "Categoría:";
            //
            // cmbCategoria
            //
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(130, 30);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(210, 25);
            cmbCategoria.TabIndex = 1;
            //
            // lblProveedor
            //
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblProveedor.ForeColor = Color.FromArgb(30, 41, 59);
            lblProveedor.Location = new Point(20, 147);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(71, 17);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            //
            // cmbProveedor
            //
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Segoe UI", 9.5F);
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(130, 144);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(550, 25);
            cmbProveedor.TabIndex = 7;
            //
            // lblNombreProducto
            //
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreProducto.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombreProducto.Location = new Point(20, 71);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(61, 17);
            lblNombreProducto.TabIndex = 0;
            lblNombreProducto.Text = "Nombre:";
            //
            // txtNombreProducto
            //
            txtNombreProducto.Font = new Font("Segoe UI", 9.5F);
            txtNombreProducto.Location = new Point(130, 68);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.PlaceholderText = "Ej: Funda Silicona iPhone 15";
            txtNombreProducto.Size = new Size(210, 24);
            txtNombreProducto.TabIndex = 2;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(30, 41, 59);
            lblDescripcion.Location = new Point(20, 109);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(80, 17);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "Descripción:";
            //
            // txtDescripcion
            //
            txtDescripcion.Font = new Font("Segoe UI", 9.5F);
            txtDescripcion.Location = new Point(130, 106);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Detalle breve del producto";
            txtDescripcion.Size = new Size(210, 24);
            txtDescripcion.TabIndex = 3;
            //
            // lblPrecioVenta
            //
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPrecioVenta.ForeColor = Color.FromArgb(30, 41, 59);
            lblPrecioVenta.Location = new Point(380, 33);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(86, 17);
            lblPrecioVenta.TabIndex = 0;
            lblPrecioVenta.Text = "Precio Venta:";
            //
            // txtPrecioVenta
            //
            txtPrecioVenta.Font = new Font("Segoe UI", 9.5F);
            txtPrecioVenta.Location = new Point(490, 30);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.PlaceholderText = "Ej: 15000";
            txtPrecioVenta.Size = new Size(190, 24);
            txtPrecioVenta.TabIndex = 4;
            //
            // lblStockActual
            //
            lblStockActual.AutoSize = true;
            lblStockActual.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblStockActual.ForeColor = Color.FromArgb(30, 41, 59);
            lblStockActual.Location = new Point(380, 71);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(86, 17);
            lblStockActual.TabIndex = 0;
            lblStockActual.Text = "Stock Actual:";
            //
            // txtStockActual
            //
            txtStockActual.Font = new Font("Segoe UI", 9.5F);
            txtStockActual.Location = new Point(490, 68);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.PlaceholderText = "Unidades disponibles";
            txtStockActual.Size = new Size(190, 24);
            txtStockActual.TabIndex = 5;
            //
            // lblStockMinimo
            //
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblStockMinimo.ForeColor = Color.FromArgb(30, 41, 59);
            lblStockMinimo.Location = new Point(380, 109);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(94, 17);
            lblStockMinimo.TabIndex = 0;
            lblStockMinimo.Text = "Stock Mínimo:";
            //
            // txtStockMinimo
            //
            txtStockMinimo.Font = new Font("Segoe UI", 9.5F);
            txtStockMinimo.Location = new Point(490, 106);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.PlaceholderText = "Aviso de stock bajo";
            txtStockMinimo.Size = new Size(190, 24);
            txtStockMinimo.TabIndex = 6;
            //
            // tabPage2
            //
            tabPage2.BackColor = Color.FromArgb(241, 245, 249);
            tabPage2.Controls.Add(lblResultadoCategoria);
            tabPage2.Controls.Add(grpGestionCategoria);
            tabPage2.Controls.Add(dgvCategorias);
            tabPage2.Controls.Add(lblListadoCategoria);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(892, 560);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Categorías";
            //
            // lblListadoCategoria
            //
            lblListadoCategoria.AutoSize = true;
            lblListadoCategoria.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblListadoCategoria.ForeColor = Color.FromArgb(15, 23, 42);
            lblListadoCategoria.Location = new Point(12, 10);
            lblListadoCategoria.Name = "lblListadoCategoria";
            lblListadoCategoria.Size = new Size(204, 25);
            lblListadoCategoria.TabIndex = 0;
            lblListadoCategoria.Text = "Listado de Categorías";
            //
            // dgvCategorias
            //
            dgvCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(12, 48);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.Size = new Size(524, 498);
            dgvCategorias.TabIndex = 1;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            //
            // grpGestionCategoria
            //
            grpGestionCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpGestionCategoria.Controls.Add(btnVolverCategoria);
            grpGestionCategoria.Controls.Add(btnEliminarCategoria);
            grpGestionCategoria.Controls.Add(flpAccionesCategoria);
            grpGestionCategoria.Controls.Add(txtNombreCategoria);
            grpGestionCategoria.Controls.Add(lblNombreCategoria);
            grpGestionCategoria.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpGestionCategoria.ForeColor = Color.FromArgb(15, 23, 42);
            grpGestionCategoria.Location = new Point(552, 48);
            grpGestionCategoria.Name = "grpGestionCategoria";
            grpGestionCategoria.Size = new Size(328, 250);
            grpGestionCategoria.TabIndex = 2;
            grpGestionCategoria.TabStop = false;
            grpGestionCategoria.Text = "Gestión de Categoría";
            //
            // lblNombreCategoria
            //
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreCategoria.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombreCategoria.Location = new Point(16, 32);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(61, 17);
            lblNombreCategoria.TabIndex = 0;
            lblNombreCategoria.Text = "Nombre:";
            //
            // txtNombreCategoria
            //
            txtNombreCategoria.Font = new Font("Segoe UI", 9.5F);
            txtNombreCategoria.Location = new Point(16, 54);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.PlaceholderText = "Ej: Fundas y Protectores";
            txtNombreCategoria.Size = new Size(296, 24);
            txtNombreCategoria.TabIndex = 1;
            //
            // flpAccionesCategoria
            //
            flpAccionesCategoria.Controls.Add(btnNuevaCategoria);
            flpAccionesCategoria.Controls.Add(btnGuardarCategoria);
            flpAccionesCategoria.Controls.Add(btnModificarCategoria);
            flpAccionesCategoria.Controls.Add(btnConfirmarCategoria);
            flpAccionesCategoria.Controls.Add(btnCancelarCategoria);
            flpAccionesCategoria.Location = new Point(16, 92);
            flpAccionesCategoria.Name = "flpAccionesCategoria";
            flpAccionesCategoria.Size = new Size(308, 42);
            flpAccionesCategoria.TabIndex = 2;
            //
            // btnNuevaCategoria
            //
            btnNuevaCategoria.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevaCategoria.FlatAppearance.BorderSize = 0;
            btnNuevaCategoria.FlatStyle = FlatStyle.Flat;
            btnNuevaCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNuevaCategoria.ForeColor = Color.White;
            btnNuevaCategoria.Margin = new Padding(0, 0, 8, 8);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(144, 32);
            btnNuevaCategoria.TabIndex = 0;
            btnNuevaCategoria.Text = "Agregar";
            btnNuevaCategoria.UseVisualStyleBackColor = false;
            btnNuevaCategoria.Click += btnNuevaCategoria_Click;
            //
            // btnGuardarCategoria
            //
            btnGuardarCategoria.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardarCategoria.FlatAppearance.BorderSize = 0;
            btnGuardarCategoria.FlatStyle = FlatStyle.Flat;
            btnGuardarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardarCategoria.ForeColor = Color.White;
            btnGuardarCategoria.Margin = new Padding(0, 0, 8, 8);
            btnGuardarCategoria.Name = "btnGuardarCategoria";
            btnGuardarCategoria.Size = new Size(144, 32);
            btnGuardarCategoria.TabIndex = 1;
            btnGuardarCategoria.Text = "Guardar";
            btnGuardarCategoria.UseVisualStyleBackColor = false;
            btnGuardarCategoria.Click += btnGuardarCategoria_Click;
            //
            // btnModificarCategoria
            //
            btnModificarCategoria.BackColor = Color.FromArgb(37, 99, 235);
            btnModificarCategoria.FlatAppearance.BorderSize = 0;
            btnModificarCategoria.FlatStyle = FlatStyle.Flat;
            btnModificarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnModificarCategoria.ForeColor = Color.White;
            btnModificarCategoria.Margin = new Padding(0, 0, 8, 8);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(144, 32);
            btnModificarCategoria.TabIndex = 2;
            btnModificarCategoria.Text = "Modificar";
            btnModificarCategoria.UseVisualStyleBackColor = false;
            btnModificarCategoria.Click += btnModificarCategoria_Click;
            //
            // btnEliminarCategoria
            //
            btnEliminarCategoria.BackColor = Color.FromArgb(239, 68, 68);
            btnEliminarCategoria.FlatAppearance.BorderSize = 0;
            btnEliminarCategoria.FlatStyle = FlatStyle.Flat;
            btnEliminarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEliminarCategoria.ForeColor = Color.White;
            btnEliminarCategoria.Location = new Point(16, 150);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(296, 32);
            btnEliminarCategoria.TabIndex = 3;
            btnEliminarCategoria.Text = "Dar de baja";
            btnEliminarCategoria.UseVisualStyleBackColor = false;
            btnEliminarCategoria.Click += btnEliminarCategoria_Click;
            //
            // btnConfirmarCategoria
            //
            btnConfirmarCategoria.BackColor = Color.FromArgb(16, 185, 129);
            btnConfirmarCategoria.FlatAppearance.BorderSize = 0;
            btnConfirmarCategoria.FlatStyle = FlatStyle.Flat;
            btnConfirmarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnConfirmarCategoria.ForeColor = Color.White;
            btnConfirmarCategoria.Margin = new Padding(0, 0, 8, 8);
            btnConfirmarCategoria.Name = "btnConfirmarCategoria";
            btnConfirmarCategoria.Size = new Size(144, 32);
            btnConfirmarCategoria.TabIndex = 4;
            btnConfirmarCategoria.Text = "Confirmar";
            btnConfirmarCategoria.UseVisualStyleBackColor = false;
            btnConfirmarCategoria.Click += btnConfirmarCategoria_Click;
            //
            // btnCancelarCategoria
            //
            btnCancelarCategoria.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelarCategoria.FlatAppearance.BorderSize = 0;
            btnCancelarCategoria.FlatStyle = FlatStyle.Flat;
            btnCancelarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelarCategoria.ForeColor = Color.White;
            btnCancelarCategoria.Margin = new Padding(0, 0, 8, 8);
            btnCancelarCategoria.Name = "btnCancelarCategoria";
            btnCancelarCategoria.Size = new Size(144, 32);
            btnCancelarCategoria.TabIndex = 5;
            btnCancelarCategoria.Text = "Cancelar";
            btnCancelarCategoria.UseVisualStyleBackColor = false;
            btnCancelarCategoria.Click += btnCancelarCategoria_Click;
            //
            // btnVolverCategoria
            //
            btnVolverCategoria.BackColor = Color.FromArgb(100, 116, 139);
            btnVolverCategoria.FlatAppearance.BorderSize = 0;
            btnVolverCategoria.FlatStyle = FlatStyle.Flat;
            btnVolverCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolverCategoria.ForeColor = Color.White;
            btnVolverCategoria.Location = new Point(16, 200);
            btnVolverCategoria.Name = "btnVolverCategoria";
            btnVolverCategoria.Size = new Size(296, 32);
            btnVolverCategoria.TabIndex = 3;
            btnVolverCategoria.Text = "Volver";
            btnVolverCategoria.UseVisualStyleBackColor = false;
            btnVolverCategoria.Click += btnVolverMenu_Click;
            //
            // lblResultadoProducto
            //
            lblResultadoProducto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultadoProducto.ForeColor = Color.FromArgb(16, 185, 129);
            lblResultadoProducto.Location = new Point(20, 182);
            lblResultadoProducto.Name = "lblResultadoProducto";
            lblResultadoProducto.Size = new Size(670, 44);
            //
            // lblResultadoCategoria
            //
            lblResultadoCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblResultadoCategoria.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultadoCategoria.ForeColor = Color.FromArgb(16, 185, 129);
            lblResultadoCategoria.Location = new Point(552, 310);
            lblResultadoCategoria.Name = "lblResultadoCategoria";
            lblResultadoCategoria.Size = new Size(328, 60);
            //
            // FormProductos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(900, 626);
            Controls.Add(tabProductoCategoria);
            Controls.Add(panelIdioma);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(916, 665);
            Name = "FormProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Producto y Stock";
            Load += FormProductos_Load;
            panelIdioma.ResumeLayout(false);
            panelIdioma.PerformLayout();
            tabProductoCategoria.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            grpDetalleProducto.ResumeLayout(false);
            grpDetalleProducto.PerformLayout();
            flpAcciones.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            grpGestionCategoria.ResumeLayout(false);
            grpGestionCategoria.PerformLayout();
            flpAccionesCategoria.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblResultadoCategoria;

        private Label lblResultadoProducto;

        private Panel panelIdioma;
        private Label lblIdioma;
        private ComboBox cmbIdioma;
        private TabControl tabProductoCategoria;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblCatalogoExistencia;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvProductos;
        private GroupBox grpDetalleProducto;
        private FlowLayoutPanel flpAcciones;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEstadoProducto;
        private Button btnConfirmar;
        private Button btnCancelarEdicion;
        private Button btnVolverMenu;
        private Label lblCategorias;
        private ComboBox cmbCategoria;
        private Label lblProveedor;
        private ComboBox cmbProveedor;
        private Label lblNombreProducto;
        private TextBox txtNombreProducto;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrecioVenta;
        private TextBox txtPrecioVenta;
        private Label lblStockActual;
        private TextBox txtStockActual;
        private Label lblStockMinimo;
        private TextBox txtStockMinimo;
        private Label lblListadoCategoria;
        private DataGridView dgvCategorias;
        private GroupBox grpGestionCategoria;
        private Label lblNombreCategoria;
        private TextBox txtNombreCategoria;
        private FlowLayoutPanel flpAccionesCategoria;
        private Button btnNuevaCategoria;
        private Button btnGuardarCategoria;
        private Button btnModificarCategoria;
        private Button btnConfirmarCategoria;
        private Button btnCancelarCategoria;
        private Button btnEliminarCategoria;
        private Button btnVolverCategoria;
    }
}
