namespace GU_Tercero
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIngresar = new Button();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            llb_OlvidoContraseña = new LinkLabel();
            lblNombreUsuario = new Label();
            lblPassword = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.None;
            btnIngresar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(289, 213);
            btnIngresar.Margin = new Padding(2, 1, 2, 1);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(81, 22);
            btnIngresar.TabIndex = 0;
            btnIngresar.Text = "Iniciar ";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click_1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Location = new Point(273, 159);
            txtPassword.Margin = new Padding(2, 1, 2, 1);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(110, 23);
            txtPassword.TabIndex = 1;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.None;
            txtUsuario.Location = new Point(274, 113);
            txtUsuario.Margin = new Padding(2, 1, 2, 1);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(110, 23);
            txtUsuario.TabIndex = 2;
            // 
            // llb_OlvidoContraseña
            // 
            llb_OlvidoContraseña.Anchor = AnchorStyles.None;
            llb_OlvidoContraseña.AutoSize = true;
            llb_OlvidoContraseña.BackColor = Color.Transparent;
            llb_OlvidoContraseña.DisabledLinkColor = Color.Silver;
            llb_OlvidoContraseña.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            llb_OlvidoContraseña.Location = new Point(265, 189);
            llb_OlvidoContraseña.Name = "llb_OlvidoContraseña";
            llb_OlvidoContraseña.Size = new Size(127, 15);
            llb_OlvidoContraseña.TabIndex = 4;
            llb_OlvidoContraseña.TabStop = true;
            llb_OlvidoContraseña.Text = "¿Olvidó su contraseña?";
            llb_OlvidoContraseña.LinkClicked += llb_OlvidoContraseña_LinkClicked;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.None;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.BackColor = Color.Transparent;
            lblNombreUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNombreUsuario.Location = new Point(282, 92);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(92, 15);
            lblNombreUsuario.TabIndex = 6;
            lblNombreUsuario.Text = "Nombre Usuario";
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.None;
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(291, 140);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(68, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Contraseña";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Semibold", 24.75F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.Location = new Point(279, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(102, 45);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "Login";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(680, 388);
            Controls.Add(lblTitulo);
            Controls.Add(lblPassword);
            Controls.Add(lblNombreUsuario);
            Controls.Add(llb_OlvidoContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(txtPassword);
            Controls.Add(btnIngresar);
            Font = new Font("Segoe UI", 9F);
            IsMdiContainer = true;
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIngresar;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private LinkLabel llb_OlvidoContraseña;
        private Label lblNombreUsuario;
        private Label lblPassword;
        private Label lblTitulo;
    }
}
