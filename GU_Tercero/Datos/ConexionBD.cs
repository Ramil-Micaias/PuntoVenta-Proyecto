namespace Datos
{
    // cadena de conexion a la base, la usan todos los DAO
    public class ConexionBD
    {
        // se conecta al SQL Express local con la base GU_TERCERO
        public static string cadenaConexion =
            @"Server=.\SQLEXPRESS;Database=GU_TERCERO;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
