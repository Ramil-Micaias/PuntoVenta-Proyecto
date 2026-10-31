using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;

namespace GU_Tercero
{
    public partial class FormRecuperoContraseña : Form
    {
        private ConfiguracionSistema configuracion = null!;
        private List<int> idsPreguntasCargadas = new List<int>();
        private string? avisoSinPreguntas;
        private int intentosFallidos = 0;
        private bool operacionEnCurso = false;
        private const int MaximoIntentos = 3;

        public FormRecuperoContraseña()
        {
            InitializeComponent();

            // Las preguntas se cargan solo al presionar Confirmar (o Enter). Antes se cargaban
            // al salir del campo de usuario: al hacer clic en Cancelar los botones se movían
            // debajo del mouse y el clic se perdía, por eso Cancelar parecía confirmar.
            txtNombreUsuario.TextChanged += txtNombreUsuario_TextChanged;
        }

        // Enter en el usuario o en las respuestas hace lo mismo que el botón Confirmar.
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && !btnCancelar.Focused && btnValidar.Enabled)
            {
                btnValidar.PerformClick();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void FormRecuperoContraseña_Load(object sender, EventArgs e)
        {
            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            configuracion = configuracionNegocio.ObtenerConfiguracion();

            OcultarPreguntas();

            btnValidar.Visible = true;
            btnCancelar.Visible = true;
            ReubicarControles();

            txtNombreUsuario.Focus();
        }

        // Si se cambia el usuario después de cargar sus preguntas, se ocultan y hay que
        // volver a presionar Confirmar.
        private void txtNombreUsuario_TextChanged(object? sender, EventArgs e)
        {
            if (idsPreguntasCargadas.Count > 0)
            {
                OcultarPreguntas();
            }
        }

        private void CargarPreguntasDelUsuario()
        {
            string usuario = txtNombreUsuario.Text.Trim();

            OcultarPreguntas();

            if (string.IsNullOrEmpty(usuario))
            {
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            DataTable preguntas = negocio.ObtenerPreguntasUsuario(usuario);

            avisoSinPreguntas = null;

            if (preguntas.Rows.Count == 0)
            {
                // Mismo mensaje si el usuario no existe o si no tiene preguntas, para no
                // revelar qué nombres de usuario existen.
                avisoSinPreguntas = "El usuario ingresado no existe o no tiene preguntas de seguridad configuradas. "
                    + "Verifique el nombre de usuario o solicite ayuda al administrador.";

                return;
            }

            idsPreguntasCargadas.Clear();

            int cantidad = Math.Min(preguntas.Rows.Count, configuracion.Cantidad_Preguntas == 2 ? 2 : 3);

            for (int i = 0; i < cantidad; i++)
            {
                int idPregunta = Convert.ToInt32(preguntas.Rows[i]["Id_Pregunta"]);

                idsPreguntasCargadas.Add(idPregunta);

                AsignarPregunta(i, PrepararTextoPregunta(preguntas.Rows[i]["Pregunta"].ToString() ?? string.Empty));
            }

            OcultarPreguntasNoUsadas();
        }

        // Normaliza el texto de la pregunta antes de mostrarlo.
        // Algunas cargas de la base dejaron un caracter U+00C2 pegado antes del signo
        // de apertura, y si no se quita se ve "Â¿" y despues se agrega un segundo "?",
        // dejando la pregunta doble.
        private static string PrepararTextoPregunta(string texto)
        {
            string limpio = texto.Replace("\u00C2", string.Empty).Trim();

            if (!limpio.StartsWith("¿"))
            {
                limpio = "¿" + limpio;
            }

            if (!limpio.EndsWith("?"))
            {
                limpio = limpio + "?";
            }

            return limpio;
        }

        private void AsignarPregunta(int indice, string texto)
        {
            switch (indice)
            {
                case 0:
                    lblPregunta1.Text = texto;
                    break;
                case 1:
                    lblPregunta2.Text = texto;
                    break;
                case 2:
                    lblPregunta3.Text = texto;
                    break;
            }
        }

        private void OcultarPreguntas()
        {
            // La lista se vacía antes de recalcular la visibilidad: si se hiciera al revés,
            // las preguntas quedarían visibles sin ninguna cargada detrás.
            idsPreguntasCargadas.Clear();

            OcultarPreguntasNoUsadas();
        }

        private void OcultarPreguntasNoUsadas()
        {
            bool mostrarPrimera = idsPreguntasCargadas.Count >= 1;
            bool mostrarSegunda = idsPreguntasCargadas.Count >= 2;
            bool mostrarTercera = idsPreguntasCargadas.Count >= 3;

            lblPregunta1.Visible = mostrarPrimera;
            txtRespuesta1.Visible = mostrarPrimera;
            lblPregunta2.Visible = mostrarSegunda;
            txtRespuesta2.Visible = mostrarSegunda;
            lblPregunta3.Visible = mostrarTercera;
            txtRespuesta3.Visible = mostrarTercera;

            // Confirmar siempre se puede usar: sin preguntas cargadas busca al usuario,
            // con preguntas cargadas valida las respuestas.
            btnValidar.Visible = true;
            btnValidar.Enabled = !operacionEnCurso;

            ReubicarControles();
        }

        // Las preguntas vienen de la base de datos y su largo es variable, así que los
        // controles se apilan a medida que se conoce el alto real de cada etiqueta. Sin esto
        // una pregunta larga se monta sobre su campo de respuesta.
        private void ReubicarControles()
        {
            Label[] etiquetas = { lblPregunta1, lblPregunta2, lblPregunta3 };
            TextBox[] campos = { txtRespuesta1, txtRespuesta2, txtRespuesta3 };

            // Las medidas se toman del campo de usuario y se convierten con LogicalToDeviceUnits
            // para que respeten el zoom de la pantalla (125%, 150%, 200%...). Con números fijos
            // en píxeles, en pantallas con zoom los botones quedaban encima del campo de usuario.
            int margenIzquierdo = txtNombreUsuario.Left;
            int anchoDisponible = ClientSize.Width - (margenIzquierdo * 2);
            int separacion = LogicalToDeviceUnits(26);

            // Cuando no hay preguntas para mostrar los botones igual tienen que estar
            // visibles, asi que se los ubica debajo del campo de usuario.
            int y = txtNombreUsuario.Bottom + LogicalToDeviceUnits(24);

            for (int i = 0; i < etiquetas.Length; i++)
            {
                if (!etiquetas[i].Visible)
                {
                    continue;
                }

                int altoEtiqueta = etiquetas[i].GetPreferredSize(new Size(anchoDisponible, 0)).Height;

                etiquetas[i].Location = new Point(margenIzquierdo, y);

                y += altoEtiqueta + LogicalToDeviceUnits(6);

                campos[i].Location = new Point(margenIzquierdo, y);

                y += campos[i].Height + separacion;
            }

            btnValidar.Location = new Point(margenIzquierdo, y);
            btnCancelar.Location = new Point(btnValidar.Right + LogicalToDeviceUnits(15), y);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string usuario = txtNombreUsuario.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return;
            }

            // Primer paso: buscar al usuario y mostrar sus preguntas.
            if (idsPreguntasCargadas.Count == 0)
            {
                CargarPreguntasDelUsuario();

                if (idsPreguntasCargadas.Count == 0)
                {
                    MessageBox.Show(avisoSinPreguntas, "Recuperación no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreUsuario.Focus();
                    txtNombreUsuario.SelectAll();
                    return;
                }

                txtRespuesta1.Focus();
                return;
            }

            string[] respuestas = { txtRespuesta1.Text, txtRespuesta2.Text, txtRespuesta3.Text };

            for (int i = 0; i < idsPreguntasCargadas.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(respuestas[i]))
                {
                    MessageBox.Show("Por favor, responda todas las preguntas de seguridad indicadas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRespuesta1.Focus();
                    return;
                }
            }

            operacionEnCurso = true;
            btnValidar.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                bool esValido = true;

                for (int i = 0; i < idsPreguntasCargadas.Count; i++)
                {
                    if (!negocio.ValidarPreguntaSeguridad(usuario, idsPreguntasCargadas[i], respuestas[i]))
                    {
                        esValido = false;
                        break;
                    }
                }

                if (!esValido)
                {
                    intentosFallidos++;

                    if (intentosFallidos >= MaximoIntentos)
                    {
                        MessageBox.Show(
                            "Superó el máximo de intentos permitidos. Por seguridad, vuelva a intentar más tarde o solicite asistencia al administrador.",
                            "Acceso restringido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        this.Close();
                        return;
                    }

                    MessageBox.Show(
                        "Una o más respuestas no son correctas. Le quedan " + (MaximoIntentos - intentosFallidos) + " intento(s).",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    LimpiarRespuestas();

                    return;
                }

                ResultadoRecuperacionPassword resultado = negocio.RecuperarPassword(usuario);

                MostrarResultado(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error inesperado al recuperar la contraseña: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // El formulario se cierra solo cuando la recuperación termina bien, así que
                // se chequea que siga vivo antes de volver a tocar los controles.
                operacionEnCurso = false;

                if (!IsDisposed)
                {
                    Cursor = Cursors.Default;
                    btnValidar.Enabled = true;
                }
            }
        }

        private void MostrarResultado(ResultadoRecuperacionPassword resultado)
        {
            if (resultado.Exitoso)
            {
                MessageBox.Show(
                    "Se envió una contraseña temporal al correo " + resultado.CorreoDestinatario + ".\n\n"
                    + "Al ingresar con ella, el sistema le solicitará definir una nueva contraseña.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();

                return;
            }

            if (!string.IsNullOrEmpty(resultado.PasswordTemporalParaMostrar))
            {
                // No se modificó la contraseña del usuario en la base, así que esta temporal
                // todavía sirve para ingresar. Se muestra por pantalla porque si el servidor de
                // correo está caído no hay otro canal para entregarla.
                DialogResult confirmacion = MessageBox.Show(
                    "No se pudo enviar el correo de recuperación.\n\n"
                    + resultado.Error + "\n\n"
                    + "Para que no quede sin acceso al sistema, su contraseña temporal es:\n\n"
                    + resultado.PasswordTemporalParaMostrar + "\n\n"
                    + "Anótela ahora. Al ingresar con ella el sistema le solicitará definir una nueva contraseña.\n\n"
                    + "¿Desea volver al inicio de sesión con esta contraseña?",
                    "Contraseña temporal generada",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    LimpiarRespuestas();
                }

                return;
            }

            MessageBox.Show(resultado.Error, "No se pudo recuperar la contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);

            LimpiarRespuestas();
        }

        private void LimpiarRespuestas()
        {
            txtRespuesta1.Clear();
            txtRespuesta2.Clear();
            txtRespuesta3.Clear();
            txtRespuesta1.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Form1 ya se muestra solo cuando este formulario se cierra (lo tiene enlazado
            // en llb_OlvidoContraseña_LinkClicked), así que acá no se crea una segunda
            // instancia del login.
            this.Close();
        }
    }
}
