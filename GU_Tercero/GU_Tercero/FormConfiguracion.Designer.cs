namespace GU_Tercero
{
    partial class FormConfiguracion
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
            grpContrasenas = new GroupBox();
            lblMinCaracteres = new Label();
            nudCantidadMinimaCaracteres = new NumericUpDown();
            lblCantidadPreguntas = new Label();
            nudCantidadPreguntas = new NumericUpDown();
            lblHistorial = new Label();
            nudHistorialCantidadContraseña = new NumericUpDown();
            grpPolitasSeguridad = new GroupBox();
            chkMayusculas = new CheckBox();
            chkNumeros = new CheckBox();
            chkEspecial = new CheckBox();
            chk2FA = new CheckBox();
            chkNoRepetir = new CheckBox();
            chkDatosPersonales = new CheckBox();
            btnRestaurar = new Button();
            lblResultado = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            panelHeader.SuspendLayout();
            grpContrasenas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadMinimaCaracteres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadPreguntas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHistorialCantidadContraseña).BeginInit();
            grpPolitasSeguridad.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(760, 56);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(24, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(316, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CONFIGURACIÓN DEL SISTEMA";
            //
            // grpContrasenas
            //
            grpContrasenas.Controls.Add(nudHistorialCantidadContraseña);
            grpContrasenas.Controls.Add(lblHistorial);
            grpContrasenas.Controls.Add(nudCantidadPreguntas);
            grpContrasenas.Controls.Add(lblCantidadPreguntas);
            grpContrasenas.Controls.Add(nudCantidadMinimaCaracteres);
            grpContrasenas.Controls.Add(lblMinCaracteres);
            grpContrasenas.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpContrasenas.ForeColor = Color.FromArgb(15, 23, 42);
            grpContrasenas.Location = new Point(16, 72);
            grpContrasenas.Name = "grpContrasenas";
            grpContrasenas.Size = new Size(356, 200);
            grpContrasenas.TabIndex = 1;
            grpContrasenas.TabStop = false;
            grpContrasenas.Text = "Contraseñas";
            //
            // lblMinCaracteres
            //
            lblMinCaracteres.AutoSize = true;
            lblMinCaracteres.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMinCaracteres.ForeColor = Color.FromArgb(30, 41, 59);
            lblMinCaracteres.Location = new Point(20, 40);
            lblMinCaracteres.Name = "lblMinCaracteres";
            lblMinCaracteres.Size = new Size(182, 17);
            lblMinCaracteres.TabIndex = 0;
            lblMinCaracteres.Text = "Cantidad mínima caracteres:";
            //
            // nudCantidadMinimaCaracteres
            //
            nudCantidadMinimaCaracteres.Font = new Font("Segoe UI", 9.5F);
            nudCantidadMinimaCaracteres.Location = new Point(250, 37);
            nudCantidadMinimaCaracteres.Name = "nudCantidadMinimaCaracteres";
            nudCantidadMinimaCaracteres.Size = new Size(86, 24);
            nudCantidadMinimaCaracteres.TabIndex = 1;
            //
            // lblCantidadPreguntas
            //
            lblCantidadPreguntas.AutoSize = true;
            lblCantidadPreguntas.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCantidadPreguntas.ForeColor = Color.FromArgb(30, 41, 59);
            lblCantidadPreguntas.Location = new Point(20, 90);
            lblCantidadPreguntas.Name = "lblCantidadPreguntas";
            lblCantidadPreguntas.Size = new Size(154, 17);
            lblCantidadPreguntas.TabIndex = 2;
            lblCantidadPreguntas.Text = "Preguntas al recuperar:";
            //
            // nudCantidadPreguntas
            //
            nudCantidadPreguntas.Font = new Font("Segoe UI", 9.5F);
            nudCantidadPreguntas.Location = new Point(250, 87);
            nudCantidadPreguntas.Name = "nudCantidadPreguntas";
            nudCantidadPreguntas.Size = new Size(86, 24);
            nudCantidadPreguntas.TabIndex = 3;
            //
            // lblHistorial
            //
            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblHistorial.ForeColor = Color.FromArgb(30, 41, 59);
            lblHistorial.Location = new Point(20, 140);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(205, 17);
            lblHistorial.TabIndex = 4;
            lblHistorial.Text = "Historial (contraseñas a recordar):";
            //
            // nudHistorialCantidadContraseña
            //
            nudHistorialCantidadContraseña.Font = new Font("Segoe UI", 9.5F);
            nudHistorialCantidadContraseña.Location = new Point(250, 137);
            nudHistorialCantidadContraseña.Name = "nudHistorialCantidadContraseña";
            nudHistorialCantidadContraseña.Size = new Size(86, 24);
            nudHistorialCantidadContraseña.TabIndex = 5;
            //
            // grpPolitasSeguridad
            //
            grpPolitasSeguridad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpPolitasSeguridad.Controls.Add(chkMayusculas);
            grpPolitasSeguridad.Controls.Add(chkNumeros);
            grpPolitasSeguridad.Controls.Add(chkEspecial);
            grpPolitasSeguridad.Controls.Add(chk2FA);
            grpPolitasSeguridad.Controls.Add(chkNoRepetir);
            grpPolitasSeguridad.Controls.Add(chkDatosPersonales);
            grpPolitasSeguridad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpPolitasSeguridad.ForeColor = Color.FromArgb(15, 23, 42);
            grpPolitasSeguridad.Location = new Point(388, 72);
            grpPolitasSeguridad.Name = "grpPolitasSeguridad";
            grpPolitasSeguridad.Size = new Size(356, 200);
            grpPolitasSeguridad.TabIndex = 2;
            grpPolitasSeguridad.TabStop = false;
            grpPolitasSeguridad.Text = "Políticas de Seguridad";
            //
            // chkMayusculas
            //
            chkMayusculas.AutoSize = true;
            chkMayusculas.Font = new Font("Segoe UI", 9.5F);
            chkMayusculas.ForeColor = Color.FromArgb(30, 41, 59);
            chkMayusculas.Location = new Point(20, 32);
            chkMayusculas.Name = "chkMayusculas";
            chkMayusculas.Size = new Size(144, 21);
            chkMayusculas.TabIndex = 0;
            chkMayusculas.Text = "Requerir mayúsculas";
            chkMayusculas.UseVisualStyleBackColor = true;
            //
            // chkNumeros
            //
            chkNumeros.AutoSize = true;
            chkNumeros.Font = new Font("Segoe UI", 9.5F);
            chkNumeros.ForeColor = Color.FromArgb(30, 41, 59);
            chkNumeros.Location = new Point(20, 59);
            chkNumeros.Name = "chkNumeros";
            chkNumeros.Size = new Size(130, 21);
            chkNumeros.TabIndex = 1;
            chkNumeros.Text = "Requerir números";
            chkNumeros.UseVisualStyleBackColor = true;
            //
            // chkEspecial
            //
            chkEspecial.AutoSize = true;
            chkEspecial.Font = new Font("Segoe UI", 9.5F);
            chkEspecial.ForeColor = Color.FromArgb(30, 41, 59);
            chkEspecial.Location = new Point(20, 86);
            chkEspecial.Name = "chkEspecial";
            chkEspecial.Size = new Size(176, 21);
            chkEspecial.TabIndex = 2;
            chkEspecial.Text = "Requerir carácter especial";
            chkEspecial.UseVisualStyleBackColor = true;
            //
            // chk2FA
            //
            chk2FA.AutoSize = true;
            chk2FA.Font = new Font("Segoe UI", 9.5F);
            chk2FA.ForeColor = Color.FromArgb(30, 41, 59);
            chk2FA.Location = new Point(20, 113);
            chk2FA.Name = "chk2FA";
            chk2FA.Size = new Size(185, 21);
            chk2FA.TabIndex = 3;
            chk2FA.Text = "Autenticación en dos pasos";
            chk2FA.UseVisualStyleBackColor = true;
            //
            // chkNoRepetir
            //
            chkNoRepetir.AutoSize = true;
            chkNoRepetir.Font = new Font("Segoe UI", 9.5F);
            chkNoRepetir.ForeColor = Color.FromArgb(30, 41, 59);
            chkNoRepetir.Location = new Point(20, 140);
            chkNoRepetir.Name = "chkNoRepetir";
            chkNoRepetir.Size = new Size(212, 21);
            chkNoRepetir.TabIndex = 4;
            chkNoRepetir.Text = "No permitir repetir contraseñas";
            chkNoRepetir.UseVisualStyleBackColor = true;
            //
            // chkDatosPersonales
            //
            chkDatosPersonales.AutoSize = true;
            chkDatosPersonales.Font = new Font("Segoe UI", 9.5F);
            chkDatosPersonales.ForeColor = Color.FromArgb(30, 41, 59);
            chkDatosPersonales.Location = new Point(20, 167);
            chkDatosPersonales.Name = "chkDatosPersonales";
            chkDatosPersonales.Size = new Size(173, 21);
            chkDatosPersonales.TabIndex = 5;
            chkDatosPersonales.Text = "Validar datos personales";
            chkDatosPersonales.UseVisualStyleBackColor = true;
            //
            // btnRestaurar
            //
            btnRestaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestaurar.BackColor = Color.FromArgb(37, 99, 235);
            btnRestaurar.FlatAppearance.BorderSize = 0;
            btnRestaurar.FlatStyle = FlatStyle.Flat;
            btnRestaurar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnRestaurar.ForeColor = Color.White;
            btnRestaurar.Location = new Point(316, 292);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(140, 34);
            btnRestaurar.TabIndex = 3;
            btnRestaurar.Text = "Restaurar valores";
            btnRestaurar.UseVisualStyleBackColor = false;
            btnRestaurar.Click += btnRestaurar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.FromArgb(100, 116, 139);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(468, 292);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 34);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // btnGuardar
            //
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(610, 292);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(134, 34);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // lblResultado
            //
            lblResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblResultado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultado.ForeColor = Color.FromArgb(16, 185, 129);
            lblResultado.Location = new Point(16, 288);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(290, 42);
            //
            // FormConfiguracion
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(760, 342);
            Controls.Add(lblResultado);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(btnRestaurar);
            Controls.Add(grpPolitasSeguridad);
            Controls.Add(grpContrasenas);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(776, 381);
            Name = "FormConfiguracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Configuración del Sistema";
            Load += FormConfiguracion_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpContrasenas.ResumeLayout(false);
            grpContrasenas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadMinimaCaracteres).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadPreguntas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHistorialCantidadContraseña).EndInit();
            grpPolitasSeguridad.ResumeLayout(false);
            grpPolitasSeguridad.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblResultado;

        private Panel panelHeader;
        private Label lblTitulo;
        private GroupBox grpContrasenas;
        private Label lblMinCaracteres;
        private Label lblCantidadPreguntas;
        private Label lblHistorial;
        private CheckBox chkMayusculas;
        private CheckBox chkNumeros;
        private CheckBox chkEspecial;
        private CheckBox chk2FA;
        private CheckBox chkNoRepetir;
        private CheckBox chkDatosPersonales;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnRestaurar;
        private GroupBox grpPolitasSeguridad;
        private NumericUpDown nudCantidadMinimaCaracteres;
        private NumericUpDown nudCantidadPreguntas;
        private NumericUpDown nudHistorialCantidadContraseña;
    }
}
