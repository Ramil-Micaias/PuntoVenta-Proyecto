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

        public FormMenu(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
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