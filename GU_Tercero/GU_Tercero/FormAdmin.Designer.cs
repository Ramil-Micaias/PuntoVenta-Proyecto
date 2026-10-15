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
            panelHeader = new Panel();
            lblTitulo = new Label();
            dgvUsuarios = new DataGridView();
            grpDatos = new GroupBox();
            btnVolver = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            chkBloqueado = new CheckBox();
            chkActivo = new CheckBox();
            cmbRol = new ComboBox();
            lblRol = new Label();
            txtNombreUsuario = new TextBox();
            lblNombreUsuario = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpDatos.SuspendLayout();
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
            lblTitulo.Size = new Size(229, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE USUARIOS";
            //
            // dgvUsuarios
            //
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(16, 68);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(868, 254);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            //
            // grpDatos
            //
            grpDatos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatos.Controls.Add(btnVolver);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Controls.Add(btnModificar);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(chkBloqueado);
            grpDatos.Controls.Add(chkActivo);
            grpDatos.Controls.Add(cmbRol);
            grpDatos.Controls.Add(lblRol);
            grpDatos.Controls.Add(txtNombreUsuario);
            grpDatos.Controls.Add(lblNombreUsuario);
            grpDatos.Controls.Add(txtCorreo);
            grpDatos.Controls.Add(lblCorreo);
            grpDatos.Controls.Add(txtDni);
            grpDatos.Controls.Add(lblDni);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtApellido);
            grpDatos.Controls.Add(lblApellido);
            grpDatos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpDatos.ForeColor = Color.FromArgb(15, 23, 42);
            grpDatos.Location = new Point(16, 332);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(868, 236);
            grpDatos.TabIndex = 2;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del Usuario";
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(706, 186);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(146, 32);
            btnVolver.TabIndex = 13;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // btnEliminar
            //
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.FromArgb(239, 68, 68);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(706, 136);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(146, 32);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click_1;
            //
            // btnModificar
            //
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.BackColor = Color.FromArgb(37, 99, 235);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(706, 98);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(146, 32);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            //
            // btnGuardar
            //
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(706, 60);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(146, 32);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnNuevo
            //
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(706, 22);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(146, 32);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            //
            // chkBloqueado
            //
            chkBloqueado.AutoSize = true;
            chkBloqueado.Font = new Font("Segoe UI", 9.5F);
            chkBloqueado.ForeColor = Color.FromArgb(30, 41, 59);
            chkBloqueado.Location = new Point(220, 158);
            chkBloqueado.Name = "chkBloqueado";
            chkBloqueado.Size = new Size(87, 21);
            chkBloqueado.TabIndex = 8;
            chkBloqueado.Text = "Bloqueado";
            chkBloqueado.UseVisualStyleBackColor = true;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F);
            chkActivo.ForeColor = Color.FromArgb(30, 41, 59);
            chkActivo.Location = new Point(130, 158);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(61, 21);
            chkActivo.TabIndex = 7;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            //
            // cmbRol
            //
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 9.5F);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(470, 106);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(200, 25);
            cmbRol.TabIndex = 6;
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(30, 41, 59);
            lblRol.Location = new Point(360, 109);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(30, 17);
            lblRol.TabIndex = 0;
            lblRol.Text = "Rol:";
            //
            // txtNombreUsuario
            //
            txtNombreUsuario.Font = new Font("Segoe UI", 9.5F);
            txtNombreUsuario.Location = new Point(130, 106);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.PlaceholderText = "Ej: jperez";
            txtNombreUsuario.Size = new Size(200, 24);
            txtNombreUsuario.TabIndex = 5;
            //
            // lblNombreUsuario
            //
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombreUsuario.Location = new Point(20, 109);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(57, 17);
            lblNombreUsuario.TabIndex = 0;
            lblNombreUsuario.Text = "Usuario:";
            //
            // txtCorreo
            //
            txtCorreo.Font = new Font("Segoe UI", 9.5F);
            txtCorreo.Location = new Point(470, 68);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ej: usuario@correo.com";
            txtCorreo.Size = new Size(200, 24);
            txtCorreo.TabIndex = 4;
            //
            // lblCorreo
            //
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCorreo.ForeColor = Color.FromArgb(30, 41, 59);
            lblCorreo.Location = new Point(360, 71);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(51, 17);
            lblCorreo.TabIndex = 0;
            lblCorreo.Text = "Correo:";
            //
            // txtDni
            //
            txtDni.Font = new Font("Segoe UI", 9.5F);
            txtDni.Location = new Point(130, 68);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "Sin puntos. Ej: 30123456";
            txtDni.Size = new Size(200, 24);
            txtDni.TabIndex = 3;
            //
            // lblDni
            //
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDni.ForeColor = Color.FromArgb(30, 41, 59);
            lblDni.Location = new Point(20, 71);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(33, 17);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI:";
            //
            // txtNombre
            //
            txtNombre.Font = new Font("Segoe UI", 9.5F);
            txtNombre.Location = new Point(470, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Juan";
            txtNombre.Size = new Size(200, 24);
            txtNombre.TabIndex = 2;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombre.Location = new Point(360, 33);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(59, 17);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            //
            // txtApellido
            //
            txtApellido.Font = new Font("Segoe UI", 9.5F);
            txtApellido.Location = new Point(130, 30);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ej: Pérez";
            txtApellido.Size = new Size(200, 24);
            txtApellido.TabIndex = 1;
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(30, 41, 59);
            lblApellido.Location = new Point(20, 33);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(60, 17);
            lblApellido.TabIndex = 0;
            lblApellido.Text = "Apellido:";
            //
            // FormAdmin
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(900, 584);
            Controls.Add(grpDatos);
            Controls.Add(dgvUsuarios);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(916, 623);
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Gestión de Usuarios";
            Load += FormAdmin_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private DataGridView dgvUsuarios;
        private GroupBox grpDatos;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnVolver;
        private CheckBox chkActivo;
        private CheckBox chkBloqueado;
        private ComboBox cmbRol;
        private Label lblRol;
        private TextBox txtNombreUsuario;
        private Label lblNombreUsuario;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private TextBox txtDni;
        private Label lblDni;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtApellido;
        private Label lblApellido;
    }
}
