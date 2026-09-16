namespace GU_Tercero
{
    partial class FormAdmin
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
            dgvUsuarios = new DataGridView();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            txtIdUsuario = new TextBox();
            txtNombreUsuario = new TextBox();
            txtPasswordTemporal = new TextBox();
            chkActivo = new CheckBox();
            chkBloqueado = new CheckBox();
            cmbRol = new ComboBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtCorreo = new TextBox();
            lblNombreUsuario = new Label();
            lblIdUsuario = new Label();
            lblPasswordTemporal = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            lblRol = new Label();
            lblCorreo = new Label();
            btnGuardar = new Button();
            lblTitulo = new Label();
            btnCerrarSesion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.Anchor = AnchorStyles.None;
            dgvUsuarios.BackgroundColor = Color.Gainsboro;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(12, 52);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(581, 226);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.None;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            btnNuevo.Location = new Point(39, 309);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.None;
            btnModificar.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            btnModificar.Location = new Point(39, 338);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.None;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            btnEliminar.Location = new Point(39, 367);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Anchor = AnchorStyles.None;
            txtIdUsuario.Location = new Point(160, 309);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.ReadOnly = true;
            txtIdUsuario.Size = new Size(100, 23);
            txtIdUsuario.TabIndex = 4;
            txtIdUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Anchor = AnchorStyles.None;
            txtNombreUsuario.Location = new Point(266, 309);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 5;
            txtNombreUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPasswordTemporal
            // 
            txtPasswordTemporal.Anchor = AnchorStyles.None;
            txtPasswordTemporal.Location = new Point(372, 309);
            txtPasswordTemporal.Name = "txtPasswordTemporal";
            txtPasswordTemporal.ReadOnly = true;
            txtPasswordTemporal.Size = new Size(100, 23);
            txtPasswordTemporal.TabIndex = 6;
            txtPasswordTemporal.TextAlign = HorizontalAlignment.Center;
            // 
            // chkActivo
            // 
            chkActivo.Anchor = AnchorStyles.None;
            chkActivo.AutoSize = true;
            chkActivo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            chkActivo.Location = new Point(158, 397);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(58, 19);
            chkActivo.TabIndex = 7;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // chkBloqueado
            // 
            chkBloqueado.Anchor = AnchorStyles.None;
            chkBloqueado.AutoSize = true;
            chkBloqueado.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            chkBloqueado.Location = new Point(224, 397);
            chkBloqueado.Name = "chkBloqueado";
            chkBloqueado.Size = new Size(82, 19);
            chkBloqueado.TabIndex = 8;
            chkBloqueado.Text = "Bloqueado";
            chkBloqueado.UseVisualStyleBackColor = true;
            // 
            // cmbRol
            // 
            cmbRol.Anchor = AnchorStyles.None;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(642, 210);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(121, 23);
            cmbRol.TabIndex = 9;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.None;
            txtNombre.Location = new Point(478, 309);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 10;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.None;
            txtApellido.Location = new Point(584, 309);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 11;
            txtApellido.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDni
            // 
            txtDni.Anchor = AnchorStyles.None;
            txtDni.Location = new Point(690, 309);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 12;
            txtDni.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.None;
            txtCorreo.Location = new Point(158, 355);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(100, 23);
            txtCorreo.TabIndex = 13;
            txtCorreo.TextAlign = HorizontalAlignment.Center;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.None;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNombreUsuario.Location = new Point(264, 291);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(92, 15);
            lblNombreUsuario.TabIndex = 14;
            lblNombreUsuario.Text = "Nombre Usuario";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.Anchor = AnchorStyles.None;
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblIdUsuario.Location = new Point(158, 291);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(60, 15);
            lblIdUsuario.TabIndex = 15;
            lblIdUsuario.Text = "Id Usuario";
            // 
            // lblPasswordTemporal
            // 
            lblPasswordTemporal.Anchor = AnchorStyles.None;
            lblPasswordTemporal.AutoSize = true;
            lblPasswordTemporal.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblPasswordTemporal.Location = new Point(368, 292);
            lblPasswordTemporal.Name = "lblPasswordTemporal";
            lblPasswordTemporal.Size = new Size(109, 15);
            lblPasswordTemporal.TabIndex = 16;
            lblPasswordTemporal.Text = "Password Temporal";
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.None;
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNombre.Location = new Point(503, 291);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(49, 15);
            lblNombre.TabIndex = 17;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.Anchor = AnchorStyles.None;
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblApellido.Location = new Point(606, 292);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(50, 15);
            lblApellido.TabIndex = 18;
            lblApellido.Text = "Apellido";
            // 
            // lblDni
            // 
            lblDni.Anchor = AnchorStyles.None;
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblDni.Location = new Point(726, 292);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(28, 15);
            lblDni.TabIndex = 19;
            lblDni.Text = "DNI";
            // 
            // lblRol
            // 
            lblRol.Anchor = AnchorStyles.None;
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRol.Location = new Point(642, 192);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(23, 15);
            lblRol.TabIndex = 20;
            lblRol.Text = "Rol";
            lblRol.Click += lblRol_Click;
            // 
            // lblCorreo
            // 
            lblCorreo.Anchor = AnchorStyles.None;
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(158, 338);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(41, 15);
            lblCorreo.TabIndex = 21;
            lblCorreo.Text = "Correo";
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.None;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(715, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(8, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(228, 30);
            lblTitulo.TabIndex = 23;
            lblTitulo.Text = "Gestión Administrador";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(12, 415);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(87, 23);
            btnCerrarSesion.TabIndex = 24;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblTitulo);
            Controls.Add(btnGuardar);
            Controls.Add(lblCorreo);
            Controls.Add(lblRol);
            Controls.Add(lblDni);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblPasswordTemporal);
            Controls.Add(lblIdUsuario);
            Controls.Add(lblNombreUsuario);
            Controls.Add(txtCorreo);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(cmbRol);
            Controls.Add(chkBloqueado);
            Controls.Add(chkActivo);
            Controls.Add(txtPasswordTemporal);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtIdUsuario);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvUsuarios);
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAdmin";
            Load += FormAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private TextBox txtIdUsuario;
        private TextBox txtNombreUsuario;
        private TextBox txtPasswordTemporal;
        private CheckBox chkActivo;
        private CheckBox chkBloqueado;
        private ComboBox cmbRol;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtCorreo;
        private Label lblNombreUsuario;
        private Label lblIdUsuario;
        private Label lblPasswordTemporal;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private Label lblRol;
        private Label lblCorreo;
        private Button btnGuardar;
        private Label lblTitulo;
        private Button btnCerrarSesion;
    }
}