using Datos.Entidades;
using Logica;
using System;
using System.ComponentModel;
using Vista;

namespace GU_Tercero
{
    public partial class FormMenu : Form
    {
        private Usuario usuarioLogueado;
        public bool EsCierreSesion { get; private set; } = false;

        // Textos que muestran los paneles del resumen diario.
        private Label lblValorVentas = new Label();
        private Label lblDetalleVentas = new Label();
        private Label lblValorTaller = new Label();
        private Label lblDetalleTaller = new Label();
        private Label lblValorStock = new Label();
        private Label lblDetalleStock = new Label();
        private Label lblValorCompras = new Label();
        private Label lblDetalleCompras = new Label();

        public FormMenu(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
            CrearPaneles();
            this.VisibleChanged += FormMenu_VisibleChanged;
        }

        // Cada vez que se vuelve al menú desde otro formulario se actualizan los totales.
        private void FormMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                CargarResumen();
            }
        }

        private void CrearPaneles()
        {
            CrearPanel("VENTAS DEL DÍA", Color.FromArgb(59, 130, 246), 0, 0, lblValorVentas, lblDetalleVentas);
            CrearPanel("ÓRDENES DE TALLER", Color.FromArgb(16, 185, 129), 1, 0, lblValorTaller, lblDetalleTaller);
            CrearPanel("ALERTAS DE STOCK", Color.FromArgb(239, 68, 68), 0, 1, lblValorStock, lblDetalleStock);
            CrearPanel("COMPRAS DEL DÍA", Color.FromArgb(79, 70, 229), 1, 1, lblValorCompras, lblDetalleCompras);
        }

        // Arma un panel de color con un título, el valor principal y una línea de detalle.
        private void CrearPanel(string titulo, Color color, int columna, int fila, Label lblValor, Label lblDetalle)
        {
            Panel panel = new Panel();
            panel.BackColor = color;
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(8);
            panel.Padding = new Padding(20, 18, 20, 18);

            Label lblTituloPanel = new Label();
            lblTituloPanel.Text = titulo;
            lblTituloPanel.Dock = DockStyle.Top;
            lblTituloPanel.AutoSize = true;
            lblTituloPanel.ForeColor = Color.White;
            lblTituloPanel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            lblValor.Text = "-";
            lblValor.Dock = DockStyle.Top;
            lblValor.AutoSize = true;
            lblValor.ForeColor = Color.White;
            lblValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

            lblDetalle.Text = "";
            lblDetalle.Dock = DockStyle.Top;
            lblDetalle.AutoSize = true;
            lblDetalle.ForeColor = Color.FromArgb(241, 245, 249);
            lblDetalle.Font = new Font("Segoe UI", 9.5F);

            // Se agregan al revés porque con Dock = Top el último queda arriba.
            panel.Controls.Add(lblDetalle);
            panel.Controls.Add(lblValor);
            panel.Controls.Add(lblTituloPanel);

            tlpPaneles.Controls.Add(panel, columna, fila);
        }

        private void CargarResumen()
        {
            try
            {
                GestorResumen gestorResumen = new GestorResumen();
                ResumenDiario resumen = gestorResumen.ObtenerResumenDiario();

                lblValorVentas.Text = "$" + resumen.Total_Ventas_Dia.ToString("N2");
                lblDetalleVentas.Text = "Ventas registradas: " + resumen.Cantidad_Ventas_Dia;

                lblValorTaller.Text = resumen.Ordenes_Taller_Activas + " Activas";
                lblDetalleTaller.Text = "Órdenes sin entregar";

                lblValorStock.Text = resumen.Productos_Stock_Bajo + " Productos Bajos";
                lblDetalleStock.Text = "Stock en el mínimo o por debajo";

                lblValorCompras.Text = "$" + resumen.Total_Compras_Dia.ToString("N2");
                lblDetalleCompras.Text = "Compras registradas: " + resumen.Cantidad_Compras_Dia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el resumen diario: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            if (usuarioLogueado != null)
            {
                lblNombreUsuario.Text = usuarioLogueado.Nombre_Usuario;
            }
            else
            {
                lblNombreUsuario.Text = "admin";
            }
            lblNombreUsuario.Visible = true;
            lblNombreUsuario.Left = lblBienvenido.Right;
            CargarLogo();
            AplicarPermisosPorRol();
        }

        private void AplicarPermisosPorRol()
        {
            string rol = usuarioLogueado?.Nombre_Rol ?? "Administrador";

            if (rol == "Vendedor")
            {
                // El vendedor solo puede ver Ventas (POS), Mi Perfil y Cerrar Sesión
                gestionDeUsuariosToolStripMenuItem.Visible = false;
                productoYStockToolStripMenuItem.Visible = false;
                proveedoresToolStripMenuItem.Visible = false;
                comprasToolStripMenuItem.Visible = false;
                tallerToolStripMenuItem.Visible = false;
                configuraciónDelSistemaToolStripMenuItem.Visible = false;
                ventasToolStripMenuItem.Visible = true;
                configuraciónToolStripMenuItem.Visible = true;
                miPerfilToolStripMenuItem.Visible = true;
                cerrarSesionToolStripMenuItem.Visible = true;
            }
            else if (rol == "Tecnico")
            {
                // El técnico solo puede ver Taller, Mi Perfil y Cerrar Sesión
                gestionDeUsuariosToolStripMenuItem.Visible = false;
                productoYStockToolStripMenuItem.Visible = false;
                proveedoresToolStripMenuItem.Visible = false;
                comprasToolStripMenuItem.Visible = false;
                ventasToolStripMenuItem.Visible = false;
                configuraciónDelSistemaToolStripMenuItem.Visible = false;
                tallerToolStripMenuItem.Visible = true;
                configuraciónToolStripMenuItem.Visible = true;
                miPerfilToolStripMenuItem.Visible = true;
                cerrarSesionToolStripMenuItem.Visible = true;
            }
            else
            {
                // Administrador tiene acceso completo
                gestionDeUsuariosToolStripMenuItem.Visible = true;
                productoYStockToolStripMenuItem.Visible = true;
                proveedoresToolStripMenuItem.Visible = true;
                ventasToolStripMenuItem.Visible = true;
                comprasToolStripMenuItem.Visible = true;
                tallerToolStripMenuItem.Visible = true;
                configuraciónToolStripMenuItem.Visible = true;
                configuraciónDelSistemaToolStripMenuItem.Visible = true;
                miPerfilToolStripMenuItem.Visible = true;
                cerrarSesionToolStripMenuItem.Visible = true;
            }

            // Los accesos rápidos siguen los mismos permisos que el menú.
            btnAccesoVenta.Visible = ventasToolStripMenuItem.Available;
            btnAccesoTaller.Visible = tallerToolStripMenuItem.Available;
            btnAccesoStock.Visible = productoYStockToolStripMenuItem.Available;
            btnAccesoCompra.Visible = comprasToolStripMenuItem.Available;
        }

        private void CargarLogo()
        {
            try
            {
                string[] rutasPosibles = new string[]
                {
                    System.IO.Path.Combine(Application.StartupPath, "loguito trtansparente.png"),
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\loguito trtansparente.png"),
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\loguito trtansparente.png"),
                    @"C:\Users\LanzceTest\Desktop\github isft\loguito trtansparente.png"
                };

                foreach (string ruta in rutasPosibles)
                {
                    if (System.IO.File.Exists(ruta))
                    {
                        picLogoMenu.Image = System.Drawing.Image.FromFile(ruta);
                        picLogoMenu.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    }
                }
            }
            catch { }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (FormAdmin formAdmin = new FormAdmin())
            {
                formAdmin.ShowDialog();
            }

            this.Show();
        }

        private void configuraciónDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (FormConfiguracion configuracion = new FormConfiguracion())
            {
                configuracion.ShowDialog();
            }

            this.Show();
        }

        private void productoYStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el Menú Principal

            using (FormProductos formProducto = new FormProductos())
            {
                formProducto.ShowDialog();
            }

            this.Show(); // Reaparece el Menú al cerrar Productos
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EsCierreSesion = true;
            this.Close();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si la ventana se cierra por la cruz (X) y NO por cerrar sesión, salimos del proceso completo
            if (!EsCierreSesion)
            {
                Application.Exit();
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 

            using (FormProveedores formProveedores = new FormProveedores())
            {
                formProveedores.ShowDialog();
            }

            this.Show(); 
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (FormVentas formVentas = new FormVentas(usuarioLogueado))
            {
                formVentas.ShowDialog();
            }

            this.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (FormCompras formCompras = new FormCompras(usuarioLogueado))
            {
                formCompras.ShowDialog();
            }

            this.Show();
        }

        private void miPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (FormUsuario formUsuario = new FormUsuario(usuarioLogueado))
            {
                formUsuario.ShowDialog();
            }

            this.Show();
        }

        private void tallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (FormTaller formTaller = new FormTaller())
            {
                formTaller.ShowDialog();
            }

            this.Show();
        }
    }
}