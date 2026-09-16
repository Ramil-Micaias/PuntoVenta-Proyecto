using Datos.Entidades;
using Logica;

namespace GU_Tercero
{
    public partial class FormRecuperoContraseña : Form
    {
        private ConfiguracionSistema configuracion; 
        public FormRecuperoContraseña()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormRecuperoContraseña_Load(object sender, EventArgs e)
        {
            // Obtener la configuración actual del sistema
            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            configuracion = configuracionNegocio.ObtenerConfiguracion();

            // Asignar los textos de las preguntas
            lblPregunta1.Text = "¿Nombre de tu primera mascota?";
            lblPregunta2.Text = "¿Ciudad donde naciste?";
            lblPregunta3.Text = "¿Comida favorita?";

            // Ocultar la tercera pregunta si la configuración exige únicamente 2
            if (configuracion.Cantidad_Preguntas == 2)
            {
                lblPregunta3.Visible = false;
                txtRespuesta3.Visible = false;
            }
            else
            {
                lblPregunta3.Visible = true;
                txtRespuesta3.Visible = true;
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {

            string usuario = txtNombreUsuario.Text.Trim();

            // Validar que se haya ingresado el nombre de usuario
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que se completen las respuestas según la cantidad configurada
            if (string.IsNullOrEmpty(txtRespuesta1.Text.Trim()) || string.IsNullOrEmpty(txtRespuesta2.Text.Trim()))
            {
                MessageBox.Show("Por favor, responda a las preguntas de seguridad indicadas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (configuracion.Cantidad_Preguntas == 3 && string.IsNullOrEmpty(txtRespuesta3.Text.Trim()))
            {
                MessageBox.Show("Por favor, responda a las tres preguntas de seguridad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            // Validar Respuestas
            bool pregunta1 = negocio.ValidarPreguntaSeguridad(usuario, 1, txtRespuesta1.Text.Trim());
            bool pregunta2 = negocio.ValidarPreguntaSeguridad(usuario, 2, txtRespuesta2.Text.Trim());

            bool esValido = false;

            if (configuracion.Cantidad_Preguntas == 2)
            {
                esValido = pregunta1 && pregunta2;
            }
            else // 3 preguntas
            {
                bool pregunta3 = negocio.ValidarPreguntaSeguridad(usuario, 3, txtRespuesta3.Text.Trim());
                esValido = pregunta1 && pregunta2 && pregunta3;
            }

            // Si las respuestas son correctas, se recupera la contraseña
            if (esValido)
            {
                negocio.RecuperarPassword(usuario);

                MessageBox.Show("Se ha enviado una nueva contraseña temporal a tu correo electrónico.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Una o más respuestas (o el usuario) son incorrectos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();

            this.Hide();
        }
    }
}
