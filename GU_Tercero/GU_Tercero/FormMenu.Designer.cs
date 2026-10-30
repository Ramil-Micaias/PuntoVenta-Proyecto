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
            productoYStockToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            consultaStockToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            configuraciónDelSistemaToolStripMenuItem = new ToolStripMenuItem();
            miPerfilToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            comprasToolStripMenuItem = new ToolStripMenuItem();
            cajaToolStripMenuItem = new ToolStripMenuItem();
            tallerToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            lblBienvenido = new Label();
            lblNombreUsuario = new Label();
            picLogoMenu = new PictureBox();
            lblResumen = new Label();
            tlpPaneles = new TableLayoutPanel();
            grpAccesos = new GroupBox();
            flpAccesos = new FlowLayoutPanel();
            btnAccesoVenta = new Button();
            btnAccesoTaller = new Button();
            btnAccesoStock = new Button();
            btnAccesoCompra = new Button();
            grpAccesos.SuspendLayout();
            flpAccesos.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoMenu).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestionDeUsuariosToolStripMenuItem, productoYStockToolStripMenuItem, proveedoresToolStripMenuItem, ventasToolStripMenuItem, comprasToolStripMenuItem, cajaToolStripMenuItem, tallerToolStripMenuItem, clientesToolStripMenuItem, configuraciónToolStripMenuItem, cerrarSesionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1000, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gestionDeUsuariosToolStripMenuItem
            // 
            gestionDeUsuariosToolStripMenuItem.Name = "gestionDeUsuariosToolStripMenuItem";
            gestionDeUsuariosToolStripMenuItem.Size = new Size(125, 20);
            gestionDeUsuariosToolStripMenuItem.Text = "Gestion de Usuarios";
            gestionDeUsuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // 
            // 
            // productoYStockToolStripMenuItem
            // 
            productoYStockToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productosToolStripMenuItem, consultaStockToolStripMenuItem });
            productoYStockToolStripMenuItem.Name = "productoYStockToolStripMenuItem";
            productoYStockToolStripMenuItem.Size = new Size(108, 20);
            productoYStockToolStripMenuItem.Text = "Producto y Stock";
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(200, 22);
            productosToolStripMenuItem.Text = "Productos y Categorías";
            productosToolStripMenuItem.Click += productoYStockToolStripMenuItem_Click;
            // 
            // consultaStockToolStripMenuItem
            // 
            consultaStockToolStripMenuItem.Name = "consultaStockToolStripMenuItem";
            consultaStockToolStripMenuItem.Size = new Size(200, 22);
            consultaStockToolStripMenuItem.Text = "Consulta de Stock";
            consultaStockToolStripMenuItem.Click += consultaStockToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miPerfilToolStripMenuItem, configuraciónDelSistemaToolStripMenuItem });
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(96, 20);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // miPerfilToolStripMenuItem
            // 
            miPerfilToolStripMenuItem.Name = "miPerfilToolStripMenuItem";
            miPerfilToolStripMenuItem.Size = new Size(215, 22);
            miPerfilToolStripMenuItem.Text = "Mi Perfil";
            miPerfilToolStripMenuItem.Click += miPerfilToolStripMenuItem_Click;
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
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(86, 20);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            proveedoresToolStripMenuItem.Click += proveedoresToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(112, 20);
            ventasToolStripMenuItem.Text = "Ventas (POS)";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // comprasToolStripMenuItem
            // 
            comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            comprasToolStripMenuItem.Size = new Size(78, 20);
            comprasToolStripMenuItem.Text = "Compras";
            comprasToolStripMenuItem.Click += comprasToolStripMenuItem_Click;
            // 
            // cajaToolStripMenuItem
            // 
            cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            cajaToolStripMenuItem.Size = new Size(84, 20);
            cajaToolStripMenuItem.Text = "Caja Diaria";
            cajaToolStripMenuItem.Click += cajaToolStripMenuItem_Click;
            // 
            // tallerToolStripMenuItem
            // 
            tallerToolStripMenuItem.Name = "tallerToolStripMenuItem";
            tallerToolStripMenuItem.Size = new Size(58, 20);
            tallerToolStripMenuItem.Text = "Taller";
            tallerToolStripMenuItem.Click += tallerToolStripMenuItem_Click;
            //
            // clientesToolStripMenuItem
            //
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(70, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.FromArgb(15, 23, 42);
            lblBienvenido.Location = new Point(24, 40);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(110, 25);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenido,";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(37, 99, 235);
            lblNombreUsuario.Location = new Point(132, 40);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(64, 25);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "admin";
            // 
            // picLogoMenu
            // 
            picLogoMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picLogoMenu.BackColor = Color.Transparent;
            picLogoMenu.Location = new Point(648, 410);
            picLogoMenu.Name = "picLogoMenu";
            picLogoMenu.Size = new Size(328, 170);
            picLogoMenu.TabIndex = 3;
            picLogoMenu.TabStop = false;
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblResumen.ForeColor = Color.FromArgb(15, 23, 42);
            lblResumen.Location = new Point(24, 84);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(296, 30);
            lblResumen.TabIndex = 4;
            lblResumen.Text = "Resumen de Actividad Diaria";
            // 
            // tlpPaneles
            // 
            tlpPaneles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpPaneles.ColumnCount = 2;
            tlpPaneles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpPaneles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpPaneles.Location = new Point(24, 128);
            tlpPaneles.Name = "tlpPaneles";
            tlpPaneles.RowCount = 2;
            tlpPaneles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPaneles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPaneles.Size = new Size(600, 440);
            tlpPaneles.TabIndex = 5;
            // 
            // grpAccesos
            // 
            grpAccesos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpAccesos.Controls.Add(flpAccesos);
            grpAccesos.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            grpAccesos.ForeColor = Color.FromArgb(15, 23, 42);
            grpAccesos.Location = new Point(648, 128);
            grpAccesos.Name = "grpAccesos";
            grpAccesos.Size = new Size(328, 260);
            grpAccesos.TabIndex = 6;
            grpAccesos.TabStop = false;
            grpAccesos.Text = "Accesos Rápidos";
            // 
            // flpAccesos
            // 
            flpAccesos.Controls.Add(btnAccesoVenta);
            flpAccesos.Controls.Add(btnAccesoTaller);
            flpAccesos.Controls.Add(btnAccesoStock);
            flpAccesos.Controls.Add(btnAccesoCompra);
            flpAccesos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpAccesos.Location = new Point(6, 28);
            flpAccesos.Size = new Size(316, 226);
            flpAccesos.FlowDirection = FlowDirection.TopDown;
            flpAccesos.Name = "flpAccesos";
            flpAccesos.Padding = new Padding(8);
            flpAccesos.TabIndex = 0;
            flpAccesos.WrapContents = false;
            // 
            // btnAccesoVenta
            // 
            btnAccesoVenta.BackColor = Color.White;
            btnAccesoVenta.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAccesoVenta.FlatStyle = FlatStyle.Flat;
            btnAccesoVenta.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnAccesoVenta.ForeColor = Color.FromArgb(15, 23, 42);
            btnAccesoVenta.Margin = new Padding(0, 0, 0, 10);
            btnAccesoVenta.Name = "btnAccesoVenta";
            btnAccesoVenta.Size = new Size(300, 44);
            btnAccesoVenta.TabIndex = 0;
            btnAccesoVenta.Text = "Registrar Venta";
            btnAccesoVenta.UseVisualStyleBackColor = false;
            btnAccesoVenta.Click += ventasToolStripMenuItem_Click;
            // 
            // btnAccesoTaller
            // 
            btnAccesoTaller.BackColor = Color.White;
            btnAccesoTaller.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAccesoTaller.FlatStyle = FlatStyle.Flat;
            btnAccesoTaller.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnAccesoTaller.ForeColor = Color.FromArgb(15, 23, 42);
            btnAccesoTaller.Margin = new Padding(0, 0, 0, 10);
            btnAccesoTaller.Name = "btnAccesoTaller";
            btnAccesoTaller.Size = new Size(300, 44);
            btnAccesoTaller.TabIndex = 1;
            btnAccesoTaller.Text = "Ingresar Equipo a Taller";
            btnAccesoTaller.UseVisualStyleBackColor = false;
            btnAccesoTaller.Click += tallerToolStripMenuItem_Click;
            // 
            // btnAccesoStock
            // 
            btnAccesoStock.BackColor = Color.White;
            btnAccesoStock.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAccesoStock.FlatStyle = FlatStyle.Flat;
            btnAccesoStock.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnAccesoStock.ForeColor = Color.FromArgb(15, 23, 42);
            btnAccesoStock.Margin = new Padding(0, 0, 0, 10);
            btnAccesoStock.Name = "btnAccesoStock";
            btnAccesoStock.Size = new Size(300, 44);
            btnAccesoStock.TabIndex = 2;
            btnAccesoStock.Text = "Verificar Alertas de Stock";
            btnAccesoStock.UseVisualStyleBackColor = false;
            btnAccesoStock.Click += btnAccesoStock_Click;
            // 
            // btnAccesoCompra
            // 
            btnAccesoCompra.BackColor = Color.White;
            btnAccesoCompra.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAccesoCompra.FlatStyle = FlatStyle.Flat;
            btnAccesoCompra.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnAccesoCompra.ForeColor = Color.FromArgb(15, 23, 42);
            btnAccesoCompra.Margin = new Padding(0, 0, 0, 10);
            btnAccesoCompra.Name = "btnAccesoCompra";
            btnAccesoCompra.Size = new Size(300, 44);
            btnAccesoCompra.TabIndex = 3;
            btnAccesoCompra.Text = "Registrar Compra";
            btnAccesoCompra.UseVisualStyleBackColor = false;
            btnAccesoCompra.Click += comprasToolStripMenuItem_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1000, 600);
            Controls.Add(grpAccesos);
            Controls.Add(tlpPaneles);
            Controls.Add(lblResumen);
            Controls.Add(picLogoMenu);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblBienvenido);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1016, 639);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApIBigStore - Sistema de Gestión Integrado";
            Load += FormMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoMenu).EndInit();
            flpAccesos.ResumeLayout(false);
            grpAccesos.ResumeLayout(false);
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
        private ToolStripMenuItem configuraciónDelSistemaToolStripMenuItem;
        private ToolStripMenuItem productoYStockToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem consultaStockToolStripMenuItem;
        private PictureBox picLogoMenu;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem comprasToolStripMenuItem;
        private ToolStripMenuItem cajaToolStripMenuItem;
        private ToolStripMenuItem tallerToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem miPerfilToolStripMenuItem;
        private Label lblResumen;
        private TableLayoutPanel tlpPaneles;
        private GroupBox grpAccesos;
        private FlowLayoutPanel flpAccesos;
        private Button btnAccesoVenta;
        private Button btnAccesoTaller;
        private Button btnAccesoStock;
        private Button btnAccesoCompra;
    }
}