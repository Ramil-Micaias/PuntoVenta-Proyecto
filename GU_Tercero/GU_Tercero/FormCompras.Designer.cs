namespace Vista
{
    partial class FormCompras
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
            grpProveedor = new GroupBox();
            cmbProveedor = new ComboBox();
            lblProveedor = new Label();
            grpAgregar = new GroupBox();
            btnAgregarDetalle = new Button();
            txtPrecioVenta = new TextBox();
            lblPrecioVenta = new Label();
            txtCantidad = new TextBox();
            lblCantidad = new Label();
            txtCosto = new TextBox();
            lblCosto = new Label();
            cmbProducto = new ComboBox();
            lblProducto = new Label();
            grpDetalle = new GroupBox();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            lblTotalValor = new Label();
            lblTotalTitulo = new Label();
            dgvDetalle = new DataGridView();
            panelHeader.SuspendLayout();
            grpProveedor.SuspendLayout();
            grpAgregar.SuspendLayout();
            grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
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
            panelHeader.Size = new Size(1080, 56);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(454, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE COMPRAS (INGRESO DE MERCADERÍA)";
            //
            // lblCu
            //
            lblCu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCu.AutoSize = true;
            lblCu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCu.ForeColor = Color.FromArgb(148, 163, 184);
            lblCu.Location = new Point(1017, 18);
            lblCu.Name = "lblCu";
            lblCu.Size = new Size(41, 19);
            lblCu.TabIndex = 1;
            lblCu.Text = "CU04";
            //
            // grpProveedor
            //
            grpProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpProveedor.Controls.Add(cmbProveedor);
            grpProveedor.Controls.Add(lblProveedor);
            grpProveedor.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpProveedor.ForeColor = Color.FromArgb(15, 23, 42);
            grpProveedor.Location = new Point(16, 68);
            grpProveedor.Name = "grpProveedor";
            grpProveedor.Size = new Size(1048, 64);
            grpProveedor.TabIndex = 0;
            grpProveedor.TabStop = false;
            grpProveedor.Text = "Selección de Proveedor";
            //
            // lblProveedor
            //
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblProveedor.ForeColor = Color.FromArgb(30, 41, 59);
            lblProveedor.Location = new Point(16, 27);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(70, 17);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            //
            // cmbProveedor
            //
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Segoe UI", 9.5F);
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(100, 23);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(600, 25);
            cmbProveedor.TabIndex = 1;
            //
            // grpAgregar
            //
            grpAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpAgregar.Controls.Add(btnAgregarDetalle);
            grpAgregar.Controls.Add(txtPrecioVenta);
            grpAgregar.Controls.Add(lblPrecioVenta);
            grpAgregar.Controls.Add(txtCantidad);
            grpAgregar.Controls.Add(lblCantidad);
            grpAgregar.Controls.Add(txtCosto);
            grpAgregar.Controls.Add(lblCosto);
            grpAgregar.Controls.Add(cmbProducto);
            grpAgregar.Controls.Add(lblProducto);
            grpAgregar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpAgregar.ForeColor = Color.FromArgb(15, 23, 42);
            grpAgregar.Location = new Point(16, 142);
            grpAgregar.Name = "grpAgregar";
            grpAgregar.Size = new Size(430, 502);
            grpAgregar.TabIndex = 1;
            grpAgregar.TabStop = false;
            grpAgregar.Text = "Agregar Insumos/Productos";
            //
            // lblProducto
            //
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblProducto.ForeColor = Color.FromArgb(30, 41, 59);
            lblProducto.Location = new Point(16, 30);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(64, 17);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto:";
            //
            // cmbProducto
            //
            cmbProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Font = new Font("Segoe UI", 9.5F);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(16, 50);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(398, 25);
            cmbProducto.TabIndex = 1;
            //
            // lblCosto
            //
            lblCosto.AutoSize = true;
            lblCosto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCosto.ForeColor = Color.FromArgb(30, 41, 59);
            lblCosto.Location = new Point(16, 92);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(99, 17);
            lblCosto.TabIndex = 2;
            lblCosto.Text = "Costo Unit. ($):";
            //
            // txtCosto
            //
            txtCosto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCosto.Font = new Font("Segoe UI", 9.5F);
            txtCosto.Location = new Point(16, 112);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(398, 25);
            txtCosto.TabIndex = 3;
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.FromArgb(30, 41, 59);
            lblCantidad.Location = new Point(16, 154);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(117, 17);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cantidad Recibida:";
            //
            // txtCantidad
            //
            txtCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCantidad.Font = new Font("Segoe UI", 9.5F);
            txtCantidad.Location = new Point(16, 174);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(398, 25);
            txtCantidad.TabIndex = 5;
            //
            // lblPrecioVenta
            //
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPrecioVenta.ForeColor = Color.FromArgb(30, 41, 59);
            lblPrecioVenta.Location = new Point(16, 216);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(137, 17);
            lblPrecioVenta.TabIndex = 6;
            lblPrecioVenta.Text = "Precio Venta Sugerido:";
            //
            // txtPrecioVenta
            //
            txtPrecioVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrecioVenta.Font = new Font("Segoe UI", 9.5F);
            txtPrecioVenta.Location = new Point(16, 236);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(398, 25);
            txtPrecioVenta.TabIndex = 7;
            //
            // btnAgregarDetalle
            //
            btnAgregarDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAgregarDetalle.BackColor = Color.FromArgb(37, 99, 235);
            btnAgregarDetalle.FlatStyle = FlatStyle.Flat;
            btnAgregarDetalle.FlatAppearance.BorderSize = 0;
            btnAgregarDetalle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAgregarDetalle.ForeColor = Color.White;
            btnAgregarDetalle.Location = new Point(16, 290);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(398, 40);
            btnAgregarDetalle.TabIndex = 8;
            btnAgregarDetalle.Text = "Agregar al Detalle";
            btnAgregarDetalle.UseVisualStyleBackColor = false;
            //
            // grpDetalle
            //
            grpDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalle.Controls.Add(dgvDetalle);
            grpDetalle.Controls.Add(lblTotalTitulo);
            grpDetalle.Controls.Add(lblTotalValor);
            grpDetalle.Controls.Add(btnCancelar);
            grpDetalle.Controls.Add(btnRegistrar);
            grpDetalle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpDetalle.ForeColor = Color.FromArgb(15, 23, 42);
            grpDetalle.Location = new Point(454, 142);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new Size(610, 502);
            grpDetalle.TabIndex = 2;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Detalle del Ingreso";
            //
            // dgvDetalle
            //
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalle.BackgroundColor = Color.FromArgb(226, 232, 240);
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.GridColor = Color.FromArgb(203, 213, 225);
            dgvDetalle.Location = new Point(16, 26);
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(578, 352);
            dgvDetalle.TabIndex = 0;
            //
            // lblTotalTitulo
            //
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalTitulo.Location = new Point(16, 396);
            lblTotalTitulo.Name = "lblTotalTitulo";
            lblTotalTitulo.Size = new Size(65, 21);
            lblTotalTitulo.TabIndex = 1;
            lblTotalTitulo.Text = "TOTAL";
            //
            // lblTotalValor
            //
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalValor.ForeColor = Color.FromArgb(16, 185, 129);
            lblTotalValor.Location = new Point(140, 392);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(74, 30);
            lblTotalValor.TabIndex = 2;
            lblTotalValor.Text = "$0,00";
            //
            // btnCancelar
            //
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelar.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(250, 442);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnRegistrar
            //
            btnRegistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrar.BackColor = Color.FromArgb(16, 185, 129);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(404, 442);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(190, 40);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar Compra";
            btnRegistrar.UseVisualStyleBackColor = false;
            //
            // FormCompras
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1080, 660);
            Controls.Add(grpDetalle);
            Controls.Add(grpAgregar);
            Controls.Add(grpProveedor);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 620);
            Name = "FormCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CU04: Registro de Compras - Ingreso de Mercadería";
            Load += FormCompras_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpProveedor.ResumeLayout(false);
            grpProveedor.PerformLayout();
            grpAgregar.ResumeLayout(false);
            grpAgregar.PerformLayout();
            grpDetalle.ResumeLayout(false);
            grpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblCu;
        private GroupBox grpProveedor;
        private ComboBox cmbProveedor;
        private Label lblProveedor;
        private GroupBox grpAgregar;
        private Label lblProducto;
        private ComboBox cmbProducto;
        private Label lblCosto;
        private TextBox txtCosto;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Label lblPrecioVenta;
        private TextBox txtPrecioVenta;
        private Button btnAgregarDetalle;
        private GroupBox grpDetalle;
        private DataGridView dgvDetalle;
        private Label lblTotalTitulo;
        private Label lblTotalValor;
        private Button btnCancelar;
        private Button btnRegistrar;
    }
}
