namespace Seguridad
{
    // resultado de mandar un mail: si salio o el error
    public class ResultadoEnvioEmail
    {
        public bool Enviado { get; set; }

        public string Error { get; set; } = string.Empty;
    }
}
