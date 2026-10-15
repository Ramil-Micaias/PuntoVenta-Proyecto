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

        // Valores que muestran los paneles del resumen diario.
        private Label lblValorVentas = null!;
        private Label lblDetalleVentas = null!;
        private Label lblValorTaller = null!;
        private Label lblValorStock = null!;
        private Label lblValorCompras = null!;
        private Label lblDetalleCompras = null!;

        public FormMenu(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
            CrearPaneles();

            // Cada vez que se vuelve al menú desde otro formulario se actualizan los totales.
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible)
                {
                    CargarResumen();
                }
            };
        }

        private void CrearPaneles()
        {
            lblValorVentas = CrearPanel("VENTAS DEL DÍA", Color.FromArgb(59, 130, 246), 0, 0, out lblDetalleVentas);
            lblValorTaller = CrearPanel("ÓRDENES DE TALLER", Color.FromArgb(16, 185, 129), 1, 0, out _);
            lblValorStock = CrearPanel("ALERTAS DE STOCK", Color.FromArgb(239, 68, 68), 0, 1, out _);
            lblValorCompras = CrearPanel("COMPRAS DEL DÍA", Color.FromArgb(79, 70, 229), 1, 1, out lblDetalleCompras);
        }

        // Arma un panel de color con título, valor principal y una línea de detalle.
        private Label CrearPanel(string titulo, Color color, int columna, int fila, out Label detalle)
        {
            Panel panel = new Panel
            {
                BackColor = color,
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                Padding = new Padding(20, 18, 20, 18)
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Dock = DockStyle.Top,
                Height = 28,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold)
            };

            Label lblValor = new Label
            {
                Text = "-",
                Dock = DockStyle.Top,
                Height = 50,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold)
            };

            detalle = new Label
            {
                Text = string.Empty,
                Dock = DockStyle.Top,
                Height = 24,
                ForeColor = Color.FromArgb(241, 245, 249),
                Font = new Font("Segoe UI", 9.5F)
            };

            // Se agregan al revés porque Dock = Top apila el último arriba.
            panel.Controls.Add(detalle);
            panel.Controls.Add(lblValor);
            panel.Controls.Add(lblTitulo);

            tlpPaneles.Controls.Add(panel, columna, fila);
            return lblValor;
        }

        private void CargarResumen()
        {
            try
            {
                ResumenDiario resumen = new GestorResumen().ObtenerResumenDiario();

                lblValorVentas.Text = "$" + resumen.Total_Ventas_Dia.ToString("N2");
                lblDetalleVentas.Text = resumen.Cantidad_Ventas_Dia + (resumen.Cantidad_Ventas_Dia == 1 ? " venta registrada" : " ventas registradas");
                lblValorTaller.Text = resumen.Ordenes_Taller_Activas + (resumen.Ordenes_Taller_Activas == 1 ? " Activa" : " Activas");
                lblValorStock.Text = resumen.Productos_Stock_Bajo + (resumen.Productos_Stock_Bajo == 1 ? " Producto Bajo" : " Productos Bajos");
                lblValorCompras.Text = "$" + resumen.Total_Compras_Dia.ToString("N2");
                lblDetalleCompras.Text = resumen.Cantidad_Compras_Dia + (resumen.Cantidad_Compras_Dia == 1 ? " compra registrada" : " compras registradas");
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