using Datos.Entidades;
using Logica;

namespace GU_Tercero
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }
        private void CargarConfiguracion()
        {
            ConfiguracionNegocio negocio = new ConfiguracionNegocio();

            ConfiguracionSistema configuracion = negocio.ObtenerConfiguracion();

            nudCantidadMinimaCaracteres.Value = configuracion.Min_Caracteres;

            nudCantidadPreguntas.Value = configuracion.Cantidad_Preguntas;

            nudHistorialCantidadContraseña.Value = configuracion.Cantidad_HistorialPasswords;

            chkMayusculas.Checked = configuracion.Requiere_Mayusculas;

            chkNumeros.Checked = configuracion.Requiere_Numeros;

            chkEspecial.Checked = configuracion.Requiere_Especial;

            chk2FA.Checked = configuracion.Habilitar_2FA;

            chkNoRepetir.Checked = configuracion.No_RepetirPasswords;

            chkDatosPersonales.Checked = configuracion.Validar_DatosPersonales;
        }

        private void GuardarConfiguracion()
        {
            try
            {
                ConfiguracionSistema configuracion = new ConfiguracionSistema();

                configuracion.Id_Configuracion = 1;

                configuracion.Min_Caracteres = (int)nudCantidadMinimaCaracteres.Value;

                configuracion.Cantidad_Preguntas = (int)nudCantidadPreguntas.Value;

                configuracion.Cantidad_HistorialPasswords = (int)nudHistorialCantidadContraseña.Value;

                configuracion.Requiere_Mayusculas = chkMayusculas.Checked;

                configuracion.Requiere_Numeros = chkNumeros.Checked;

                configuracion.Requiere_Especial = chkEspecial.Checked;

                configuracion.Habilitar_2FA = chk2FA.Checked;

                configuracion.No_RepetirPasswords = chkNoRepetir.Checked;

                configuracion.Validar_DatosPersonales = chkDatosPersonales.Checked;

                ConfiguracionNegocio negocio = new ConfiguracionNegocio();

                negocio.GuardarConfiguracion(configuracion);

                MessageBox.Show("La configuración fue guardada correctamente.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la configuración.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            CargarConfiguracion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConfiguracion();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            CargarConfiguracion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
