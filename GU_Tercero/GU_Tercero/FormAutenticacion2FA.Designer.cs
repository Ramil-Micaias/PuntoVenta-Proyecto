namespace GU_Tercero
{
    partial class FormAutenticacion2FA
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
            lblMensaje = new Label();
            txtCodigo = new TextBox();
            btnVerificar = new Button();
            btnCancelar = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // lblMensaje
            // 
            lblMensaje.Anchor = AnchorStyles.None;
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            lblMensaje.Location = new Point(78, 64);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(469, 21);
            lblMensaje.TabIndex = 0;
            lblMensaje.Text = "Ingrese el código de verificación enviado a su correo electrónico.";
            // 
            // txtCodigo
            // 
            txtCodigo.Anchor = AnchorStyles.None;
            txtCodigo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            txtCodigo.Location = new Point(219, 102);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(180, 24);
            txtCodigo.TabIndex = 1;
            txtCodigo.TextAlign = HorizontalAlignment.Center;
            // 
            // btnVerificar
            // 
            btnVerificar.Anchor = AnchorStyles.None;
            btnVerificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            btnVerificar.Location = new Point(362, 166);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(75, 23);
            btnVerificar.TabIndex = 2;
            btnVerificar.Text = "Verificar";
            btnVerificar.UseVisualStyleBackColor = true;
            btnVerificar.Click += btnVerificar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            btnCancelar.Location = new Point(185, 166);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(145, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(347, 30);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "AUTENTICACIÓN EN DOS PASOS   ";
            // 
            // FormAutenticacion2FA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(632, 301);
            Controls.Add(lblTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnVerificar);
            Controls.Add(txtCodigo);
            Controls.Add(lblMensaje);
            Name = "FormAutenticacion2FA";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAutenticacion2FA";
            Load += FormAutenticacion2FA_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMensaje;
        private TextBox txtCodigo;
        private Button btnVerificar;
        private Button btnCancelar;
        private Label lblTitulo;
    }
}