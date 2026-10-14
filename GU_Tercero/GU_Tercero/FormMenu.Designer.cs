namespace GU_Tercero
{
    partial class FormMenu
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
            this.pnlContenido = new Panel();
            this.pnlBarraSecciones = new Panel();
            this.pnlLineaSecciones = new Panel();
            this.flpSecciones = new Panel();
            this.pnlCabecera = new Panel();
            this.lblTituloPantalla = new Label();
            this.pnlDerecha = new Panel();
            this.pnlAcciones = new Panel();
            this.btnSalir = new Button();
            this.btnLimpiar = new Button();
            this.pnlSistema = new Panel();
            this.txtSistema = new TextBox();
            this.lblSistema = new Label();
            this.pnlMarca = new Panel();
            this.pnlMarcaTexto = new Panel();
            this.lblSubtitulo = new Label();
            this.picLogo = new PictureBox();
            this.pnlContenido.SuspendLayout();
            this.pnlBarraSecciones.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlSistema.SuspendLayout();
            this.pnlMarca.SuspendLayout();
            this.pnlMarcaTexto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picLogo).BeginInit();
            this.SuspendLayout();
            //
            // pnlContenido
            //
            this.pnlContenido.BackColor = Tema.FondoPantalla;
            this.pnlContenido.Dock = DockStyle.Fill;
            this.pnlContenido.Location = new Point(0, 118);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new Padding(8);
            this.pnlContenido.Size = new Size(1360, 702);
            this.pnlContenido.TabIndex = 2;
            //
            // pnlBarraSecciones
            //
            this.pnlBarraSecciones.BackColor = Tema.NavFondo;
            this.pnlBarraSecciones.Controls.Add(this.flpSecciones);
            this.pnlBarraSecciones.Controls.Add(this.pnlLineaSecciones);
            this.pnlBarraSecciones.Dock = DockStyle.Top;
            this.pnlBarraSecciones.Location = new Point(0, 74);
            this.pnlBarraSecciones.Name = "pnlBarraSecciones";
            this.pnlBarraSecciones.Size = new Size(1360, 44);
            this.pnlBarraSecciones.TabIndex = 1;
            //
            // pnlLineaSecciones
            //
            this.pnlLineaSecciones.BackColor = Tema.NavBorde;
            this.pnlLineaSecciones.Dock = DockStyle.Bottom;
            this.pnlLineaSecciones.Location = new Point(0, 43);
            this.pnlLineaSecciones.Name = "pnlLineaSecciones";
            this.pnlLineaSecciones.Size = new Size(1360, 1);
            this.pnlLineaSecciones.TabIndex = 1;
            //
            // flpSecciones
            //
            // Los botones se ubican a mano en ConstruirBarraSecciones: con FlowLayoutPanel
            // quedaban todos apilados en el origen cuando la ventana arrancaba maximizada.
            this.flpSecciones.AutoScroll = true;
            this.flpSecciones.BackColor = Tema.NavFondo;
            this.flpSecciones.Dock = DockStyle.Fill;
            this.flpSecciones.Location = new Point(0, 0);
            this.flpSecciones.Name = "flpSecciones";
            this.flpSecciones.Padding = new Padding(12, 2, 12, 0);
            this.flpSecciones.Size = new Size(1360, 43);
            this.flpSecciones.TabIndex = 0;
            //
            // pnlCabecera
            //
            this.pnlCabecera.BackColor = Tema.CabeceraFondo;
            this.pnlCabecera.Controls.Add(this.lblTituloPantalla);
            this.pnlCabecera.Controls.Add(this.pnlDerecha);
            this.pnlCabecera.Controls.Add(this.pnlMarca);
            this.pnlCabecera.Dock = DockStyle.Top;
            this.pnlCabecera.Location = new Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new Size(1360, 74);
            this.pnlCabecera.TabIndex = 0;
            //
            // lblTituloPantalla
            //
            this.lblTituloPantalla.Dock = DockStyle.Fill;
            this.lblTituloPantalla.Font = Tema.FuenteTituloPantalla;
            this.lblTituloPantalla.ForeColor = Tema.CabeceraTitulo;
            this.lblTituloPantalla.Location = new Point(348, 0);
            this.lblTituloPantalla.Name = "lblTituloPantalla";
            this.lblTituloPantalla.Size = new Size(684, 74);
            this.lblTituloPantalla.TabIndex = 2;
            this.lblTituloPantalla.Text = "Inicio";
            this.lblTituloPantalla.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlDerecha
            //
            this.pnlDerecha.BackColor = Tema.CabeceraFondo;
            this.pnlDerecha.Controls.Add(this.pnlAcciones);
            this.pnlDerecha.Controls.Add(this.pnlSistema);
            this.pnlDerecha.Dock = DockStyle.Right;
            this.pnlDerecha.Location = new Point(1032, 0);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Padding = new Padding(0, 8, 18, 8);
            this.pnlDerecha.Size = new Size(328, 74);
            this.pnlDerecha.TabIndex = 1;
            //
            // pnlAcciones
            //
            this.pnlAcciones.Controls.Add(this.btnSalir);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Dock = DockStyle.Fill;
            this.pnlAcciones.Location = new Point(0, 30);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new Size(310, 36);
            this.pnlAcciones.TabIndex = 1;
            //
            // btnSalir
            //
            this.btnSalir.BackColor = Tema.Acento;
            this.btnSalir.Cursor = Cursors.Hand;
            this.btnSalir.Dock = DockStyle.Left;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = Tema.AcentoHover;
            this.btnSalir.FlatAppearance.MouseOverBackColor = Tema.AcentoHover;
            this.btnSalir.Font = Tema.FuenteNav;
            this.btnSalir.ForeColor = Color.White;
            this.btnSalir.FlatStyle = FlatStyle.Flat;
            this.btnSalir.Location = new Point(108, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(100, 28);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = Tema.BotonNeutro;
            this.btnLimpiar.Cursor = Cursors.Hand;
            this.btnLimpiar.Dock = DockStyle.Left;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = Tema.BotonNeutroHover;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = Tema.BotonNeutroHover;
            this.btnLimpiar.Font = Tema.FuenteNav;
            this.btnLimpiar.ForeColor = Color.White;
            this.btnLimpiar.FlatStyle = FlatStyle.Flat;
            this.btnLimpiar.Location = new Point(0, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 28);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // pnlSistema
            //
            this.pnlSistema.Controls.Add(this.txtSistema);
            this.pnlSistema.Controls.Add(this.lblSistema);
            this.pnlSistema.Dock = DockStyle.Top;
            this.pnlSistema.Location = new Point(0, 0);
            this.pnlSistema.Name = "pnlSistema";
            this.pnlSistema.Size = new Size(310, 30);
            this.pnlSistema.TabIndex = 0;
            //
            // txtSistema
            //
            this.txtSistema.Dock = DockStyle.Fill;
            this.txtSistema.Font = Tema.FuenteCampo;
            this.txtSistema.Location = new Point(68, 3);
            this.txtSistema.Name = "txtSistema";
            this.txtSistema.ReadOnly = true;
            this.txtSistema.Size = new Size(242, 25);
            this.txtSistema.TabIndex = 1;
            this.txtSistema.TabStop = false;
            this.txtSistema.Text = "AplBigstore";
            this.txtSistema.TextAlign = HorizontalAlignment.Left;
            //
            // lblSistema
            //
            this.lblSistema.Dock = DockStyle.Left;
            this.lblSistema.Font = Tema.FuenteEtiqueta;
            this.lblSistema.ForeColor = Tema.CabeceraSubtitulo;
            this.lblSistema.Location = new Point(0, 0);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new Size(62, 30);
            this.lblSistema.TabIndex = 0;
            this.lblSistema.Text = "Sistema";
            this.lblSistema.TextAlign = ContentAlignment.MiddleRight;
            //
            // pnlMarca
            //
            this.pnlMarca.BackColor = Tema.CabeceraFondo;
            this.pnlMarca.Controls.Add(this.pnlMarcaTexto);
            this.pnlMarca.Controls.Add(this.picLogo);
            this.pnlMarca.Dock = DockStyle.Left;
            this.pnlMarca.Location = new Point(0, 0);
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Padding = new Padding(24, 0, 0, 0);
            this.pnlMarca.Size = new Size(340, 74);
            this.pnlMarca.TabIndex = 0;
            //
            // pnlMarcaTexto
            //
            this.pnlMarcaTexto.Controls.Add(this.lblSubtitulo);
            this.pnlMarcaTexto.Dock = DockStyle.Fill;
            this.pnlMarcaTexto.Location = new Point(174, 0);
            this.pnlMarcaTexto.Name = "pnlMarcaTexto";
            this.pnlMarcaTexto.Padding = new Padding(14, 0, 0, 0);
            this.pnlMarcaTexto.Size = new Size(166, 74);
            this.pnlMarcaTexto.TabIndex = 1;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.Dock = DockStyle.Fill;
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.CabeceraSubtitulo;
            this.lblSubtitulo.Location = new Point(14, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new Size(152, 74);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "Gestión de ventas, stock y taller";
            this.lblSubtitulo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // picLogo
            //
            // El logo ya trae el nombre adentro, así que no se repite el texto al lado.
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Dock = DockStyle.Left;
            this.picLogo.Location = new Point(24, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new Size(150, 74);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            //
            // FormMenu
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Tema.FondoPantalla;
            this.ClientSize = new Size(1360, 820);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlBarraSecciones);
            this.Controls.Add(this.pnlCabecera);
            this.MinimumSize = new Size(1100, 720);
            this.Name = "FormMenu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AplBigstore";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlBarraSecciones.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.pnlSistema.ResumeLayout(false);
            this.pnlMarca.ResumeLayout(false);
            this.pnlMarcaTexto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.picLogo).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlContenido;
        private Panel pnlBarraSecciones;
        private Panel pnlLineaSecciones;
        private Panel flpSecciones;
        private Panel pnlCabecera;
        private Label lblTituloPantalla;
        private Panel pnlDerecha;
        private Panel pnlAcciones;
        private Button btnSalir;
        private Button btnLimpiar;
        private Panel pnlSistema;
        private TextBox txtSistema;
        private Label lblSistema;
        private Panel pnlMarca;
        private Panel pnlMarcaTexto;
        private Label lblSubtitulo;
        private PictureBox picLogo;
    }
}