namespace GU_Tercero
{
    partial class FormCambioPassword
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
            btnCambiarPassword = new Button();
            txtNuevaPassword = new TextBox();
            lblCambioPassword = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnCambiarPassword
            // 
            btnCambiarPassword.Anchor = AnchorStyles.None;
            btnCambiarPassword.BackColor = Color.FromArgb(37, 99, 235);
            btnCambiarPassword.FlatAppearance.BorderSize = 0;
            btnCambiarPassword.FlatStyle = FlatStyle.Flat;
            btnCambiarPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCambiarPassword.ForeColor = Color.White;
            btnCambiarPassword.Location = new Point(280, 240);
            btnCambiarPassword.Name = "btnCambiarPassword";
            btnCambiarPassword.Size = new Size(240, 38);
            btnCambiarPassword.TabIndex = 2;
            btnCambiarPassword.Text = "Guardar Contraseña";
            btnCambiarPassword.UseVisualStyleBackColor = false;
            btnCambiarPassword.Click += btnCambiarPassword_Click;
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Anchor = AnchorStyles.None;
            txtNuevaPassword.Font = new Font("Segoe UI", 10F);
            txtNuevaPassword.Location = new Point(280, 175);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.PasswordChar = '*';
            txtNuevaPassword.Size = new Size(240, 25);
            txtNuevaPassword.TabIndex = 1;
            // 
            // lblCambioPassword
            // 
            lblCambioPassword.Anchor = AnchorStyles.None;
            lblCambioPassword.AutoSize = true;
            lblCambioPassword.BackColor = Color.Transparent;
            lblCambioPassword.Font = new Font("Segoe UI Bold", 20F);
            lblCambioPassword.ForeColor = Color.FromArgb(15, 23, 42);
            lblCambioPassword.Location = new Point(220, 70);
            lblCambioPassword.Name = "lblCambioPassword";
            lblCambioPassword.Size = new Size(360, 37);
            lblCambioPassword.TabIndex = 0;
            lblCambioPassword.TabStop = false;
            lblCambioPassword.Text = "Ingrese una nueva contraseña";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.BackColor = Color.FromArgb(226, 232, 240);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancelar.Location = new Point(340, 290);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 32);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormCambioPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(lblCambioPassword);
            Controls.Add(txtNuevaPassword);
            Controls.Add(btnCambiarPassword);
            Font = new Font("Segoe UI", 9F);
            Name = "FormCambioPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambiar Contraseña";
            FormClosing += FormCambioPassword_FormClosing;
            Load += FormCambioPassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCambiarPassword;
        private TextBox txtNuevaPassword;
        private Label lblCambioPassword;
        private Button btnCancelar;
    }
}