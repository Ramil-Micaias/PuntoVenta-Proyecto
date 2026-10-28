using Datos;
using Datos.Entidades;
using Logica.Seguridad;
using Seguridad;
using System;

namespace Logica
{
    // Autenticación en dos pasos: si está habilitada en la Configuración del Sistema,
    // después de validar usuario y contraseña se envía un código al correo del usuario
    // y se pide ingresarlo para terminar el inicio de sesión.
    public class Autenticacion2FANegocio
    {
        public const int MINUTOS_VALIDEZ = 5;
        public const int INTENTOS_MAXIMOS = 3;

        private readonly Codigo2FADAO codigoDAO = new Codigo2FADAO();
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        public bool EstaHabilitada()
        {
            ConfiguracionSistema configuracion = new ConfiguracionNegocio().ObtenerConfiguracion();

            return configuracion != null && configuracion.Habilitar_2FA;
        }

        // Genera un código nuevo, lo guarda y lo envía por correo.
        // Si el correo no sale, el código se invalida y el resultado trae el motivo.
        public ResultadoEnvioEmail EnviarCodigo(Usuario usuario)
        {
            string correo = usuarioDAO.ObtenerCorreoUsuario(usuario.Nombre_Usuario);

            if (string.IsNullOrWhiteSpace(correo))
            {
                return new ResultadoEnvioEmail
                {
                    Error = "El usuario no tiene un correo electrónico registrado y activo. "
                        + "Solicite al administrador que registre su correo para poder ingresar."
                };
            }

            string codigo = Autenticacion2FAHelper.GenerarCodigo();
            codigoDAO.GuardarCodigo(usuario.Id_Usuario, codigo, MINUTOS_VALIDEZ);

            string cuerpo = "Hola " + usuario.Nombre_Usuario + "," + Environment.NewLine + Environment.NewLine
                + "Su código de verificación para ingresar al sistema es: " + codigo + Environment.NewLine + Environment.NewLine
                + "El código vence en " + MINUTOS_VALIDEZ + " minutos y se puede usar una sola vez." + Environment.NewLine
                + "Si usted no intentó ingresar, avise al administrador.";

            ResultadoEnvioEmail envio = EmailHelper.EnviarCorreo(correo, "Código de verificación - Punto Venta", cuerpo);

            if (!envio.Enviado)
            {
                codigoDAO.InvalidarCodigos(usuario.Id_Usuario);
            }

            return envio;
        }

        // Devuelve null si el código es correcto, o el mensaje a mostrar si no lo es.
        public string? ValidarCodigo(Usuario usuario, string codigo)
        {
            codigo = (codigo ?? string.Empty).Trim();

            if (codigo.Length == 0)
                return "Ingrese el código de verificación.";

            // El dígito verificador (AplicaLhun) detecta errores de tipeo sin consultar la base.
            if (!Autenticacion2FAHelper.TieneFormatoValido(codigo))
                return "El código no es válido. Revise que haya copiado los " + Autenticacion2FAHelper.LARGO_CODIGO + " dígitos correctamente.";

            string resultado = codigoDAO.ValidarCodigo(usuario.Id_Usuario, codigo);

            if (resultado == "OK")
                return null;

            if (resultado == "EXPIRADO")
                return "El código venció. Presione \"Reenviar código\" para recibir uno nuevo.";

            return "El código ingresado es incorrecto.";
        }

        public void CancelarVerificacion(Usuario usuario)
        {
            codigoDAO.InvalidarCodigos(usuario.Id_Usuario);
        }

        // Muestra el correo sin revelarlo completo. Ejemplo: d*******0@gmail.com
        public string ObtenerCorreoEnmascarado(Usuario usuario)
        {
            string correo = usuarioDAO.ObtenerCorreoUsuario(usuario.Nombre_Usuario);
            int arroba = correo.IndexOf('@');

            if (arroba <= 1)
                return correo;

            string nombre = correo.Substring(0, arroba);

            return nombre[0] + new string('*', nombre.Length - 2) + nombre[nombre.Length - 1] + correo.Substring(arroba);
        }
    }
}
