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
            lblTitulo = new Label();
            lblMensaje = new Label();
            lblCorreo = new Label();
            txtCodigo = new TextBox();
            btnVerificar = new Button();
            btnCancelar = new Button();
            lnkReenviar = new LinkLabel();
            lblVencimiento = new Label();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Bold", 18F);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(20, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(480, 34);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Verificación en Dos Pasos";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblMensaje
            //
            lblMensaje.Font = new Font("Segoe UI", 10F);
            lblMensaje.ForeColor = Color.FromArgb(51, 65, 85);
            lblMensaje.Location = new Point(20, 70);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(480, 22);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "Ingrese el código de verificación enviado a su correo electrónico:";
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblCorreo
            //
            lblCorreo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCorreo.ForeColor = Color.FromArgb(37, 99, 235);
            lblCorreo.Location = new Point(20, 94);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(480, 22);
            lblCorreo.TabIndex = 2;
            lblCorreo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // txtCodigo
            //
            txtCodigo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtCodigo.Location = new Point(170, 132);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "000000";
            txtCodigo.Size = new Size(180, 36);
            txtCodigo.TabIndex = 3;
            txtCodigo.TextAlign = HorizontalAlignment.Center;
            //
            // lblVencimiento
            //
            lblVencimiento.Font = new Font("Segoe UI", 9F);
            lblVencimiento.ForeColor = Color.FromArgb(100, 116, 139);
            lblVencimiento.Location = new Point(20, 176);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(480, 20);
            lblVencimiento.TabIndex = 4;
            lblVencimiento.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnVerificar
            //
            btnVerificar.BackColor = Color.FromArgb(37, 99, 235);
            btnVerificar.FlatAppearance.BorderSize = 0;
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVerificar.ForeColor = Color.White;
            btnVerificar.Location = new Point(140, 208);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(240, 38);
            btnVerificar.TabIndex = 5;
            btnVerificar.Text = "Verificar";
            btnVerificar.UseVisualStyleBackColor = false;
            btnVerificar.Click += btnVerificar_Click;
            //
            // lnkReenviar
            //
            lnkReenviar.Font = new Font("Segoe UI", 9.5F);
            lnkReenviar.LinkColor = Color.FromArgb(37, 99, 235);
            lnkReenviar.Location = new Point(140, 256);
            lnkReenviar.Name = "lnkReenviar";
            lnkReenviar.Size = new Size(240, 20);
            lnkReenviar.TabIndex = 6;
            lnkReenviar.TabStop = true;
            lnkReenviar.Text = "Reenviar código";
            lnkReenviar.TextAlign = ContentAlignment.MiddleCenter;
            lnkReenviar.LinkClicked += lnkReenviar_LinkClicked;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(226, 232, 240);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancelar.Location = new Point(200, 288);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 32);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // FormAutenticacion2FA
            //
            AcceptButton = btnVerificar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(520, 340);
            Controls.Add(btnCancelar);
            Controls.Add(lnkReenviar);
            Controls.Add(btnVerificar);
            Controls.Add(lblVencimiento);
            Controls.Add(txtCodigo);
            Controls.Add(lblCorreo);
            Controls.Add(lblMensaje);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAutenticacion2FA";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Verificación en Dos Pasos";
            Load += FormAutenticacion2FA_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMensaje;
        private Label lblCorreo;
        private TextBox txtCodigo;
        private Label lblVencimiento;
        private Button btnVerificar;
        private LinkLabel lnkReenviar;
        private Button btnCancelar;
    }
}
