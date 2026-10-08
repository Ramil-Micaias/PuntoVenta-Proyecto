namespace Logica
{
    // Resultado del proceso de recuperación de contraseña. La vista usa este objeto para
    // decidir qué mostrar: éxito, error, o una contraseña temporal si el correo falló.
    public class ResultadoRecuperacionPassword
    {
        // Indica que se generó una contraseña nueva y quedó guardada en la base.
        public bool Exitoso { get; set; }

        // Correo al que se envió la contraseña temporal, si es que se envió.
        public string? CorreoDestinatario { get; set; }

        // Mensaje de error cuando Exitoso es false.
        public string Error { get; set; } = string.Empty;

        // Contraseña temporal a mostrar por pantalla. Solo se completa cuando el envío
        // del correo falló, para que el usuario no quede nunca sin acceso al sistema.
        public string? PasswordTemporalParaMostrar { get; set; }
    }
}
