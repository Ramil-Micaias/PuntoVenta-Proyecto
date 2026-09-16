using Datos.Entidades;
using Logica;
using Logica.Seguridad;

namespace GU_Tercero
{
    // FormPreguntasSeguridad: Implementa un mecanismo de configuración inicial de preguntas 
    // de seguridad almacenadas de forma segura utilizando SHA256.
    public partial class FormPreguntasSeguridad : Form
    {
        private Usuario usuarioLogueado;

        public FormPreguntasSeguridad(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void FormPreguntasSeguridad_Load(object sender, EventArgs e)
        {
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            lblPreguntaTres.Text = "¿Comida favorita?";

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            ConfiguracionSistema configuracion = configuracionNegocio.ObtenerConfiguracion();

            bool requiereTresPreguntas = configuracion.Cantidad_Preguntas != 2;
            lblPreguntaTres.Visible = requiereTresPreguntas;
            txtRespuestaTres.Visible = requiereTresPreguntas;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuestaUno.Text) || string.IsNullOrWhiteSpace(txtRespuestaDos.Text))
            {
                MessageBox.Show("Complete todas las respuestas obligatorias.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            ConfiguracionSistema configuracion = configuracionNegocio.ObtenerConfiguracion();

            if (configuracion.Cantidad_Preguntas == 3 && string.IsNullOrWhiteSpace(txtRespuestaTres.Text))
            {
                MessageBox.Show("Complete la tercera respuesta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            // Guardar hashes
            string hash1 = HashHelper.GenerarSHA256(txtRespuestaUno.Text.Trim());
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 1, hash1);

            string hash2 = HashHelper.GenerarSHA256(txtRespuestaDos.Text.Trim());
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 2, hash2);

            if (configuracion.Cantidad_Preguntas == 3)
            {
                string hash3 = HashHelper.GenerarSHA256(txtRespuestaTres.Text.Trim());
                negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 3, hash3);
            }

            MessageBox.Show("Preguntas guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Redirección al sistema según el rol
            if (usuarioLogueado.Nombre_Rol == "Administrador")
            {
                FormMenu menu = new FormMenu(usuarioLogueado);
                menu.FormClosed += (s, args) => Application.Exit();
                menu.Show();
            }
            else
            {
                FormUsuario formUsuario = new FormUsuario(usuarioLogueado);
                formUsuario.FormClosed += (s, args) => Application.Exit();
                formUsuario.Show();
            }

            // Liberamos este formulario
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerramos la ventana actual para regresar a la vista anterior que la invocó
            this.Close();
        }
    }
}