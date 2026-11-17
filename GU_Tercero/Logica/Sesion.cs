using Datos.Entidades;

namespace Logica
{
    // guarda el usuario que esta logueado para usarlo en todo el programa
    public static class Sesion
    {
        public static Usuario? UsuarioActual { get; private set; }

        // se calcula una vez al iniciar sesion para no consultar la base cada vez
        public static bool PuedeVerBitacora { get; private set; }

        // arranca la sesion y se fija si tiene el permiso de bitacora
        public static void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
            PuedeVerBitacora = GestorBitacora.UsuarioTienePermiso(usuario.Id_Usuario, GestorBitacora.PERMISO_VER_BITACORA);
        }

        // limpia la sesion al salir
        public static void Cerrar()
        {
            UsuarioActual = null;
            PuedeVerBitacora = false;
        }
    }
}
