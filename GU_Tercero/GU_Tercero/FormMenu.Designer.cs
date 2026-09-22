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
            productoYStockToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            configuraciónDelSistemaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            lblBienvenido = new Label();
            lblNombreUsuario = new Label();
            picLogoMenu = new PictureBox();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoMenu).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.None;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestionDeUsuariosToolStripMenuItem, productoYStockToolStripMenuItem, configuraciónToolStripMenuItem, cerrarSesionToolStripMenuItem, proveedoresToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(11, 4, 0, 4);
            menuStrip1.Size = new Size(1243, 46);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gestionDeUsuariosToolStripMenuItem
            // 
            gestionDeUsuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem });
            gestionDeUsuariosToolStripMenuItem.Name = "gestionDeUsuariosToolStripMenuItem";
            gestionDeUsuariosToolStripMenuItem.Size = new Size(249, 36);
            gestionDeUsuariosToolStripMenuItem.Text = "Gestion de Usuarios";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(241, 44);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // productoYStockToolStripMenuItem
            // 
            productoYStockToolStripMenuItem.Name = "productoYStockToolStripMenuItem";
            productoYStockToolStripMenuItem.Size = new Size(213, 36);
            productoYStockToolStripMenuItem.Text = "Producto y Stock";
            productoYStockToolStripMenuItem.Click += productoYStockToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configuraciónDelSistemaToolStripMenuItem });
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(187, 36);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // configuraciónDelSistemaToolStripMenuItem
            // 
            configuraciónDelSistemaToolStripMenuItem.Name = "configuraciónDelSistemaToolStripMenuItem";
            configuraciónDelSistemaToolStripMenuItem.Size = new Size(431, 44);
            configuraciónDelSistemaToolStripMenuItem.Text = "Configuración del Sistema";
            configuraciónDelSistemaToolStripMenuItem.Click += configuraciónDelSistemaToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(177, 36);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // lblBienvenido
            // 
            lblBienvenido.Anchor = AnchorStyles.None;
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.FromArgb(15, 23, 42);
            lblBienvenido.Location = new Point(446, 341);
            lblBienvenido.Margin = new Padding(6, 0, 6, 0);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(318, 72);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenido,";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.None;
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Microsoft Sans Serif", 20F);
            lblNombreUsuario.ForeColor = Color.FromArgb(37, 99, 235);
            lblNombreUsuario.Location = new Point(734, 341);
            lblNombreUsuario.Margin = new Padding(6, 0, 6, 0);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(175, 63);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "admin";
            // 
            // picLogoMenu
            // 
            picLogoMenu.Anchor = AnchorStyles.None;
            picLogoMenu.BackColor = Color.Transparent;
            picLogoMenu.Location = new Point(550, 427);
            picLogoMenu.Margin = new Padding(6, 6, 6, 6);
            picLogoMenu.Name = "picLogoMenu";
            picLogoMenu.Size = new Size(371, 341);
            picLogoMenu.TabIndex = 3;
            picLogoMenu.TabStop = false;
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(164, 38);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            proveedoresToolStripMenuItem.Click += proveedoresToolStripMenuItem_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1473, 922);
            Controls.Add(picLogoMenu);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblBienvenido);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMenu";
            Load += FormMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoMenu).EndInit();
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
        private ToolStripMenuItem proveedoresToolStripMenuItem;
    }
}