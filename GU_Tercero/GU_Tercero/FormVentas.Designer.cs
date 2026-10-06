namespace Vista
{
    partial class FormVentas
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
            panelIzq = new Panel();
            grpBusqueda = new GroupBox();
            btnAgregarCarrito = new Button();
            numCantidad = new NumericUpDown();
            lblCantidad = new Label();
            dgvResultados = new DataGridView();
            btnBuscar = new Button();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            txtBuscar = new TextBox();
            lblBuscarNombre = new Label();
            grpCarrito = new GroupBox();
            dgvCarrito = new DataGridView();
            lblResumenCarrito = new Label();
            btnQuitarSeleccionado = new Button();
            panelDer = new Panel();
            grpResumen = new GroupBox();
            lblAyuda = new Label();
            btnCancelarOperacion = new Button();
            btnConfirmarVenta = new Button();
            lblTotalNeto = new Label();
            lblTotalTitulo = new Label();
            numDescuento = new NumericUpDown();
            lblDescuentoTitulo = new Label();
            lblSubtotalValor = new Label();
            lblSubtotalTitulo = new Label();
            cmbMetodoPago = new ComboBox();
            lblMetodoPago = new Label();
            cmbCliente = new ComboBox();
            lblCliente = new Label();
            panelHeader.SuspendLayout();
            panelIzq.SuspendLayout();
            grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            grpCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            panelDer.SuspendLayout();
            grpResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDescuento).BeginInit();
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
            // lblCu
            // 
            lblCu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCu.AutoSize = true;
            lblCu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCu.ForeColor = Color.FromArgb(148, 163, 184);
            lblCu.Location = new Point(1017, 18);
            lblCu.Name = "lblCu";
            lblCu.Size = new Size(44, 19);
            lblCu.TabIndex = 1;
            lblCu.Text = "CU01";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(279, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE VENTAS (POS)";
            // 
            // panelIzq
            // 
            panelIzq.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelIzq.Controls.Add(grpBusqueda);
            panelIzq.Controls.Add(grpCarrito);
            panelIzq.Location = new Point(16, 68);
            panelIzq.Name = "panelIzq";
            panelIzq.Size = new Size(690, 576);
            panelIzq.TabIndex = 1;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Controls.Add(btnAgregarCarrito);
            grpBusqueda.Controls.Add(numCantidad);
            grpBusqueda.Controls.Add(lblCantidad);
            grpBusqueda.Controls.Add(dgvResultados);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(cmbCategoria);
            grpBusqueda.Controls.Add(lblCategoria);
            grpBusqueda.Controls.Add(txtBuscar);
            grpBusqueda.Controls.Add(lblBuscarNombre);
            grpBusqueda.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpBusqueda.ForeColor = Color.FromArgb(15, 23, 42);
            grpBusqueda.Location = new Point(0, 0);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(690, 178);
            grpBusqueda.TabIndex = 0;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Búsqueda de Productos";
            // 
            // btnAgregarCarrito
            // 
            btnAgregarCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarCarrito.BackColor = Color.FromArgb(37, 99, 235);
            btnAgregarCarrito.FlatAppearance.BorderSize = 0;
            btnAgregarCarrito.FlatStyle = FlatStyle.Flat;
            btnAgregarCarrito.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAgregarCarrito.ForeColor = Color.White;
            btnAgregarCarrito.Location = new Point(500, 142);
            btnAgregarCarrito.Name = "btnAgregarCarrito";
            btnAgregarCarrito.Size = new Size(174, 27);
            btnAgregarCarrito.TabIndex = 8;
            btnAgregarCarrito.Text = "Agregar al Carrito";
            btnAgregarCarrito.UseVisualStyleBackColor = false;
            // 
            // numCantidad
            // 
            numCantidad.Font = new Font("Segoe UI", 9.5F);
            numCantidad.Location = new Point(84, 143);
            numCantidad.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(70, 24);
            numCantidad.TabIndex = 7;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.FromArgb(30, 41, 59);
            lblCantidad.Location = new Point(16, 147);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(65, 17);
            lblCantidad.TabIndex = 6;
            lblCantidad.Text = "Cantidad:";
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.BackgroundColor = Color.FromArgb(226, 232, 240);
            dgvResultados.BorderStyle = BorderStyle.None;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.GridColor = Color.FromArgb(203, 213, 225);
            dgvResultados.Location = new Point(16, 60);
            dgvResultados.MultiSelect = false;
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(658, 78);
            dgvResultados.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(37, 99, 235);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(612, 24);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(62, 27);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(482, 25);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(126, 25);
            cmbCategoria.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategoria.Location = new Point(410, 29);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(69, 17);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "Categoría:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(210, 25);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(190, 24);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscarNombre
            // 
            lblBuscarNombre.AutoSize = true;
            lblBuscarNombre.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBuscarNombre.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscarNombre.Location = new Point(16, 29);
            lblBuscarNombre.Name = "lblBuscarNombre";
            lblBuscarNombre.Size = new Size(185, 17);
            lblBuscarNombre.TabIndex = 0;
            lblBuscarNombre.Text = "Buscar por nombre o código:";
            // 
            // grpCarrito
            // 
            grpCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpCarrito.Controls.Add(dgvCarrito);
            grpCarrito.Controls.Add(lblResumenCarrito);
            grpCarrito.Controls.Add(btnQuitarSeleccionado);
            grpCarrito.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpCarrito.ForeColor = Color.FromArgb(15, 23, 42);
            grpCarrito.Location = new Point(0, 186);
            grpCarrito.Name = "grpCarrito";
            grpCarrito.Size = new Size(690, 390);
            grpCarrito.TabIndex = 1;
            grpCarrito.TabStop = false;
            grpCarrito.Text = "Detalle del Carrito";
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCarrito.BackgroundColor = Color.FromArgb(226, 232, 240);
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.GridColor = Color.FromArgb(203, 213, 225);
            dgvCarrito.Location = new Point(16, 26);
            dgvCarrito.MultiSelect = false;
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(658, 312);
            dgvCarrito.TabIndex = 0;
            // 
            // lblResumenCarrito
            // 
            lblResumenCarrito.AutoSize = true;
            lblResumenCarrito.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblResumenCarrito.ForeColor = Color.FromArgb(71, 85, 105);
            lblResumenCarrito.Location = new Point(16, 353);
            lblResumenCarrito.Name = "lblResumenCarrito";
            lblResumenCarrito.Size = new Size(75, 17);
            lblResumenCarrito.TabIndex = 1;
            lblResumenCarrito.Text = "Artículos: 0";
            // 
            // btnQuitarSeleccionado
            // 
            btnQuitarSeleccionado.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarSeleccionado.BackColor = Color.FromArgb(239, 68, 68);
            btnQuitarSeleccionado.FlatAppearance.BorderSize = 0;
            btnQuitarSeleccionado.FlatStyle = FlatStyle.Flat;
            btnQuitarSeleccionado.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnQuitarSeleccionado.ForeColor = Color.White;
            btnQuitarSeleccionado.Location = new Point(520, 348);
            btnQuitarSeleccionado.Name = "btnQuitarSeleccionado";
            btnQuitarSeleccionado.Size = new Size(154, 27);
            btnQuitarSeleccionado.TabIndex = 2;
            btnQuitarSeleccionado.Text = "Quitar Seleccionado";
            btnQuitarSeleccionado.UseVisualStyleBackColor = false;
            // 
            // panelDer
            // 
            panelDer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDer.Controls.Add(grpResumen);
            panelDer.Location = new Point(714, 68);
            panelDer.Name = "panelDer";
            panelDer.Size = new Size(350, 576);
            panelDer.TabIndex = 2;
            // 
            // grpResumen
            // 
            grpResumen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpResumen.Controls.Add(lblAyuda);
            grpResumen.Controls.Add(btnCancelarOperacion);
            grpResumen.Controls.Add(btnConfirmarVenta);
            grpResumen.Controls.Add(lblTotalNeto);
            grpResumen.Controls.Add(lblTotalTitulo);
            grpResumen.Controls.Add(numDescuento);
            grpResumen.Controls.Add(lblDescuentoTitulo);
            grpResumen.Controls.Add(lblSubtotalValor);
            grpResumen.Controls.Add(lblSubtotalTitulo);
            grpResumen.Controls.Add(cmbMetodoPago);
            grpResumen.Controls.Add(lblMetodoPago);
            grpResumen.Controls.Add(cmbCliente);
            grpResumen.Controls.Add(lblCliente);
            grpResumen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpResumen.ForeColor = Color.FromArgb(15, 23, 42);
            grpResumen.Location = new Point(0, 0);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(350, 576);
            grpResumen.TabIndex = 0;
            grpResumen.TabStop = false;
            grpResumen.Text = "Resumen de Pago";
            // 
            // lblAyuda
            // 
            lblAyuda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAyuda.Font = new Font("Segoe UI", 8.5F);
            lblAyuda.ForeColor = Color.FromArgb(100, 116, 139);
            lblAyuda.Location = new Point(16, 470);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(318, 40);
            lblAyuda.TabIndex = 12;
            lblAyuda.Text = "Al confirmar se descuenta el stock, se registra el ingreso en la caja y se emite el comprobante interno.";
            // 
            // btnCancelarOperacion
            // 
            btnCancelarOperacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCancelarOperacion.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelarOperacion.FlatAppearance.BorderSize = 0;
            btnCancelarOperacion.FlatStyle = FlatStyle.Flat;
            btnCancelarOperacion.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnCancelarOperacion.ForeColor = Color.White;
            btnCancelarOperacion.Location = new Point(16, 410);
            btnCancelarOperacion.Name = "btnCancelarOperacion";
            btnCancelarOperacion.Size = new Size(318, 44);
            btnCancelarOperacion.TabIndex = 11;
            btnCancelarOperacion.Text = "CANCELAR OPERACIÓN";
            btnCancelarOperacion.UseVisualStyleBackColor = false;
            // 
            // btnConfirmarVenta
            // 
            btnConfirmarVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConfirmarVenta.BackColor = Color.FromArgb(16, 185, 129);
            btnConfirmarVenta.FlatAppearance.BorderSize = 0;
            btnConfirmarVenta.FlatStyle = FlatStyle.Flat;
            btnConfirmarVenta.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnConfirmarVenta.ForeColor = Color.White;
            btnConfirmarVenta.Location = new Point(16, 352);
            btnConfirmarVenta.Name = "btnConfirmarVenta";
            btnConfirmarVenta.Size = new Size(318, 48);
            btnConfirmarVenta.TabIndex = 10;
            btnConfirmarVenta.Text = "CONFIRMAR VENTA";
            btnConfirmarVenta.UseVisualStyleBackColor = false;
            // 
            // lblTotalNeto
            // 
            lblTotalNeto.AutoSize = true;
            lblTotalNeto.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalNeto.ForeColor = Color.FromArgb(16, 185, 129);
            lblTotalNeto.Location = new Point(14, 282);
            lblTotalNeto.Name = "lblTotalNeto";
            lblTotalNeto.Size = new Size(94, 41);
            lblTotalNeto.TabIndex = 9;
            lblTotalNeto.Text = "$0,00";
            // 
            // lblTotalTitulo
            // 
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalTitulo.Location = new Point(16, 258);
            lblTotalTitulo.Name = "lblTotalTitulo";
            lblTotalTitulo.Size = new Size(106, 21);
            lblTotalTitulo.TabIndex = 8;
            lblTotalTitulo.Text = "TOTAL NETO:";
            // 
            // numDescuento
            // 
            numDescuento.DecimalPlaces = 2;
            numDescuento.Font = new Font("Segoe UI", 9.5F);
            numDescuento.Location = new Point(140, 208);
            numDescuento.Name = "numDescuento";
            numDescuento.Size = new Size(90, 24);
            numDescuento.TabIndex = 7;
            // 
            // lblDescuentoTitulo
            // 
            lblDescuentoTitulo.AutoSize = true;
            lblDescuentoTitulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDescuentoTitulo.ForeColor = Color.FromArgb(30, 41, 59);
            lblDescuentoTitulo.Location = new Point(16, 212);
            lblDescuentoTitulo.Name = "lblDescuentoTitulo";
            lblDescuentoTitulo.Size = new Size(98, 17);
            lblDescuentoTitulo.TabIndex = 6;
            lblDescuentoTitulo.Text = "Descuento (%):";
            // 
            // lblSubtotalValor
            // 
            lblSubtotalValor.AutoSize = true;
            lblSubtotalValor.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubtotalValor.ForeColor = Color.FromArgb(15, 23, 42);
            lblSubtotalValor.Location = new Point(16, 171);
            lblSubtotalValor.Name = "lblSubtotalValor";
            lblSubtotalValor.Size = new Size(49, 20);
            lblSubtotalValor.TabIndex = 5;
            lblSubtotalValor.Text = "$0,00";
            // 
            // lblSubtotalTitulo
            // 
            lblSubtotalTitulo.AutoSize = true;
            lblSubtotalTitulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblSubtotalTitulo.ForeColor = Color.FromArgb(30, 41, 59);
            lblSubtotalTitulo.Location = new Point(16, 150);
            lblSubtotalTitulo.Name = "lblSubtotalTitulo";
            lblSubtotalTitulo.Size = new Size(62, 17);
            lblSubtotalTitulo.TabIndex = 4;
            lblSubtotalTitulo.Text = "Subtotal:";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.Font = new Font("Segoe UI", 9.5F);
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(16, 106);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(318, 25);
            cmbMetodoPago.TabIndex = 3;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMetodoPago.ForeColor = Color.FromArgb(30, 41, 59);
            lblMetodoPago.Location = new Point(16, 86);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(113, 17);
            lblMetodoPago.TabIndex = 2;
            lblMetodoPago.Text = "Método de Pago:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 9.5F);
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(16, 48);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(318, 25);
            cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCliente.ForeColor = Color.FromArgb(30, 41, 59);
            lblCliente.Location = new Point(16, 28);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(52, 17);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1080, 660);
            Controls.Add(panelDer);
            Controls.Add(panelIzq);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 620);
            Name = "FormVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CU01: Registro de Ventas - Punto de Venta (POS)";
            Load += FormVentas_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelIzq.ResumeLayout(false);
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            grpCarrito.ResumeLayout(false);
            grpCarrito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            panelDer.ResumeLayout(false);
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDescuento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblCu;
        private Panel panelIzq;
        private GroupBox grpBusqueda;
        private Label lblBuscarNombre;
        private TextBox txtBuscar;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Button btnBuscar;
        private DataGridView dgvResultados;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Button btnAgregarCarrito;
        private GroupBox grpCarrito;
        private DataGridView dgvCarrito;
        private Label lblResumenCarrito;
        private Button btnQuitarSeleccionado;
        private Panel panelDer;
        private GroupBox grpResumen;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblMetodoPago;
        private ComboBox cmbMetodoPago;
        private Label lblSubtotalTitulo;
        private Label lblSubtotalValor;
        private Label lblDescuentoTitulo;
        private NumericUpDown numDescuento;
        private Label lblTotalTitulo;
        private Label lblTotalNeto;
        private Button btnConfirmarVenta;
        private Button btnCancelarOperacion;
        private Label lblAyuda;
    }
}
