namespace Vista
{
    partial class FormProveedores
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvProveedores = new DataGridView();
            grpDetalleProveedores = new GroupBox();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtCUIT = new TextBox();
            lblCuit = new Label();
            txtRazonSocial = new TextBox();
            lblRazonSocial = new Label();
            lblProveedoresRegistrados = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            grpDetalleProveedores.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProveedores
            // 
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProveedores.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProveedores.Location = new Point(16, 45);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(768, 205);
            dgvProveedores.TabIndex = 0;
            // 
            // grpDetalleProveedores
            // 
            grpDetalleProveedores.Controls.Add(btnEliminar);
            grpDetalleProveedores.Controls.Add(btnGuardar);
            grpDetalleProveedores.Controls.Add(btnModificar);
            grpDetalleProveedores.Controls.Add(btnNuevo);
            grpDetalleProveedores.Controls.Add(txtDireccion);
            grpDetalleProveedores.Controls.Add(lblDireccion);
            grpDetalleProveedores.Controls.Add(txtEmail);
            grpDetalleProveedores.Controls.Add(lblEmail);
            grpDetalleProveedores.Controls.Add(txtTelefono);
            grpDetalleProveedores.Controls.Add(lblTelefono);
            grpDetalleProveedores.Controls.Add(txtCUIT);
            grpDetalleProveedores.Controls.Add(lblCuit);
            grpDetalleProveedores.Controls.Add(txtRazonSocial);
            grpDetalleProveedores.Controls.Add(lblRazonSocial);
            grpDetalleProveedores.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            grpDetalleProveedores.ForeColor = Color.FromArgb(15, 23, 42);
            grpDetalleProveedores.Location = new Point(16, 260);
            grpDetalleProveedores.Name = "grpDetalleProveedores";
            grpDetalleProveedores.Size = new Size(768, 175);
            grpDetalleProveedores.TabIndex = 1;
            grpDetalleProveedores.TabStop = false;
            grpDetalleProveedores.Text = "Detalle de Proveedores";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(239, 68, 68);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(610, 130);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(140, 30);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(610, 95);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 30);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(37, 99, 235);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(610, 60);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(140, 30);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(610, 25);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(140, 30);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo Proveedor";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 9.5F);
            txtDireccion.Location = new Point(370, 65);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(210, 24);
            txtDireccion.TabIndex = 9;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDireccion.ForeColor = Color.FromArgb(30, 41, 59);
            lblDireccion.Location = new Point(300, 68);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(66, 17);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Dirección:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(370, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(210, 24);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(30, 41, 59);
            lblEmail.Location = new Point(300, 33);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(43, 17);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9.5F);
            txtTelefono.Location = new Point(110, 100);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(170, 24);
            txtTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(30, 41, 59);
            lblTelefono.Location = new Point(20, 103);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(62, 17);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtCUIT
            // 
            txtCUIT.Font = new Font("Segoe UI", 9.5F);
            txtCUIT.Location = new Point(110, 65);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(170, 24);
            txtCUIT.TabIndex = 3;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCuit.ForeColor = Color.FromArgb(30, 41, 59);
            lblCuit.Location = new Point(20, 68);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(39, 17);
            lblCuit.TabIndex = 2;
            lblCuit.Text = "CUIT:";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Font = new Font("Segoe UI", 9.5F);
            txtRazonSocial.Location = new Point(110, 30);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(170, 24);
            txtRazonSocial.TabIndex = 1;
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRazonSocial.ForeColor = Color.FromArgb(30, 41, 59);
            lblRazonSocial.Location = new Point(20, 33);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(86, 17);
            lblRazonSocial.TabIndex = 0;
            lblRazonSocial.Text = "Razón Social:";
            // 
            // lblProveedoresRegistrados
            // 
            lblProveedoresRegistrados.AutoSize = true;
            lblProveedoresRegistrados.Font = new Font("Microsoft Sans Serif", 14F);
            lblProveedoresRegistrados.ForeColor = Color.FromArgb(15, 23, 42);
            lblProveedoresRegistrados.Location = new Point(16, 12);
            lblProveedoresRegistrados.Name = "lblProveedoresRegistrados";
            lblProveedoresRegistrados.Size = new Size(222, 24);
            lblProveedoresRegistrados.TabIndex = 2;
            lblProveedoresRegistrados.Text = "Proveedores Registrados";
            // 
            // FormProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(800, 450);
            Controls.Add(lblProveedoresRegistrados);
            Controls.Add(grpDetalleProveedores);
            Controls.Add(dgvProveedores);
            Font = new Font("Segoe UI", 9F);
            Name = "FormProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Proveedores";
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            grpDetalleProveedores.ResumeLayout(false);
            grpDetalleProveedores.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProveedores;
        private GroupBox grpDetalleProveedores;
        private Label lblRazonSocial;
        private TextBox txtCUIT;
        private Label lblCuit;
        private TextBox txtRazonSocial;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private Button btnModificar;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnGuardar;
        private Label lblProveedoresRegistrados;
    }
}