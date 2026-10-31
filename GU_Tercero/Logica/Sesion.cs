using Datos.Entidades;

namespace Logica
{
    // Usuario que tiene la sesión abierta. Se usa para saber quién hizo cada
    // operación al registrarla en la bitácora y qué permisos especiales tiene.
    // Los ingresos correctos no se registran en la bitácora (solo los fallidos y los bloqueos).
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
