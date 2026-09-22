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
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.None;
            btnIngresar.BackColor = Color.FromArgb(37, 99, 235);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(255, 240);
            btnIngresar.Margin = new Padding(2, 1, 2, 1);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(170, 35);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click_1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(255, 160);
            txtPassword.Margin = new Padding(2, 1, 2, 1);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(170, 25);
            txtPassword.TabIndex = 1;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.None;
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(255, 105);
            txtUsuario.Margin = new Padding(2, 1, 2, 1);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(170, 25);
            txtUsuario.TabIndex = 0;
            // 
            // llb_OlvidoContraseña
            // 
            llb_OlvidoContraseña.Anchor = AnchorStyles.None;
            llb_OlvidoContraseña.AutoSize = true;
            llb_OlvidoContraseña.BackColor = Color.Transparent;
            llb_OlvidoContraseña.DisabledLinkColor = Color.Silver;
            llb_OlvidoContraseña.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            llb_OlvidoContraseña.LinkColor = Color.FromArgb(37, 99, 235);
            llb_OlvidoContraseña.Location = new Point(275, 195);
            llb_OlvidoContraseña.Name = "llb_OlvidoContraseña";
            llb_OlvidoContraseña.Size = new Size(130, 15);
            llb_OlvidoContraseña.TabIndex = 3;
            llb_OlvidoContraseña.TabStop = true;
            llb_OlvidoContraseña.Text = "¿Olvidó su contraseña?";
            llb_OlvidoContraseña.LinkClicked += llb_OlvidoContraseña_LinkClicked;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.None;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.BackColor = Color.Transparent;
            lblNombreUsuario.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(30, 41, 59);
            lblNombreUsuario.Location = new Point(255, 85);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(111, 17);
            lblNombreUsuario.TabIndex = 0;
            lblNombreUsuario.TabStop = false;
            lblNombreUsuario.Text = "Nombre Usuario:";
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.None;
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(30, 41, 59);
            lblPassword.Location = new Point(255, 140);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 17);
            lblPassword.TabIndex = 0;
            lblPassword.TabStop = false;
            lblPassword.Text = "Contraseña:";
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Bold", 22F);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(245, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(190, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.TabStop = false;
            lblTitulo.Text = "Iniciar Sesión";
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.None;
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(45, 75);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(180, 180);
            picLogo.TabIndex = 9;
            picLogo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(680, 388);
            Controls.Add(picLogo);
            Controls.Add(lblTitulo);
            Controls.Add(lblPassword);
            Controls.Add(lblNombreUsuario);
            Controls.Add(llb_OlvidoContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(txtPassword);
            Controls.Add(btnIngresar);
            Font = new Font("Segoe UI", 9F);
            IsMdiContainer = false;
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
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
        private PictureBox picLogo;
    }
}
