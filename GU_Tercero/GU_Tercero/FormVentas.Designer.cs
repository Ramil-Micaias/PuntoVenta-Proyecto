namespace Vista
{
    partial class FormVentas
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
            grpDatosVenta = new GroupBox();
            lblBuscarCliente = new Label();
            txtBuscarCliente = new TextBox();
            lblMetodoPago = new Label();
            cmbMetodoPago = new ComboBox();
            lblNumeroFactura = new Label();
            txtNumeroFactura = new TextBox();
            lblFecha = new Label();
            dateTimePicker1 = new DateTimePicker();
            grpAgregarProducto = new GroupBox();
            lblProducto = new Label();
            cmb = new ComboBox();
            txtPrecioVenta = new TextBox();
            lblPrecioVenta = new Label();
            numCantidad = new NumericUpDown();
            lblCantidad = new Label();
            btnAgregarCarrito = new Button();
            grpDetalleVenta = new GroupBox();
            dataGridView1 = new DataGridView();
            lblTotal = new Label();
            txtTotal = new TextBox();
            btnRegistrarVenta = new Button();
            txtCancelar = new Button();
            grpDatosVenta.SuspendLayout();
            grpAgregarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            grpDetalleVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // grpDatosVenta
            // 
            grpDatosVenta.Controls.Add(dateTimePicker1);
            grpDatosVenta.Controls.Add(lblFecha);
            grpDatosVenta.Controls.Add(txtNumeroFactura);
            grpDatosVenta.Controls.Add(lblNumeroFactura);
            grpDatosVenta.Controls.Add(cmbMetodoPago);
            grpDatosVenta.Controls.Add(lblMetodoPago);
            grpDatosVenta.Controls.Add(txtBuscarCliente);
            grpDatosVenta.Controls.Add(lblBuscarCliente);
            grpDatosVenta.Location = new Point(12, 12);
            grpDatosVenta.Name = "grpDatosVenta";
            grpDatosVenta.Size = new Size(776, 87);
            grpDatosVenta.TabIndex = 0;
            grpDatosVenta.TabStop = false;
            grpDatosVenta.Text = "Datos de la Venta";
            // 
            // lblBuscarCliente
            // 
            lblBuscarCliente.AutoSize = true;
            lblBuscarCliente.Location = new Point(8, 26);
            lblBuscarCliente.Name = "lblBuscarCliente";
            lblBuscarCliente.Size = new Size(85, 15);
            lblBuscarCliente.TabIndex = 0;
            lblBuscarCliente.Text = "Buscar Cliente:";
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(95, 22);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(150, 23);
            txtBuscarCliente.TabIndex = 1;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(274, 26);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(98, 15);
            lblMetodoPago.TabIndex = 2;
            lblMetodoPago.Text = "Metodo de Pago:";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(376, 22);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(150, 23);
            cmbMetodoPago.TabIndex = 3;
            // 
            // lblNumeroFactura
            // 
            lblNumeroFactura.AutoSize = true;
            lblNumeroFactura.Location = new Point(549, 26);
            lblNumeroFactura.Name = "lblNumeroFactura";
            lblNumeroFactura.Size = new Size(66, 15);
            lblNumeroFactura.TabIndex = 4;
            lblNumeroFactura.Text = "N° Factura:";
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(619, 23);
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.Size = new Size(150, 23);
            txtNumeroFactura.TabIndex = 5;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(573, 64);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 6;
            lblFecha.Text = "Fecha:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/mm/yyyy";
            dateTimePicker1.Location = new Point(620, 60);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(150, 23);
            dateTimePicker1.TabIndex = 7;
            // 
            // grpAgregarProducto
            // 
            grpAgregarProducto.Controls.Add(btnAgregarCarrito);
            grpAgregarProducto.Controls.Add(lblCantidad);
            grpAgregarProducto.Controls.Add(numCantidad);
            grpAgregarProducto.Controls.Add(lblPrecioVenta);
            grpAgregarProducto.Controls.Add(txtPrecioVenta);
            grpAgregarProducto.Controls.Add(cmb);
            grpAgregarProducto.Controls.Add(lblProducto);
            grpAgregarProducto.Location = new Point(12, 99);
            grpAgregarProducto.Name = "grpAgregarProducto";
            grpAgregarProducto.Size = new Size(776, 103);
            grpAgregarProducto.TabIndex = 1;
            grpAgregarProducto.TabStop = false;
            grpAgregarProducto.Text = "Agregar Producto";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(13, 29);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto:";
            // 
            // cmb
            // 
            cmb.FormattingEnabled = true;
            cmb.Location = new Point(78, 26);
            cmb.Name = "cmb";
            cmb.Size = new Size(167, 23);
            cmb.TabIndex = 1;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(376, 27);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(167, 23);
            txtPrecioVenta.TabIndex = 2;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Location = new Point(282, 30);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(91, 15);
            lblPrecioVenta.TabIndex = 3;
            lblPrecioVenta.Text = "Precio de Venta:";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(649, 28);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(120, 23);
            numCantidad.TabIndex = 4;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(588, 31);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // btnAgregarCarrito
            // 
            btnAgregarCarrito.Location = new Point(267, 65);
            btnAgregarCarrito.Name = "btnAgregarCarrito";
            btnAgregarCarrito.Size = new Size(259, 23);
            btnAgregarCarrito.TabIndex = 6;
            btnAgregarCarrito.Text = "Agregar al carrito";
            btnAgregarCarrito.UseVisualStyleBackColor = true;
            // 
            // grpDetalleVenta
            // 
            grpDetalleVenta.Controls.Add(txtCancelar);
            grpDetalleVenta.Controls.Add(btnRegistrarVenta);
            grpDetalleVenta.Controls.Add(txtTotal);
            grpDetalleVenta.Controls.Add(lblTotal);
            grpDetalleVenta.Controls.Add(dataGridView1);
            grpDetalleVenta.Location = new Point(12, 203);
            grpDetalleVenta.Name = "grpDetalleVenta";
            grpDetalleVenta.Size = new Size(776, 235);
            grpDetalleVenta.TabIndex = 2;
            grpDetalleVenta.TabStop = false;
            grpDetalleVenta.Text = "Detalle de la Venta";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(477, 207);
            dataGridView1.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(551, 52);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "TOTAL:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(599, 49);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(128, 23);
            txtTotal.TabIndex = 2;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Location = new Point(675, 125);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(94, 23);
            btnRegistrarVenta.TabIndex = 3;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            // 
            // txtCancelar
            // 
            txtCancelar.Location = new Point(549, 125);
            txtCancelar.Name = "txtCancelar";
            txtCancelar.Size = new Size(94, 23);
            txtCancelar.TabIndex = 4;
            txtCancelar.Text = "Cancelar";
            txtCancelar.UseVisualStyleBackColor = true;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpDetalleVenta);
            Controls.Add(grpAgregarProducto);
            Controls.Add(grpDatosVenta);
            Name = "FormVentas";
            Text = "Registro de Ventas";
            grpDatosVenta.ResumeLayout(false);
            grpDatosVenta.PerformLayout();
            grpAgregarProducto.ResumeLayout(false);
            grpAgregarProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            grpDetalleVenta.ResumeLayout(false);
            grpDetalleVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatosVenta;
        private TextBox txtBuscarCliente;
        private Label lblBuscarCliente;
        private TextBox txtNumeroFactura;
        private Label lblNumeroFactura;
        private ComboBox cmbMetodoPago;
        private Label lblMetodoPago;
        private DateTimePicker dateTimePicker1;
        private Label lblFecha;
        private GroupBox grpAgregarProducto;
        private TextBox txtPrecioVenta;
        private ComboBox cmb;
        private Label lblProducto;
        private Button btnAgregarCarrito;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Label lblPrecioVenta;
        private GroupBox grpDetalleVenta;
        private Button txtCancelar;
        private Button btnRegistrarVenta;
        private TextBox txtTotal;
        private Label lblTotal;
        private DataGridView dataGridView1;
    }
}