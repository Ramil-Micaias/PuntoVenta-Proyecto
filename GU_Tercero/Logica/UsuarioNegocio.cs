using Datos;
using Datos.Entidades;
using Logica.Seguridad;
using Seguridad;
using System.Data;
using System.Security.Cryptography;
using System.Text;

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

        //// Genera una contraseña temporal que cumple con la política de seguridad vigente.
        // Antes generaba 8 caracteres al azar sin importar la configuración: si el sistema
        // exigía mayúscula, número o carácter especial, la contraseña enviada podía incumplirla.
        private string GenerarPasswordTemporal(ConfiguracionSistema configuracion)
        {
            const string mayusculas = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string minusculas = "abcdefghijkmnopqrstuvwxyz";
            const string numeros = "23456789";
            const string especiales = "@#$%&*?";

            StringBuilder pool = new StringBuilder();
            List<char> obligatorios = new List<char>();

            pool.Append(minusculas);
            obligatorios.Add(Character(minusculas));

            if (configuracion.Requiere_Mayusculas)
            {
                pool.Append(mayusculas);
                obligatorios.Add(Character(mayusculas));
            }

            if (configuracion.Requiere_Numeros)
            {
                pool.Append(numeros);
                obligatorios.Add(Character(numeros));
            }

            if (configuracion.Requiere_Especial)
            {
                pool.Append(especiales);
                obligatorios.Add(Character(especiales));
            }

            int longitud = Math.Max(configuracion.Min_Caracteres, obligatorios.Count + 4);

            char[] password = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                password[i] = Character(pool.ToString());
            }

            // Se reemplazan las primeras posiciones por los caracteres obligatorios
            // para garantizar que la contraseña cumpla con la configuración.
            for (int i = 0; i < obligatorios.Count; i++)
            {
                password[i] = obligatorios[i];
            }

            return new string(password);
        }

        // Elige un carácter al azar de forma criptográficamente segura.
        private static char Character(string conjunto)
        {
            return conjunto[RandomNumberGenerator.GetInt32(conjunto.Length)];
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
            string passwordTemporal = GenerarPasswordTemporal(new ConfiguracionNegocio().ObtenerConfiguracion());

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

        // Este método valida la respuesta de seguridad ingresada contra la guardada para el usuario.
        // Se aceptan los dos formatos de hash del sistema: el actual (normalizado a minúsculas)
        // y el histórico de las pantallas que guardaban la respuesta sin normalizar. Sin esto,
        // los usuarios dados de alta por el administrador nunca podían recuperar su contraseña.
        public bool ValidarPreguntaSeguridad(string nombreUsuario, int idPregunta, string respuesta)
        {
            string hashGuardado = usuarioDAO.ObtenerHashRespuesta(nombreUsuario, idPregunta);

            if (string.IsNullOrEmpty(hashGuardado))
            {
                return false;
            }

            if (HashHelper.CompararHashSeguro(hashGuardado, HashHelper.GenerarHashRespuesta(respuesta)))
            {
                return true;
            }

            return HashHelper.CompararHashSeguro(hashGuardado, HashHelper.GenerarHashRespuestaLegado(respuesta));
        }

        // Este método genera una nueva contraseña temporal, la encripta y la envía al correo
        // registrado del usuario. El orden es intencional: primero se envía el correo y solo
        // después se guarda el hash en la base. Así, si el servidor de correo falla, la cuenta
        // conserva su contraseña anterior y el usuario no queda bloqueado sin acceso.
        public ResultadoRecuperacionPassword RecuperarPassword(string nombreUsuario)
        {
            ResultadoRecuperacionPassword resultado = new ResultadoRecuperacionPassword();

            Usuario usuario = usuarioDAO.Login(nombreUsuario);

            if (usuario == null || !usuario.Activo || usuario.Bloqueado)
            {
                resultado.Error = "El usuario no existe, está inactivo o se encuentra bloqueado.";

                return resultado;
            }

            string correo = usuarioDAO.ObtenerCorreoUsuario(nombreUsuario);

            if (string.IsNullOrWhiteSpace(correo))
            {
                resultado.Error = "El usuario no tiene un correo electrónico registrado y activo. "
                    + "Debe solicitar al administrador que registre su correo para poder recuperar la contraseña.";

                return resultado;
            }

            // Se genera una contraseña que cumple con la política de seguridad configurada.
            string passwordTemporal = GenerarPasswordTemporal(new ConfiguracionNegocio().ObtenerConfiguracion());

            string passwordHash = HashHelper.GenerarSHA256(nombreUsuario + passwordTemporal);

            string cuerpo = "Hola " + usuario.Nombre_Usuario + "," + Environment.NewLine + Environment.NewLine
                + "Se solicitó el restablecimiento de su contraseña." + Environment.NewLine
                + "Su contraseña temporal es: " + passwordTemporal + Environment.NewLine + Environment.NewLine
                + "Por seguridad, al ingresar con esta contraseña el sistema le solicitará definir una nueva.";

            ResultadoEnvioEmail envio = EmailHelper.EnviarCorreo(correo, "Recuperación de contraseña - Punto Venta", cuerpo);

            if (!envio.Enviado)
            {
                // No se toca la base: el usuario conserva su contraseña actual y el formulario
                // le muestra la contraseña temporal por pantalla para que no quede sin acceso.
                resultado.Error = envio.Error;
                resultado.PasswordTemporalParaMostrar = passwordTemporal;

                return resultado;
            }

            usuarioDAO.ReestablecerPassword(nombreUsuario, passwordHash);
            usuarioDAO.RegistrarHistorialPassword(usuario.Id_Usuario, passwordHash);

            resultado.Exitoso = true;
            resultado.CorreoDestinatario = correo;

            return resultado;
        }

        // Obtiene el correo electrónico asociado al usuario.
        public string ObtenerCorreoUsuario(string nombreUsuario)
        {
            return usuarioDAO.ObtenerCorreoUsuario(nombreUsuario);
        }
    }
}