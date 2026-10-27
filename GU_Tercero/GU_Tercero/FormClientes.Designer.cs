namespace Vista
{
    partial class FormClientes
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvClientes = new DataGridView();
            lblResumen = new Label();
            btnVolver = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 56);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(110, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CLIENTES";
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            lblBuscar.Location = new Point(16, 73);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(50, 17);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(76, 70);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Apellido, nombre o DNI";
            txtBuscar.Size = new Size(908, 24);
            txtBuscar.TabIndex = 2;
            //
            // dgvClientes
            //
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(16, 104);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(968, 402);
            dgvClientes.TabIndex = 3;
            //
            // lblResumen
            //
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblResumen.ForeColor = Color.FromArgb(30, 41, 59);
            lblResumen.Location = new Point(16, 522);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(72, 17);
            lblResumen.TabIndex = 4;
            lblResumen.Text = "Clientes: 0";
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(838, 514);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(146, 34);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // FormClientes
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1000, 564);
            Controls.Add(btnVolver);
            Controls.Add(lblResumen);
            Controls.Add(dgvClientes);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 520);
            Name = "FormClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Clientes";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvClientes;
        private Label lblResumen;
        private Button btnVolver;
    }
}
