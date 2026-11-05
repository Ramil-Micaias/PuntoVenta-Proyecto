using Datos;
using Datos.Entidades;
using Logica.Seguridad;

namespace Logica
{
    public class ConfiguracionNegocio
    {
        ConfiguracionDAO configuracionDAO = new ConfiguracionDAO();
        
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        public ConfiguracionSistema ObtenerConfiguracion()
        {
            return configuracionDAO.ObtenerConfiguracion();
        }

        public void GuardarConfiguracion(ConfiguracionSistema configuracion)
        {
            var antes = GestorBitacora.EstadoDeObjeto(configuracionDAO.ObtenerConfiguracion());

            configuracionDAO.GuardarConfiguracion(configuracion);

            GestorBitacora.RegistrarCambios(GestorBitacora.CONFIGURACION, "Cambio en la configuración del sistema.",
                GestorBitacora.CRITICA, antes, GestorBitacora.EstadoDeObjeto(configuracionDAO.ObtenerConfiguracion()));
        }

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
