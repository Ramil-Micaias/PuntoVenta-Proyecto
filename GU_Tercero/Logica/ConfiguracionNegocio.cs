using Datos;
using Datos.Entidades;
using Logica.Seguridad;

namespace Logica
{
    // La clase ConfiguracionNegocio pertenece a la capa de negocio y se
    // encarga de coordinar la obtención y actualización de la configuración
    // del sistema entre la Vista y la capa de Datos.
    public class ConfiguracionNegocio
    {
        ConfiguracionDAO configuracionDAO = new ConfiguracionDAO();
        
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        // Obtiene la configuración actual del sistema.
        public ConfiguracionSistema ObtenerConfiguracion()
        {
            return configuracionDAO.ObtenerConfiguracion();
        }

        // Guarda la configuración modificada por el administrador.
        public void GuardarConfiguracion(ConfiguracionSistema configuracion)
        {
            configuracionDAO.GuardarConfiguracion(configuracion);
        }

        //Este método valida que la contraseña cumpla con las políticas de seguridad configuradas.
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

            // Verifica que la contraseña contenga al menos un carácter especial.
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

            if (configuracion.No_RepetirPasswords)
            {
                string passwordHash = HashHelper.GenerarSHA256(usuario.Nombre_Usuario + password);

                if (usuarioDAO.ExistePasswordHistorial(usuario.Id_Usuario, passwordHash))
                {
                    return "La contraseña ya fue utilizada anteriormente.";
                }
            }

            return "OK";
        }
    }
}   
