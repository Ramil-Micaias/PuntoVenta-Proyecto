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
            btnCambiarPassword.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCambiarPassword.Location = new Point(300, 142);
            btnCambiarPassword.Name = "btnCambiarPassword";
            btnCambiarPassword.Size = new Size(156, 23);
            btnCambiarPassword.TabIndex = 0;
            btnCambiarPassword.Text = "Guardar Contrseña";
            btnCambiarPassword.TextAlign = ContentAlignment.TopCenter;
            btnCambiarPassword.UseVisualStyleBackColor = true;
            btnCambiarPassword.Click += btnCambiarPassword_Click;
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Anchor = AnchorStyles.None;
            txtNuevaPassword.BorderStyle = BorderStyle.None;
            txtNuevaPassword.Location = new Point(275, 110);
            txtNuevaPassword.Multiline = true;
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.Size = new Size(206, 23);
            txtNuevaPassword.TabIndex = 1;
            txtNuevaPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCambioPassword
            // 
            lblCambioPassword.AutoSize = true;
            lblCambioPassword.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCambioPassword.Location = new Point(232, 69);
            lblCambioPassword.Name = "lblCambioPassword";
            lblCambioPassword.Size = new Size(298, 30);
            lblCambioPassword.TabIndex = 2;
            lblCambioPassword.Text = "Ingrese una nueva contraseña";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(21, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormCambioPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(lblCambioPassword);
            Controls.Add(txtNuevaPassword);
            Controls.Add(btnCambiarPassword);
            Name = "FormCambioPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCambioPassword";
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