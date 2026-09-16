
namespace GU_Tercero
{
    partial class FormRecuperoContraseña
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
            lblNombreUsuario = new Label();
            lblPregunta1 = new Label();
            lblPregunta2 = new Label();
            lblPregunta3 = new Label();
            txtNombreUsuario = new TextBox();
            txtRespuesta1 = new TextBox();
            txtRespuesta2 = new TextBox();
            txtRespuesta3 = new TextBox();
            btnValidar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.Location = new Point(207, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(303, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Recuperación de Contraseña";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.None;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNombreUsuario.Location = new Point(314, 69);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(108, 15);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Nombre de Usuario";
            // 
            // lblPregunta1
            // 
            lblPregunta1.Anchor = AnchorStyles.None;
            lblPregunta1.AutoSize = true;
            lblPregunta1.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblPregunta1.Location = new Point(279, 116);
            lblPregunta1.Name = "lblPregunta1";
            lblPregunta1.Size = new Size(180, 15);
            lblPregunta1.TabIndex = 2;
            lblPregunta1.Text = "¿Nombre de tu primera mascota?";
            lblPregunta1.Click += label3_Click;
            // 
            // lblPregunta2
            // 
            lblPregunta2.Anchor = AnchorStyles.None;
            lblPregunta2.AutoSize = true;
            lblPregunta2.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblPregunta2.Location = new Point(291, 165);
            lblPregunta2.Name = "lblPregunta2";
            lblPregunta2.Size = new Size(132, 15);
            lblPregunta2.TabIndex = 3;
            lblPregunta2.Text = "¿Ciudad donde naciste?";
            // 
            // lblPregunta3
            // 
            lblPregunta3.Anchor = AnchorStyles.None;
            lblPregunta3.AutoSize = true;
            lblPregunta3.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblPregunta3.Location = new Point(305, 214);
            lblPregunta3.Name = "lblPregunta3";
            lblPregunta3.Size = new Size(102, 15);
            lblPregunta3.TabIndex = 4;
            lblPregunta3.Text = "¿Comida favorita?";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Anchor = AnchorStyles.None;
            txtNombreUsuario.BorderStyle = BorderStyle.None;
            txtNombreUsuario.Font = new Font("Segoe UI", 9F);
            txtNombreUsuario.Location = new Point(220, 89);
            txtNombreUsuario.Multiline = true;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(273, 23);
            txtNombreUsuario.TabIndex = 5;
            txtNombreUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtRespuesta1
            // 
            txtRespuesta1.Anchor = AnchorStyles.None;
            txtRespuesta1.BorderStyle = BorderStyle.None;
            txtRespuesta1.Font = new Font("Segoe UI", 9F);
            txtRespuesta1.Location = new Point(220, 135);
            txtRespuesta1.Multiline = true;
            txtRespuesta1.Name = "txtRespuesta1";
            txtRespuesta1.Size = new Size(274, 23);
            txtRespuesta1.TabIndex = 6;
            txtRespuesta1.TextAlign = HorizontalAlignment.Center;
            // 
            // txtRespuesta2
            // 
            txtRespuesta2.Anchor = AnchorStyles.None;
            txtRespuesta2.BorderStyle = BorderStyle.None;
            txtRespuesta2.Font = new Font("Segoe UI", 9F);
            txtRespuesta2.Location = new Point(219, 183);
            txtRespuesta2.Multiline = true;
            txtRespuesta2.Name = "txtRespuesta2";
            txtRespuesta2.Size = new Size(274, 23);
            txtRespuesta2.TabIndex = 7;
            txtRespuesta2.TextAlign = HorizontalAlignment.Center;
            // 
            // txtRespuesta3
            // 
            txtRespuesta3.Anchor = AnchorStyles.None;
            txtRespuesta3.BorderStyle = BorderStyle.None;
            txtRespuesta3.Font = new Font("Segoe UI", 9F);
            txtRespuesta3.Location = new Point(219, 232);
            txtRespuesta3.Multiline = true;
            txtRespuesta3.Name = "txtRespuesta3";
            txtRespuesta3.Size = new Size(274, 23);
            txtRespuesta3.TabIndex = 8;
            txtRespuesta3.TextAlign = HorizontalAlignment.Center;
            // 
            // btnValidar
            // 
            btnValidar.Anchor = AnchorStyles.None;
            btnValidar.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            btnValidar.Location = new Point(263, 266);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(196, 23);
            btnValidar.TabIndex = 9;
            btnValidar.Text = "Validar Respuestas";
            btnValidar.UseVisualStyleBackColor = true;
            btnValidar.Click += btnValidar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(12, 372);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormRecuperoContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(716, 426);
            Controls.Add(btnCancelar);
            Controls.Add(btnValidar);
            Controls.Add(txtRespuesta3);
            Controls.Add(txtRespuesta2);
            Controls.Add(txtRespuesta1);
            Controls.Add(txtNombreUsuario);
            Controls.Add(lblPregunta3);
            Controls.Add(lblPregunta2);
            Controls.Add(lblPregunta1);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F);
            Name = "FormRecuperoContraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRecuperoContraseña";
            Load += FormRecuperoContraseña_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombreUsuario;
        private Label lblPregunta1;
        private Label lblPregunta2;
        private Label lblPregunta3;
        private TextBox txtNombreUsuario;
        private TextBox txtRespuesta1;
        private TextBox txtRespuesta2;
        private TextBox txtRespuesta3;
        private Button btnValidar;
        private Button btnCancelar;
    }
}