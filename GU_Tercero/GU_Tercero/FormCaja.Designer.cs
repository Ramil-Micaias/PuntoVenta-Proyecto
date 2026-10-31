namespace Vista
{
    partial class FormCaja
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
            grpResumen = new GroupBox();
            lblEstado = new Label();
            btnHistorial = new Button();
            lblSaldoInicialTitulo = new Label();
            lblSaldoInicialValor = new Label();
            lblIngresosTitulo = new Label();
            lblIngresosValor = new Label();
            lblEgresosTitulo = new Label();
            lblEgresosValor = new Label();
            lblSaldoTitulo = new Label();
            lblSaldoValor = new Label();
            grpMovimientos = new GroupBox();
            dgvMovimientos = new DataGridView();
            lblApertura = new Label();
            lblResultado = new Label();
            txtSaldoInicial = new TextBox();
            btnAbrirCaja = new Button();
            btnVolver = new Button();
            btnCerrarCaja = new Button();
            btnRegistrarMovimiento = new Button();
            panelHeader.SuspendLayout();
            grpResumen.SuspendLayout();
            grpMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
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
            lblCu.Text = "CU06";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(140, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CAJA DIARIA";
            //
            // grpResumen
            //
            grpResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpResumen.Controls.Add(lblEstado);
            grpResumen.Controls.Add(btnHistorial);
            grpResumen.Controls.Add(lblSaldoInicialTitulo);
            grpResumen.Controls.Add(lblSaldoInicialValor);
            grpResumen.Controls.Add(lblIngresosTitulo);
            grpResumen.Controls.Add(lblIngresosValor);
            grpResumen.Controls.Add(lblEgresosTitulo);
            grpResumen.Controls.Add(lblEgresosValor);
            grpResumen.Controls.Add(lblSaldoTitulo);
            grpResumen.Controls.Add(lblSaldoValor);
            grpResumen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpResumen.ForeColor = Color.FromArgb(15, 23, 42);
            grpResumen.Location = new Point(16, 68);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(1048, 118);
            grpResumen.TabIndex = 0;
            grpResumen.TabStop = false;
            grpResumen.Text = "Caja de la Jornada";
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(30, 41, 59);
            lblEstado.Location = new Point(16, 26);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(10, 17);
            lblEstado.TabIndex = 0;
            // 
            // btnHistorial
            // 
            btnHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHistorial.BackColor = Color.FromArgb(37, 99, 235);
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnHistorial.ForeColor = Color.White;
            btnHistorial.Location = new Point(882, 20);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(150, 30);
            btnHistorial.TabIndex = 9;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = false;
            //
            // lblSaldoInicialTitulo
            //
            lblSaldoInicialTitulo.AutoSize = true;
            lblSaldoInicialTitulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblSaldoInicialTitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSaldoInicialTitulo.Location = new Point(16, 56);
            lblSaldoInicialTitulo.Name = "lblSaldoInicialTitulo";
            lblSaldoInicialTitulo.Size = new Size(87, 17);
            lblSaldoInicialTitulo.TabIndex = 1;
            lblSaldoInicialTitulo.Text = "Saldo Inicial";
            //
            // lblSaldoInicialValor
            //
            lblSaldoInicialValor.AutoSize = true;
            lblSaldoInicialValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSaldoInicialValor.ForeColor = Color.FromArgb(15, 23, 42);
            lblSaldoInicialValor.Location = new Point(16, 76);
            lblSaldoInicialValor.Name = "lblSaldoInicialValor";
            lblSaldoInicialValor.Size = new Size(60, 25);
            lblSaldoInicialValor.TabIndex = 2;
            lblSaldoInicialValor.Text = "$0,00";
            //
            // lblIngresosTitulo
            //
            lblIngresosTitulo.AutoSize = true;
            lblIngresosTitulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblIngresosTitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblIngresosTitulo.Location = new Point(276, 56);
            lblIngresosTitulo.Name = "lblIngresosTitulo";
            lblIngresosTitulo.Size = new Size(62, 17);
            lblIngresosTitulo.TabIndex = 3;
            lblIngresosTitulo.Text = "Ingresos";
            //
            // lblIngresosValor
            //
            lblIngresosValor.AutoSize = true;
            lblIngresosValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblIngresosValor.ForeColor = Color.FromArgb(16, 185, 129);
            lblIngresosValor.Location = new Point(276, 76);
            lblIngresosValor.Name = "lblIngresosValor";
            lblIngresosValor.Size = new Size(60, 25);
            lblIngresosValor.TabIndex = 4;
            lblIngresosValor.Text = "$0,00";
            //
            // lblEgresosTitulo
            //
            lblEgresosTitulo.AutoSize = true;
            lblEgresosTitulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEgresosTitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblEgresosTitulo.Location = new Point(536, 56);
            lblEgresosTitulo.Name = "lblEgresosTitulo";
            lblEgresosTitulo.Size = new Size(58, 17);
            lblEgresosTitulo.TabIndex = 5;
            lblEgresosTitulo.Text = "Egresos";
            //
            // lblEgresosValor
            //
            lblEgresosValor.AutoSize = true;
            lblEgresosValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblEgresosValor.ForeColor = Color.FromArgb(239, 68, 68);
            lblEgresosValor.Location = new Point(536, 76);
            lblEgresosValor.Name = "lblEgresosValor";
            lblEgresosValor.Size = new Size(60, 25);
            lblEgresosValor.TabIndex = 6;
            lblEgresosValor.Text = "$0,00";
            //
            // lblSaldoTitulo
            //
            lblSaldoTitulo.AutoSize = true;
            lblSaldoTitulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblSaldoTitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSaldoTitulo.Location = new Point(796, 56);
            lblSaldoTitulo.Name = "lblSaldoTitulo";
            lblSaldoTitulo.Size = new Size(114, 17);
            lblSaldoTitulo.TabIndex = 7;
            lblSaldoTitulo.Text = "Saldo Disponible (efectivo)";
            //
            // lblSaldoValor
            //
            lblSaldoValor.AutoSize = true;
            lblSaldoValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSaldoValor.ForeColor = Color.FromArgb(37, 99, 235);
            lblSaldoValor.Location = new Point(796, 76);
            lblSaldoValor.Name = "lblSaldoValor";
            lblSaldoValor.Size = new Size(60, 25);
            lblSaldoValor.TabIndex = 8;
            lblSaldoValor.Text = "$0,00";
            //
            // grpMovimientos
            //
            grpMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpMovimientos.Controls.Add(lblResultado);
            grpMovimientos.Controls.Add(dgvMovimientos);
            grpMovimientos.Controls.Add(lblApertura);
            grpMovimientos.Controls.Add(txtSaldoInicial);
            grpMovimientos.Controls.Add(btnAbrirCaja);
            grpMovimientos.Controls.Add(btnVolver);
            grpMovimientos.Controls.Add(btnCerrarCaja);
            grpMovimientos.Controls.Add(btnRegistrarMovimiento);
            grpMovimientos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpMovimientos.ForeColor = Color.FromArgb(15, 23, 42);
            grpMovimientos.Location = new Point(16, 196);
            grpMovimientos.Name = "grpMovimientos";
            grpMovimientos.Size = new Size(1048, 448);
            grpMovimientos.TabIndex = 1;
            grpMovimientos.TabStop = false;
            grpMovimientos.Text = "Movimientos Registrados";
            //
            // dgvMovimientos
            //
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMovimientos.BackgroundColor = Color.FromArgb(226, 232, 240);
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.GridColor = Color.FromArgb(203, 213, 225);
            dgvMovimientos.Location = new Point(16, 26);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(1016, 352);
            dgvMovimientos.TabIndex = 0;
            //
            // lblApertura
            //
            lblApertura.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblApertura.AutoSize = true;
            lblApertura.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblApertura.ForeColor = Color.FromArgb(30, 41, 59);
            lblApertura.Location = new Point(16, 403);
            lblApertura.Name = "lblApertura";
            lblApertura.Size = new Size(116, 17);
            lblApertura.TabIndex = 1;
            lblApertura.Text = "Saldo Inicial ($):";
            //
            // txtSaldoInicial
            //
            txtSaldoInicial.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtSaldoInicial.Font = new Font("Segoe UI", 9.5F);
            txtSaldoInicial.Location = new Point(140, 400);
            txtSaldoInicial.Name = "txtSaldoInicial";
            txtSaldoInicial.PlaceholderText = "Efectivo en caja. Ej: 20000";
            txtSaldoInicial.Size = new Size(200, 24);
            txtSaldoInicial.TabIndex = 2;
            //
            // btnAbrirCaja
            //
            btnAbrirCaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAbrirCaja.BackColor = Color.FromArgb(37, 99, 235);
            btnAbrirCaja.FlatAppearance.BorderSize = 0;
            btnAbrirCaja.FlatStyle = FlatStyle.Flat;
            btnAbrirCaja.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAbrirCaja.ForeColor = Color.White;
            btnAbrirCaja.Location = new Point(350, 392);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new Size(150, 40);
            btnAbrirCaja.TabIndex = 3;
            btnAbrirCaja.Text = "Abrir Caja";
            btnAbrirCaja.UseVisualStyleBackColor = false;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(554, 392);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(130, 40);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // btnCerrarCaja
            //
            btnCerrarCaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrarCaja.BackColor = Color.FromArgb(239, 68, 68);
            btnCerrarCaja.FlatAppearance.BorderSize = 0;
            btnCerrarCaja.FlatStyle = FlatStyle.Flat;
            btnCerrarCaja.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCerrarCaja.ForeColor = Color.White;
            btnCerrarCaja.Location = new Point(694, 392);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new Size(135, 40);
            btnCerrarCaja.TabIndex = 5;
            btnCerrarCaja.Text = "Cerrar Caja";
            btnCerrarCaja.UseVisualStyleBackColor = false;
            //
            // btnRegistrarMovimiento
            //
            btnRegistrarMovimiento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrarMovimiento.BackColor = Color.FromArgb(16, 185, 129);
            btnRegistrarMovimiento.FlatAppearance.BorderSize = 0;
            btnRegistrarMovimiento.FlatStyle = FlatStyle.Flat;
            btnRegistrarMovimiento.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnRegistrarMovimiento.ForeColor = Color.White;
            btnRegistrarMovimiento.Location = new Point(839, 392);
            btnRegistrarMovimiento.Name = "btnRegistrarMovimiento";
            btnRegistrarMovimiento.Size = new Size(193, 40);
            btnRegistrarMovimiento.TabIndex = 6;
            btnRegistrarMovimiento.Text = "Registrar Movimiento";
            btnRegistrarMovimiento.UseVisualStyleBackColor = false;
            //
            // lblResultado
            //
            lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResultado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultado.ForeColor = Color.FromArgb(16, 185, 129);
            lblResultado.Location = new Point(16, 396);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(520, 36);
            lblResultado.Visible = false;
            //
            // FormCaja
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1080, 660);
            Controls.Add(grpMovimientos);
            Controls.Add(grpResumen);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 620);
            Name = "FormCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Caja Diaria";
            Load += FormCaja_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            grpMovimientos.ResumeLayout(false);
            grpMovimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblResultado;

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblCu;
        private GroupBox grpResumen;
        private Label lblEstado;
        private Button btnHistorial;
        private Label lblSaldoInicialTitulo;
        private Label lblSaldoInicialValor;
        private Label lblIngresosTitulo;
        private Label lblIngresosValor;
        private Label lblEgresosTitulo;
        private Label lblEgresosValor;
        private Label lblSaldoTitulo;
        private Label lblSaldoValor;
        private GroupBox grpMovimientos;
        private DataGridView dgvMovimientos;
        private Label lblApertura;
        private TextBox txtSaldoInicial;
        private Button btnAbrirCaja;
        private Button btnVolver;
        private Button btnCerrarCaja;
        private Button btnRegistrarMovimiento;
    }
}
