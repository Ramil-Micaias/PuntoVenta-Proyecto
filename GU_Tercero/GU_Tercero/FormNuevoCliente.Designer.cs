namespace Vista
{
    partial class FormNuevoCliente
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
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
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
            panelHeader.Size = new Size(420, 50);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(141, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NUEVO CLIENTE";
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(30, 41, 59);
            lblApellido.Location = new Point(24, 73);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(60, 17);
            lblApellido.TabIndex = 0;
            lblApellido.Text = "Apellido:";
            //
            // txtApellido
            //
            txtApellido.Font = new Font("Segoe UI", 9.5F);
            txtApellido.Location = new Point(130, 70);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ej: Gómez";
            txtApellido.Size = new Size(260, 24);
            txtApellido.TabIndex = 1;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombre.Location = new Point(24, 111);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(59, 17);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Font = new Font("Segoe UI", 9.5F);
            txtNombre.Location = new Point(130, 108);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Ana";
            txtNombre.Size = new Size(260, 24);
            txtNombre.TabIndex = 2;
            //
            // lblDni
            //
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDni.ForeColor = Color.FromArgb(30, 41, 59);
            lblDni.Location = new Point(24, 149);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(33, 17);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI:";
            //
            // txtDni
            //
            txtDni.Font = new Font("Segoe UI", 9.5F);
            txtDni.Location = new Point(130, 146);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "Sin puntos. Ej: 40111222";
            txtDni.Size = new Size(260, 24);
            txtDni.TabIndex = 3;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(30, 41, 59);
            lblTelefono.Location = new Point(24, 187);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(62, 17);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono:";
            //
            // txtTelefono
            //
            txtTelefono.Font = new Font("Segoe UI", 9.5F);
            txtTelefono.Location = new Point(130, 184);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Opcional. Ej: 1155550000";
            txtTelefono.Size = new Size(260, 24);
            txtTelefono.TabIndex = 4;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(270, 232);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 34);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(100, 116, 139);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(140, 232);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 34);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // FormNuevoCliente
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            CancelButton = btnCancelar;
            ClientSize = new Size(420, 286);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNuevoCliente";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ApIBigStore - Nuevo Cliente";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
