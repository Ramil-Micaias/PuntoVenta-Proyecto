using Datos.Entidades;

namespace Logica
{
    public static class Sesion
    {
        public static Usuario? UsuarioActual { get; private set; }

        public static bool PuedeVerBitacora { get; private set; }

        public static void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
            PuedeVerBitacora = GestorBitacora.UsuarioTienePermiso(usuario.Id_Usuario, GestorBitacora.PERMISO_VER_BITACORA);
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
            PuedeVerBitacora = false;
        }
    }
}
