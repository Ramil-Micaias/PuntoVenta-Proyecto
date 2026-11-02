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
            dgvBitacora = new DataGridView();
            lblCantidad = new Label();
            btnVolver = new Button();
            panelHeader.SuspendLayout();
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
            // dgvBitacora
            //
            dgvBitacora.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Location = new Point(16, 72);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.Size = new Size(1068, 500);
            dgvBitacora.TabIndex = 1;
            //
            // lblCantidad
            //
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.FromArgb(30, 41, 59);
            lblCantidad.Location = new Point(16, 594);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(160, 17);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Movimientos: 0";
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(938, 586);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(146, 34);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // FormBitacora
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1100, 636);
            Controls.Add(btnVolver);
            Controls.Add(lblCantidad);
            Controls.Add(dgvBitacora);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 500);
            Name = "FormBitacora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Bitácora";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private DataGridView dgvBitacora;
        private Label lblCantidad;
        private Button btnVolver;
    }
}
