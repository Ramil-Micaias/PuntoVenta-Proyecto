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
            tabProductoCategoria = new TabControl();
            tabPage1 = new TabPage();
            panelProductos = new Panel();
            lblCatalogoExistencia = new Label();
            panel1 = new Panel();
            btnVolverMenu = new Button();
            txtStockMinimo = new TextBox();
            lblStockMinimo = new Label();
            txtNombreProducto = new TextBox();
            lblNombreProducto = new Label();
            btnModificar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            lblCategorias = new Label();
            cmbCategoria = new ComboBox();
            txtStockActual = new TextBox();
            lblStockActual = new Label();
            txtPrecioVenta = new TextBox();
            lblPrecioVenta = new Label();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            dgvProductos = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            tabPage2 = new TabPage();
            grpGestionCategoria = new GroupBox();
            btnEliminarCategoria = new Button();
            btnGuardarCategoria = new Button();
            btnModificarCategoria = new Button();
            btnNuevaCategoria = new Button();
            textBox1 = new TextBox();
            lblNombreCategoria = new Label();
            lblListadoCategoria = new Label();
            dataGridView1 = new DataGridView();
            tabProductoCategoria.SuspendLayout();
            tabPage1.SuspendLayout();
            panelProductos.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            tabPage2.SuspendLayout();
            grpGestionCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabProductoCategoria
            // 
            tabProductoCategoria.Controls.Add(tabPage1);
            tabProductoCategoria.Controls.Add(tabPage2);
            tabProductoCategoria.Location = new Point(0, 0);
            tabProductoCategoria.Name = "tabProductoCategoria";
            tabProductoCategoria.SelectedIndex = 0;
            tabProductoCategoria.Size = new Size(801, 450);
            tabProductoCategoria.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panelProductos);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(793, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Producto";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelProductos
            // 
            panelProductos.BackColor = Color.FromArgb(241, 245, 249);
            panelProductos.Controls.Add(lblCatalogoExistencia);
            panelProductos.Controls.Add(panel1);
            panelProductos.Controls.Add(dgvProductos);
            panelProductos.Dock = DockStyle.Top;
            panelProductos.Location = new Point(3, 3);
            panelProductos.Name = "panelProductos";
            panelProductos.Size = new Size(787, 416);
            panelProductos.TabIndex = 0;
            // 
            // lblCatalogoExistencia
            // 
            lblCatalogoExistencia.AutoSize = true;
            lblCatalogoExistencia.Font = new Font("Segoe UI Bold", 14F);
            lblCatalogoExistencia.ForeColor = Color.FromArgb(15, 23, 42);
            lblCatalogoExistencia.Location = new Point(10, 10);
            lblCatalogoExistencia.Name = "lblCatalogoExistencia";
            lblCatalogoExistencia.Size = new Size(220, 25);
            lblCatalogoExistencia.TabIndex = 5;
            lblCatalogoExistencia.Text = "Catálogo de Existencias";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(241, 245, 249);
            panel1.Controls.Add(btnVolverMenu);
            panel1.Controls.Add(txtStockMinimo);
            panel1.Controls.Add(lblStockMinimo);
            panel1.Controls.Add(txtNombreProducto);
            panel1.Controls.Add(lblNombreProducto);
            panel1.Controls.Add(btnModificar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(lblCategorias);
            panel1.Controls.Add(cmbCategoria);
            panel1.Controls.Add(txtStockActual);
            panel1.Controls.Add(lblStockActual);
            panel1.Controls.Add(txtPrecioVenta);
            panel1.Controls.Add(lblPrecioVenta);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(lblDescripcion);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(lblBuscar);
            panel1.Location = new Point(10, 240);
            panel1.Name = "panel1";
            panel1.Size = new Size(765, 170);
            panel1.TabIndex = 4;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(105, 115);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(170, 24);
            txtBuscar.TabIndex = 6;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscar.Location = new Point(15, 118);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(51, 17);
            lblBuscar.TabIndex = 17;
            lblBuscar.Text = "Buscar:";
            // 
            // btnVolverMenu
            // 
            btnVolverMenu.BackColor = Color.FromArgb(100, 116, 139);
            btnVolverMenu.FlatAppearance.BorderSize = 0;
            btnVolverMenu.FlatStyle = FlatStyle.Flat;
            btnVolverMenu.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolverMenu.ForeColor = Color.White;
            btnVolverMenu.Location = new Point(610, 115);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(140, 30);
            btnVolverMenu.TabIndex = 11;
            btnVolverMenu.Text = "Volver";
            btnVolverMenu.UseVisualStyleBackColor = false;
            btnVolverMenu.Click += btnVolverMenu_Click;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Font = new Font("Segoe UI", 9.5F);
            txtStockMinimo.Location = new Point(390, 80);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(170, 24);
            txtStockMinimo.TabIndex = 5;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblStockMinimo.ForeColor = Color.FromArgb(30, 41, 59);
            lblStockMinimo.Location = new Point(295, 83);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(92, 17);
            lblStockMinimo.TabIndex = 16;
            lblStockMinimo.Text = "Stock Mínimo:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Font = new Font("Segoe UI", 9.5F);
            txtNombreProducto.Location = new Point(105, 45);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(170, 24);
            txtNombreProducto.TabIndex = 0;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreProducto.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombreProducto.Location = new Point(15, 48);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(61, 17);
            lblNombreProducto.TabIndex = 14;
            lblNombreProducto.Text = "Nombre:";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(37, 99, 235);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(610, 45);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(140, 30);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(610, 80);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 30);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(610, 10);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(140, 30);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo Producto";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblCategorias
            // 
            lblCategorias.AutoSize = true;
            lblCategorias.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCategorias.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategorias.Location = new Point(15, 13);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(76, 17);
            lblCategorias.TabIndex = 9;
            lblCategorias.Text = "Categorías:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(105, 10);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(170, 25);
            cmbCategoria.TabIndex = 7;
            // 
            // txtStockActual
            // 
            txtStockActual.Font = new Font("Segoe UI", 9.5F);
            txtStockActual.Location = new Point(390, 45);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(170, 24);
            txtStockActual.TabIndex = 4;
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblStockActual.ForeColor = Color.FromArgb(30, 41, 59);
            lblStockActual.Location = new Point(295, 48);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(84, 17);
            lblStockActual.TabIndex = 6;
            lblStockActual.Text = "Stock Actual:";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Font = new Font("Segoe UI", 9.5F);
            txtPrecioVenta.Location = new Point(390, 10);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(170, 24);
            txtPrecioVenta.TabIndex = 3;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPrecioVenta.ForeColor = Color.FromArgb(30, 41, 59);
            lblPrecioVenta.Location = new Point(295, 13);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(86, 17);
            lblPrecioVenta.TabIndex = 4;
            lblPrecioVenta.Text = "Precio Venta:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 9.5F);
            txtDescripcion.Location = new Point(105, 80);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(170, 24);
            txtDescripcion.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(30, 41, 59);
            lblDescripcion.Location = new Point(15, 83);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(80, 17);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "Descripción:";
            // 
            // dgvProductos
            // 
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(10, 40);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(765, 190);
            dgvProductos.TabIndex = 3;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(105, 115);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(170, 24);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscar.Location = new Point(15, 118);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(51, 17);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(241, 245, 249);
            tabPage2.Controls.Add(grpGestionCategoria);
            tabPage2.Controls.Add(lblListadoCategoria);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(793, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Categoría";
            // 
            // grpGestionCategoria
            // 
            grpGestionCategoria.Controls.Add(btnEliminarCategoria);
            grpGestionCategoria.Controls.Add(btnGuardarCategoria);
            grpGestionCategoria.Controls.Add(btnModificarCategoria);
            grpGestionCategoria.Controls.Add(btnNuevaCategoria);
            grpGestionCategoria.Controls.Add(textBox1);
            grpGestionCategoria.Controls.Add(lblNombreCategoria);
            grpGestionCategoria.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            grpGestionCategoria.ForeColor = Color.FromArgb(15, 23, 42);
            grpGestionCategoria.Location = new Point(480, 40);
            grpGestionCategoria.Name = "grpGestionCategoria";
            grpGestionCategoria.Size = new Size(295, 360);
            grpGestionCategoria.TabIndex = 2;
            grpGestionCategoria.TabStop = false;
            grpGestionCategoria.Text = "Gestión de Categoría";
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.BackColor = Color.FromArgb(239, 68, 68);
            btnEliminarCategoria.FlatAppearance.BorderSize = 0;
            btnEliminarCategoria.FlatStyle = FlatStyle.Flat;
            btnEliminarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEliminarCategoria.ForeColor = Color.White;
            btnEliminarCategoria.Location = new Point(155, 130);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(125, 30);
            btnEliminarCategoria.TabIndex = 5;
            btnEliminarCategoria.Text = "Eliminar";
            btnEliminarCategoria.UseVisualStyleBackColor = false;
            // 
            // btnGuardarCategoria
            // 
            btnGuardarCategoria.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardarCategoria.FlatAppearance.BorderSize = 0;
            btnGuardarCategoria.FlatStyle = FlatStyle.Flat;
            btnGuardarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardarCategoria.ForeColor = Color.White;
            btnGuardarCategoria.Location = new Point(155, 90);
            btnGuardarCategoria.Name = "btnGuardarCategoria";
            btnGuardarCategoria.Size = new Size(125, 30);
            btnGuardarCategoria.TabIndex = 4;
            btnGuardarCategoria.Text = "Guardar";
            btnGuardarCategoria.UseVisualStyleBackColor = false;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.BackColor = Color.FromArgb(37, 99, 235);
            btnModificarCategoria.FlatAppearance.BorderSize = 0;
            btnModificarCategoria.FlatStyle = FlatStyle.Flat;
            btnModificarCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnModificarCategoria.ForeColor = Color.White;
            btnModificarCategoria.Location = new Point(15, 130);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(125, 30);
            btnModificarCategoria.TabIndex = 3;
            btnModificarCategoria.Text = "Modificar";
            btnModificarCategoria.UseVisualStyleBackColor = false;
            // 
            // btnNuevaCategoria
            // 
            btnNuevaCategoria.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevaCategoria.FlatAppearance.BorderSize = 0;
            btnNuevaCategoria.FlatStyle = FlatStyle.Flat;
            btnNuevaCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNuevaCategoria.ForeColor = Color.White;
            btnNuevaCategoria.Location = new Point(15, 90);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(125, 30);
            btnNuevaCategoria.TabIndex = 2;
            btnNuevaCategoria.Text = "Nueva Categoría";
            btnNuevaCategoria.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9.5F);
            textBox1.Location = new Point(85, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(195, 24);
            textBox1.TabIndex = 1;
            // 
            // lblNombreCategoria
            // 
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreCategoria.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombreCategoria.Location = new Point(15, 43);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(61, 17);
            lblNombreCategoria.TabIndex = 0;
            lblNombreCategoria.Text = "Nombre:";
            // 
            // lblListadoCategoria
            // 
            lblListadoCategoria.AutoSize = true;
            lblListadoCategoria.Font = new Font("Segoe UI Bold", 14F);
            lblListadoCategoria.ForeColor = Color.FromArgb(15, 23, 42);
            lblListadoCategoria.Location = new Point(10, 10);
            lblListadoCategoria.Name = "lblListadoCategoria";
            lblListadoCategoria.Size = new Size(207, 25);
            lblListadoCategoria.TabIndex = 1;
            lblListadoCategoria.Text = "Listado de Categorías";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(450, 360);
            dataGridView1.TabIndex = 0;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabProductoCategoria);
            Name = "FormProductos";
            Text = "Gestión de Producto";
            Load += FormProductos_Load;
            tabProductoCategoria.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panelProductos.ResumeLayout(false);
            panelProductos.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            grpGestionCategoria.ResumeLayout(false);
            grpGestionCategoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabProductoCategoria;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panelProductos;
        private DataGridView dgvProductos;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Panel panel1;
        private Label lblDescripcion;
        private Label lblStockActual;
        private TextBox txtPrecioVenta;
        private Label lblPrecioVenta;
        private TextBox txtDescripcion;
        private TextBox txtStockActual;
        private Button btnModificar;
        private Button btnGuardar;
        private Button btnNuevo;
        private Label lblCategorias;
        private ComboBox cmbCategoria;
        private DataGridView dataGridView1;
        private GroupBox grpGestionCategoria;
        private Label lblListadoCategoria;
        private Label lblNombreCategoria;
        private Button btnModificarCategoria;
        private Button btnNuevaCategoria;
        private TextBox textBox1;
        private Button btnEliminarCategoria;
        private Button btnGuardarCategoria;
        private TextBox txtNombreProducto;
        private Label lblNombreProducto;
        private TextBox txtStockMinimo;
        private Label lblStockMinimo;
        private Label lblCatalogoExistencia;
        private Button btnVolverMenu;
    }
}