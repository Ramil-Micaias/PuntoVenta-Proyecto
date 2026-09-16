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
        private bool esCierreSesion = false;

        public FormMenu(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = usuarioLogueado.Nombre_Usuario;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Usamos ShowDialog sin ocultar el menú de fondo, o Show si es pantalla independiente
            using (FormAdmin formAdmin = new FormAdmin())
            {
                formAdmin.ShowDialog(this);
            }
        }

        private void configuraciónDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormConfiguracion configuracion = new FormConfiguracion())
            {
                configuracion.ShowDialog(this);
            }
        }

        private void productoYStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormProductos formProducto = new FormProductos())
            {
                formProducto.ShowDialog(this);
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esCierreSesion = true;

            // Abrimos un nuevo Login limpio para iniciar sesión con otra cuenta
            Form1 login = new Form1();
            login.Show();

            // Cerramos el menú actual sin matar el nuevo Login
            this.Close();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si la ventana se cierra por la cruz (X) y NO por cerrar sesión, salimos del proceso completo
            if (!esCierreSesion)
            {
                Application.Exit();
            }
        }
    }
}