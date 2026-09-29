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
            txtUsuario.KeyDown += txtUsuario_KeyDown;
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido beep de Windows
                txtPassword.Focus();
            }
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsuario.Focus(); // Coloca el cursor directamente en el campo usuario
        }

        // Abre el menú principal según el rol del usuario.
        private void AbrirMenu(Usuario usuario)
        {
            if (usuario.Nombre_Rol == "Administrador")
            {
                FormMenu menu = new FormMenu(usuario);

                // Al cerrar el menú, volvemos a mostrar la pantalla de Login limpia (o la cerramos si fue por X)
                menu.FormClosed += (s, args) =>
                {
                    if (menu.EsCierreSesion)
                    {
                        txtUsuario.Clear();
                        txtPassword.Clear();
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                };

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

                // 1. PASO OBLIGATORIO: Cambio de Contraseña
                if (usuario.Es_Primer_Ingreso || usuario.Debe_Cambiar_Password)
                {
                    using (FormCambioPassword formCambio = new FormCambioPassword(usuario))
                    {
                        this.Hide();
                        // Si el usuario cancela o cierra la app desde el cambio, detiene el login
                        if (formCambio.ShowDialog() != DialogResult.OK)
                        {
                            LimpiarCampos();
                            this.Show();
                            return;
                        }
                    }
                }

                // 2. PASO OBLIGATORIO: Preguntas de Seguridad
                if (!negocio.UsuarioTienePreguntas(usuario.Id_Usuario))
                {
                    using (FormPreguntasSeguridad formPreguntas = new FormPreguntasSeguridad(usuario))
                    {
                        this.Hide();
                        if (formPreguntas.ShowDialog() != DialogResult.OK)
                        {
                            LimpiarCampos();
                            this.Show();
                            return;
                        }
                    }
                }

                // 3. ENTRADA AL SISTEMA: Si pasó todas las validaciones, entra al Menú
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
                        picLogo.Image = System.Drawing.Image.FromFile(ruta);
                        picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    }
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