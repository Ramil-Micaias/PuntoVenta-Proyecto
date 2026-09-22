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
        }

        private void CargarLogo()
        {
            try
            {
                string rutaLogo = System.IO.Path.Combine(Application.StartupPath, "loguito trtansparente.png");
                if (!System.IO.File.Exists(rutaLogo))
                {
                    rutaLogo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\loguito trtansparente.png");
                }

                if (!System.IO.File.Exists(rutaLogo))
                {
                    rutaLogo = @"C:\Users\LanzceTest\Desktop\correciones para el martes creo q 23-09\loguito trtansparente.png";
                }

                if (System.IO.File.Exists(rutaLogo))
                {
                    picLogoMenu.Image = System.Drawing.Image.FromFile(rutaLogo);
                    picLogoMenu.SizeMode = PictureBoxSizeMode.Zoom;
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
    }
}