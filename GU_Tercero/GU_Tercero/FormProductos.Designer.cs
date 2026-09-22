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
            lblBarra = new Label();
            txtBarra = new TextBox();
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
            txtPrecioCosto = new TextBox();
            lblPrecioCosto = new Label();
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
            btnCerrarSesion = new Button();
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
            lblCatalogoExistencia.Size = new Size(127, 15);
            lblCatalogoExistencia.TabIndex = 5;
            lblCatalogoExistencia.Text = "Catologo de Existencia";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 250, 252);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnCerrarSesion);
            panel1.Controls.Add(lblBarra);
            panel1.Controls.Add(txtBarra);
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
            panel1.Controls.Add(txtPrecioCosto);
            panel1.Controls.Add(lblPrecioCosto);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(lblDescripcion);
            panel1.Location = new Point(5, 245);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 171);
            panel1.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(220, 38, 38);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(660, 125);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(105, 32);
            btnCerrarSesion.TabIndex = 11;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblBarra
            // 
            lblBarra.AutoSize = true;
            lblBarra.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBarra.ForeColor = Color.FromArgb(30, 41, 59);
            lblBarra.Location = new Point(204, 11);
            lblBarra.Name = "lblBarra";
            lblBarra.Size = new Size(95, 15);
            lblBarra.TabIndex = 0;
            lblBarra.TabStop = false;
            lblBarra.Text = "Código de Barra:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(85, 8);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(110, 23);
            txtNombreProducto.TabIndex = 0;
            // 
            // txtBarra
            // 
            txtBarra.Location = new Point(305, 8);
            txtBarra.Name = "txtBarra";
            txtBarra.Size = new Size(110, 23);
            txtBarra.TabIndex = 1;
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.Location = new Point(85, 47);
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.Size = new Size(110, 23);
            txtPrecioCosto.TabIndex = 2;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(305, 44);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(160, 23);
            cmbCategoria.TabIndex = 3;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(85, 84);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(110, 23);
            txtPrecioVenta.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(305, 84);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(330, 23);
            txtDescripcion.TabIndex = 5;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(85, 122);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(110, 23);
            txtStockActual.TabIndex = 6;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(305, 122);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(110, 23);
            txtStockMinimo.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(30, 41, 59);
            lblDescripcion.Location = new Point(227, 87);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(73, 15);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.TabStop = false;
            lblDescripcion.Text = "Descripción:";
            // 
            // dgvProductos
            // 
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(5, 30);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(776, 205);
            dgvProductos.TabIndex = 0;
            dgvProductos.TabStop = false;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(595, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(186, 23);
            txtBuscar.TabIndex = 12;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscar.Location = new Point(495, 7);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(94, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.TabStop = false;
            lblBuscar.Text = "Buscar Producto:";
            // 
            // lblCatalogoExistencia
            // 
            lblCatalogoExistencia.AutoSize = true;
            lblCatalogoExistencia.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblCatalogoExistencia.ForeColor = Color.FromArgb(15, 23, 42);
            lblCatalogoExistencia.Location = new Point(4, 5);
            lblCatalogoExistencia.Name = "lblCatalogoExistencia";
            lblCatalogoExistencia.Size = new Size(160, 20);
            lblCatalogoExistencia.TabIndex = 0;
            lblCatalogoExistencia.TabStop = false;
            lblCatalogoExistencia.Text = "Catálogo de Existencias";
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

        private Button btnCerrarSesion;
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
        private TextBox txtPrecioCosto;
        private Label lblPrecioCosto;
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
        private Label lblBarra;
        private TextBox txtBarra;
    }
}