using System.Net;
using System.Net.Mail;
using System.Text;

namespace Seguridad
{
    public static class EmailHelper
    {
        private const string ServidorSmtp = "smtp.gmail.com";
        private const int PuertoSmtp = 587;
        private const string Remitente = "sistemaanalista52@gmail.com";
        private const string CredencialRemitente = "joxy grrq mqdp kgky";
        private const int TimeoutMilisegundos = 20000;

        // Envía un correo de texto plano. Nunca lanza excepciones: devuelve el resultado
        // del intento para que la capa de negocio decida cómo continuar.
        public static ResultadoEnvioEmail EnviarCorreo(string? destino, string asunto, string mensaje)
        {
            ResultadoEnvioEmail resultado = new ResultadoEnvioEmail();

            if (string.IsNullOrWhiteSpace(destino))
            {
                resultado.Error = "El usuario no tiene un correo electrónico registrado y activo.";

                return resultado;
            }

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(Remitente);
                    mail.To.Add(destino.Trim());
                    mail.Subject = asunto;
                    mail.Body = mensaje;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = false;

                    SmtpClient smtp = new SmtpClient(ServidorSmtp, PuertoSmtp)
                    {
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Timeout = TimeoutMilisegundos
                    };

                    smtp.Credentials = new NetworkCredential(Remitente, CredencialRemitente);

                    smtp.Send(mail);
                }

                resultado.Enviado = true;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                resultado.Error = "El servidor de correo rechazó el envío al usuario. " + ex.Message;
            }
            catch (SmtpException ex)
            {
                resultado.Error = ex.InnerException != null
                    ? "No se pudo conectar con el servidor de correo. " + ex.Message + " Detalle: " + ex.InnerException.Message
                    : "No se pudo conectar con el servidor de correo. " + ex.Message;
            }
            catch (Exception ex)
            {
                resultado.Error = "Ocurrió un error inesperado al enviar el correo. " + ex.Message;
            }

            return resultado;
        }
    }
}
