namespace Vista
{
    partial class FormNuevoEquipo
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
            lblCliente = new Label();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblModelo = new Label();
            txtModelo = new TextBox();
            lblColor = new Label();
            txtColor = new TextBox();
            lblImei = new Label();
            txtImei = new TextBox();
            lblSerie = new Label();
            txtSerie = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
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
            panelHeader.Size = new Size(420, 50);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(141, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NUEVO EQUIPO";
            //
            // lblCliente
            //
            lblCliente.Font = new Font("Segoe UI", 9.5F);
            lblCliente.ForeColor = Color.FromArgb(71, 85, 105);
            lblCliente.Location = new Point(24, 60);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(366, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTipo.ForeColor = Color.FromArgb(30, 41, 59);
            lblTipo.Location = new Point(24, 95);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(37, 17);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo:";
            //
            // cmbTipo
            //
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Segoe UI", 9.5F);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Celular", "Tablet", "Notebook", "Smartwatch", "Auriculares", "Otro" });
            cmbTipo.Location = new Point(130, 92);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(260, 25);
            cmbTipo.TabIndex = 1;
            //
            // lblMarca
            //
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMarca.ForeColor = Color.FromArgb(30, 41, 59);
            lblMarca.Location = new Point(24, 133);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(48, 17);
            lblMarca.TabIndex = 0;
            lblMarca.Text = "Marca:";
            //
            // txtMarca
            //
            txtMarca.Font = new Font("Segoe UI", 9.5F);
            txtMarca.Location = new Point(130, 130);
            txtMarca.MaxLength = 50;
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "Ej: Apple";
            txtMarca.Size = new Size(260, 24);
            txtMarca.TabIndex = 2;
            txtMarca.Text = "Apple";
            //
            // lblModelo
            //
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblModelo.ForeColor = Color.FromArgb(30, 41, 59);
            lblModelo.Location = new Point(24, 171);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(55, 17);
            lblModelo.TabIndex = 0;
            lblModelo.Text = "Modelo:";
            //
            // txtModelo
            //
            txtModelo.Font = new Font("Segoe UI", 9.5F);
            txtModelo.Location = new Point(130, 168);
            txtModelo.MaxLength = 80;
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "Ej: iPhone 14";
            txtModelo.Size = new Size(260, 24);
            txtModelo.TabIndex = 3;
            //
            // lblColor
            //
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblColor.ForeColor = Color.FromArgb(30, 41, 59);
            lblColor.Location = new Point(24, 209);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(44, 17);
            lblColor.TabIndex = 0;
            lblColor.Text = "Color:";
            //
            // txtColor
            //
            txtColor.Font = new Font("Segoe UI", 9.5F);
            txtColor.Location = new Point(130, 206);
            txtColor.MaxLength = 30;
            txtColor.Name = "txtColor";
            txtColor.PlaceholderText = "Opcional. Ej: Negro";
            txtColor.Size = new Size(260, 24);
            txtColor.TabIndex = 4;
            //
            // lblImei
            //
            lblImei.AutoSize = true;
            lblImei.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblImei.ForeColor = Color.FromArgb(30, 41, 59);
            lblImei.Location = new Point(24, 247);
            lblImei.Name = "lblImei";
            lblImei.Size = new Size(39, 17);
            lblImei.TabIndex = 0;
            lblImei.Text = "IMEI:";
            //
            // txtImei
            //
            txtImei.Font = new Font("Segoe UI", 9.5F);
            txtImei.Location = new Point(130, 244);
            txtImei.MaxLength = 15;
            txtImei.Name = "txtImei";
            txtImei.PlaceholderText = "Opcional. 15 números";
            txtImei.Size = new Size(260, 24);
            txtImei.TabIndex = 5;
            //
            // lblSerie
            //
            lblSerie.AutoSize = true;
            lblSerie.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblSerie.ForeColor = Color.FromArgb(30, 41, 59);
            lblSerie.Location = new Point(24, 285);
            lblSerie.Name = "lblSerie";
            lblSerie.Size = new Size(68, 17);
            lblSerie.TabIndex = 0;
            lblSerie.Text = "N° de serie:";
            //
            // txtSerie
            //
            txtSerie.Font = new Font("Segoe UI", 9.5F);
            txtSerie.Location = new Point(130, 282);
            txtSerie.MaxLength = 50;
            txtSerie.Name = "txtSerie";
            txtSerie.PlaceholderText = "Opcional";
            txtSerie.Size = new Size(260, 24);
            txtSerie.TabIndex = 6;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(16, 185, 129);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(270, 330);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 34);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(100, 116, 139);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(140, 330);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 34);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // FormNuevoEquipo
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            CancelButton = btnCancelar;
            ClientSize = new Size(420, 384);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtSerie);
            Controls.Add(lblSerie);
            Controls.Add(txtImei);
            Controls.Add(lblImei);
            Controls.Add(txtColor);
            Controls.Add(lblColor);
            Controls.Add(txtModelo);
            Controls.Add(lblModelo);
            Controls.Add(txtMarca);
            Controls.Add(lblMarca);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(lblCliente);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNuevoEquipo";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ApIBigStore - Nuevo Equipo";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblCliente;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblModelo;
        private TextBox txtModelo;
        private Label lblColor;
        private TextBox txtColor;
        private Label lblImei;
        private TextBox txtImei;
        private Label lblSerie;
        private TextBox txtSerie;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
