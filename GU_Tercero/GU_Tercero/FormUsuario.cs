using Datos.Entidades;
using Logica;
using Logica.Seguridad;
using System.Data;

using Vista;

namespace GU_Tercero
{
    public partial class FormUsuario : Form
    {
        private Usuario usuarioLogueado;

        // Para cambiar la contraseña primero se responden las 3 preguntas de seguridad
        // en los campos de abajo. Las preguntas no se pueden cambiar desde Mi Perfil.
        private enum Paso { Inicio, Respondiendo, NuevaPassword }

        private const int INTENTOS_MAXIMOS = 3;

        private Paso paso = Paso.Inicio;
        private int intentosFallidos = 0;
        private readonly List<int> idsPreguntas = new List<int>();

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

            CargarPreguntas();
            CambiarPaso(Paso.Inicio);
        }

        // Muestra las 3 preguntas que eligió el usuario.
        private void CargarPreguntas()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            DataTable preguntas = negocio.ObtenerPreguntasUsuario(usuarioLogueado.Nombre_Usuario);
            Label[] etiquetas = { lblPreguntaUno, lblPreguntaDos, lblPreguntaTres };

            idsPreguntas.Clear();
            for (int i = 0; i < etiquetas.Length; i++)
            {
                if (i < preguntas.Rows.Count)
                {
                    idsPreguntas.Add(Convert.ToInt32(preguntas.Rows[i]["Id_Pregunta"]));
                    etiquetas[i].Text = preguntas.Rows[i]["Pregunta"].ToString();
                }
                else
                {
                    etiquetas[i].Text = "(sin pregunta cargada)";
                }
            }
        }

        // Habilita los campos que corresponden a cada paso y limpia lo escrito.
        private void CambiarPaso(Paso nuevoPaso)
        {
            paso = nuevoPaso;

            bool respondiendo = paso == Paso.Respondiendo;
            txtRespuestaUno.Enabled = respondiendo;
            txtRespuestaDos.Enabled = respondiendo;
            txtRespuestaTres.Enabled = respondiendo;
            txtRespuestaUno.Clear();
            txtRespuestaDos.Clear();
            txtRespuestaTres.Clear();

            bool nuevaPassword = paso == Paso.NuevaPassword;
            txtNuevaPassword.Enabled = nuevaPassword;
            txtConfirmarPassword.Enabled = nuevaPassword;
            txtNuevaPassword.Clear();
            txtConfirmarPassword.Clear();

            // "Cambiar contraseña" pasa a "Verificar respuestas"; "Confirmar cambios" solo se usa
            // cuando las respuestas fueron correctas.
            btnCambiarPassword.Text = respondiendo ? "Verificar respuestas" : "Cambiar contraseña";
            HabilitarBoton(btnCambiarPassword, !nuevaPassword, Color.FromArgb(37, 99, 235));
            HabilitarBoton(btnConfirmarCambios, nuevaPassword, Color.FromArgb(16, 185, 129));

            if (paso == Paso.Inicio)
                intentosFallidos = 0;
            else if (respondiendo)
                txtRespuestaUno.Focus();
            else
                txtNuevaPassword.Focus();
        }

        // Los botones planos deshabilitados se ven igual que los habilitados: se pintan de gris.
        private void HabilitarBoton(Button boton, bool habilitar, Color color)
        {
            boton.Enabled = habilitar;
            boton.BackColor = habilitar ? color : Color.FromArgb(148, 163, 184);
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);

            if (paso == Paso.Inicio)
            {
                if (idsPreguntas.Count < UsuarioNegocio.TOTAL_PREGUNTAS)
                {
                    MessageBox.Show("No tiene sus preguntas de seguridad completas. Vuelva a iniciar sesión para cargarlas.",
                        "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CambiarPaso(Paso.Respondiendo);
                return;
            }

            VerificarRespuestas();
        }

        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);
            GuardarPassword();
        }

        // Controla las 3 respuestas. Si son correctas habilita la nueva contraseña.
        private void VerificarRespuestas()
        {
            string[] respuestas = { txtRespuestaUno.Text, txtRespuestaDos.Text, txtRespuestaTres.Text };

            foreach (string respuesta in respuestas)
            {
                if (string.IsNullOrWhiteSpace(respuesta))
                {
                    MessageBox.Show("Responda las 3 preguntas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            UsuarioNegocio negocio = new UsuarioNegocio();
            bool correctas = true;

            for (int i = 0; i < idsPreguntas.Count; i++)
            {
                if (!negocio.ValidarPreguntaSeguridad(usuarioLogueado.Nombre_Usuario, idsPreguntas[i], respuestas[i]))
                {
                    correctas = false;
                    break;
                }
            }

            if (correctas)
            {
                CambiarPaso(Paso.NuevaPassword);
                return;
            }

            intentosFallidos++;

            if (intentosFallidos >= INTENTOS_MAXIMOS)
            {
                MessageBox.Show("Superó los " + INTENTOS_MAXIMOS + " intentos. No se habilitó el cambio de contraseña.",
                    "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CambiarPaso(Paso.Inicio);
                return;
            }

            // No se indica cuál respuesta falló, para no dar pistas.
            MessageBox.Show("Alguna respuesta no es correcta.\nIntentos restantes: " + (INTENTOS_MAXIMOS - intentosFallidos),
                "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtRespuestaUno.Clear();
            txtRespuestaDos.Clear();
            txtRespuestaTres.Clear();
            txtRespuestaUno.Focus();
        }

        private void GuardarPassword()
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

            Mensajes.Exito(lblResultado, "La contraseña fue modificada correctamente.");

            // Vuelve a bloquear los campos (limpia lo escrito).
            CambiarPaso(Paso.Inicio);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
