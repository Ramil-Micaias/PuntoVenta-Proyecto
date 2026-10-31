namespace Vista
{
    partial class FormBitacora
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
            lblTitulo = new Label();
            grpFiltros = new GroupBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            lblCriticidad = new Label();
            cmbCriticidad = new ComboBox();
            lblModulo = new Label();
            cmbModulo = new ComboBox();
            txtTexto = new TextBox();
            btnBuscar = new Button();
            dgvBitacora = new DataGridView();
            lblCantidad = new Label();
            lblAnterior = new Label();
            txtAnterior = new TextBox();
            lblPosterior = new Label();
            txtPosterior = new TextBox();
            btnVolver = new Button();
            panelHeader.SuspendLayout();
            grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 56);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "BITÁCORA DEL SISTEMA";
            //
            // grpFiltros
            //
            grpFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFiltros.Controls.Add(lblDesde);
            grpFiltros.Controls.Add(dtpDesde);
            grpFiltros.Controls.Add(lblHasta);
            grpFiltros.Controls.Add(dtpHasta);
            grpFiltros.Controls.Add(lblCriticidad);
            grpFiltros.Controls.Add(cmbCriticidad);
            grpFiltros.Controls.Add(lblModulo);
            grpFiltros.Controls.Add(cmbModulo);
            grpFiltros.Controls.Add(txtTexto);
            grpFiltros.Controls.Add(btnBuscar);
            grpFiltros.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpFiltros.ForeColor = Color.FromArgb(15, 23, 42);
            grpFiltros.Location = new Point(16, 68);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(1068, 72);
            grpFiltros.TabIndex = 1;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros";
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDesde.ForeColor = Color.FromArgb(30, 41, 59);
            lblDesde.Location = new Point(14, 33);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(47, 17);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            dtpDesde.Font = new Font("Segoe UI", 9.5F);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(66, 30);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(120, 24);
            dtpDesde.TabIndex = 1;
            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblHasta.ForeColor = Color.FromArgb(30, 41, 59);
            lblHasta.Location = new Point(200, 33);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(44, 17);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            dtpHasta.Font = new Font("Segoe UI", 9.5F);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(250, 30);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(120, 24);
            dtpHasta.TabIndex = 3;
            //
            // lblCriticidad
            //
            lblCriticidad.AutoSize = true;
            lblCriticidad.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCriticidad.ForeColor = Color.FromArgb(30, 41, 59);
            lblCriticidad.Location = new Point(384, 33);
            lblCriticidad.Name = "lblCriticidad";
            lblCriticidad.Size = new Size(70, 17);
            lblCriticidad.TabIndex = 4;
            lblCriticidad.Text = "Criticidad:";
            //
            // cmbCriticidad
            //
            cmbCriticidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriticidad.Font = new Font("Segoe UI", 9.5F);
            cmbCriticidad.Location = new Point(460, 29);
            cmbCriticidad.Name = "cmbCriticidad";
            cmbCriticidad.Size = new Size(124, 25);
            cmbCriticidad.TabIndex = 5;
            //
            // lblModulo
            //
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblModulo.ForeColor = Color.FromArgb(30, 41, 59);
            lblModulo.Location = new Point(598, 33);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(55, 17);
            lblModulo.TabIndex = 6;
            lblModulo.Text = "Módulo:";
            //
            // cmbModulo
            //
            cmbModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModulo.Font = new Font("Segoe UI", 9.5F);
            cmbModulo.Location = new Point(660, 29);
            cmbModulo.Name = "cmbModulo";
            cmbModulo.Size = new Size(130, 25);
            cmbModulo.TabIndex = 7;
            //
            // txtTexto
            //
            txtTexto.Font = new Font("Segoe UI", 9.5F);
            txtTexto.Location = new Point(804, 30);
            txtTexto.Name = "txtTexto";
            txtTexto.PlaceholderText = "Usuario u operación";
            txtTexto.Size = new Size(150, 24);
            txtTexto.TabIndex = 8;
            //
            // btnBuscar
            //
            btnBuscar.BackColor = Color.FromArgb(37, 99, 235);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(966, 26);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 32);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            //
            // dgvBitacora
            //
            dgvBitacora.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Location = new Point(16, 150);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.Size = new Size(1068, 290);
            dgvBitacora.TabIndex = 2;
            //
            // lblCantidad
            //
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.FromArgb(30, 41, 59);
            lblCantidad.Location = new Point(16, 448);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(160, 17);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Operaciones encontradas: 0";
            //
            // lblAnterior
            //
            lblAnterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAnterior.AutoSize = true;
            lblAnterior.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblAnterior.ForeColor = Color.FromArgb(30, 41, 59);
            lblAnterior.Location = new Point(16, 474);
            lblAnterior.Name = "lblAnterior";
            lblAnterior.Size = new Size(104, 17);
            lblAnterior.TabIndex = 4;
            lblAnterior.Text = "Estado anterior:";
            //
            // txtAnterior
            //
            txtAnterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtAnterior.BackColor = Color.White;
            txtAnterior.Font = new Font("Consolas", 9.5F);
            txtAnterior.Location = new Point(16, 494);
            txtAnterior.Multiline = true;
            txtAnterior.Name = "txtAnterior";
            txtAnterior.ReadOnly = true;
            txtAnterior.ScrollBars = ScrollBars.Vertical;
            txtAnterior.Size = new Size(526, 100);
            txtAnterior.TabIndex = 5;
            //
            // lblPosterior
            //
            lblPosterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPosterior.AutoSize = true;
            lblPosterior.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPosterior.ForeColor = Color.FromArgb(30, 41, 59);
            lblPosterior.Location = new Point(558, 474);
            lblPosterior.Name = "lblPosterior";
            lblPosterior.Size = new Size(111, 17);
            lblPosterior.TabIndex = 6;
            lblPosterior.Text = "Estado posterior:";
            //
            // txtPosterior
            //
            txtPosterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPosterior.BackColor = Color.White;
            txtPosterior.Font = new Font("Consolas", 9.5F);
            txtPosterior.Location = new Point(558, 494);
            txtPosterior.Multiline = true;
            txtPosterior.Name = "txtPosterior";
            txtPosterior.ReadOnly = true;
            txtPosterior.ScrollBars = ScrollBars.Vertical;
            txtPosterior.Size = new Size(526, 100);
            txtPosterior.TabIndex = 7;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(938, 604);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(146, 34);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // FormBitacora
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1100, 650);
            Controls.Add(btnVolver);
            Controls.Add(txtPosterior);
            Controls.Add(lblPosterior);
            Controls.Add(txtAnterior);
            Controls.Add(lblAnterior);
            Controls.Add(lblCantidad);
            Controls.Add(dgvBitacora);
            Controls.Add(grpFiltros);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1116, 600);
            Name = "FormBitacora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Bitácora";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private GroupBox grpFiltros;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Label lblCriticidad;
        private ComboBox cmbCriticidad;
        private Label lblModulo;
        private ComboBox cmbModulo;
        private TextBox txtTexto;
        private Button btnBuscar;
        private DataGridView dgvBitacora;
        private Label lblCantidad;
        private Label lblAnterior;
        private TextBox txtAnterior;
        private Label lblPosterior;
        private TextBox txtPosterior;
        private Button btnVolver;
    }
}
