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
            menuStrip1 = new MenuStrip();
            gestionDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            configuraciónDelSistemaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            productoYStockToolStripMenuItem = new ToolStripMenuItem();
            lblBienvenido = new Label();
            lblNombreUsuario = new Label();
            picLogoMenu = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogoMenu).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.None;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestionDeUsuariosToolStripMenuItem, productoYStockToolStripMenuItem, configuraciónToolStripMenuItem, cerrarSesionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(549, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gestionDeUsuariosToolStripMenuItem
            // 
            gestionDeUsuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem });
            gestionDeUsuariosToolStripMenuItem.Name = "gestionDeUsuariosToolStripMenuItem";
            gestionDeUsuariosToolStripMenuItem.Size = new Size(125, 20);
            gestionDeUsuariosToolStripMenuItem.Text = "Gestion de Usuarios";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(121, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configuraciónDelSistemaToolStripMenuItem });
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(96, 20);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // configuraciónDelSistemaToolStripMenuItem
            // 
            configuraciónDelSistemaToolStripMenuItem.Name = "configuraciónDelSistemaToolStripMenuItem";
            configuraciónDelSistemaToolStripMenuItem.Size = new Size(215, 22);
            configuraciónDelSistemaToolStripMenuItem.Text = "Configuración del Sistema";
            configuraciónDelSistemaToolStripMenuItem.Click += configuraciónDelSistemaToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(92, 20);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // productoYStockToolStripMenuItem
            // 
            productoYStockToolStripMenuItem.Name = "productoYStockToolStripMenuItem";
            productoYStockToolStripMenuItem.Size = new Size(108, 20);
            productoYStockToolStripMenuItem.Text = "Producto y Stock";
            productoYStockToolStripMenuItem.Click += productoYStockToolStripMenuItem_Click;
            // 
            // lblBienvenido
            // 
            lblBienvenido.Anchor = AnchorStyles.None;
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.FromArgb(15, 23, 42);
            lblBienvenido.Location = new Point(233, 160);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(160, 37);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenido,";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.None;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI Bold", 20F);
            lblNombreUsuario.ForeColor = Color.FromArgb(37, 99, 235);
            lblNombreUsuario.Location = new Point(393, 160);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(160, 37);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "admin";
            // 
            // picLogoMenu
            // 
            picLogoMenu.Anchor = AnchorStyles.None;
            picLogoMenu.BackColor = Color.Transparent;
            picLogoMenu.Location = new Point(296, 200);
            picLogoMenu.Name = "picLogoMenu";
            picLogoMenu.Size = new Size(200, 160);
            picLogoMenu.TabIndex = 3;
            picLogoMenu.TabStop = false;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(793, 432);
            Controls.Add(picLogoMenu);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblBienvenido);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMenu";
            Load += FormMenu_Load;
            ((System.ComponentModel.ISupportInitialize)picLogoMenu).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gestionDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem configuraciónToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private Label lblBienvenido;
        private Label lblNombreUsuario;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem configuraciónDelSistemaToolStripMenuItem;
        private ToolStripMenuItem productoYStockToolStripMenuItem;
        private PictureBox picLogoMenu;
    }
}