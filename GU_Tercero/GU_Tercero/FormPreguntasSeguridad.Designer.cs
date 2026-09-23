namespace GU_Tercero
{
    partial class FormPreguntasSeguridad
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
            btnGuardar = new Button();
            txtRespuestaUno = new TextBox();
            txtRespuestaDos = new TextBox();
            txtRespuestaTres = new TextBox();
            lblPreguntaUno = new Label();
            lblPreguntaDos = new Label();
            lblPreguntaTres = new Label();
            btnCancelar = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.None;
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(248, 335);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 36);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtRespuestaUno
            // 
            txtRespuestaUno.Anchor = AnchorStyles.None;
            txtRespuestaUno.Font = new Font("Segoe UI", 10F);
            txtRespuestaUno.Location = new Point(248, 135);
            txtRespuestaUno.Name = "txtRespuestaUno";
            txtRespuestaUno.Size = new Size(304, 25);
            txtRespuestaUno.TabIndex = 1;
            // 
            // txtRespuestaDos
            // 
            txtRespuestaDos.Anchor = AnchorStyles.None;
            txtRespuestaDos.Font = new Font("Segoe UI", 10F);
            txtRespuestaDos.Location = new Point(248, 205);
            txtRespuestaDos.Name = "txtRespuestaDos";
            txtRespuestaDos.Size = new Size(304, 25);
            txtRespuestaDos.TabIndex = 2;
            // 
            // txtRespuestaTres
            // 
            txtRespuestaTres.Anchor = AnchorStyles.None;
            txtRespuestaTres.Font = new Font("Segoe UI", 10F);
            txtRespuestaTres.Location = new Point(248, 275);
            txtRespuestaTres.Name = "txtRespuestaTres";
            txtRespuestaTres.Size = new Size(304, 25);
            txtRespuestaTres.TabIndex = 3;
            // 
            // lblPreguntaUno
            // 
            lblPreguntaUno.Anchor = AnchorStyles.None;
            lblPreguntaUno.AutoSize = true;
            lblPreguntaUno.BackColor = Color.Transparent;
            lblPreguntaUno.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPreguntaUno.ForeColor = Color.FromArgb(30, 41, 59);
            lblPreguntaUno.Location = new Point(248, 113);
            lblPreguntaUno.Name = "lblPreguntaUno";
            lblPreguntaUno.Size = new Size(211, 17);
            lblPreguntaUno.TabIndex = 0;
            lblPreguntaUno.TabStop = false;
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            // 
            // lblPreguntaDos
            // 
            lblPreguntaDos.Anchor = AnchorStyles.None;
            lblPreguntaDos.AutoSize = true;
            lblPreguntaDos.BackColor = Color.Transparent;
            lblPreguntaDos.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPreguntaDos.ForeColor = Color.FromArgb(30, 41, 59);
            lblPreguntaDos.Location = new Point(248, 183);
            lblPreguntaDos.Name = "lblPreguntaDos";
            lblPreguntaDos.Size = new Size(158, 17);
            lblPreguntaDos.TabIndex = 0;
            lblPreguntaDos.TabStop = false;
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            // 
            // lblPreguntaTres
            // 
            lblPreguntaTres.Anchor = AnchorStyles.None;
            lblPreguntaTres.AutoSize = true;
            lblPreguntaTres.BackColor = Color.Transparent;
            lblPreguntaTres.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPreguntaTres.ForeColor = Color.FromArgb(30, 41, 59);
            lblPreguntaTres.Location = new Point(248, 253);
            lblPreguntaTres.Name = "lblPreguntaTres";
            lblPreguntaTres.Size = new Size(125, 17);
            lblPreguntaTres.TabIndex = 0;
            lblPreguntaTres.TabStop = false;
            lblPreguntaTres.Text = "¿Comida favorita?";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.BackColor = Color.FromArgb(226, 232, 240);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancelar.Location = new Point(412, 335);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 36);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Bold", 20F);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(248, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(318, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.TabStop = false;
            lblTitulo.Text = "Preguntas de Seguridad";
            // 
            // FormPreguntasSeguridad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(lblPreguntaTres);
            Controls.Add(lblPreguntaDos);
            Controls.Add(lblPreguntaUno);
            Controls.Add(txtRespuestaTres);
            Controls.Add(txtRespuestaDos);
            Controls.Add(txtRespuestaUno);
            Controls.Add(btnGuardar);
            Font = new Font("Segoe UI", 9F);
            Name = "FormPreguntasSeguridad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preguntas de Seguridad";
            Load += FormPreguntasSeguridad_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGuardar;
        private TextBox txtRespuestaUno;
        private TextBox txtRespuestaDos;
        private TextBox txtRespuestaTres;
        private Label lblPreguntaUno;
        private Label lblPreguntaDos;
        private Label lblPreguntaTres;
        private Button btnCancelar;
        private Label lblTitulo;
    }
}