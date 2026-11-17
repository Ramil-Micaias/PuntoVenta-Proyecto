using Datos;
using Datos.Entidades;
using Logica.Seguridad;

namespace Logica
{
    // logica de la configuracion del sistema y de las politicas de contrasenia
    public class ConfiguracionNegocio
    {
        ConfiguracionDAO configuracionDAO = new ConfiguracionDAO();
        
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        // lee la configuracion
        public ConfiguracionSistema ObtenerConfiguracion()
        {
            return configuracionDAO.ObtenerConfiguracion();
        }

        // al recuperar la contrasenia se piden 2 o 3 preguntas
        public const int MINIMO_PREGUNTAS_RECUPERAR = 2;
        public const int MAXIMO_PREGUNTAS_RECUPERAR = 3;

        // valida y guarda la configuracion, queda en la bitacora como critica
        public void GuardarConfiguracion(ConfiguracionSistema configuracion)
        {
            if (configuracion.Cantidad_Preguntas < MINIMO_PREGUNTAS_RECUPERAR || configuracion.Cantidad_Preguntas > MAXIMO_PREGUNTAS_RECUPERAR)
                throw new Exception("La cantidad de preguntas al recuperar debe ser " + MINIMO_PREGUNTAS_RECUPERAR + " o " + MAXIMO_PREGUNTAS_RECUPERAR + ".");

            var antes = GestorBitacora.EstadoDeObjeto(configuracionDAO.ObtenerConfiguracion());

            configuracionDAO.GuardarConfiguracion(configuracion);

            GestorBitacora.RegistrarCambios(GestorBitacora.CONFIGURACION, "Cambio en la configuración del sistema.",
                GestorBitacora.CRITICA, antes, GestorBitacora.EstadoDeObjeto(configuracionDAO.ObtenerConfiguracion()));
        }

        // revisa que la contrasenia cumpla las politicas, devuelve OK o el mensaje de error
        public string ValidarPassword(string password, Usuario usuario)
        {
            ConfiguracionSistema configuracion = configuracionDAO.ObtenerConfiguracion();

            Persona persona = usuarioDAO.ObtenerPersona(usuario.Id_Usuario);

            if (password.Length < configuracion.Min_Caracteres)
            {
                return $"La contraseña debe tener al menos {configuracion.Min_Caracteres} caracteres.";
            }

            if (configuracion.Requiere_Mayusculas)
            {
                bool tieneMayuscula = false;

                foreach (char caracter in password)
                {
                    if (char.IsUpper(caracter))
                    {
                        tieneMayuscula = true;
                        break;
                    }
                }

                if (!tieneMayuscula)
                {
                    return "La contraseña debe contener al menos una letra mayúscula.";
                }
            }

            if (configuracion.Requiere_Numeros)
            {
                bool tieneNumero = false;

                foreach (char caracter in password)
                {
                    if (char.IsDigit(caracter))
                    {
                        tieneNumero = true;
                        break;
                    }
                }

                if (!tieneNumero)
                {
                    return "La contraseña debe contener al menos un número.";
                }
            }

            if (configuracion.Requiere_Especial)
                {
                    bool tieneCaracterEspecial = false;

                    foreach (char caracter in password)
                    {
                        if (!char.IsLetterOrDigit(caracter))
                        {
                            tieneCaracterEspecial = true;
                            break;
                        }
                    }

                    if (!tieneCaracterEspecial)
                    {
                        return "La contraseña debe contener al menos un carácter especial.";
                    }
                }

            // no puede tener el nombre, el apellido ni el DNI
            if (configuracion.Validar_DatosPersonales)
            {
                if (!string.IsNullOrWhiteSpace(persona.Nombre))
                {
                    if (password.ToLower().Contains(persona.Nombre.ToLower()))
                    {
                        return "La contraseña no puede contener el nombre.";
                    }
                }

                if (!string.IsNullOrWhiteSpace(persona.Apellido))
                {
                    if (password.ToLower().Contains(persona.Apellido.ToLower()))
                    {
                        return "La contraseña no puede contener el apellido.";
                    }
                }

                if (!string.IsNullOrWhiteSpace(persona.DNI))
                {
                    if (password.Contains(persona.DNI))
                    {
                        return "La contraseña no puede contener el DNI.";
                    }
                }
            }

            // no puede ser una contrasenia que ya uso
            if (configuracion.No_RepetirPasswords)
            {
                string passwordHash = HashHelper.GenerarHashPassword(usuario.Nombre_Usuario, password);

                if (usuarioDAO.ExistePasswordHistorial(usuario.Id_Usuario, passwordHash))
                {
                    return "La contraseña ya fue utilizada anteriormente.";
                }
            }

            return "OK";
        }
    }
}   
