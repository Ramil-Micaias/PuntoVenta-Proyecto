namespace Logica
{
    // resultado de recuperar la contrasenia
    public class ResultadoRecuperacionPassword
    {
        public bool Exitoso { get; set; }

        public string? CorreoDestinatario { get; set; }

        public string Error { get; set; } = string.Empty;

        // si no se pudo mandar el mail se muestra en pantalla
        public string? PasswordTemporalParaMostrar { get; set; }
    }
}
