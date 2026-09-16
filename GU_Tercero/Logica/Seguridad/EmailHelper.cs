using System.Net;
using System.Net.Mail;

namespace Seguridad
{
    public static class EmailHelper
    {
        public static void EnviarCorreo(string destino, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            
            mail.From = new MailAddress("sistemaanalista52@gmail.com");

            mail.To.Add(destino);

            mail.Subject = asunto;
            mail.Body = mensaje;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential("sistemaanalista52@gmail.com", "joxy grrq mqdp kgky");

            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
