namespace Vista
{
    partial class FormHistorialCaja
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
            grpFiltros = new GroupBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            lblMedio = new Label();
            cmbMedio = new ComboBox();
            btnBuscar = new Button();
            lblHoraDesde = new Label();
            dtpHoraDesde = new DateTimePicker();
            lblHoraHasta = new Label();
            dtpHoraHasta = new DateTimePicker();
            lblTexto = new Label();
            txtTexto = new TextBox();
            lblImporte = new Label();
            txtImporteDesde = new TextBox();
            lblImporteA = new Label();
            txtImporteHasta = new TextBox();
            grpCajas = new GroupBox();
            dgvCajas = new DataGridView();
            grpMovimientos = new GroupBox();
            lblMostrando = new Label();
            dgvMovimientos = new DataGridView();
            lblResumen = new Label();
            btnVolver = new Button();
            panelHeader.SuspendLayout();
            grpFiltros.SuspendLayout();
            grpCajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCajas).BeginInit();
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
            lblCu.Text = "CU10";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(210, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "HISTORIAL DE CAJA";
            //
            // grpFiltros
            //
            grpFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFiltros.Controls.Add(lblDesde);
            grpFiltros.Controls.Add(dtpDesde);
            grpFiltros.Controls.Add(lblHasta);
            grpFiltros.Controls.Add(dtpHasta);
            grpFiltros.Controls.Add(lblMedio);
            grpFiltros.Controls.Add(cmbMedio);
            grpFiltros.Controls.Add(btnBuscar);
            grpFiltros.Controls.Add(lblHoraDesde);
            grpFiltros.Controls.Add(dtpHoraDesde);
            grpFiltros.Controls.Add(lblHoraHasta);
            grpFiltros.Controls.Add(dtpHoraHasta);
            grpFiltros.Controls.Add(lblTexto);
            grpFiltros.Controls.Add(txtTexto);
            grpFiltros.Controls.Add(lblImporte);
            grpFiltros.Controls.Add(txtImporteDesde);
            grpFiltros.Controls.Add(lblImporteA);
            grpFiltros.Controls.Add(txtImporteHasta);
            grpFiltros.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpFiltros.ForeColor = Color.FromArgb(15, 23, 42);
            grpFiltros.Location = new Point(16, 66);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(1048, 102);
            grpFiltros.TabIndex = 1;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Período a consultar";
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDesde.ForeColor = Color.FromArgb(30, 41, 59);
            lblDesde.Location = new Point(16, 31);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(48, 17);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            dtpDesde.Font = new Font("Segoe UI", 9.5F);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(72, 27);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(130, 24);
            dtpDesde.TabIndex = 1;
            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblHasta.ForeColor = Color.FromArgb(30, 41, 59);
            lblHasta.Location = new Point(222, 31);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(45, 17);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            dtpHasta.Font = new Font("Segoe UI", 9.5F);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(276, 27);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(130, 24);
            dtpHasta.TabIndex = 3;
            //
            // lblMedio
            //
            lblMedio.AutoSize = true;
            lblMedio.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMedio.ForeColor = Color.FromArgb(30, 41, 59);
            lblMedio.Location = new Point(428, 31);
            lblMedio.Name = "lblMedio";
            lblMedio.Size = new Size(108, 17);
            lblMedio.TabIndex = 4;
            lblMedio.Text = "Medio de pago:";
            //
            // cmbMedio
            //
            cmbMedio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedio.Font = new Font("Segoe UI", 9.5F);
            cmbMedio.Location = new Point(544, 27);
            cmbMedio.Name = "cmbMedio";
            cmbMedio.Size = new Size(200, 25);
            cmbMedio.TabIndex = 5;
            //
            // btnBuscar
            //
            btnBuscar.BackColor = Color.FromArgb(37, 99, 235);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(902, 24);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 30);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            //
            // lblHoraDesde
            //
            lblHoraDesde.AutoSize = true;
            lblHoraDesde.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblHoraDesde.ForeColor = Color.FromArgb(30, 41, 59);
            lblHoraDesde.Location = new Point(16, 67);
            lblHoraDesde.Name = "lblHoraDesde";
            lblHoraDesde.Size = new Size(80, 17);
            lblHoraDesde.Text = "Hora desde:";
            //
            // dtpHoraDesde
            //
            dtpHoraDesde.CustomFormat = "HH:mm";
            dtpHoraDesde.Font = new Font("Segoe UI", 9.5F);
            dtpHoraDesde.Format = DateTimePickerFormat.Custom;
            dtpHoraDesde.Location = new Point(100, 63);
            dtpHoraDesde.Name = "dtpHoraDesde";
            dtpHoraDesde.ShowUpDown = true;
            dtpHoraDesde.Size = new Size(70, 24);
            //
            // lblHoraHasta
            //
            lblHoraHasta.AutoSize = true;
            lblHoraHasta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblHoraHasta.ForeColor = Color.FromArgb(30, 41, 59);
            lblHoraHasta.Location = new Point(182, 67);
            lblHoraHasta.Name = "lblHoraHasta";
            lblHoraHasta.Size = new Size(42, 17);
            lblHoraHasta.Text = "hasta:";
            //
            // dtpHoraHasta
            //
            dtpHoraHasta.CustomFormat = "HH:mm";
            dtpHoraHasta.Font = new Font("Segoe UI", 9.5F);
            dtpHoraHasta.Format = DateTimePickerFormat.Custom;
            dtpHoraHasta.Location = new Point(228, 63);
            dtpHoraHasta.Name = "dtpHoraHasta";
            dtpHoraHasta.ShowUpDown = true;
            dtpHoraHasta.Size = new Size(70, 24);
            //
            // lblTexto
            //
            lblTexto.AutoSize = true;
            lblTexto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTexto.ForeColor = Color.FromArgb(30, 41, 59);
            lblTexto.Location = new Point(318, 67);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(50, 17);
            lblTexto.Text = "Buscar:";
            //
            // txtTexto
            //
            txtTexto.Font = new Font("Segoe UI", 9.5F);
            txtTexto.Location = new Point(372, 63);
            txtTexto.Name = "txtTexto";
            txtTexto.PlaceholderText = "Comprobante, detalle, usuario o medio";
            txtTexto.Size = new Size(250, 24);
            //
            // lblImporte
            //
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblImporte.ForeColor = Color.FromArgb(30, 41, 59);
            lblImporte.Location = new Point(640, 67);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(58, 17);
            lblImporte.Text = "Importe:";
            //
            // txtImporteDesde
            //
            txtImporteDesde.Font = new Font("Segoe UI", 9.5F);
            txtImporteDesde.Location = new Point(702, 63);
            txtImporteDesde.Name = "txtImporteDesde";
            txtImporteDesde.PlaceholderText = "Desde";
            txtImporteDesde.Size = new Size(90, 24);
            //
            // lblImporteA
            //
            lblImporteA.AutoSize = true;
            lblImporteA.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblImporteA.ForeColor = Color.FromArgb(30, 41, 59);
            lblImporteA.Location = new Point(796, 67);
            lblImporteA.Name = "lblImporteA";
            lblImporteA.Size = new Size(12, 17);
            lblImporteA.Text = "a";
            //
            // txtImporteHasta
            //
            txtImporteHasta.Font = new Font("Segoe UI", 9.5F);
            txtImporteHasta.Location = new Point(812, 63);
            txtImporteHasta.Name = "txtImporteHasta";
            txtImporteHasta.PlaceholderText = "Hasta";
            txtImporteHasta.Size = new Size(90, 24);
            //
            // grpCajas
            //
            grpCajas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCajas.Controls.Add(dgvCajas);
            grpCajas.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpCajas.ForeColor = Color.FromArgb(15, 23, 42);
            grpCajas.Location = new Point(16, 176);
            grpCajas.Name = "grpCajas";
            grpCajas.Size = new Size(1048, 170);
            grpCajas.TabIndex = 2;
            grpCajas.TabStop = false;
            grpCajas.Text = "Cajas del período (toque una para ver sus movimientos)";
            //
            // dgvCajas
            //
            dgvCajas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCajas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCajas.Location = new Point(16, 26);
            dgvCajas.Name = "dgvCajas";
            dgvCajas.Size = new Size(1016, 130);
            dgvCajas.TabIndex = 0;
            //
            // grpMovimientos
            //
            grpMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpMovimientos.Controls.Add(lblMostrando);
            grpMovimientos.Controls.Add(dgvMovimientos);
            grpMovimientos.Controls.Add(lblResumen);
            grpMovimientos.Controls.Add(btnVolver);
            grpMovimientos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpMovimientos.ForeColor = Color.FromArgb(15, 23, 42);
            grpMovimientos.Location = new Point(16, 354);
            grpMovimientos.Name = "grpMovimientos";
            grpMovimientos.Size = new Size(1048, 290);
            grpMovimientos.TabIndex = 3;
            grpMovimientos.TabStop = false;
            grpMovimientos.Text = "Movimientos";
            //
            // lblMostrando
            //
            lblMostrando.AutoSize = true;
            lblMostrando.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMostrando.ForeColor = Color.FromArgb(37, 99, 235);
            lblMostrando.Location = new Point(16, 24);
            lblMostrando.Name = "lblMostrando";
            lblMostrando.Size = new Size(10, 17);
            lblMostrando.TabIndex = 0;
            //
            // dgvMovimientos
            //
            dgvMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Location = new Point(16, 46);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(1016, 170);
            dgvMovimientos.TabIndex = 1;
            //
            // lblResumen
            //
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblResumen.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblResumen.ForeColor = Color.FromArgb(30, 41, 59);
            lblResumen.Location = new Point(16, 224);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(860, 58);
            lblResumen.TabIndex = 2;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(902, 238);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(130, 38);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // FormHistorialCaja
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1080, 660);
            Controls.Add(grpMovimientos);
            Controls.Add(grpCajas);
            Controls.Add(grpFiltros);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 620);
            Name = "FormHistorialCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Historial de Caja";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            grpCajas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCajas).EndInit();
            grpMovimientos.ResumeLayout(false);
            grpMovimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblCu;
        private Label lblTitulo;
        private GroupBox grpFiltros;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Label lblMedio;
        private ComboBox cmbMedio;
        private Button btnBuscar;
        private Label lblHoraDesde;
        private DateTimePicker dtpHoraDesde;
        private Label lblHoraHasta;
        private DateTimePicker dtpHoraHasta;
        private Label lblTexto;
        private TextBox txtTexto;
        private Label lblImporte;
        private TextBox txtImporteDesde;
        private Label lblImporteA;
        private TextBox txtImporteHasta;
        private GroupBox grpCajas;
        private DataGridView dgvCajas;
        private GroupBox grpMovimientos;
        private Label lblMostrando;
        private DataGridView dgvMovimientos;
        private Label lblResumen;
        private Button btnVolver;
    }
}
