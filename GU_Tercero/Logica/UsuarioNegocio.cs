using Datos;
using Datos.Entidades;
using Logica.Seguridad;
using Seguridad;
using System.Data;

namespace Logica
{
    //La clase UsuarioNegocio pertenece a la capa de negocio y contiene las reglas principales del sistema.
    //Se encarga de validar accesos, controlar seguridad, aplicar restricciones y coordinar la comunicación entre la interfaz y la capa de datos.
    public class UsuarioNegocio
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        //método ValidarLogin: Centraliza toda la lógica de autenticación y
        //seguridad del login, incluyendo validación de contraseña, bloqueo por intentos fallidos y actualización de accesos.
        public Usuario ValidarLogin(string nombreUsuario, string password)
        {
            Usuario usuario = usuarioDAO.Login(nombreUsuario);

            if (usuario == null)
                return null;

            if (usuario.Bloqueado || !usuario.Activo)
                return null;

            string passwordHash = HashHelper.GenerarSHA256(nombreUsuario + password);

            //Si coincide: Reinicia intentos, Actualiza ultimo LOGIN, devuelve el usuario correspondiente.
            if (usuario.PasswordHash == passwordHash)
            {
                usuarioDAO.ReiniciarIntentos(usuario.Id_Usuario);
                usuarioDAO.ActualizarUltimoLogin(usuario.Id_Usuario);

                return usuario;
            }

            //Si no coincide: Aumenta Intentos, Verifica si llego al limite y bloquea el usuario correspondiente.
            usuarioDAO.AumentarIntentos(usuario.Id_Usuario);

            usuario = usuarioDAO.Login(nombreUsuario);

            if (usuario.Intentos_Fallidos >= 3)
                usuarioDAO.BloquearUsuario(usuario.Id_Usuario);

            return null;
        }

        //método Actualiza la contraseña del usuario y registra el cambio en el historial.
        public void CambiarPassword(int idUsuario, string passwordHash)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.CambiarPassword(idUsuario, passwordHash);

            dao.RegistrarHistorialPassword(idUsuario, passwordHash);
        }
        
        // Registra la contraseña utilizada por el usuario en el historial.
        public void RegistrarHistorialPassword(int idUsuario, string passwordHash)
        {
            usuarioDAO.RegistrarHistorialPassword(idUsuario, passwordHash);
        }

        //método ObtenerPreguntas: Le pide a DAO las Preguntas de Seguridad.
        public List<PreguntasSeguridad> ObtenerPreguntas()
        {
            return usuarioDAO.ObtenerPreguntas();
        }

        //método GuardarPreguntaSeguridad: recibe los datos desde la Vista y le pide al DAO que los guarde en SQL Server.
        //para luego validar identidad del usuario más adelante.
        public void GuardarPreguntaSeguridad(int idUsuario, int idPregunta, string respuestaHash)
        {
            usuarioDAO.GuardarPreguntaSeguridad(idUsuario, idPregunta, respuestaHash);
        }

        //metodo UsuarioTienePreguntas: Determina si el usuario ya configuró preguntas de seguridad.
        public bool UsuarioTienePreguntas(int idUsuario)
        {
            return usuarioDAO.UsuarioTienePreguntas(idUsuario);
        }

        //método ObtenerUsuarios: Le pide al DAO los usuarios y devuelve el DataTable a la Vista.
        public DataTable ObtenerUsuarios()
        {
            return usuarioDAO.ObtenerUsuarios();
        }

        //método ObtenerRoles: Pide al DAO los roles y los devuelve a la Vista.
        public DataTable ObtenerRoles()
        {
            return usuarioDAO.ObtenerRoles();
        }

        //// Genera una contraseña temporal de 8 caracteres utilizando letras y números.
        // Esta contraseña será utilizada en el primer ingreso del usuario al sistema.
        private string GenerarPasswordTemporal()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            //Crea un objeto que genera números aleatorios.
            Random random = new Random();

            string password = "";

            //Crea un ciclo que se repetirá 8 veces. Porque queremos una contraseña de 8 caracteres.
            for (int i = 0; i < 8; i++)
            {
                //elige una posición aleatoria.
                password += caracteres[random.Next(caracteres.Length)];
            }

            return password;
        }

        public bool ExisteDni(string dni)
        {
            return usuarioDAO.ExisteDni(dni);
        }

        //// Genera una contraseña temporal, calcula su hash SHA256 junto al nombre de usuario
        // y registra el nuevo usuario con sus datos personales, correo y rol asignado.
        public string InsertarUsuarioCompleto(string apellido, string nombre, string dni, string correo, string nombreUsuario, int idRol)
        {
            if (usuarioDAO.ExisteDni(dni))
            {
                throw new Exception("El DNI ingresado ya se encuentra registrado en el sistema.");
            }

            // 2. Proceso normal
            string passwordTemporal = GenerarPasswordTemporal();

            string passwordHash = HashHelper.GenerarSHA256(nombreUsuario + passwordTemporal);

            int idUsuario = usuarioDAO.InsertarUsuarioCompleto(apellido, nombre, dni, correo, nombreUsuario, passwordHash, idRol);

            RegistrarHistorialPassword(idUsuario, passwordHash);

            return passwordTemporal;
        }

        //Recibe los datos modificados del usuario y coordina su actualización
        //mediante la capa de acceso a datos.
        public void ModificarUsuario(int idUsuario, string apellido, string nombre, string dni, string correo, string nombreUsuario, int idRol, bool activo, bool bloqueado)
        {
            usuarioDAO.ModificarUsuario(idUsuario, apellido, nombre, dni, correo, nombreUsuario, idRol, activo, bloqueado);
        }

        // Gestiona la baja lógica de un usuario y delega la operación a la capa de acceso a datos.
        public void DesactivarUsuario(int idUsuario)
        {
            usuarioDAO.DesactivarUsuario(idUsuario);
        }

        // Este método solicita a la capa de datos las preguntas de seguridad del usuario.
        public DataTable ObtenerPreguntasUsuario(string nombreUsuario)
        {
            return usuarioDAO.ObtenerPreguntasUsuario(nombreUsuario);
        }

        // Este método genera el hash SHA256 de la respuesta ingresada y solicita su validación a la capa de datos.
        public bool ValidarPreguntaSeguridad(string nombreUsuario, int idPregunta, string respuesta)
        {
            string respuestaHash = SeguridadHelper.GenerarSHA256(respuesta.Trim());

            return usuarioDAO.ValidarPreguntaSeguridad(nombreUsuario, idPregunta, respuestaHash);
        }

        // Este método genera una nueva contraseña temporal, la encripta, actualiza la base de datos y la envía
        // al correo registrado del usuario.
        public string RecuperarPassword(string nombreUsuario)
        {
            //Genera una contraseña aleatoria
            string passwordTemporal = GenerarPasswordTemporal();

            //La encripta
            string passwordHash = SeguridadHelper.GenerarSHA256(nombreUsuario + passwordTemporal);

            //Actualiza la base
            usuarioDAO.ReestablecerPassword(nombreUsuario, passwordHash);

            //Obtiene el correo
            string correo = usuarioDAO.ObtenerCorreoUsuario(nombreUsuario);

            //Envía el correo
            EmailHelper.EnviarCorreo(correo, "Recuperación de contraseña", "Su nueva contraseña temporal es: " + passwordTemporal);

            return passwordTemporal;
        }

        // Obtiene el correo electrónico asociado al usuario.
        public string ObtenerCorreoUsuario(string nombreUsuario)
        {
            return usuarioDAO.ObtenerCorreoUsuario(nombreUsuario);
        }
    }
}