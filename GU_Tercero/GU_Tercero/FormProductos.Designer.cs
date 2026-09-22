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
            panelProductos.Controls.Add(lblCatalogoExistencia);
            panelProductos.Controls.Add(panel1);
            panelProductos.Controls.Add(dgvProductos);
            panelProductos.Controls.Add(txtBuscar);
            panelProductos.Controls.Add(lblBuscar);
            panelProductos.Dock = DockStyle.Top;
            panelProductos.Location = new Point(3, 3);
            panelProductos.Name = "panelProductos";
            panelProductos.Size = new Size(787, 416);
            panelProductos.TabIndex = 0;
            // 
            // lblCatalogoExistencia
            // 
            lblCatalogoExistencia.AutoSize = true;
            lblCatalogoExistencia.Location = new Point(4, 6);
            lblCatalogoExistencia.Name = "lblCatalogoExistencia";
            lblCatalogoExistencia.Size = new Size(126, 15);
            lblCatalogoExistencia.TabIndex = 5;
            lblCatalogoExistencia.Text = "Catologo de Existencia";
            // 
            // panel1
            // 
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
            panel1.Location = new Point(5, 249);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 171);
            panel1.TabIndex = 4;
            // 
            // btnVolverMenu
            // 
            btnVolverMenu.BackColor = Color.FromArgb(100, 116, 139);
            btnVolverMenu.FlatAppearance.BorderSize = 0;
            btnVolverMenu.FlatStyle = FlatStyle.Flat;
            btnVolverMenu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnVolverMenu.ForeColor = Color.White;
            btnVolverMenu.Location = new Point(698, 86);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(75, 23);
            btnVolverMenu.TabIndex = 11;
            btnVolverMenu.TabStop = false;
            btnVolverMenu.Text = "Volver";
            btnVolverMenu.UseVisualStyleBackColor = false;
            btnVolverMenu.Click += btnVolverMenu_Click;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(85, 142);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 5;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(1, 145);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(81, 15);
            lblStockMinimo.TabIndex = 16;
            lblStockMinimo.Text = "Stock Minimo";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(88, 34);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(100, 23);
            txtNombreProducto.TabIndex = 0;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(31, 38);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 14;
            lblNombreProducto.Text = "Nombre";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(37, 99, 235);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(698, 30);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 9;
            btnModificar.TabStop = false;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(22, 163, 74);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(698, 58);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.TabStop = false;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(71, 85, 105);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(698, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 8;
            btnNuevo.TabStop = false;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblCategorias
            // 
            lblCategorias.AutoSize = true;
            lblCategorias.Location = new Point(19, 12);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(63, 15);
            lblCategorias.TabIndex = 9;
            lblCategorias.Text = "Categorias";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(88, 6);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(179, 23);
            cmbCategoria.TabIndex = 7;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(85, 115);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(100, 23);
            txtStockActual.TabIndex = 4;
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(10, 119);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(73, 15);
            lblStockActual.TabIndex = 6;
            lblStockActual.Text = "Stock Actual";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(85, 87);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 3;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Location = new Point(11, 91);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(72, 15);
            lblPrecioVenta.TabIndex = 4;
            lblPrecioVenta.Text = "Precio Venta";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(88, 62);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(100, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(13, 66);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "Descripción";
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(5, 25);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(502, 217);
            dgvProductos.TabIndex = 3;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(592, 6);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(186, 23);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(544, 6);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(42, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(grpGestionCategoria);
            tabPage2.Controls.Add(lblListadoCategoria);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(793, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Categoria";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpGestionCategoria
            // 
            grpGestionCategoria.Controls.Add(btnEliminarCategoria);
            grpGestionCategoria.Controls.Add(btnGuardarCategoria);
            grpGestionCategoria.Controls.Add(btnModificarCategoria);
            grpGestionCategoria.Controls.Add(btnNuevaCategoria);
            grpGestionCategoria.Controls.Add(textBox1);
            grpGestionCategoria.Controls.Add(lblNombreCategoria);
            grpGestionCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpGestionCategoria.Location = new Point(491, 62);
            grpGestionCategoria.Name = "grpGestionCategoria";
            grpGestionCategoria.Size = new Size(293, 352);
            grpGestionCategoria.TabIndex = 2;
            grpGestionCategoria.TabStop = false;
            grpGestionCategoria.Text = "Gestión de Categoría";
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarCategoria.Location = new Point(167, 306);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(120, 23);
            btnEliminarCategoria.TabIndex = 5;
            btnEliminarCategoria.Text = "Eliminar";
            btnEliminarCategoria.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCategoria
            // 
            btnGuardarCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarCategoria.Location = new Point(167, 279);
            btnGuardarCategoria.Name = "btnGuardarCategoria";
            btnGuardarCategoria.Size = new Size(120, 23);
            btnGuardarCategoria.TabIndex = 4;
            btnGuardarCategoria.Text = "Guardar";
            btnGuardarCategoria.UseVisualStyleBackColor = true;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarCategoria.Location = new Point(15, 306);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(120, 23);
            btnModificarCategoria.TabIndex = 3;
            btnModificarCategoria.Text = "Modificar Categoria";
            btnModificarCategoria.UseVisualStyleBackColor = true;
            // 
            // btnNuevaCategoria
            // 
            btnNuevaCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevaCategoria.Location = new Point(15, 279);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(120, 23);
            btnNuevaCategoria.TabIndex = 2;
            btnNuevaCategoria.Text = "Nueva Categoria";
            btnNuevaCategoria.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(79, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 23);
            textBox1.TabIndex = 1;
            // 
            // lblNombreCategoria
            // 
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreCategoria.Location = new Point(15, 43);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(51, 15);
            lblNombreCategoria.TabIndex = 0;
            lblNombreCategoria.Text = "Nombre";
            // 
            // lblListadoCategoria
            // 
            lblListadoCategoria.AutoSize = true;
            lblListadoCategoria.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblListadoCategoria.Location = new Point(3, 26);
            lblListadoCategoria.Name = "lblListadoCategoria";
            lblListadoCategoria.Size = new Size(193, 25);
            lblListadoCategoria.TabIndex = 1;
            lblListadoCategoria.Text = "Listado de Categorias";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 70);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(425, 344);
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