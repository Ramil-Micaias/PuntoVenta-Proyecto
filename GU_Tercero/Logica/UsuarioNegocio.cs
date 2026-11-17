using Datos;
using Datos.Entidades;
using Logica.Seguridad;
using Seguridad;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Logica
{
    // logica de usuarios: login, contrasenias, preguntas y ABM
    public class UsuarioNegocio
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        // valida usuario y contrasenia, si esta mal suma intentos y al tercero lo bloquea
        public Usuario ValidarLogin(string nombreUsuario, string password)
        {
            Usuario usuario = usuarioDAO.Login(nombreUsuario);

            if (usuario == null)
            {
                GestorBitacora.RegistrarParaUsuario(nombreUsuario, GestorBitacora.SEGURIDAD,
                    "Ingreso fallido: el usuario no existe.", GestorBitacora.ADVERTENCIA);
                return null;
            }

            if (usuario.Bloqueado || !usuario.Activo)
            {
                GestorBitacora.RegistrarParaUsuario(usuario.Nombre_Usuario, GestorBitacora.SEGURIDAD,
                    "Intento de ingreso de un usuario " + (usuario.Bloqueado ? "bloqueado." : "inactivo."), GestorBitacora.ADVERTENCIA);
                return null;
            }

            // si el digito verificador no coincide es porque alguien toco la contrasenia en la base
            if (!HashHelper.DigitoVerificadorValido(usuario.PasswordHash))
            {
                GestorBitacora.RegistrarParaUsuario(usuario.Nombre_Usuario, GestorBitacora.SEGURIDAD,
                    "Ingreso rechazado: la contraseña guardada no coincide con su dígito verificador.", GestorBitacora.CRITICA);
                return null;
            }

            string passwordHash = HashHelper.GenerarHashPassword(nombreUsuario, password);

            if (usuario.PasswordHash == passwordHash)
            {
                usuarioDAO.ReiniciarIntentos(usuario.Id_Usuario);
                usuarioDAO.ActualizarUltimoLogin(usuario.Id_Usuario);

                return usuario;
            }

            // contrasenia incorrecta: sumamos el intento y lo volvemos a leer para saber cuantos lleva
            usuarioDAO.AumentarIntentos(usuario.Id_Usuario);

            usuario = usuarioDAO.Login(nombreUsuario);

            GestorBitacora.RegistrarParaUsuario(usuario.Nombre_Usuario, GestorBitacora.SEGURIDAD,
                "Ingreso fallido: contraseña incorrecta (intento " + usuario.Intentos_Fallidos + " de " + INTENTOS_MAXIMOS_LOGIN + ").",
                GestorBitacora.ADVERTENCIA);

            if (usuario.Intentos_Fallidos >= INTENTOS_MAXIMOS_LOGIN)
            {
                usuarioDAO.BloquearUsuario(usuario.Id_Usuario);
                GestorBitacora.RegistrarParaUsuario(usuario.Nombre_Usuario, GestorBitacora.SEGURIDAD,
                    "Usuario bloqueado por superar los " + INTENTOS_MAXIMOS_LOGIN + " intentos fallidos.", GestorBitacora.CRITICA,
                    new Dictionary<string, object?> { ["Bloqueado"] = false }, new Dictionary<string, object?> { ["Bloqueado"] = true });
            }

            return null;
        }

        // a los 3 intentos fallidos se bloquea
        public const int INTENTOS_MAXIMOS_LOGIN = 3;

        // arma el mensaje con los intentos que le quedan
        public string MensajeLoginFallido(string nombreUsuario)
        {
            Usuario usuario = usuarioDAO.Login(nombreUsuario);

            if (usuario == null)
                return "Usuario o contraseña incorrectos.";

            if (usuario.Bloqueado)
                return "El usuario está bloqueado por superar los " + INTENTOS_MAXIMOS_LOGIN + " intentos fallidos.\n"
                    + "Solicite al administrador que lo desbloquee o recupere su contraseña.";

            if (!usuario.Activo)
                return "El usuario está inactivo. Comuníquese con el administrador.";

            if (!HashHelper.DigitoVerificadorValido(usuario.PasswordHash))
                return "No se pudo validar la contraseña: la contraseña guardada fue alterada.\n"
                    + "Recupere su contraseña o comuníquese con el administrador.";

            int restantes = INTENTOS_MAXIMOS_LOGIN - usuario.Intentos_Fallidos;

            return "Usuario o contraseña incorrectos.\n"
                + "Intentos restantes: " + restantes + ". Si se agotan, el usuario se bloquea.";
        }

        // cambia la contrasenia y lo registra en la bitacora
        public void CambiarPassword(int idUsuario, string passwordHash)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.CambiarPassword(idUsuario, passwordHash);

            dao.RegistrarHistorialPassword(idUsuario, passwordHash);

            var estado = EstadoUsuario(idUsuario);
            string nombreUsuario = estado?["Nombre_Usuario"]?.ToString() ?? ("Id " + idUsuario);
            GestorBitacora.RegistrarParaUsuario(nombreUsuario, GestorBitacora.SEGURIDAD, "Cambio de contraseña.", GestorBitacora.ADVERTENCIA);
        }

        // datos del usuario para la bitacora
        private Dictionary<string, object?>? EstadoUsuario(int idUsuario)
        {
            try
            {
                return GestorBitacora.EstadoDeFila(usuarioDAO.ObtenerUsuarios(), "Id_Usuario", idUsuario);
            }
            catch
            {
                return null;
            }
        }
        
        // guarda la contrasenia en el historial
        public void RegistrarHistorialPassword(int idUsuario, string passwordHash)
        {
            usuarioDAO.RegistrarHistorialPassword(idUsuario, passwordHash);
        }

        // guarda una respuesta del usuario
        public void GuardarPreguntaSeguridad(int idUsuario, int idPregunta, string respuestaHash)
        {
            usuarioDAO.GuardarPreguntaSeguridad(idUsuario, idPregunta, respuestaHash);
        }

        // cada usuario carga siempre 3 preguntas
        public const int TOTAL_PREGUNTAS = 3;

        // true si ya cargo las 3 preguntas
        public bool UsuarioTienePreguntas(int idUsuario)
        {
            return usuarioDAO.CantidadPreguntasUsuario(idUsuario) >= TOTAL_PREGUNTAS;
        }

        // usuarios para la grilla
        public DataTable ObtenerUsuarios()
        {
            return usuarioDAO.ObtenerUsuarios();
        }

        // el rol Usuario no se ofrece al crear o modificar
        public const string ROL_NO_ASIGNABLE = "Usuario";

        // roles que se pueden asignar (saca el rol Usuario)
        public DataTable ObtenerRoles()
        {
            DataTable roles = usuarioDAO.ObtenerRoles();

            foreach (DataRow fila in roles.Select("Nombre_Rol = '" + ROL_NO_ASIGNABLE + "'"))
                roles.Rows.Remove(fila);

            return roles;
        }

        // genera una contrasenia al azar que cumple la configuracion
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

            // el largo es el minimo configurado, o mas si hacen falta los caracteres obligatorios
            int longitud = Math.Max(configuracion.Min_Caracteres, obligatorios.Count + 4);

            char[] password = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                password[i] = Character(pool.ToString());
            }

            for (int i = 0; i < obligatorios.Count; i++)
            {
                password[i] = obligatorios[i];
            }

            return new string(password);
        }

        // devuelve un caracter al azar del conjunto
        private static char Character(string conjunto)
        {
            return conjunto[RandomNumberGenerator.GetInt32(conjunto.Length)];
        }

        // valida, crea el usuario con una contrasenia temporal y devuelve esa contrasenia
        public string InsertarUsuarioCompleto(string apellido, string nombre, string dni, string correo, string nombreUsuario, int idRol)
        {
            ValidarDatosUsuario(0, apellido, nombre, dni, correo, nombreUsuario, idRol);

            string passwordTemporal = GenerarPasswordTemporal(new ConfiguracionNegocio().ObtenerConfiguracion());

            string passwordHash = HashHelper.GenerarHashPassword(nombreUsuario, passwordTemporal);

            int idUsuario = usuarioDAO.InsertarUsuarioCompleto(apellido, nombre, dni, correo, nombreUsuario, passwordHash, idRol);

            RegistrarHistorialPassword(idUsuario, passwordHash);

            GestorBitacora.Registrar(GestorBitacora.USUARIOS, "Alta del usuario " + nombreUsuario.Trim() + ".", GestorBitacora.INFORMATIVA,
                null, EstadoUsuario(idUsuario));

            return passwordTemporal;
        }

        // valida y modifica el usuario, en la bitacora queda lo que cambio
        public void ModificarUsuario(int idUsuario, string apellido, string nombre, string dni, string correo, string nombreUsuario, int idRol, bool activo, bool bloqueado)
        {
            ValidarDatosUsuario(idUsuario, apellido, nombre, dni, correo, nombreUsuario, idRol);

            var antes = EstadoUsuario(idUsuario);

            usuarioDAO.ModificarUsuario(idUsuario, apellido, nombre, dni, correo, nombreUsuario, idRol, activo, bloqueado);

            var despues = EstadoUsuario(idUsuario);

            bool cambioRol = antes != null && despues != null && !Equals(antes["Nombre_Rol"], despues["Nombre_Rol"]);
            GestorBitacora.RegistrarCambios(GestorBitacora.USUARIOS,
                (cambioRol ? "Cambio de rol del usuario " : "Modificación del usuario ") + nombreUsuario.Trim() + ".",
                cambioRol ? GestorBitacora.CRITICA : GestorBitacora.ADVERTENCIA, antes, despues);
        }

        // valida todos los datos del usuario y que no esten repetidos
        public void ValidarDatosUsuario(int idUsuario, string apellido, string nombre, string dni, string correo, string nombreUsuario, int idRol)
        {
            if (string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dni)
                || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(nombreUsuario) || idRol <= 0)
                throw new Exception("Debe completar todos los campos obligatorios.");

            if (ObtenerRoles().Select("Id_Rol = " + idRol).Length == 0)
                throw new Exception("Debe elegir un rol válido.");

            if (!Validaciones.EsNombreValido(apellido))
                throw new Exception("El apellido solo puede tener letras y espacios (hasta 50 caracteres).");

            if (!Validaciones.EsNombreValido(nombre))
                throw new Exception("El nombre solo puede tener letras y espacios (hasta 50 caracteres).");

            if (!Validaciones.EsDniValido(dni))
                throw new Exception("El DNI debe tener 7 u 8 números, sin puntos.");

            if (!Validaciones.EsEmailValido(correo))
                throw new Exception("El correo no es válido. Debe tener el formato nombre@dominio.com.");

            if (!Validaciones.EsNombreUsuarioValido(nombreUsuario))
                throw new Exception("El nombre de usuario debe tener entre 3 y 50 caracteres, sin espacios (letras, números, punto, guion o guion bajo).");

            if (usuarioDAO.ExisteDniEnOtroUsuario(dni.Trim(), idUsuario))
                throw new Exception("Ya existe un usuario con el DNI ingresado.");

            if (idUsuario > 0 && usuarioDAO.ExisteDniDeOtraPersona(dni.Trim(), idUsuario))
                throw new Exception("El DNI ingresado ya pertenece a otra persona registrada en el sistema.");

            if (usuarioDAO.ExisteCorreoDeOtraPersona(correo.Trim(), dni.Trim(), idUsuario))
                throw new Exception("El correo ingresado ya está registrado para otra persona.");

            if (usuarioDAO.ExisteNombreUsuario(nombreUsuario.Trim(), idUsuario))
                throw new Exception("El nombre de usuario ya está en uso.");
        }

        // baja logica del usuario
        public void DesactivarUsuario(int idUsuario)
        {
            var antes = EstadoUsuario(idUsuario);
            usuarioDAO.DesactivarUsuario(idUsuario);

            GestorBitacora.RegistrarCambios(GestorBitacora.USUARIOS, "Inactivación del usuario " + antes?["Nombre_Usuario"] + ".",
                GestorBitacora.CRITICA, antes, EstadoUsuario(idUsuario));
        }

        // vuelve a activar el usuario
        public void ActivarUsuario(int idUsuario)
        {
            var antes = EstadoUsuario(idUsuario);

            usuarioDAO.ActivarUsuario(idUsuario);
            usuarioDAO.DesbloquearUsuario(idUsuario);

            GestorBitacora.RegistrarCambios(GestorBitacora.USUARIOS, "Activación del usuario " + antes?["Nombre_Usuario"] + ".",
                GestorBitacora.ADVERTENCIA, antes, EstadoUsuario(idUsuario));
        }

        // desbloquea el usuario
        public void DesbloquearUsuario(int idUsuario)
        {
            var antes = EstadoUsuario(idUsuario);

            usuarioDAO.DesbloquearUsuario(idUsuario);

            GestorBitacora.RegistrarCambios(GestorBitacora.USUARIOS, "Desbloqueo del usuario " + antes?["Nombre_Usuario"] + ".",
                GestorBitacora.ADVERTENCIA, antes, EstadoUsuario(idUsuario));
        }

        // preguntas del usuario para recuperar la contrasenia
        public DataTable ObtenerPreguntasUsuario(string nombreUsuario)
        {
            return usuarioDAO.ObtenerPreguntasUsuario(nombreUsuario);
        }

        // compara la respuesta con la guardada
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

        // genera una contrasenia temporal y se la manda por mail
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

            string passwordTemporal = GenerarPasswordTemporal(new ConfiguracionNegocio().ObtenerConfiguracion());

            string passwordHash = HashHelper.GenerarHashPassword(nombreUsuario, passwordTemporal);

            string cuerpo = "Hola " + usuario.Nombre_Usuario + "," + Environment.NewLine + Environment.NewLine
                + "Se solicitó el restablecimiento de su contraseña." + Environment.NewLine
                + "Su contraseña temporal es: " + passwordTemporal + Environment.NewLine + Environment.NewLine
                + "Por seguridad, al ingresar con esta contraseña el sistema le solicitará definir una nueva.";

            ResultadoEnvioEmail envio = EmailHelper.EnviarCorreo(correo, "Recuperación de contraseña - Punto Venta", cuerpo);

            // si no se pudo mandar el mail no se cambia la contrasenia
            if (!envio.Enviado)
            {
                resultado.Error = envio.Error;
                resultado.PasswordTemporalParaMostrar = passwordTemporal;

                return resultado;
            }

            usuarioDAO.ReestablecerPassword(nombreUsuario, passwordHash);
            usuarioDAO.RegistrarHistorialPassword(usuario.Id_Usuario, passwordHash);

            resultado.Exitoso = true;
            resultado.CorreoDestinatario = correo;

            GestorBitacora.RegistrarParaUsuario(usuario.Nombre_Usuario, GestorBitacora.SEGURIDAD,
                "Recuperación de contraseña: se envió una contraseña temporal al correo.", GestorBitacora.ADVERTENCIA);

            return resultado;
        }

        // manda por mail la contrasenia temporal al usuario nuevo
        public ResultadoEnvioEmail EnviarPasswordInicial(string correo, string nombreUsuario, string passwordTemporal)
        {
            string cuerpo = "Hola " + nombreUsuario + "," + Environment.NewLine + Environment.NewLine
                + "Se creó su usuario para ingresar al sistema." + Environment.NewLine
                + "Usuario: " + nombreUsuario + Environment.NewLine
                + "Contraseña temporal: " + passwordTemporal + Environment.NewLine + Environment.NewLine
                + "Al ingresar por primera vez el sistema le solicitará definir una nueva contraseña.";

            return EmailHelper.EnviarCorreo(correo, "Alta de usuario - Punto Venta", cuerpo);
        }

    }
}