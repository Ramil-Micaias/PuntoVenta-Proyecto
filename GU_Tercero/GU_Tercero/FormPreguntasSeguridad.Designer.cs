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
            btnGuardar.Location = new Point(379, 240);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtRespuestaUno
            // 
            txtRespuestaUno.Location = new Point(258, 110);
            txtRespuestaUno.Name = "txtRespuestaUno";
            txtRespuestaUno.Size = new Size(302, 23);
            txtRespuestaUno.TabIndex = 5;
            // 
            // txtRespuestaDos
            // 
            txtRespuestaDos.Location = new Point(258, 157);
            txtRespuestaDos.Name = "txtRespuestaDos";
            txtRespuestaDos.Size = new Size(302, 23);
            txtRespuestaDos.TabIndex = 6;
            // 
            // txtRespuestaTres
            // 
            txtRespuestaTres.Location = new Point(258, 203);
            txtRespuestaTres.Name = "txtRespuestaTres";
            txtRespuestaTres.Size = new Size(302, 23);
            txtRespuestaTres.TabIndex = 7;
            // 
            // lblPreguntaUno
            // 
            lblPreguntaUno.AutoSize = true;
            lblPreguntaUno.Font = new Font("Segoe UI", 9.25F, FontStyle.Italic);
            lblPreguntaUno.Location = new Point(316, 90);
            lblPreguntaUno.Name = "lblPreguntaUno";
            lblPreguntaUno.Size = new Size(197, 17);
            lblPreguntaUno.TabIndex = 9;
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            // 
            // lblPreguntaDos
            // 
            lblPreguntaDos.AutoSize = true;
            lblPreguntaDos.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPreguntaDos.Location = new Point(346, 139);
            lblPreguntaDos.Name = "lblPreguntaDos";
            lblPreguntaDos.Size = new Size(132, 15);
            lblPreguntaDos.TabIndex = 10;
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            // 
            // lblPreguntaTres
            // 
            lblPreguntaTres.AutoSize = true;
            lblPreguntaTres.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPreguntaTres.Location = new Point(365, 184);
            lblPreguntaTres.Name = "lblPreguntaTres";
            lblPreguntaTres.Size = new Size(102, 15);
            lblPreguntaTres.TabIndex = 11;
            lblPreguntaTres.Text = "¿Comida favorita?";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(21, 391);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(313, 37);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(211, 30);
            lblTitulo.TabIndex = 14;
            lblTitulo.Text = "Preguntas Seguridad";
            // 
            // FormPreguntasSeguridad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
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
            Name = "FormPreguntasSeguridad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPreguntasSeguridad";
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