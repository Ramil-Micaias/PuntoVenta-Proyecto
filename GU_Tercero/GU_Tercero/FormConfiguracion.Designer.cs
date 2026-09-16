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
            lblTitulo = new Label();
            lblMinCaracteres = new Label();
            lblCantidadPreguntas = new Label();
            lblHistorial = new Label();
            chkMayusculas = new CheckBox();
            chkNumeros = new CheckBox();
            chkEspecial = new CheckBox();
            chk2FA = new CheckBox();
            chkNoRepetir = new CheckBox();
            chkDatosPersonales = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnRestaurar = new Button();
            grpPolitasSeguridad = new GroupBox();
            nudCantidadMinimaCaracteres = new NumericUpDown();
            nudCantidadPreguntas = new NumericUpDown();
            nudHistorialCantidadContraseña = new NumericUpDown();
            grpPolitasSeguridad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadMinimaCaracteres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadPreguntas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHistorialCantidadContraseña).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(10, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(262, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración del Sistema";
            // 
            // lblMinCaracteres
            // 
            lblMinCaracteres.Anchor = AnchorStyles.None;
            lblMinCaracteres.AutoSize = true;
            lblMinCaracteres.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            lblMinCaracteres.Location = new Point(12, 59);
            lblMinCaracteres.Name = "lblMinCaracteres";
            lblMinCaracteres.Size = new Size(163, 15);
            lblMinCaracteres.TabIndex = 1;
            lblMinCaracteres.Text = "Cantidad minima caracteres:";
            // 
            // lblCantidadPreguntas
            // 
            lblCantidadPreguntas.Anchor = AnchorStyles.None;
            lblCantidadPreguntas.AutoSize = true;
            lblCantidadPreguntas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            lblCantidadPreguntas.Location = new Point(13, 100);
            lblCantidadPreguntas.Name = "lblCantidadPreguntas";
            lblCantidadPreguntas.Size = new Size(134, 15);
            lblCantidadPreguntas.TabIndex = 3;
            lblCantidadPreguntas.Text = "Cantidad de Preguntas:";
            // 
            // lblHistorial
            // 
            lblHistorial.Anchor = AnchorStyles.None;
            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            lblHistorial.Location = new Point(14, 140);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(199, 15);
            lblHistorial.TabIndex = 5;
            lblHistorial.Text = "Historial (Cantidad de Contraseña):";
            // 
            // chkMayusculas
            // 
            chkMayusculas.AutoSize = true;
            chkMayusculas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            chkMayusculas.Location = new Point(6, 32);
            chkMayusculas.Name = "chkMayusculas";
            chkMayusculas.Size = new Size(88, 19);
            chkMayusculas.TabIndex = 7;
            chkMayusculas.Text = "Mayusculas";
            chkMayusculas.UseVisualStyleBackColor = true;
            // 
            // chkNumeros
            // 
            chkNumeros.AutoSize = true;
            chkNumeros.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            chkNumeros.Location = new Point(6, 57);
            chkNumeros.Name = "chkNumeros";
            chkNumeros.Size = new Size(76, 19);
            chkNumeros.TabIndex = 8;
            chkNumeros.Text = "Numeros";
            chkNumeros.UseVisualStyleBackColor = true;
            // 
            // chkEspecial
            // 
            chkEspecial.AutoSize = true;
            chkEspecial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            chkEspecial.Location = new Point(6, 82);
            chkEspecial.Name = "chkEspecial";
            chkEspecial.Size = new Size(164, 19);
            chkEspecial.TabIndex = 9;
            chkEspecial.Text = "Requerir carácter especial";
            chkEspecial.UseVisualStyleBackColor = true;
            // 
            // chk2FA
            // 
            chk2FA.AutoSize = true;
            chk2FA.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            chk2FA.Location = new Point(6, 107);
            chk2FA.Name = "chk2FA";
            chk2FA.Size = new Size(171, 19);
            chk2FA.TabIndex = 10;
            chk2FA.Text = "Autenticación en dos pasos";
            chk2FA.UseVisualStyleBackColor = true;
            // 
            // chkNoRepetir
            // 
            chkNoRepetir.AutoSize = true;
            chkNoRepetir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            chkNoRepetir.Location = new Point(6, 132);
            chkNoRepetir.Name = "chkNoRepetir";
            chkNoRepetir.Size = new Size(196, 19);
            chkNoRepetir.TabIndex = 11;
            chkNoRepetir.Text = "No permitir repetir contraseñas";
            chkNoRepetir.UseVisualStyleBackColor = true;
            // 
            // chkDatosPersonales
            // 
            chkDatosPersonales.AutoSize = true;
            chkDatosPersonales.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            chkDatosPersonales.Location = new Point(6, 157);
            chkDatosPersonales.Name = "chkDatosPersonales";
            chkDatosPersonales.Size = new Size(160, 19);
            chkDatosPersonales.TabIndex = 12;
            chkDatosPersonales.Text = "Validar datos personales";
            chkDatosPersonales.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.None;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            btnGuardar.Location = new Point(421, 281);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            btnCancelar.Location = new Point(170, 281);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Anchor = AnchorStyles.None;
            btnRestaurar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRestaurar.Location = new Point(279, 281);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(112, 23);
            btnRestaurar.TabIndex = 15;
            btnRestaurar.Text = "Restaurar valores";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // grpPolitasSeguridad
            // 
            grpPolitasSeguridad.Anchor = AnchorStyles.None;
            grpPolitasSeguridad.BackColor = SystemColors.ActiveCaption;
            grpPolitasSeguridad.Controls.Add(chkMayusculas);
            grpPolitasSeguridad.Controls.Add(chkNumeros);
            grpPolitasSeguridad.Controls.Add(chkEspecial);
            grpPolitasSeguridad.Controls.Add(chk2FA);
            grpPolitasSeguridad.Controls.Add(chkDatosPersonales);
            grpPolitasSeguridad.Controls.Add(chkNoRepetir);
            grpPolitasSeguridad.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic);
            grpPolitasSeguridad.Location = new Point(410, 51);
            grpPolitasSeguridad.Name = "grpPolitasSeguridad";
            grpPolitasSeguridad.Size = new Size(224, 185);
            grpPolitasSeguridad.TabIndex = 16;
            grpPolitasSeguridad.TabStop = false;
            grpPolitasSeguridad.Text = "Políticas de Seguridad";
            // 
            // nudCantidadMinimaCaracteres
            // 
            nudCantidadMinimaCaracteres.Anchor = AnchorStyles.None;
            nudCantidadMinimaCaracteres.Location = new Point(219, 55);
            nudCantidadMinimaCaracteres.Name = "nudCantidadMinimaCaracteres";
            nudCantidadMinimaCaracteres.Size = new Size(90, 23);
            nudCantidadMinimaCaracteres.TabIndex = 17;
            // 
            // nudCantidadPreguntas
            // 
            nudCantidadPreguntas.Anchor = AnchorStyles.None;
            nudCantidadPreguntas.Location = new Point(219, 95);
            nudCantidadPreguntas.Name = "nudCantidadPreguntas";
            nudCantidadPreguntas.Size = new Size(90, 23);
            nudCantidadPreguntas.TabIndex = 18;
            // 
            // nudHistorialCantidadContraseña
            // 
            nudHistorialCantidadContraseña.Anchor = AnchorStyles.None;
            nudHistorialCantidadContraseña.Location = new Point(219, 137);
            nudHistorialCantidadContraseña.Name = "nudHistorialCantidadContraseña";
            nudHistorialCantidadContraseña.Size = new Size(90, 23);
            nudHistorialCantidadContraseña.TabIndex = 19;
            // 
            // FormConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(677, 347);
            Controls.Add(nudHistorialCantidadContraseña);
            Controls.Add(nudCantidadPreguntas);
            Controls.Add(nudCantidadMinimaCaracteres);
            Controls.Add(grpPolitasSeguridad);
            Controls.Add(btnRestaurar);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblHistorial);
            Controls.Add(lblCantidadPreguntas);
            Controls.Add(lblMinCaracteres);
            Controls.Add(lblTitulo);
            Name = "FormConfiguracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormConfiguracion";
            Load += FormConfiguracion_Load;
            grpPolitasSeguridad.ResumeLayout(false);
            grpPolitasSeguridad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadMinimaCaracteres).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadPreguntas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHistorialCantidadContraseña).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
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