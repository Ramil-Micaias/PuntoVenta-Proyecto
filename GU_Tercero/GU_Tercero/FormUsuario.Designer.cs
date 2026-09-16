using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuario));
            lblMiCuenta = new Label();
            lblUsuario = new Label();
            lblRol = new Label();
            grpInformacionUsuario = new GroupBox();
            lblNombreRol = new Label();
            lblNombreUsuario = new Label();
            grpCambiarContraseña = new GroupBox();
            btnCambiarPassword = new Button();
            txtConfirmarPassword = new TextBox();
            txtNuevaPassword = new TextBox();
            lblConfirmarPassword = new Label();
            lblNuevaPassword = new Label();
            grpPreguntasSeguridad = new GroupBox();
            btnGuardarPreguntas = new Button();
            txtRespuestaTres = new TextBox();
            lblPreguntaTres = new Label();
            txtRespuestaDos = new TextBox();
            lblPreguntaDos = new Label();
            txtRespuestaUno = new TextBox();
            lblPreguntaUno = new Label();
            btnCerrarSesion = new Button();
            lblMensaje = new Label();
            label1 = new Label();
            grpInformacionUsuario.SuspendLayout();
            grpCambiarContraseña.SuspendLayout();
            grpPreguntasSeguridad.SuspendLayout();
            SuspendLayout();
            // 
            // lblMiCuenta
            // 
            lblMiCuenta.Anchor = AnchorStyles.None;
            lblMiCuenta.AutoSize = true;
            lblMiCuenta.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMiCuenta.Location = new Point(274, 1);
            lblMiCuenta.Name = "lblMiCuenta";
            lblMiCuenta.Size = new Size(137, 37);
            lblMiCuenta.TabIndex = 0;
            lblMiCuenta.Text = "Mi cuenta";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            lblUsuario.Location = new Point(6, 27);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 17);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            lblRol.Location = new Point(30, 57);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(30, 17);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol:";
            // 
            // grpInformacionUsuario
            // 
            grpInformacionUsuario.Anchor = AnchorStyles.None;
            grpInformacionUsuario.BackColor = SystemColors.ActiveCaption;
            grpInformacionUsuario.Controls.Add(lblNombreRol);
            grpInformacionUsuario.Controls.Add(lblNombreUsuario);
            grpInformacionUsuario.Controls.Add(lblUsuario);
            grpInformacionUsuario.Controls.Add(lblRol);
            grpInformacionUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            grpInformacionUsuario.Location = new Point(46, 34);
            grpInformacionUsuario.Name = "grpInformacionUsuario";
            grpInformacionUsuario.Size = new Size(336, 81);
            grpInformacionUsuario.TabIndex = 3;
            grpInformacionUsuario.TabStop = false;
            grpInformacionUsuario.Text = "Información del usuario";
            // 
            // lblNombreRol
            // 
            lblNombreRol.AutoSize = true;
            lblNombreRol.Location = new Point(85, 59);
            lblNombreRol.Name = "lblNombreRol";
            lblNombreRol.Size = new Size(42, 17);
            lblNombreRol.TabIndex = 4;
            lblNombreRol.Text = "label1";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(86, 29);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(42, 17);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "label1";
            // 
            // grpCambiarContraseña
            // 
            grpCambiarContraseña.Anchor = AnchorStyles.None;
            grpCambiarContraseña.BackColor = SystemColors.ActiveCaption;
            grpCambiarContraseña.Controls.Add(btnCambiarPassword);
            grpCambiarContraseña.Controls.Add(txtConfirmarPassword);
            grpCambiarContraseña.Controls.Add(txtNuevaPassword);
            grpCambiarContraseña.Controls.Add(lblConfirmarPassword);
            grpCambiarContraseña.Controls.Add(lblNuevaPassword);
            grpCambiarContraseña.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            grpCambiarContraseña.Location = new Point(46, 114);
            grpCambiarContraseña.Name = "grpCambiarContraseña";
            grpCambiarContraseña.Size = new Size(336, 163);
            grpCambiarContraseña.TabIndex = 4;
            grpCambiarContraseña.TabStop = false;
            grpCambiarContraseña.Text = "Cambiar contraseña";
            // 
            // btnCambiarPassword
            // 
            btnCambiarPassword.Location = new Point(100, 128);
            btnCambiarPassword.Name = "btnCambiarPassword";
            btnCambiarPassword.Size = new Size(135, 23);
            btnCambiarPassword.TabIndex = 4;
            btnCambiarPassword.Text = "Cambiar contraseña";
            btnCambiarPassword.UseVisualStyleBackColor = true;
            btnCambiarPassword.Click += btnCambiarPassword_Click;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.Location = new Point(15, 92);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(197, 25);
            txtConfirmarPassword.TabIndex = 3;
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Location = new Point(15, 45);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.Size = new Size(197, 25);
            txtNuevaPassword.TabIndex = 2;
            // 
            // lblConfirmarPassword
            // 
            lblConfirmarPassword.AutoSize = true;
            lblConfirmarPassword.Location = new Point(12, 72);
            lblConfirmarPassword.Name = "lblConfirmarPassword";
            lblConfirmarPassword.Size = new Size(138, 17);
            lblConfirmarPassword.TabIndex = 1;
            lblConfirmarPassword.Text = "Confirmar Contraseña";
            // 
            // lblNuevaPassword
            // 
            lblNuevaPassword.AutoSize = true;
            lblNuevaPassword.Location = new Point(13, 25);
            lblNuevaPassword.Name = "lblNuevaPassword";
            lblNuevaPassword.Size = new Size(118, 17);
            lblNuevaPassword.TabIndex = 0;
            lblNuevaPassword.Text = "Nueva Contraseña";
            // 
            // grpPreguntasSeguridad
            // 
            grpPreguntasSeguridad.Anchor = AnchorStyles.None;
            grpPreguntasSeguridad.BackColor = SystemColors.ActiveCaption;
            grpPreguntasSeguridad.Controls.Add(btnGuardarPreguntas);
            grpPreguntasSeguridad.Controls.Add(txtRespuestaTres);
            grpPreguntasSeguridad.Controls.Add(lblPreguntaTres);
            grpPreguntasSeguridad.Controls.Add(txtRespuestaDos);
            grpPreguntasSeguridad.Controls.Add(lblPreguntaDos);
            grpPreguntasSeguridad.Controls.Add(txtRespuestaUno);
            grpPreguntasSeguridad.Controls.Add(lblPreguntaUno);
            grpPreguntasSeguridad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            grpPreguntasSeguridad.Location = new Point(46, 276);
            grpPreguntasSeguridad.Name = "grpPreguntasSeguridad";
            grpPreguntasSeguridad.Size = new Size(336, 226);
            grpPreguntasSeguridad.TabIndex = 5;
            grpPreguntasSeguridad.TabStop = false;
            grpPreguntasSeguridad.Text = "Preguntas de seguridad";
            // 
            // btnGuardarPreguntas
            // 
            btnGuardarPreguntas.Location = new Point(106, 187);
            btnGuardarPreguntas.Name = "btnGuardarPreguntas";
            btnGuardarPreguntas.Size = new Size(129, 23);
            btnGuardarPreguntas.TabIndex = 6;
            btnGuardarPreguntas.Text = "Guardar preguntas";
            btnGuardarPreguntas.UseVisualStyleBackColor = true;
            btnGuardarPreguntas.Click += btnGuardarPreguntas_Click;
            // 
            // txtRespuestaTres
            // 
            txtRespuestaTres.Location = new Point(15, 143);
            txtRespuestaTres.Name = "txtRespuestaTres";
            txtRespuestaTres.Size = new Size(100, 25);
            txtRespuestaTres.TabIndex = 5;
            // 
            // lblPreguntaTres
            // 
            lblPreguntaTres.AutoSize = true;
            lblPreguntaTres.Location = new Point(15, 123);
            lblPreguntaTres.Name = "lblPreguntaTres";
            lblPreguntaTres.Size = new Size(114, 17);
            lblPreguntaTres.TabIndex = 4;
            lblPreguntaTres.Text = "¿Comida favorita?";
            // 
            // txtRespuestaDos
            // 
            txtRespuestaDos.Location = new Point(15, 95);
            txtRespuestaDos.Name = "txtRespuestaDos";
            txtRespuestaDos.Size = new Size(100, 25);
            txtRespuestaDos.TabIndex = 3;
            // 
            // lblPreguntaDos
            // 
            lblPreguntaDos.AutoSize = true;
            lblPreguntaDos.Location = new Point(13, 75);
            lblPreguntaDos.Name = "lblPreguntaDos";
            lblPreguntaDos.Size = new Size(147, 17);
            lblPreguntaDos.TabIndex = 2;
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            // 
            // txtRespuestaUno
            // 
            txtRespuestaUno.Location = new Point(15, 47);
            txtRespuestaUno.Name = "txtRespuestaUno";
            txtRespuestaUno.Size = new Size(100, 25);
            txtRespuestaUno.TabIndex = 1;
            // 
            // lblPreguntaUno
            // 
            lblPreguntaUno.AutoSize = true;
            lblPreguntaUno.Location = new Point(13, 27);
            lblPreguntaUno.Name = "lblPreguntaUno";
            lblPreguntaUno.Size = new Size(204, 17);
            lblPreguntaUno.TabIndex = 0;
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.None;
            btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(572, 471);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(90, 23);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.Anchor = AnchorStyles.None;
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMensaje.Location = new Point(388, 288);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(249, 45);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "Para modificar sus preguntas de seguridad, \r\ncomplete nuevamente todas las respuestas y \r\nhaga clic en \"Guardar\"";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(388, 124);
            label1.Name = "label1";
            label1.Size = new Size(322, 60);
            label1.TabIndex = 8;
            label1.Text = resources.GetString("label1.Text");
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(708, 500);
            Controls.Add(label1);
            Controls.Add(lblMensaje);
            Controls.Add(btnCerrarSesion);
            Controls.Add(grpPreguntasSeguridad);
            Controls.Add(grpCambiarContraseña);
            Controls.Add(grpInformacionUsuario);
            Controls.Add(lblMiCuenta);
            Margin = new Padding(2, 1, 2, 1);
            Name = "FormUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormUsuario";
            Load += FormUsuario_Load;
            grpInformacionUsuario.ResumeLayout(false);
            grpInformacionUsuario.PerformLayout();
            grpCambiarContraseña.ResumeLayout(false);
            grpCambiarContraseña.PerformLayout();
            grpPreguntasSeguridad.ResumeLayout(false);
            grpPreguntasSeguridad.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMiCuenta;
        private Label lblUsuario;
        private Label lblRol;
        private GroupBox grpInformacionUsuario;
        private Label lblNombreRol;
        private Label lblNombreUsuario;
        private GroupBox grpCambiarContraseña;
        private Button btnCambiarPassword;
        private TextBox txtConfirmarPassword;
        private TextBox txtNuevaPassword;
        private Label lblConfirmarPassword;
        private Label lblNuevaPassword;
        private GroupBox grpPreguntasSeguridad;
        private Button btnGuardarPreguntas;
        private TextBox txtRespuestaTres;
        private Label lblPreguntaTres;
        private TextBox txtRespuestaDos;
        private Label lblPreguntaDos;
        private TextBox txtRespuestaUno;
        private Label lblPreguntaUno;
        private Button btnCerrarSesion;
        private Label lblMensaje;
        private Label label1;
    }
}