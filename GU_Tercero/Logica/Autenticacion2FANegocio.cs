using Datos;
using Datos.Entidades;
using Logica.Seguridad;
using Seguridad;
using System;

namespace Logica
{
    // logica de la verificacion en dos pasos
    public class Autenticacion2FANegocio
    {
        // el codigo dura 5 minutos y hay 3 intentos
        public const int MINUTOS_VALIDEZ = 5;
        public const int INTENTOS_MAXIMOS = 3;

        private readonly Codigo2FADAO codigoDAO = new Codigo2FADAO();
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        // true si el admin activo el 2FA en la configuracion
        public bool EstaHabilitada()
        {
            ConfiguracionSistema configuracion = new ConfiguracionNegocio().ObtenerConfiguracion();

            return configuracion != null && configuracion.Habilitar_2FA;
        }

        // genera el codigo, lo guarda y lo manda por mail
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

        // valida el codigo, devuelve null si esta bien o el mensaje de error
        public string? ValidarCodigo(Usuario usuario, string codigo)
        {
            codigo = (codigo ?? string.Empty).Trim();

            if (codigo.Length == 0)
                return "Ingrese el código de verificación.";

            if (!Autenticacion2FAHelper.TieneFormatoValido(codigo))
                return "El código no es válido. Revise que haya copiado los " + Autenticacion2FAHelper.LARGO_CODIGO + " dígitos correctamente.";

            string resultado = codigoDAO.ValidarCodigo(usuario.Id_Usuario, codigo);

            if (resultado == "OK")
                return null;

            if (resultado == "EXPIRADO")
                return "El código venció. Presione \"Reenviar código\" para recibir uno nuevo.";

            return "El código ingresado es incorrecto.";
        }

        // anula los codigos si cancela
        public void CancelarVerificacion(Usuario usuario)
        {
            codigoDAO.InvalidarCodigos(usuario.Id_Usuario);
        }

        // muestra el correo con asteriscos, ej: l****o@gmail.com
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
