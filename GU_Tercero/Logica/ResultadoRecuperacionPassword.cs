namespace Logica
{
    public class ResultadoRecuperacionPassword
    {
        public bool Exitoso { get; set; }

        public string? CorreoDestinatario { get; set; }

        public string Error { get; set; } = string.Empty;

        public string? PasswordTemporalParaMostrar { get; set; }
    }
}
