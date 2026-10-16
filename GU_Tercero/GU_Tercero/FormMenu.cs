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

        // Lo marca el acceso rápido "Verificar Alertas de Stock".
        private bool abrirAlertasStock = false;

        // Textos que muestran los paneles del resumen diario.
        private Label lblValorVentas = new Label();
        private Label lblDetalleVentas = new Label();
        private Label lblValorTaller = new Label();
        private Label lblDetalleTaller = new Label();
        private Label lblValorStock = new Label();
        private Label lblDetalleStock = new Label();
        private Label lblValorCompras = new Label();
        private Label lblDetalleCompras = new Label();
        private Label lblValorProgreso = new Label();
        private Label lblDetalleProgreso = new Label();
        private Label lblValorReparaciones = new Label();
        private Label lblDetalleReparaciones = new Label();
        private Label lblValorComision = new Label();
        private Label lblDetalleComision = new Label();

        public FormMenu(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
            CrearPaneles();
            this.VisibleChanged += FormMenu_VisibleChanged;
        }

        private string ObtenerRol()
        {
            return usuarioLogueado?.Nombre_Rol ?? "Administrador";
        }

        // Cada vez que se vuelve al menú desde otro formulario se actualizan los totales.
        private void FormMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                CargarResumen();
            }
        }

        // Cada rol ve solo los paneles que tienen que ver con su trabajo.
        private void CrearPaneles()
        {
            string rol = ObtenerRol();

            if (rol == "Tecnico")
            {
                CrearPanel("ÓRDENES DE TALLER", Color.FromArgb(16, 185, 129), 0, 0, lblValorTaller, lblDetalleTaller);
                CrearPanel("PROGRESO DE TRABAJO", Color.FromArgb(59, 130, 246), 1, 0, lblValorProgreso, lblDetalleProgreso);
                CrearPanel("TOTAL DE REPARACIONES", Color.FromArgb(79, 70, 229), 0, 1, lblValorReparaciones, lblDetalleReparaciones);
                CrearPanel("MI COMISIÓN (10%)", Color.FromArgb(217, 119, 6), 1, 1, lblValorComision, lblDetalleComision);
            }
            else if (rol == "Vendedor")
            {
                CrearPanel("VENTAS DEL DÍA", Color.FromArgb(59, 130, 246), 0, 0, lblValorVentas, lblDetalleVentas);
                CrearPanel("ALERTAS DE STOCK", Color.FromArgb(239, 68, 68), 1, 0, lblValorStock, lblDetalleStock);

                // Con dos paneles alcanza una sola fila.
                tlpPaneles.RowStyles[1].Height = 0;
            }
            else
            {
                CrearPanel("VENTAS DEL DÍA", Color.FromArgb(59, 130, 246), 0, 0, lblValorVentas, lblDetalleVentas);
                CrearPanel("ÓRDENES DE TALLER", Color.FromArgb(16, 185, 129), 1, 0, lblValorTaller, lblDetalleTaller);
                CrearPanel("ALERTAS DE STOCK", Color.FromArgb(239, 68, 68), 0, 1, lblValorStock, lblDetalleStock);
                CrearPanel("COMPRAS DEL DÍA", Color.FromArgb(79, 70, 229), 1, 1, lblValorCompras, lblDetalleCompras);
            }
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

                if (ObtenerRol() == "Tecnico")
                {
                    CargarResumenTecnico(gestorResumen);
                }
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

        private void CargarResumenTecnico(GestorResumen gestorResumen)
        {
            ResumenTecnico resumen = gestorResumen.ObtenerResumenTecnico(usuarioLogueado.Id_Usuario);

            int porcentaje = 0;
            if (resumen.Ordenes_Asignadas > 0)
            {
                porcentaje = resumen.Ordenes_Terminadas * 100 / resumen.Ordenes_Asignadas;
            }

            lblValorProgreso.Text = porcentaje + "% Terminado";
            lblDetalleProgreso.Text = resumen.Ordenes_Terminadas + " de " + resumen.Ordenes_Asignadas + " órdenes asignadas";

            lblValorReparaciones.Text = "$" + resumen.Total_Reparaciones.ToString("N2");
            lblDetalleReparaciones.Text = "Reparaciones terminadas: " + resumen.Ordenes_Terminadas;

            decimal comision = gestorResumen.CalcularComisionTecnico(resumen.Total_Reparaciones);
            lblValorComision.Text = "$" + comision.ToString("N2");
            lblDetalleComision.Text = "10% del total de tus reparaciones";
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
            if (ObtenerRol() == "Tecnico")
            {
                lblResumen.Text = "Resumen de Mi Trabajo en el Taller";
            }
            CargarLogo();
            AplicarPermisosPorRol();
        }

        private void AplicarPermisosPorRol()
        {
            // Los permisos de cada rol están en Navegacion, así el menú principal
            // y el menú de cada pantalla muestran lo mismo.
            string rol = ObtenerRol();

            gestionDeUsuariosToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.USUARIOS);
            productosToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.PRODUCTOS);
            consultaStockToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.CONSULTA_STOCK);
            proveedoresToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.PROVEEDORES);
            ventasToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.VENTAS);
            comprasToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.COMPRAS);
            tallerToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.TALLER);
            miPerfilToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.MI_PERFIL);
            configuraciónDelSistemaToolStripMenuItem.Visible = Navegacion.PuedeVer(rol, Navegacion.CONFIGURACION);

            // Los accesos rápidos siguen los mismos permisos que el menú.
            btnAccesoVenta.Visible = Navegacion.PuedeVer(rol, Navegacion.VENTAS);
            btnAccesoTaller.Visible = Navegacion.PuedeVer(rol, Navegacion.TALLER);
            btnAccesoStock.Visible = Navegacion.PuedeVer(rol, Navegacion.CONSULTA_STOCK);
            btnAccesoCompra.Visible = Navegacion.PuedeVer(rol, Navegacion.COMPRAS);
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

        // Abre la pantalla elegida. Si desde su menú el usuario elige otra pantalla,
        // se cierra la actual y se abre la nueva sin pasar por el menú principal.
        private void AbrirPantalla(string pantalla)
        {
            this.Hide();
            string rol = ObtenerRol();

            while (pantalla != Navegacion.MENU_PRINCIPAL)
            {
                if (pantalla == Navegacion.CERRAR_SESION)
                {
                    EsCierreSesion = true;
                    this.Close();
                    return;
                }

                Navegacion.Destino = Navegacion.MENU_PRINCIPAL;

                using (Form form = CrearPantalla(pantalla))
                {
                    Navegacion.AgregarMenu(form, rol, pantalla);
                    form.ShowDialog();
                }

                pantalla = Navegacion.Destino;
            }

            this.Show();
        }

        private Form CrearPantalla(string pantalla)
        {
            if (pantalla == Navegacion.USUARIOS) return new FormAdmin();
            if (pantalla == Navegacion.PRODUCTOS) return new FormProductos();
            if (pantalla == Navegacion.CONSULTA_STOCK)
            {
                // El acceso rápido de alertas abre la consulta mostrando solo el stock bajo.
                bool soloBajoMinimo = abrirAlertasStock;
                abrirAlertasStock = false;
                return new FormConsultaStock(usuarioLogueado, soloBajoMinimo);
            }
            if (pantalla == Navegacion.PROVEEDORES) return new FormProveedores();
            if (pantalla == Navegacion.VENTAS) return new FormVentas(usuarioLogueado);
            if (pantalla == Navegacion.COMPRAS) return new FormCompras(usuarioLogueado);
            if (pantalla == Navegacion.TALLER) return new FormTaller();
            if (pantalla == Navegacion.MI_PERFIL) return new FormUsuario(usuarioLogueado);
            return new FormConfiguracion();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.USUARIOS);
        }

        private void configuraciónDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.CONFIGURACION);
        }

        private void productoYStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.PRODUCTOS);
        }

        private void consultaStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.CONSULTA_STOCK);
        }

        private void btnAccesoStock_Click(object sender, EventArgs e)
        {
            abrirAlertasStock = true;
            AbrirPantalla(Navegacion.CONSULTA_STOCK);
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
            AbrirPantalla(Navegacion.PROVEEDORES);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.VENTAS);
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.COMPRAS);
        }

        private void miPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.MI_PERFIL);
        }

        private void tallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPantalla(Navegacion.TALLER);
        }
    }
}
