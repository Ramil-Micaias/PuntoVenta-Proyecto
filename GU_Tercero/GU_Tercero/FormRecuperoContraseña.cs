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

            txtNombreUsuario.Leave += txtNombreUsuario_Leave;

            // El Enter se atiende a nivel del formulario con ProcessDialogKey y no con el
            // evento KeyDown del TextBox. Con AcceptButton configurado, Windows se come la
            // tecla Enter cuando el boton esta deshabilitado y el KeyDown nunca se dispara,
            // por lo que escribir el usuario y apretar Enter no cargaba las preguntas.
            // En cambio Tab si dispara el Leave y por eso funcionaba solo de esa forma.
        }

        // Intercepta Enter antes que Windows. En el campo de usuario carga las preguntas
        // y en los campos de respuesta valida, que es lo que se espera al apretar Enter.
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (txtNombreUsuario.Focused)
                {
                    CargarPreguntasDelUsuario();

                    if (idsPreguntasCargadas.Count > 0)
                    {
                        txtRespuesta1.Focus();
                    }

                    return true;
                }

                if (txtRespuesta1.Focused || txtRespuesta2.Focused || txtRespuesta3.Focused)
                {
                    if (btnValidar.Enabled)
                    {
                        btnValidar.PerformClick();
                        return true;
                    }
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        private void FormRecuperoContraseña_Load(object sender, EventArgs e)
        {
            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            configuracion = configuracionNegocio.ObtenerConfiguracion();

            OcultarPreguntas();

            // Ambos botones quedan visibles desde el arranque; el de validar se
            // deshabilita solo hasta que se carguen las preguntas del usuario.
            btnValidar.Visible = true;
            btnValidar.Enabled = false;
            btnCancelar.Visible = true;
            ReubicarControles();

            txtNombreUsuario.Focus();
        }

        // Al salir del campo se consultan las preguntas que el usuario tiene configuradas
        // realmente. Antes se mostraban siempre tres textos fijos y se validaban contra los
        // Id_Pregunta 1, 2 y 3 suponiendo que ese era el orden elegido por cada usuario.
        private void txtNombreUsuario_Leave(object? sender, EventArgs e)
        {
            CargarPreguntasDelUsuario();
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
                // No se muestra un MessageBox acá: este método se dispara cada vez que el
                // usuario sale del campo o presiona Enter, y el aviso se repite molesto.
                avisoSinPreguntas = "El usuario no tiene preguntas de seguridad configuradas, por lo que no puede recuperar la contraseña. "
                    + "Debe solicitar al administrador que las configure.";

                return;
            }

            btnValidar.Enabled = true;

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

            // Los dos botones quedan siempre visibles. Ocultar el de validar dejaba la
            // pantalla inicial con un solo boton, y se lee como que al formulario le
            // falta algo. Se deshabilita hasta que haya preguntas cargadas para validar.
            btnValidar.Visible = true;
            btnValidar.Enabled = mostrarPrimera && !operacionEnCurso;

            ReubicarControles();
        }

        // Las preguntas vienen de la base de datos y su largo es variable, así que los
        // controles se apilan a medida que se conoce el alto real de cada etiqueta. Sin esto
        // una pregunta larga se monta sobre su campo de respuesta.
        private void ReubicarControles()
        {
            Label[] etiquetas = { lblPregunta1, lblPregunta2, lblPregunta3 };
            TextBox[] campos = { txtRespuesta1, txtRespuesta2, txtRespuesta3 };

            const int margenIzquierdo = 30;
            const int anchoDisponible = 660;
            const int separacion = 26;

            // Cuando no hay preguntas para mostrar los botones igual tienen que estar
            // visibles, asi que se los ubica debajo del campo de usuario.
            int y = etiquetas[0].Visible ? 152 : 158;

            for (int i = 0; i < etiquetas.Length; i++)
            {
                if (!etiquetas[i].Visible)
                {
                    continue;
                }

                int altoEtiqueta = etiquetas[i].GetPreferredSize(new Size(anchoDisponible, 0)).Height;

                etiquetas[i].Location = new Point(margenIzquierdo, y);

                y += altoEtiqueta + 6;

                campos[i].Location = new Point(margenIzquierdo, y);

                y += campos[i].Height + separacion;
            }

            btnValidar.Location = new Point(margenIzquierdo, y);
            btnCancelar.Location = new Point(margenIzquierdo + 215, y);
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

            if (idsPreguntasCargadas.Count == 0)
            {
                CargarPreguntasDelUsuario();
            }

            if (idsPreguntasCargadas.Count == 0)
            {
                if (avisoSinPreguntas != null)
                {
                    MessageBox.Show(avisoSinPreguntas, "Recuperación no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Complete el nombre de usuario y presione Tab o Enter para cargar sus preguntas de seguridad.",
                        "Recuperación de contraseña",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

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
                    btnValidar.Enabled = idsPreguntasCargadas.Count > 0;
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
