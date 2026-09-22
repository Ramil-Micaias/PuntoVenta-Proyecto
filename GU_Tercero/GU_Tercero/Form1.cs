using Datos.Entidades;
using Logica;
using Logica.Seguridad;
using Seguridad;

namespace GU_Tercero
{
    // El Form1 es la interfaz inicial del sistema y actúa como punto de entrada para la autenticación de usuarios.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Nota: Recordá quitar o comentar el MessageBox de prueba en producción
            // MessageBox.Show(HashHelper.GenerarSHA256("adminEsty123"));
        }

        // Abre el menú principal según el rol del usuario.
        private void AbrirMenu(Usuario usuario)
        {
            if (usuario.Nombre_Rol == "Administrador")
            {
                FormMenu menu = new FormMenu(usuario);

                // Cuando el usuario cierre el menú principal, se cierra toda la aplicación
                menu.FormClosed += (s, args) => this.Close();

                menu.Show();
                this.Hide();
            }
            else
            {
                FormUsuario formUsuario = new FormUsuario(usuario);

                // Si la vista de usuario no es el menú principal, al cerrarla también cerramos la app
                formUsuario.FormClosed += (s, args) => this.Close();

                formUsuario.Show();
                this.Hide();
            }
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            Usuario usuario = negocio.ValidarLogin(txtUsuario.Text, txtPassword.Text);

            if (usuario != null)
            {
                if (usuario.Bloqueado || !usuario.Activo)
                {
                    MessageBox.Show("Usuario bloqueado o inactivo", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (usuario.Es_Primer_Ingreso || usuario.Debe_Cambiar_Password)
                {
                    FormCambioPassword form = new FormCambioPassword(usuario);

                    // Al cerrar el formulario de cambio de contraseña, volvemos a mostrar el Login
                    form.FormClosed += (s, args) => this.Show();

                    form.Show();
                    this.Hide();
                    return;
                }

                // Abrir menú según corresponda (ya incluye this.Hide() dentro)
                AbrirMenu(usuario);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarLogo();
        }

        private void CargarLogo()
        {
            try
            {
                string rutaLogo = System.IO.Path.Combine(Application.StartupPath, "loguito trtansparente.png");
                if (!System.IO.File.Exists(rutaLogo))
                {
                    // Buscar en la raíz del proyecto si estamos en debug
                    rutaLogo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\loguito trtansparente.png");
                }

                if (!System.IO.File.Exists(rutaLogo))
                {
                    rutaLogo = @"C:\Users\LanzceTest\Desktop\correciones para el martes creo q 23-09\loguito trtansparente.png";
                }

                if (System.IO.File.Exists(rutaLogo))
                {
                    picLogo.Image = System.Drawing.Image.FromFile(rutaLogo);
                    picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch { }
        }

        private void llb_OlvidoContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperoContraseña formrecupero = new FormRecuperoContraseña();

            // Al cerrar el formulario de recuperación, se vuelve a mostrar el Login
            formrecupero.FormClosed += (s, args) => this.Show();

            formrecupero.Show();
            this.Hide();
        }
    }
}