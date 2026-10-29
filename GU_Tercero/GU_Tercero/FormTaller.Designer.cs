namespace GU_Tercero
{
    partial class FormTaller
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblTecnico = new Label();
            cmbTecnico = new ComboBox();
            btnBuscar = new Button();
            chkSoloPendientes = new CheckBox();
            chkMisOrdenes = new CheckBox();
            lblLeyenda = new Label();
            grpOrdenes = new GroupBox();
            dgvOrdenes = new DataGridView();
            lblResumen = new Label();
            lblResultado = new Label();
            btnNuevaOrden = new Button();
            btnVerOrden = new Button();
            btnVolver = new Button();
            panelHeader.SuspendLayout();
            grpFiltros.SuspendLayout();
            grpOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
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
            lblCu.Text = "CU08";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(350, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TALLER - ÓRDENES DE REPARACIÓN";
            //
            // grpFiltros
            //
            grpFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFiltros.Controls.Add(lblLeyenda);
            grpFiltros.Controls.Add(chkMisOrdenes);
            grpFiltros.Controls.Add(chkSoloPendientes);
            grpFiltros.Controls.Add(btnBuscar);
            grpFiltros.Controls.Add(cmbTecnico);
            grpFiltros.Controls.Add(lblTecnico);
            grpFiltros.Controls.Add(cmbEstado);
            grpFiltros.Controls.Add(lblEstado);
            grpFiltros.Controls.Add(txtBuscar);
            grpFiltros.Controls.Add(lblBuscar);
            grpFiltros.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpFiltros.ForeColor = Color.FromArgb(15, 23, 42);
            grpFiltros.Location = new Point(16, 66);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(1048, 100);
            grpFiltros.TabIndex = 1;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Búsqueda de Órdenes";
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscar.Location = new Point(16, 33);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(50, 17);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(80, 30);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Cliente, DNI, equipo, IMEI o N° de orden";
            txtBuscar.Size = new Size(330, 24);
            txtBuscar.TabIndex = 1;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(30, 41, 59);
            lblEstado.Location = new Point(426, 33);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(51, 17);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado:";
            //
            // cmbEstado
            //
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 9.5F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(486, 30);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(170, 25);
            cmbEstado.TabIndex = 2;
            //
            // lblTecnico
            //
            lblTecnico.AutoSize = true;
            lblTecnico.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTecnico.ForeColor = Color.FromArgb(30, 41, 59);
            lblTecnico.Location = new Point(670, 33);
            lblTecnico.Name = "lblTecnico";
            lblTecnico.Size = new Size(58, 17);
            lblTecnico.TabIndex = 0;
            lblTecnico.Text = "Técnico:";
            //
            // cmbTecnico
            //
            cmbTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTecnico.Font = new Font("Segoe UI", 9.5F);
            cmbTecnico.FormattingEnabled = true;
            cmbTecnico.Location = new Point(735, 30);
            cmbTecnico.Name = "cmbTecnico";
            cmbTecnico.Size = new Size(200, 25);
            cmbTecnico.TabIndex = 3;
            //
            // btnBuscar
            //
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(37, 99, 235);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(948, 28);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(84, 28);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            //
            // chkSoloPendientes
            //
            chkSoloPendientes.AutoSize = true;
            chkSoloPendientes.Checked = true;
            chkSoloPendientes.CheckState = CheckState.Checked;
            chkSoloPendientes.Font = new Font("Segoe UI", 9.5F);
            chkSoloPendientes.ForeColor = Color.FromArgb(30, 41, 59);
            chkSoloPendientes.Location = new Point(80, 66);
            chkSoloPendientes.Name = "chkSoloPendientes";
            chkSoloPendientes.Size = new Size(279, 21);
            chkSoloPendientes.TabIndex = 5;
            chkSoloPendientes.Text = "Solo pendientes (sin entregar ni cancelar)";
            chkSoloPendientes.UseVisualStyleBackColor = true;
            //
            // chkMisOrdenes
            //
            chkMisOrdenes.AutoSize = true;
            chkMisOrdenes.Font = new Font("Segoe UI", 9.5F);
            chkMisOrdenes.ForeColor = Color.FromArgb(30, 41, 59);
            chkMisOrdenes.Location = new Point(400, 66);
            chkMisOrdenes.Name = "chkMisOrdenes";
            chkMisOrdenes.Size = new Size(128, 21);
            chkMisOrdenes.TabIndex = 6;
            chkMisOrdenes.Text = "Solo mis órdenes";
            chkMisOrdenes.UseVisualStyleBackColor = true;
            chkMisOrdenes.Visible = false;
            //
            // lblLeyenda
            //
            lblLeyenda.AutoSize = true;
            lblLeyenda.Font = new Font("Segoe UI", 9F);
            lblLeyenda.ForeColor = Color.FromArgb(185, 28, 28);
            lblLeyenda.Location = new Point(620, 68);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(286, 15);
            lblLeyenda.TabIndex = 0;
            lblLeyenda.Text = "Las filas en rojo tienen la fecha prometida vencida.";
            //
            // grpOrdenes
            //
            grpOrdenes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpOrdenes.Controls.Add(btnVolver);
            grpOrdenes.Controls.Add(btnVerOrden);
            grpOrdenes.Controls.Add(btnNuevaOrden);
            grpOrdenes.Controls.Add(lblResumen);
            grpOrdenes.Controls.Add(lblResultado);
            grpOrdenes.Controls.Add(dgvOrdenes);
            grpOrdenes.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpOrdenes.ForeColor = Color.FromArgb(15, 23, 42);
            grpOrdenes.Location = new Point(16, 174);
            grpOrdenes.Name = "grpOrdenes";
            grpOrdenes.Size = new Size(1048, 470);
            grpOrdenes.TabIndex = 2;
            grpOrdenes.TabStop = false;
            grpOrdenes.Text = "Órdenes de Reparación";
            //
            // dgvOrdenes
            //
            dgvOrdenes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenes.Location = new Point(16, 28);
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.Size = new Size(1016, 366);
            dgvOrdenes.TabIndex = 0;
            //
            // lblResumen
            //
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblResumen.ForeColor = Color.FromArgb(71, 85, 105);
            lblResumen.Location = new Point(16, 404);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(64, 17);
            lblResumen.TabIndex = 1;
            lblResumen.Text = "Órdenes: 0";
            //
            // lblResultado
            //
            lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResultado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultado.ForeColor = Color.FromArgb(16, 185, 129);
            lblResultado.Location = new Point(16, 428);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(570, 24);
            lblResultado.Visible = false;
            //
            // btnNuevaOrden
            //
            btnNuevaOrden.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNuevaOrden.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevaOrden.FlatAppearance.BorderSize = 0;
            btnNuevaOrden.FlatStyle = FlatStyle.Flat;
            btnNuevaOrden.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnNuevaOrden.ForeColor = Color.White;
            btnNuevaOrden.Location = new Point(600, 418);
            btnNuevaOrden.Name = "btnNuevaOrden";
            btnNuevaOrden.Size = new Size(150, 38);
            btnNuevaOrden.TabIndex = 2;
            btnNuevaOrden.Text = "+ Nueva Orden";
            btnNuevaOrden.UseVisualStyleBackColor = false;
            //
            // btnVerOrden
            //
            btnVerOrden.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVerOrden.BackColor = Color.FromArgb(16, 185, 129);
            btnVerOrden.FlatAppearance.BorderSize = 0;
            btnVerOrden.FlatStyle = FlatStyle.Flat;
            btnVerOrden.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVerOrden.ForeColor = Color.White;
            btnVerOrden.Location = new Point(760, 418);
            btnVerOrden.Name = "btnVerOrden";
            btnVerOrden.Size = new Size(150, 38);
            btnVerOrden.TabIndex = 3;
            btnVerOrden.Text = "Ver / Actualizar";
            btnVerOrden.UseVisualStyleBackColor = false;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(920, 418);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(112, 38);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // FormTaller
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1080, 660);
            Controls.Add(grpOrdenes);
            Controls.Add(grpFiltros);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 620);
            Name = "FormTaller";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Taller";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            grpOrdenes.ResumeLayout(false);
            grpOrdenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblResultado;

        private Panel panelHeader;
        private Label lblCu;
        private Label lblTitulo;
        private GroupBox grpFiltros;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblTecnico;
        private ComboBox cmbTecnico;
        private Button btnBuscar;
        private CheckBox chkSoloPendientes;
        private CheckBox chkMisOrdenes;
        private Label lblLeyenda;
        private GroupBox grpOrdenes;
        private DataGridView dgvOrdenes;
        private Label lblResumen;
        private Button btnNuevaOrden;
        private Button btnVerOrden;
        private Button btnVolver;
    }
}
