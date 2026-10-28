namespace GU_Tercero
{
    partial class FormUsuario
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
            lblMiCuenta = new Label();
            grpInformacionUsuario = new GroupBox();
            lblUsuario = new Label();
            lblNombreUsuario = new Label();
            lblRol = new Label();
            lblNombreRol = new Label();
            grpCambiarContraseña = new GroupBox();
            lblNuevaPassword = new Label();
            txtNuevaPassword = new TextBox();
            lblConfirmarPassword = new Label();
            txtConfirmarPassword = new TextBox();
            lblAyudaPassword = new Label();
            btnCambiarPassword = new Button();
            grpPreguntasSeguridad = new GroupBox();
            lblPreguntaUno = new Label();
            txtRespuestaUno = new TextBox();
            lblPreguntaDos = new Label();
            txtRespuestaDos = new TextBox();
            lblPreguntaTres = new Label();
            txtRespuestaTres = new TextBox();
            lblMensaje = new Label();
            btnGuardarPreguntas = new Button();
            btnVolver = new Button();
            lblResultado = new Label();
            panelHeader.SuspendLayout();
            grpInformacionUsuario.SuspendLayout();
            grpCambiarContraseña.SuspendLayout();
            grpPreguntasSeguridad.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblMiCuenta);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(760, 56);
            panelHeader.TabIndex = 0;
            //
            // lblMiCuenta
            //
            lblMiCuenta.AutoSize = true;
            lblMiCuenta.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblMiCuenta.ForeColor = Color.White;
            lblMiCuenta.Location = new Point(24, 13);
            lblMiCuenta.Name = "lblMiCuenta";
            lblMiCuenta.Size = new Size(115, 28);
            lblMiCuenta.TabIndex = 0;
            lblMiCuenta.Text = "MI PERFIL";
            //
            // grpInformacionUsuario
            //
            grpInformacionUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInformacionUsuario.Controls.Add(lblNombreRol);
            grpInformacionUsuario.Controls.Add(lblRol);
            grpInformacionUsuario.Controls.Add(lblNombreUsuario);
            grpInformacionUsuario.Controls.Add(lblUsuario);
            grpInformacionUsuario.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpInformacionUsuario.ForeColor = Color.FromArgb(15, 23, 42);
            grpInformacionUsuario.Location = new Point(16, 72);
            grpInformacionUsuario.Name = "grpInformacionUsuario";
            grpInformacionUsuario.Size = new Size(728, 76);
            grpInformacionUsuario.TabIndex = 1;
            grpInformacionUsuario.TabStop = false;
            grpInformacionUsuario.Text = "Información del usuario";
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(30, 41, 59);
            lblUsuario.Location = new Point(20, 34);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(57, 17);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            //
            // lblNombreUsuario
            //
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 9.5F);
            lblNombreUsuario.ForeColor = Color.FromArgb(15, 23, 42);
            lblNombreUsuario.Location = new Point(90, 34);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(0, 17);
            lblNombreUsuario.TabIndex = 1;
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(30, 41, 59);
            lblRol.Location = new Point(360, 34);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(30, 17);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol:";
            //
            // lblNombreRol
            //
            lblNombreRol.AutoSize = true;
            lblNombreRol.Font = new Font("Segoe UI", 9.5F);
            lblNombreRol.ForeColor = Color.FromArgb(15, 23, 42);
            lblNombreRol.Location = new Point(400, 34);
            lblNombreRol.Name = "lblNombreRol";
            lblNombreRol.Size = new Size(0, 17);
            lblNombreRol.TabIndex = 3;
            //
            // grpCambiarContraseña
            //
            grpCambiarContraseña.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCambiarContraseña.Controls.Add(btnCambiarPassword);
            grpCambiarContraseña.Controls.Add(lblAyudaPassword);
            grpCambiarContraseña.Controls.Add(txtConfirmarPassword);
            grpCambiarContraseña.Controls.Add(lblConfirmarPassword);
            grpCambiarContraseña.Controls.Add(txtNuevaPassword);
            grpCambiarContraseña.Controls.Add(lblNuevaPassword);
            grpCambiarContraseña.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpCambiarContraseña.ForeColor = Color.FromArgb(15, 23, 42);
            grpCambiarContraseña.Location = new Point(16, 160);
            grpCambiarContraseña.Name = "grpCambiarContraseña";
            grpCambiarContraseña.Size = new Size(728, 160);
            grpCambiarContraseña.TabIndex = 2;
            grpCambiarContraseña.TabStop = false;
            grpCambiarContraseña.Text = "Cambiar contraseña";
            //
            // lblNuevaPassword
            //
            lblNuevaPassword.AutoSize = true;
            lblNuevaPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNuevaPassword.ForeColor = Color.FromArgb(30, 41, 59);
            lblNuevaPassword.Location = new Point(20, 30);
            lblNuevaPassword.Name = "lblNuevaPassword";
            lblNuevaPassword.Size = new Size(122, 17);
            lblNuevaPassword.TabIndex = 0;
            lblNuevaPassword.Text = "Nueva contraseña:";
            //
            // txtNuevaPassword
            //
            txtNuevaPassword.Font = new Font("Segoe UI", 9.5F);
            txtNuevaPassword.Location = new Point(20, 52);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.PasswordChar = '*';
            txtNuevaPassword.PlaceholderText = "Ingrese la nueva contraseña";
            txtNuevaPassword.Size = new Size(300, 24);
            txtNuevaPassword.TabIndex = 1;
            //
            // lblConfirmarPassword
            //
            lblConfirmarPassword.AutoSize = true;
            lblConfirmarPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblConfirmarPassword.ForeColor = Color.FromArgb(30, 41, 59);
            lblConfirmarPassword.Location = new Point(20, 88);
            lblConfirmarPassword.Name = "lblConfirmarPassword";
            lblConfirmarPassword.Size = new Size(147, 17);
            lblConfirmarPassword.TabIndex = 2;
            lblConfirmarPassword.Text = "Confirmar contraseña:";
            //
            // txtConfirmarPassword
            //
            txtConfirmarPassword.Font = new Font("Segoe UI", 9.5F);
            txtConfirmarPassword.Location = new Point(20, 110);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.PasswordChar = '*';
            txtConfirmarPassword.PlaceholderText = "Repita la nueva contraseña";
            txtConfirmarPassword.Size = new Size(300, 24);
            txtConfirmarPassword.TabIndex = 3;
            //
            // lblAyudaPassword
            //
            lblAyudaPassword.Font = new Font("Segoe UI", 9F);
            lblAyudaPassword.ForeColor = Color.FromArgb(100, 116, 139);
            lblAyudaPassword.Location = new Point(350, 30);
            lblAyudaPassword.Name = "lblAyudaPassword";
            lblAyudaPassword.Size = new Size(360, 64);
            lblAyudaPassword.TabIndex = 4;
            lblAyudaPassword.Text = "Presione \"Cambiar contraseña\" y responda sus 3 preguntas de seguridad. Si son correctas se habilitan los campos para ingresar la nueva contraseña.";
            //
            // btnCambiarPassword
            //
            btnCambiarPassword.BackColor = Color.FromArgb(37, 99, 235);
            btnCambiarPassword.FlatAppearance.BorderSize = 0;
            btnCambiarPassword.FlatStyle = FlatStyle.Flat;
            btnCambiarPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCambiarPassword.ForeColor = Color.White;
            btnCambiarPassword.Location = new Point(350, 106);
            btnCambiarPassword.Name = "btnCambiarPassword";
            btnCambiarPassword.Size = new Size(200, 32);
            btnCambiarPassword.TabIndex = 5;
            btnCambiarPassword.Text = "Cambiar contraseña";
            btnCambiarPassword.UseVisualStyleBackColor = false;
            btnCambiarPassword.Click += btnCambiarPassword_Click;
            //
            // grpPreguntasSeguridad
            //
            grpPreguntasSeguridad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpPreguntasSeguridad.Controls.Add(btnGuardarPreguntas);
            grpPreguntasSeguridad.Controls.Add(lblMensaje);
            grpPreguntasSeguridad.Controls.Add(txtRespuestaTres);
            grpPreguntasSeguridad.Controls.Add(lblPreguntaTres);
            grpPreguntasSeguridad.Controls.Add(txtRespuestaDos);
            grpPreguntasSeguridad.Controls.Add(lblPreguntaDos);
            grpPreguntasSeguridad.Controls.Add(txtRespuestaUno);
            grpPreguntasSeguridad.Controls.Add(lblPreguntaUno);
            grpPreguntasSeguridad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpPreguntasSeguridad.ForeColor = Color.FromArgb(15, 23, 42);
            grpPreguntasSeguridad.Location = new Point(16, 332);
            grpPreguntasSeguridad.Name = "grpPreguntasSeguridad";
            grpPreguntasSeguridad.Size = new Size(728, 200);
            grpPreguntasSeguridad.TabIndex = 3;
            grpPreguntasSeguridad.TabStop = false;
            grpPreguntasSeguridad.Text = "Preguntas de seguridad";
            //
            // lblPreguntaUno
            //
            lblPreguntaUno.AutoSize = true;
            lblPreguntaUno.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPreguntaUno.ForeColor = Color.FromArgb(30, 41, 59);
            lblPreguntaUno.Location = new Point(20, 30);
            lblPreguntaUno.Name = "lblPreguntaUno";
            lblPreguntaUno.Size = new Size(210, 17);
            lblPreguntaUno.TabIndex = 0;
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            //
            // txtRespuestaUno
            //
            txtRespuestaUno.Font = new Font("Segoe UI", 9.5F);
            txtRespuestaUno.Location = new Point(20, 50);
            txtRespuestaUno.Name = "txtRespuestaUno";
            txtRespuestaUno.PlaceholderText = "Escriba su respuesta";
            txtRespuestaUno.Size = new Size(300, 24);
            txtRespuestaUno.TabIndex = 1;
            //
            // lblPreguntaDos
            //
            lblPreguntaDos.AutoSize = true;
            lblPreguntaDos.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPreguntaDos.ForeColor = Color.FromArgb(30, 41, 59);
            lblPreguntaDos.Location = new Point(20, 84);
            lblPreguntaDos.Name = "lblPreguntaDos";
            lblPreguntaDos.Size = new Size(152, 17);
            lblPreguntaDos.TabIndex = 2;
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            //
            // txtRespuestaDos
            //
            txtRespuestaDos.Font = new Font("Segoe UI", 9.5F);
            txtRespuestaDos.Location = new Point(20, 104);
            txtRespuestaDos.Name = "txtRespuestaDos";
            txtRespuestaDos.PlaceholderText = "Escriba su respuesta";
            txtRespuestaDos.Size = new Size(300, 24);
            txtRespuestaDos.TabIndex = 3;
            //
            // lblPreguntaTres
            //
            lblPreguntaTres.AutoSize = true;
            lblPreguntaTres.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPreguntaTres.ForeColor = Color.FromArgb(30, 41, 59);
            lblPreguntaTres.Location = new Point(20, 138);
            lblPreguntaTres.Name = "lblPreguntaTres";
            lblPreguntaTres.Size = new Size(118, 17);
            lblPreguntaTres.TabIndex = 4;
            lblPreguntaTres.Text = "¿Comida favorita?";
            //
            // txtRespuestaTres
            //
            txtRespuestaTres.Font = new Font("Segoe UI", 9.5F);
            txtRespuestaTres.Location = new Point(20, 158);
            txtRespuestaTres.Name = "txtRespuestaTres";
            txtRespuestaTres.PlaceholderText = "Escriba su respuesta";
            txtRespuestaTres.Size = new Size(300, 24);
            txtRespuestaTres.TabIndex = 5;
            //
            // lblMensaje
            //
            lblMensaje.Font = new Font("Segoe UI", 9F);
            lblMensaje.ForeColor = Color.FromArgb(100, 116, 139);
            lblMensaje.Location = new Point(350, 30);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(360, 48);
            lblMensaje.TabIndex = 6;
            lblMensaje.Text = "Presione \"Cambiar preguntas\" y responda las actuales. Si son correctas se habilitan los campos para cargar las nuevas respuestas.";
            //
            // btnGuardarPreguntas
            //
            btnGuardarPreguntas.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardarPreguntas.FlatAppearance.BorderSize = 0;
            btnGuardarPreguntas.FlatStyle = FlatStyle.Flat;
            btnGuardarPreguntas.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardarPreguntas.ForeColor = Color.White;
            btnGuardarPreguntas.Location = new Point(350, 100);
            btnGuardarPreguntas.Name = "btnGuardarPreguntas";
            btnGuardarPreguntas.Size = new Size(200, 32);
            btnGuardarPreguntas.TabIndex = 7;
            btnGuardarPreguntas.Text = "Cambiar preguntas";
            btnGuardarPreguntas.UseVisualStyleBackColor = false;
            btnGuardarPreguntas.Click += btnGuardarPreguntas_Click;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(594, 546);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(150, 34);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            //
            // lblResultado
            //
            lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResultado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultado.ForeColor = Color.FromArgb(16, 185, 129);
            lblResultado.Location = new Point(16, 546);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(560, 34);
            //
            // FormUsuario
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(760, 596);
            Controls.Add(lblResultado);
            Controls.Add(btnVolver);
            Controls.Add(grpPreguntasSeguridad);
            Controls.Add(grpCambiarContraseña);
            Controls.Add(grpInformacionUsuario);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(776, 635);
            Name = "FormUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Mi Perfil";
            Load += FormUsuario_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpInformacionUsuario.ResumeLayout(false);
            grpInformacionUsuario.PerformLayout();
            grpCambiarContraseña.ResumeLayout(false);
            grpCambiarContraseña.PerformLayout();
            grpPreguntasSeguridad.ResumeLayout(false);
            grpPreguntasSeguridad.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblResultado;

        private Panel panelHeader;
        private Label lblMiCuenta;
        private GroupBox grpInformacionUsuario;
        private Label lblUsuario;
        private Label lblNombreUsuario;
        private Label lblRol;
        private Label lblNombreRol;
        private GroupBox grpCambiarContraseña;
        private Label lblNuevaPassword;
        private TextBox txtNuevaPassword;
        private Label lblConfirmarPassword;
        private TextBox txtConfirmarPassword;
        private Label lblAyudaPassword;
        private Button btnCambiarPassword;
        private GroupBox grpPreguntasSeguridad;
        private Label lblPreguntaUno;
        private TextBox txtRespuestaUno;
        private Label lblPreguntaDos;
        private TextBox txtRespuestaDos;
        private Label lblPreguntaTres;
        private TextBox txtRespuestaTres;
        private Label lblMensaje;
        private Button btnGuardarPreguntas;
        private Button btnVolver;
    }
}
