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
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(12, 34);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(776, 227);
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
            grpDetalleProveedores.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpDetalleProveedores.Location = new Point(12, 267);
            grpDetalleProveedores.Name = "grpDetalleProveedores";
            grpDetalleProveedores.Size = new Size(776, 180);
            grpDetalleProveedores.TabIndex = 1;
            grpDetalleProveedores.TabStop = false;
            grpDetalleProveedores.Text = "Detalle de Proveedores";
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(637, 118);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(123, 23);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(637, 91);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(123, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificar.Location = new Point(637, 63);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(123, 23);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar Proveedor";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(637, 34);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(123, 23);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo Proveedor";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(102, 148);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(159, 23);
            txtDireccion.TabIndex = 9;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDireccion.Location = new Point(39, 151);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Direccion";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(102, 119);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(159, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(59, 124);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(102, 92);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(159, 23);
            txtTelefono.TabIndex = 5;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTelefono.Location = new Point(44, 95);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Telefono";
            // 
            // txtCUIT
            // 
            txtCUIT.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCUIT.Location = new Point(102, 63);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(159, 23);
            txtCUIT.TabIndex = 3;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCuit.Location = new Point(63, 66);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(32, 15);
            lblCuit.TabIndex = 2;
            lblCuit.Text = "CUIT";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRazonSocial.Location = new Point(102, 34);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(159, 23);
            txtRazonSocial.TabIndex = 1;
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRazonSocial.Location = new Point(23, 37);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(73, 15);
            lblRazonSocial.TabIndex = 0;
            lblRazonSocial.Text = "Razon Social";
            // 
            // lblProveedoresRegistrados
            // 
            lblProveedoresRegistrados.AutoSize = true;
            lblProveedoresRegistrados.Location = new Point(10, 16);
            lblProveedoresRegistrados.Name = "lblProveedoresRegistrados";
            lblProveedoresRegistrados.Size = new Size(136, 15);
            lblProveedoresRegistrados.TabIndex = 2;
            lblProveedoresRegistrados.Text = "Proveedores Registrados";
            // 
            // FormProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblProveedoresRegistrados);
            Controls.Add(grpDetalleProveedores);
            Controls.Add(dgvProveedores);
            Name = "FormProveedores";
            Text = "Gestión de Proveedor";
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