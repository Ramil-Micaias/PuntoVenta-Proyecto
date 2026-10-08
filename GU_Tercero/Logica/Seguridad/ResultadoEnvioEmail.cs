namespace Seguridad
{
    // Resultado de un intento de envío de correo. Se devuelve un objeto en lugar de
    // dejar que la excepción se propague para que la interfaz pueda informar el motivo
    // real del fallo y decidir si debe mostrar una contraseña temporal por pantalla.
    public class ResultadoEnvioEmail
    {
        // Indica si el mensaje llegó a entregarse al servidor SMTP.
        public bool Enviado { get; set; }

        // Detalle del error cuando Enviado es false.
        public string Error { get; set; } = string.Empty;
    }
}
