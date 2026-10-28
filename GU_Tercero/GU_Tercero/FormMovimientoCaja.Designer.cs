namespace Vista
{
    partial class FormMovimientoCaja
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
            lblTipo = new Label();
            rbIngreso = new RadioButton();
            rbEgreso = new RadioButton();
            lblImporte = new Label();
            txtImporte = new TextBox();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            lblSaldo = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(460, 50);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(240, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR MOVIMIENTO";
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTipo.ForeColor = Color.FromArgb(30, 41, 59);
            lblTipo.Location = new Point(20, 66);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(134, 17);
            lblTipo.TabIndex = 1;
            lblTipo.Text = "Tipo de Movimiento:";
            //
            // rbIngreso
            //
            rbIngreso.AutoSize = true;
            rbIngreso.Font = new Font("Segoe UI", 9.5F);
            rbIngreso.ForeColor = Color.FromArgb(30, 41, 59);
            rbIngreso.Location = new Point(20, 88);
            rbIngreso.Name = "rbIngreso";
            rbIngreso.Size = new Size(70, 21);
            rbIngreso.TabIndex = 2;
            rbIngreso.Text = "Ingreso";
            rbIngreso.UseVisualStyleBackColor = true;
            //
            // rbEgreso
            //
            rbEgreso.AutoSize = true;
            rbEgreso.Font = new Font("Segoe UI", 9.5F);
            rbEgreso.ForeColor = Color.FromArgb(30, 41, 59);
            rbEgreso.Location = new Point(120, 88);
            rbEgreso.Name = "rbEgreso";
            rbEgreso.Size = new Size(66, 21);
            rbEgreso.TabIndex = 3;
            rbEgreso.Text = "Egreso";
            rbEgreso.UseVisualStyleBackColor = true;
            //
            // lblImporte
            //
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblImporte.ForeColor = Color.FromArgb(30, 41, 59);
            lblImporte.Location = new Point(20, 122);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(83, 17);
            lblImporte.TabIndex = 4;
            lblImporte.Text = "Importe ($):";
            //
            // txtImporte
            //
            txtImporte.Font = new Font("Segoe UI", 9.5F);
            txtImporte.Location = new Point(20, 142);
            txtImporte.Name = "txtImporte";
            txtImporte.PlaceholderText = "Ej: 5000";
            txtImporte.Size = new Size(420, 24);
            txtImporte.TabIndex = 5;
            //
            // lblMotivo
            //
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMotivo.ForeColor = Color.FromArgb(30, 41, 59);
            lblMotivo.Location = new Point(20, 178);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(54, 17);
            lblMotivo.TabIndex = 6;
            lblMotivo.Text = "Motivo:";
            //
            // txtMotivo
            //
            txtMotivo.Font = new Font("Segoe UI", 9.5F);
            txtMotivo.Location = new Point(20, 198);
            txtMotivo.MaxLength = 200;
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.PlaceholderText = "Ej: Pago de flete, retiro, aporte de cambio";
            txtMotivo.Size = new Size(420, 60);
            txtMotivo.TabIndex = 7;
            //
            // lblSaldo
            //
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblSaldo.ForeColor = Color.FromArgb(37, 99, 235);
            lblSaldo.Location = new Point(20, 268);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(120, 17);
            lblSaldo.TabIndex = 8;
            lblSaldo.Text = "Saldo disponible:";
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(170, 298);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 40);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(310, 298);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 40);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // FormMovimientoCaja
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            CancelButton = btnCancelar;
            ClientSize = new Size(460, 354);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(lblSaldo);
            Controls.Add(txtMotivo);
            Controls.Add(lblMotivo);
            Controls.Add(txtImporte);
            Controls.Add(lblImporte);
            Controls.Add(rbEgreso);
            Controls.Add(rbIngreso);
            Controls.Add(lblTipo);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMovimientoCaja";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ApIBigStore - Registrar Movimiento de Caja";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblTipo;
        private RadioButton rbIngreso;
        private RadioButton rbEgreso;
        private Label lblImporte;
        private TextBox txtImporte;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label lblSaldo;
        private Button btnCancelar;
        private Button btnGuardar;
    }
}
