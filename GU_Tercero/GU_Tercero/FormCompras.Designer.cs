namespace Vista
{
    partial class FormCompras
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
            grpDatosCompra = new GroupBox();
            lblProveedor = new Label();
            cmbProveedores = new ComboBox();
            lblMetodoPago = new Label();
            cmbMetodoPago = new ComboBox();
            lblNumeroFactura = new Label();
            txtNumeroComprobante = new TextBox();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            grpDetalleCompra = new GroupBox();
            dgvDetalleCompra = new DataGridView();
            lblTotal = new Label();
            txtTotal = new TextBox();
            btnRegistrarCompra = new Button();
            btnCancelar = new Button();
            grpAgregarProducto = new GroupBox();
            cmbProducto = new ComboBox();
            lblProducto = new Label();
            lblCostoUnitorio = new Label();
            txtCostoUnitario = new TextBox();
            numCantidad = new NumericUpDown();
            lblCantidad = new Label();
            btnAgregarItem = new Button();
            grpDatosCompra.SuspendLayout();
            grpDetalleCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit();
            grpAgregarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // grpDatosCompra
            // 
            grpDatosCompra.Controls.Add(lblFecha);
            grpDatosCompra.Controls.Add(dtpFecha);
            grpDatosCompra.Controls.Add(txtNumeroComprobante);
            grpDatosCompra.Controls.Add(lblNumeroFactura);
            grpDatosCompra.Controls.Add(cmbMetodoPago);
            grpDatosCompra.Controls.Add(lblMetodoPago);
            grpDatosCompra.Controls.Add(cmbProveedores);
            grpDatosCompra.Controls.Add(lblProveedor);
            grpDatosCompra.Location = new Point(12, 3);
            grpDatosCompra.Name = "grpDatosCompra";
            grpDatosCompra.Size = new Size(776, 100);
            grpDatosCompra.TabIndex = 0;
            grpDatosCompra.TabStop = false;
            grpDatosCompra.Text = "Datos de la Compra";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(12, 25);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedores
            // 
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(76, 22);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(121, 23);
            cmbProveedores.TabIndex = 1;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(220, 25);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(82, 15);
            lblMetodoPago.TabIndex = 2;
            lblMetodoPago.Text = "Método Pago:";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(303, 22);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(121, 23);
            cmbMetodoPago.TabIndex = 3;
            // 
            // lblNumeroFactura
            // 
            lblNumeroFactura.AutoSize = true;
            lblNumeroFactura.Location = new Point(445, 25);
            lblNumeroFactura.Name = "lblNumeroFactura";
            lblNumeroFactura.Size = new Size(125, 15);
            lblNumeroFactura.TabIndex = 4;
            lblNumeroFactura.Text = "N° de Factura/Remito:";
            // 
            // txtNumeroComprobante
            // 
            txtNumeroComprobante.Location = new Point(570, 22);
            txtNumeroComprobante.Name = "txtNumeroComprobante";
            txtNumeroComprobante.Size = new Size(200, 23);
            txtNumeroComprobante.TabIndex = 5;
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/mm/yyyy";
            dtpFecha.Location = new Point(570, 60);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 6;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(467, 64);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(103, 15);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha de Compra:";
            // 
            // grpDetalleCompra
            // 
            grpDetalleCompra.Controls.Add(btnCancelar);
            grpDetalleCompra.Controls.Add(btnRegistrarCompra);
            grpDetalleCompra.Controls.Add(txtTotal);
            grpDetalleCompra.Controls.Add(lblTotal);
            grpDetalleCompra.Controls.Add(dgvDetalleCompra);
            grpDetalleCompra.Location = new Point(328, 109);
            grpDetalleCompra.Name = "grpDetalleCompra";
            grpDetalleCompra.Size = new Size(460, 329);
            grpDetalleCompra.TabIndex = 1;
            grpDetalleCompra.TabStop = false;
            grpDetalleCompra.Text = "Detalle de Compra";
            // 
            // dgvDetalleCompra
            // 
            dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleCompra.Location = new Point(6, 22);
            dgvDetalleCompra.Name = "dgvDetalleCompra";
            dgvDetalleCompra.ReadOnly = true;
            dgvDetalleCompra.Size = new Size(448, 228);
            dgvDetalleCompra.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(6, 267);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "TOTAL:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(54, 264);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(135, 23);
            txtTotal.TabIndex = 2;
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.Location = new Point(278, 264);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Size = new Size(107, 23);
            btnRegistrarCompra.TabIndex = 3;
            btnRegistrarCompra.Text = "Registrar Compra";
            btnRegistrarCompra.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(278, 293);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpAgregarProducto
            // 
            grpAgregarProducto.Controls.Add(btnAgregarItem);
            grpAgregarProducto.Controls.Add(lblCantidad);
            grpAgregarProducto.Controls.Add(numCantidad);
            grpAgregarProducto.Controls.Add(txtCostoUnitario);
            grpAgregarProducto.Controls.Add(lblCostoUnitorio);
            grpAgregarProducto.Controls.Add(lblProducto);
            grpAgregarProducto.Controls.Add(cmbProducto);
            grpAgregarProducto.Location = new Point(12, 109);
            grpAgregarProducto.Name = "grpAgregarProducto";
            grpAgregarProducto.Size = new Size(310, 316);
            grpAgregarProducto.TabIndex = 2;
            grpAgregarProducto.TabStop = false;
            grpAgregarProducto.Text = "Agregar Producto a la Lista";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(94, 22);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(208, 23);
            cmbProducto.TabIndex = 0;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(33, 25);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 1;
            lblProducto.Text = "Producto:";
            // 
            // lblCostoUnitorio
            // 
            lblCostoUnitorio.AutoSize = true;
            lblCostoUnitorio.Location = new Point(6, 71);
            lblCostoUnitorio.Name = "lblCostoUnitorio";
            lblCostoUnitorio.Size = new Size(86, 15);
            lblCostoUnitorio.TabIndex = 2;
            lblCostoUnitorio.Text = "Costo Unitario:";
            // 
            // txtCostoUnitario
            // 
            txtCostoUnitario.Location = new Point(94, 68);
            txtCostoUnitario.Name = "txtCostoUnitario";
            txtCostoUnitario.Size = new Size(208, 23);
            txtCostoUnitario.TabIndex = 3;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(94, 115);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(120, 23);
            numCantidad.TabIndex = 4;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(33, 118);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // btnAgregarItem
            // 
            btnAgregarItem.Location = new Point(176, 267);
            btnAgregarItem.Name = "btnAgregarItem";
            btnAgregarItem.Size = new Size(109, 23);
            btnAgregarItem.TabIndex = 6;
            btnAgregarItem.Text = "Agregar Producto";
            btnAgregarItem.UseVisualStyleBackColor = true;
            // 
            // FormCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpAgregarProducto);
            Controls.Add(grpDetalleCompra);
            Controls.Add(grpDatosCompra);
            Name = "FormCompras";
            Text = "Registro de Compras";
            Load += FormCompras_Load;
            grpDatosCompra.ResumeLayout(false);
            grpDatosCompra.PerformLayout();
            grpDetalleCompra.ResumeLayout(false);
            grpDetalleCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit();
            grpAgregarProducto.ResumeLayout(false);
            grpAgregarProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatosCompra;
        private ComboBox cmbProveedores;
        private Label lblProveedor;
        private Label lblMetodoPago;
        private ComboBox cmbMetodoPago;
        private TextBox txtNumeroComprobante;
        private Label lblNumeroFactura;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private GroupBox grpDetalleCompra;
        private DataGridView dgvDetalleCompra;
        private Button btnCancelar;
        private Button btnRegistrarCompra;
        private TextBox txtTotal;
        private Label lblTotal;
        private GroupBox grpAgregarProducto;
        private ComboBox cmbProducto;
        private TextBox txtCostoUnitario;
        private Label lblCostoUnitorio;
        private Label lblProducto;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Button btnAgregarItem;
    }
}