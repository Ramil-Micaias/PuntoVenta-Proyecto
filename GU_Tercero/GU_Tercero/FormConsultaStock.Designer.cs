namespace Vista
{
    partial class FormConsultaStock
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
            panelHeader = new Panel();
            lblCu = new Label();
            lblTitulo = new Label();
            grpFiltros = new GroupBox();
            btnAplicarFiltros = new Button();
            chkSoloBajoMinimo = new CheckBox();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            grpExistencias = new GroupBox();
            lblResumen = new Label();
            btnVolver = new Button();
            btnExportar = new Button();
            dgvStock = new DataGridView();
            panelHeader.SuspendLayout();
            grpFiltros.SuspendLayout();
            grpExistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
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
            panelHeader.Size = new Size(960, 56);
            panelHeader.TabIndex = 0;
            //
            // lblCu
            //
            lblCu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCu.AutoSize = true;
            lblCu.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCu.ForeColor = Color.FromArgb(148, 163, 184);
            lblCu.Location = new Point(896, 19);
            lblCu.Name = "lblCu";
            lblCu.Size = new Size(39, 19);
            lblCu.TabIndex = 1;
            lblCu.Text = "CU07";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(360, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CONSULTA DE STOCK E INVENTARIO";
            //
            // grpFiltros
            //
            grpFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFiltros.Controls.Add(btnAplicarFiltros);
            grpFiltros.Controls.Add(chkSoloBajoMinimo);
            grpFiltros.Controls.Add(cmbCategoria);
            grpFiltros.Controls.Add(lblCategoria);
            grpFiltros.Controls.Add(txtBuscar);
            grpFiltros.Controls.Add(lblBuscar);
            grpFiltros.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpFiltros.ForeColor = Color.FromArgb(15, 23, 42);
            grpFiltros.Location = new Point(16, 68);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(928, 72);
            grpFiltros.TabIndex = 1;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros de Búsqueda";
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscar.Location = new Point(16, 33);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(118, 17);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Nombre o Código:";
            //
            // txtBuscar
            //
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(140, 30);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ej: Batería iPhone";
            txtBuscar.Size = new Size(220, 24);
            txtBuscar.TabIndex = 1;
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategoria.Location = new Point(380, 33);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(70, 17);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "Categoría:";
            //
            // cmbCategoria
            //
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.Location = new Point(456, 29);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(170, 25);
            cmbCategoria.TabIndex = 3;
            //
            // chkSoloBajoMinimo
            //
            chkSoloBajoMinimo.AutoSize = true;
            chkSoloBajoMinimo.Font = new Font("Segoe UI", 9.5F);
            chkSoloBajoMinimo.ForeColor = Color.FromArgb(30, 41, 59);
            chkSoloBajoMinimo.Location = new Point(644, 31);
            chkSoloBajoMinimo.Name = "chkSoloBajoMinimo";
            chkSoloBajoMinimo.Size = new Size(174, 21);
            chkSoloBajoMinimo.TabIndex = 4;
            chkSoloBajoMinimo.Text = "Ver solo stock bajo mínimo";
            chkSoloBajoMinimo.UseVisualStyleBackColor = true;
            //
            // btnAplicarFiltros
            //
            btnAplicarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAplicarFiltros.BackColor = Color.FromArgb(37, 99, 235);
            btnAplicarFiltros.FlatAppearance.BorderSize = 0;
            btnAplicarFiltros.FlatStyle = FlatStyle.Flat;
            btnAplicarFiltros.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAplicarFiltros.ForeColor = Color.White;
            btnAplicarFiltros.Location = new Point(826, 26);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(90, 32);
            btnAplicarFiltros.TabIndex = 5;
            btnAplicarFiltros.Text = "Aplicar";
            btnAplicarFiltros.UseVisualStyleBackColor = false;
            //
            // grpExistencias
            //
            grpExistencias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpExistencias.Controls.Add(lblResumen);
            grpExistencias.Controls.Add(btnVolver);
            grpExistencias.Controls.Add(btnExportar);
            grpExistencias.Controls.Add(dgvStock);
            grpExistencias.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpExistencias.ForeColor = Color.FromArgb(15, 23, 42);
            grpExistencias.Location = new Point(16, 150);
            grpExistencias.Name = "grpExistencias";
            grpExistencias.Size = new Size(928, 434);
            grpExistencias.TabIndex = 2;
            grpExistencias.TabStop = false;
            grpExistencias.Text = "Existencias en Depósito";
            //
            // dgvStock
            //
            dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(14, 28);
            dgvStock.Name = "dgvStock";
            dgvStock.Size = new Size(900, 346);
            dgvStock.TabIndex = 0;
            //
            // lblResumen
            //
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblResumen.ForeColor = Color.FromArgb(30, 41, 59);
            lblResumen.Location = new Point(14, 394);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(80, 17);
            lblResumen.TabIndex = 1;
            lblResumen.Text = "Productos: 0";
            //
            // btnExportar
            //
            btnExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportar.BackColor = Color.FromArgb(16, 185, 129);
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(608, 386);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(170, 34);
            btnExportar.TabIndex = 2;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = false;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(788, 386);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(126, 34);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // FormConsultaStock
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(960, 600);
            Controls.Add(grpExistencias);
            Controls.Add(grpFiltros);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(976, 639);
            Name = "FormConsultaStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Consulta de Stock";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            grpExistencias.ResumeLayout(false);
            grpExistencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblCu;
        private Label lblTitulo;
        private GroupBox grpFiltros;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private CheckBox chkSoloBajoMinimo;
        private Button btnAplicarFiltros;
        private GroupBox grpExistencias;
        private DataGridView dgvStock;
        private Label lblResumen;
        private Button btnExportar;
        private Button btnVolver;
    }
}
