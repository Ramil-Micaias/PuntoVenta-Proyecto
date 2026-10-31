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
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvProveedores = new DataGridView();
            grpDetalleProveedores = new GroupBox();
            flpAcciones = new FlowLayoutPanel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            btnVolverMenu = new Button();
            txtDireccion = new TextBox();
            lblResultado = new Label();
            lblDireccion = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtCUIT = new TextBox();
            lblCuit = new Label();
            txtRazonSocial = new TextBox();
            lblRazonSocial = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            grpDetalleProveedores.SuspendLayout();
            flpAcciones.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 56);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(290, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE PROVEEDORES";
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
            txtBuscar.PlaceholderText = "Buscar por razón social o CUIT";
            txtBuscar.Size = new Size(808, 24);
            txtBuscar.TabIndex = 2;
            //
            // dgvProveedores
            //
            dgvProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(16, 104);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(868, 230);
            dgvProveedores.TabIndex = 3;
            //
            // grpDetalleProveedores
            //
            grpDetalleProveedores.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalleProveedores.Controls.Add(lblResultado);
            grpDetalleProveedores.Controls.Add(flpAcciones);
            grpDetalleProveedores.Controls.Add(btnVolverMenu);
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
            grpDetalleProveedores.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpDetalleProveedores.ForeColor = Color.FromArgb(15, 23, 42);
            grpDetalleProveedores.Location = new Point(16, 344);
            grpDetalleProveedores.Name = "grpDetalleProveedores";
            grpDetalleProveedores.Size = new Size(868, 200);
            grpDetalleProveedores.TabIndex = 4;
            grpDetalleProveedores.TabStop = false;
            grpDetalleProveedores.Text = "Detalle del Proveedor";
            //
            // flpAcciones
            //
            flpAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpAcciones.Controls.Add(btnNuevo);
            flpAcciones.Controls.Add(btnModificar);
            flpAcciones.Controls.Add(btnGuardar);
            flpAcciones.Controls.Add(btnCancelar);
            flpAcciones.Controls.Add(btnEliminar);
            flpAcciones.FlowDirection = FlowDirection.TopDown;
            flpAcciones.Location = new Point(706, 22);
            flpAcciones.Name = "flpAcciones";
            flpAcciones.Size = new Size(150, 120);
            flpAcciones.TabIndex = 10;
            flpAcciones.WrapContents = false;
            //
            // btnNuevo
            //
            btnNuevo.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Margin = new Padding(0, 0, 0, 6);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(146, 32);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Agregar";
            btnNuevo.UseVisualStyleBackColor = false;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Margin = new Padding(0, 0, 0, 6);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(146, 32);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Confirmar";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // btnModificar
            //
            btnModificar.BackColor = Color.FromArgb(37, 99, 235);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Margin = new Padding(0, 0, 0, 6);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(146, 32);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            //
            // btnEliminar
            //
            btnEliminar.BackColor = Color.FromArgb(239, 68, 68);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Margin = new Padding(0, 0, 0, 6);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(146, 32);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Inactivar";
            btnEliminar.UseVisualStyleBackColor = false;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(100, 116, 139);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Margin = new Padding(0, 0, 0, 6);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(146, 32);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnVolverMenu
            //
            btnVolverMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolverMenu.BackColor = Color.FromArgb(100, 116, 139);
            btnVolverMenu.FlatAppearance.BorderSize = 0;
            btnVolverMenu.FlatStyle = FlatStyle.Flat;
            btnVolverMenu.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolverMenu.ForeColor = Color.White;
            btnVolverMenu.Location = new Point(706, 152);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(146, 32);
            btnVolverMenu.TabIndex = 11;
            btnVolverMenu.Text = "Volver";
            btnVolverMenu.UseVisualStyleBackColor = false;
            btnVolverMenu.Click += btnVolverMenu_Click;
            //
            // txtDireccion
            //
            txtDireccion.Font = new Font("Segoe UI", 9.5F);
            txtDireccion.Location = new Point(470, 68);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PlaceholderText = "Ej: Av. Corrientes 1234, CABA";
            txtDireccion.Size = new Size(210, 24);
            txtDireccion.TabIndex = 9;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDireccion.ForeColor = Color.FromArgb(30, 41, 59);
            lblDireccion.Location = new Point(380, 71);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(66, 17);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Dirección:";
            //
            // txtEmail
            //
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(470, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Ej: ventas@proveedor.com";
            txtEmail.Size = new Size(210, 24);
            txtEmail.TabIndex = 7;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(30, 41, 59);
            lblEmail.Location = new Point(380, 33);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(43, 17);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            //
            // txtTelefono
            //
            txtTelefono.Font = new Font("Segoe UI", 9.5F);
            txtTelefono.Location = new Point(130, 106);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 11 4567-8900";
            txtTelefono.Size = new Size(210, 24);
            txtTelefono.TabIndex = 5;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(30, 41, 59);
            lblTelefono.Location = new Point(20, 109);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(62, 17);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            //
            // txtCUIT
            //
            txtCUIT.Font = new Font("Segoe UI", 9.5F);
            txtCUIT.Location = new Point(130, 68);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.PlaceholderText = "Ej: 30-71234567-8";
            txtCUIT.Size = new Size(210, 24);
            txtCUIT.TabIndex = 3;
            //
            // lblCuit
            //
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCuit.ForeColor = Color.FromArgb(30, 41, 59);
            lblCuit.Location = new Point(20, 71);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(39, 17);
            lblCuit.TabIndex = 2;
            lblCuit.Text = "CUIT:";
            //
            // txtRazonSocial
            //
            txtRazonSocial.Font = new Font("Segoe UI", 9.5F);
            txtRazonSocial.Location = new Point(130, 30);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.PlaceholderText = "Nombre de la empresa";
            txtRazonSocial.Size = new Size(210, 24);
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
            // lblResultado
            //
            lblResultado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultado.ForeColor = Color.FromArgb(16, 185, 129);
            lblResultado.Location = new Point(20, 146);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(670, 44);
            //
            // FormProveedores
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(900, 560);
            Controls.Add(grpDetalleProveedores);
            Controls.Add(dgvProveedores);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(916, 599);
            Name = "FormProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Gestión de Proveedores";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            grpDetalleProveedores.ResumeLayout(false);
            grpDetalleProveedores.PerformLayout();
            flpAcciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResultado;

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvProveedores;
        private GroupBox grpDetalleProveedores;
        private FlowLayoutPanel flpAcciones;
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
        private Button btnCancelar;
        private Button btnVolverMenu;
    }
}
