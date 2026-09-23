
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
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Bold", 20F);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(180, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(365, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.TabStop = false;
            lblTitulo.Text = "Recuperación de Contraseña";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.None;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.BackColor = Color.Transparent;
            lblNombreUsuario.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombreUsuario.Location = new Point(220, 75);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(132, 17);
            lblNombreUsuario.TabIndex = 0;
            lblNombreUsuario.TabStop = false;
            lblNombreUsuario.Text = "Nombre de Usuario:";
            // 
            // lblPregunta1
            // 
            lblPregunta1.Anchor = AnchorStyles.None;
            lblPregunta1.AutoSize = true;
            lblPregunta1.BackColor = Color.Transparent;
            lblPregunta1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPregunta1.ForeColor = Color.FromArgb(30, 41, 59);
            lblPregunta1.Location = new Point(220, 137);
            lblPregunta1.Name = "lblPregunta1";
            lblPregunta1.Size = new Size(211, 17);
            lblPregunta1.TabIndex = 0;
            lblPregunta1.TabStop = false;
            lblPregunta1.Text = "¿Nombre de tu primera mascota?";
            lblPregunta1.Click += label3_Click;
            // 
            // lblPregunta2
            // 
            lblPregunta2.Anchor = AnchorStyles.None;
            lblPregunta2.AutoSize = true;
            lblPregunta2.BackColor = Color.Transparent;
            lblPregunta2.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPregunta2.ForeColor = Color.FromArgb(30, 41, 59);
            lblPregunta2.Location = new Point(220, 199);
            lblPregunta2.Name = "lblPregunta2";
            lblPregunta2.Size = new Size(158, 17);
            lblPregunta2.TabIndex = 0;
            lblPregunta2.TabStop = false;
            lblPregunta2.Text = "¿Ciudad donde naciste?";
            // 
            // lblPregunta3
            // 
            lblPregunta3.Anchor = AnchorStyles.None;
            lblPregunta3.AutoSize = true;
            lblPregunta3.BackColor = Color.Transparent;
            lblPregunta3.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPregunta3.ForeColor = Color.FromArgb(30, 41, 59);
            lblPregunta3.Location = new Point(220, 261);
            lblPregunta3.Name = "lblPregunta3";
            lblPregunta3.Size = new Size(125, 17);
            lblPregunta3.TabIndex = 0;
            lblPregunta3.TabStop = false;
            lblPregunta3.Text = "¿Comida favorita?";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Anchor = AnchorStyles.None;
            txtNombreUsuario.Font = new Font("Segoe UI", 10F);
            txtNombreUsuario.Location = new Point(220, 97);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(280, 25);
            txtNombreUsuario.TabIndex = 1;
            // 
            // txtRespuesta1
            // 
            txtRespuesta1.Anchor = AnchorStyles.None;
            txtRespuesta1.Font = new Font("Segoe UI", 10F);
            txtRespuesta1.Location = new Point(220, 159);
            txtRespuesta1.Name = "txtRespuesta1";
            txtRespuesta1.Size = new Size(280, 25);
            txtRespuesta1.TabIndex = 2;
            // 
            // txtRespuesta2
            // 
            txtRespuesta2.Anchor = AnchorStyles.None;
            txtRespuesta2.Font = new Font("Segoe UI", 10F);
            txtRespuesta2.Location = new Point(220, 221);
            txtRespuesta2.Name = "txtRespuesta2";
            txtRespuesta2.Size = new Size(280, 25);
            txtRespuesta2.TabIndex = 3;
            // 
            // txtRespuesta3
            // 
            txtRespuesta3.Anchor = AnchorStyles.None;
            txtRespuesta3.Font = new Font("Segoe UI", 10F);
            txtRespuesta3.Location = new Point(220, 283);
            txtRespuesta3.Name = "txtRespuesta3";
            txtRespuesta3.Size = new Size(280, 25);
            txtRespuesta3.TabIndex = 4;
            // 
            // btnValidar
            // 
            btnValidar.Anchor = AnchorStyles.None;
            btnValidar.BackColor = Color.FromArgb(37, 99, 235);
            btnValidar.FlatAppearance.BorderSize = 0;
            btnValidar.FlatStyle = FlatStyle.Flat;
            btnValidar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnValidar.ForeColor = Color.White;
            btnValidar.Location = new Point(220, 335);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(135, 36);
            btnValidar.TabIndex = 5;
            btnValidar.Text = "Validar Respuestas";
            btnValidar.UseVisualStyleBackColor = false;
            btnValidar.Click += btnValidar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.BackColor = Color.FromArgb(226, 232, 240);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancelar.Location = new Point(365, 335);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(135, 36);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormRecuperoContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
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
            Text = "Recuperar Contraseña";
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