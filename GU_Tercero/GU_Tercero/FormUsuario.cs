using Datos.Entidades;
using Logica;
using Logica.Seguridad;

namespace GU_Tercero
{
    public partial class FormUsuario : Form
    {
        private Usuario usuarioLogueado;
        public FormUsuario(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            // Muestra la información del usuario.
            lblNombreUsuario.Text = usuarioLogueado.Nombre_Usuario;
            lblNombreRol.Text = usuarioLogueado.Nombre_Rol;

            // Carga las preguntas de seguridad.
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            lblPreguntaTres.Text = "¿Comida favorita?";

            // Obtiene la configuración del sistema.
            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            ConfiguracionSistema configuracion = configuracionNegocio.ObtenerConfiguracion();

            // Muestra u oculta la tercera pregunta según la configuración.
            if (configuracion.Cantidad_Preguntas == 2)
            {
                lblPreguntaTres.Visible = false;
                txtRespuestaTres.Visible = false;
            }
            else
            {
                lblPreguntaTres.Visible = true;
                txtRespuestaTres.Visible = true;
            }
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            // Valida que la nueva contraseña haya sido ingresada.
            if (txtNuevaPassword.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la nueva contraseña.");
                return;
            }

            // Valida que se confirme la nueva contraseña.
            if (txtConfirmarPassword.Text.Trim() == "")
            {
                MessageBox.Show("Confirme la nueva contraseña.");
                return;
            }

            // Verifica que ambas contraseñas sean iguales.
            if (txtNuevaPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();

            // Valida que la contraseña cumpla las políticas configuradas.
            string resultado = configuracionNegocio.ValidarPassword(txtNuevaPassword.Text.Trim(), usuarioLogueado);

            if (resultado != "OK")
            {
                MessageBox.Show(resultado);
                return;
            }

            // Genera el hash de la nueva contraseña.
            string nuevaPasswordHash = HashHelper.GenerarSHA256(usuarioLogueado.Nombre_Usuario + txtNuevaPassword.Text);

            UsuarioNegocio negocio = new UsuarioNegocio();

            // Actualiza la contraseña del usuario.
            negocio.CambiarPassword(usuarioLogueado.Id_Usuario, nuevaPasswordHash);

            MessageBox.Show("La contraseña fue modificada correctamente.");

            // Limpia los campos.
            txtNuevaPassword.Clear();
            txtConfirmarPassword.Clear();
        }

        private void btnGuardarPreguntas_Click(object sender, EventArgs e)
        {
            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            ConfiguracionSistema configuracion = configuracionNegocio.ObtenerConfiguracion();

            // Verifica que las respuestas obligatorias hayan sido ingresadas.
            if (txtRespuestaUno.Text.Trim() == "" || txtRespuestaDos.Text.Trim() == "")
            {
                MessageBox.Show("Complete todas las respuestas.");
                return;
            }

            if (configuracion.Cantidad_Preguntas == 3 && txtRespuestaTres.Text.Trim() == "")
            {
                MessageBox.Show("Complete todas las respuestas.");
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            // Guarda la primera respuesta.
            string hash1 = HashHelper.GenerarSHA256(txtRespuestaUno.Text.Trim());
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 1, hash1);

            // Guarda la segunda respuesta.
            string hash2 = HashHelper.GenerarSHA256(txtRespuestaDos.Text.Trim());
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 2, hash2);

            // Guarda la tercera respuesta si corresponde.
            if (configuracion.Cantidad_Preguntas == 3)
            {
                string hash3 = HashHelper.GenerarSHA256(txtRespuestaTres.Text.Trim());
                negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 3, hash3);
            }

            MessageBox.Show("Las preguntas de seguridad fueron actualizadas correctamente.");

            txtRespuestaUno.Clear();
            txtRespuestaDos.Clear();
            txtRespuestaTres.Clear();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
