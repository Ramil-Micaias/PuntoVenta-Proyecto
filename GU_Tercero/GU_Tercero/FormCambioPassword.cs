using Datos.Entidades;
using Logica;
using Logica.Seguridad;

namespace GU_Tercero
{
    // FormCambioPassword: Este formulario implementa una política de seguridad obligando al usuario a modificar 
    // la contraseña inicial o temporal antes de utilizar el sistema.
    public partial class FormCambioPassword : Form
    {
        private Usuario usuarioLogueado;

        public FormCambioPassword(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevaPassword.Text))
            {
                MessageBox.Show("Ingrese la nueva contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();

            string resultado = configuracionNegocio.ValidarPassword(txtNuevaPassword.Text.Trim(), usuarioLogueado);

            if (resultado != "OK")
            {
                MessageBox.Show(resultado, "Validación de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevaPasswordHash = HashHelper.GenerarSHA256(usuarioLogueado.Nombre_Usuario + txtNuevaPassword.Text.Trim());

            UsuarioNegocio negocio = new UsuarioNegocio();

            negocio.CambiarPassword(usuarioLogueado.Id_Usuario, nuevaPasswordHash);
            negocio.RegistrarHistorialPassword(usuarioLogueado.Id_Usuario, nuevaPasswordHash);

            MessageBox.Show("Contraseña cambiada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            usuarioLogueado.Debe_Cambiar_Password = false;

            if (!negocio.UsuarioTienePreguntas(usuarioLogueado.Id_Usuario))
            {
                FormPreguntasSeguridad preguntas = new FormPreguntasSeguridad(usuarioLogueado);

                // Si entra a preguntas de seguridad, al cerrar esa ventana se vuelve al Login o se cierra la app
                preguntas.FormClosed += (s, args) => this.Close();
                preguntas.Show();
                this.Hide(); // Mantenemos oculto mientras completa las preguntas
            }
            else
            {
                if (usuarioLogueado.Nombre_Rol == "Administrador")
                {
                    FormMenu menu = new FormMenu(usuarioLogueado);

                    // Al cerrar el menú principal desde este flujo, cerramos toda la aplicación
                    menu.FormClosed += (s, args) => Application.Exit();
                    menu.Show();
                }
                else
                {
                    FormUsuario formUsuario = new FormUsuario(usuarioLogueado);

                    formUsuario.FormClosed += (s, args) => Application.Exit();
                    formUsuario.Show();
                }

                // Cerramos este formulario de cambio de contraseña
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerramos la ventana. El evento FormClosed en Form1 se encargará de re-mostrar el Login original.
            this.Close();
        }
    }
}