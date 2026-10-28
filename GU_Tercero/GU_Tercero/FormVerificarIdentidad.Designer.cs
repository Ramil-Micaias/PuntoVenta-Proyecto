namespace GU_Tercero
{
    partial class FormVerificarIdentidad
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblIndicacion = new Label();
            lblPregunta1 = new Label();
            txtRespuesta1 = new TextBox();
            lblPregunta2 = new Label();
            txtRespuesta2 = new TextBox();
            lblPregunta3 = new Label();
            txtRespuesta3 = new TextBox();
            btnCancelar = new Button();
            btnVerificar = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(460, 50);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "VERIFICAR IDENTIDAD";
            //
            // lblIndicacion
            //
            lblIndicacion.Font = new Font("Segoe UI", 9.5F);
            lblIndicacion.ForeColor = Color.FromArgb(51, 65, 85);
            lblIndicacion.Location = new Point(20, 60);
            lblIndicacion.Name = "lblIndicacion";
            lblIndicacion.Size = new Size(420, 36);
            lblIndicacion.TabIndex = 1;
            lblIndicacion.Text = "Por seguridad, responda sus preguntas de seguridad para continuar.";
            //
            // lblPregunta1
            //
            lblPregunta1.AutoSize = true;
            lblPregunta1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPregunta1.ForeColor = Color.FromArgb(30, 41, 59);
            lblPregunta1.Location = new Point(20, 102);
            lblPregunta1.Name = "lblPregunta1";
            lblPregunta1.Size = new Size(80, 17);
            lblPregunta1.TabIndex = 2;
            //
            // txtRespuesta1
            //
            txtRespuesta1.Font = new Font("Segoe UI", 9.5F);
            txtRespuesta1.Location = new Point(20, 122);
            txtRespuesta1.Name = "txtRespuesta1";
            txtRespuesta1.PlaceholderText = "Escriba su respuesta";
            txtRespuesta1.Size = new Size(420, 24);
            txtRespuesta1.TabIndex = 3;
            //
            // lblPregunta2
            //
            lblPregunta2.AutoSize = true;
            lblPregunta2.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPregunta2.ForeColor = Color.FromArgb(30, 41, 59);
            lblPregunta2.Location = new Point(20, 158);
            lblPregunta2.Name = "lblPregunta2";
            lblPregunta2.Size = new Size(80, 17);
            lblPregunta2.TabIndex = 4;
            //
            // txtRespuesta2
            //
            txtRespuesta2.Font = new Font("Segoe UI", 9.5F);
            txtRespuesta2.Location = new Point(20, 178);
            txtRespuesta2.Name = "txtRespuesta2";
            txtRespuesta2.PlaceholderText = "Escriba su respuesta";
            txtRespuesta2.Size = new Size(420, 24);
            txtRespuesta2.TabIndex = 5;
            //
            // lblPregunta3
            //
            lblPregunta3.AutoSize = true;
            lblPregunta3.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPregunta3.ForeColor = Color.FromArgb(30, 41, 59);
            lblPregunta3.Location = new Point(20, 214);
            lblPregunta3.Name = "lblPregunta3";
            lblPregunta3.Size = new Size(80, 17);
            lblPregunta3.TabIndex = 6;
            //
            // txtRespuesta3
            //
            txtRespuesta3.Font = new Font("Segoe UI", 9.5F);
            txtRespuesta3.Location = new Point(20, 234);
            txtRespuesta3.Name = "txtRespuesta3";
            txtRespuesta3.PlaceholderText = "Escriba su respuesta";
            txtRespuesta3.Size = new Size(420, 24);
            txtRespuesta3.TabIndex = 7;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(170, 280);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 38);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnVerificar
            //
            btnVerificar.BackColor = Color.FromArgb(37, 99, 235);
            btnVerificar.FlatAppearance.BorderSize = 0;
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVerificar.ForeColor = Color.White;
            btnVerificar.Location = new Point(310, 280);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(130, 38);
            btnVerificar.TabIndex = 8;
            btnVerificar.Text = "Verificar";
            btnVerificar.UseVisualStyleBackColor = false;
            //
            // FormVerificarIdentidad
            //
            AcceptButton = btnVerificar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            CancelButton = btnCancelar;
            ClientSize = new Size(460, 336);
            Controls.Add(btnVerificar);
            Controls.Add(btnCancelar);
            Controls.Add(txtRespuesta3);
            Controls.Add(lblPregunta3);
            Controls.Add(txtRespuesta2);
            Controls.Add(lblPregunta2);
            Controls.Add(txtRespuesta1);
            Controls.Add(lblPregunta1);
            Controls.Add(lblIndicacion);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVerificarIdentidad";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ApIBigStore - Verificar Identidad";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblIndicacion;
        private Label lblPregunta1;
        private TextBox txtRespuesta1;
        private Label lblPregunta2;
        private TextBox txtRespuesta2;
        private Label lblPregunta3;
        private TextBox txtRespuesta3;
        private Button btnCancelar;
        private Button btnVerificar;
    }
}
