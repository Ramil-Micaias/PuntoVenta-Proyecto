using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Logica
{
    // Bitácora del sistema (CU19). Se llama desde cada operación que hay que registrar:
    // recibe los datos y los guarda en la tabla Bitacora con quién la hizo y cuándo.
    // En las modificaciones guarda el estado anterior y el posterior en JSON
    // (solo los datos que cambiaron).
    public static class GestorBitacora
    {
        // Criticidad de cada operación.
        public const string CRITICA = "Crítica";
        public const string ADVERTENCIA = "Advertencia";
        public const string INFORMATIVA = "Informativa";

        // Módulos.
        public const string SEGURIDAD = "Seguridad";
        public const string USUARIOS = "Usuarios";
        public const string PRODUCTOS = "Productos";
        public const string PROVEEDORES = "Proveedores";
        public const string VENTAS = "Ventas";
        public const string COMPRAS = "Compras";
        public const string CAJA = "Caja";
        public const string CONFIGURACION = "Configuración";
        public const string BACKUP = "Backup";

        public static readonly string[] MODULOS = { SEGURIDAD, USUARIOS, PRODUCTOS, PROVEEDORES, VENTAS, COMPRAS, CAJA, CONFIGURACION, BACKUP };
        public static readonly string[] CRITICIDADES = { CRITICA, ADVERTENCIA, INFORMATIVA };

        // Permiso especial para consultar la bitácora.
        public const string PERMISO_VER_BITACORA = "VER_BITACORA";

        // Datos que no se guardan en los estados (no aportan o cambian solos).
        private static readonly HashSet<string> COLUMNAS_IGNORADAS = new HashSet<string>
        {
            "Fecha_Alta", "Ultimo_Login", "Intentos_Fallidos", "PasswordHash"
        };

        private static readonly JsonSerializerOptions opcionesJson = new JsonSerializerOptions
        {
            // Deja los acentos y la ñ legibles en el JSON.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private static readonly BitacoraDAO bitacoraDAO = new BitacoraDAO();

        // Registra una operación a nombre del usuario que tiene la sesión abierta.
        public static void Registrar(string modulo, string operacion, string criticidad,
            Dictionary<string, object?>? estadoAnterior = null, Dictionary<string, object?>? estadoPosterior = null)
        {
            var usuario = Sesion.UsuarioActual;
            RegistrarParaUsuario(usuario?.Nombre_Usuario ?? "(sin sesión)", modulo, operacion, criticidad, estadoAnterior, estadoPosterior);
        }

        // Registra una operación indicando el usuario (por ejemplo un ingreso fallido, sin sesión abierta).
        // El apellido y nombre y el rol los completa la base en el momento. Si la bitácora falla,
        // no se corta lo que estaba haciendo el usuario.
        public static void RegistrarParaUsuario(string nombreUsuario, string modulo, string operacion, string criticidad,
            Dictionary<string, object?>? estadoAnterior = null, Dictionary<string, object?>? estadoPosterior = null)
        {
            // Si el nombre ya termina en punto (por ejemplo "S.A.") no queda un punto doble.
            if (operacion.EndsWith(".."))
                operacion = operacion.Substring(0, operacion.Length - 1);

            try
            {
                bitacoraDAO.Registrar(nombreUsuario, null, null, modulo, operacion, criticidad,
                    ToJson(estadoAnterior), ToJson(estadoPosterior));
            }
            catch
            {
                // La operación del usuario ya se hizo: no se interrumpe por la bitácora.
            }
        }

        // Registra una modificación guardando solo los datos que cambiaron. Si no cambió nada, no registra.
        public static void RegistrarCambios(string modulo, string operacion, string criticidad,
            Dictionary<string, object?>? antes, Dictionary<string, object?>? despues)
        {
            var anterior = new Dictionary<string, object?>();
            var posterior = new Dictionary<string, object?>();

            if (antes != null && despues != null)
            {
                foreach (var dato in despues)
                {
                    antes.TryGetValue(dato.Key, out object? valorAnterior);

                    if (!Equals(Normalizar(valorAnterior), Normalizar(dato.Value)))
                    {
                        anterior[dato.Key] = valorAnterior;
                        posterior[dato.Key] = dato.Value;
                    }
                }

                if (posterior.Count == 0)
                    return;
            }

            Registrar(modulo, operacion, criticidad,
                anterior.Count > 0 ? anterior : antes, posterior.Count > 0 ? posterior : despues);
        }

        // Estado de un registro tomado de una fila de una consulta (sin los Id ni las columnas ignoradas).
        public static Dictionary<string, object?>? EstadoDeFila(DataTable tabla, string columnaId, int id)
        {
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila[columnaId] != DBNull.Value && Convert.ToInt32(fila[columnaId]) == id)
                {
                    var estado = new Dictionary<string, object?>();

                    foreach (DataColumn columna in tabla.Columns)
                    {
                        if (columna.ColumnName.StartsWith("Id_") || COLUMNAS_IGNORADAS.Contains(columna.ColumnName))
                            continue;

                        estado[columna.ColumnName] = fila[columna] == DBNull.Value ? null : fila[columna];
                    }

                    return estado;
                }
            }

            return null;
        }

        // Estado de un objeto (por ejemplo la configuración): sus propiedades públicas, sin los Id.
        public static Dictionary<string, object?> EstadoDeObjeto(object objeto)
        {
            var estado = new Dictionary<string, object?>();

            foreach (PropertyInfo propiedad in objeto.GetType().GetProperties())
            {
                if (propiedad.Name.StartsWith("Id_") || COLUMNAS_IGNORADAS.Contains(propiedad.Name))
                    continue;

                estado[propiedad.Name] = propiedad.GetValue(objeto);
            }

            return estado;
        }

        // ---------- Consulta ----------

        public static DataTable Listar(DateTime desde, DateTime hasta, string? criticidad, string? modulo, string? texto)
        {
            if (desde.Date > hasta.Date)
                throw new Exception("La fecha desde no puede ser posterior a la fecha hasta.");

            return bitacoraDAO.Listar(desde, hasta, criticidad, modulo, string.IsNullOrWhiteSpace(texto) ? null : texto.Trim());
        }

        public static bool UsuarioTienePermiso(int idUsuario, string codigo)
        {
            try
            {
                return bitacoraDAO.UsuarioTienePermiso(idUsuario, codigo);
            }
            catch
            {
                return false;
            }
        }

        // Muestra el JSON guardado con sangría para leerlo en pantalla.
        public static string FormatearJson(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return "(sin datos)";

            try
            {
                using JsonDocument documento = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(documento.RootElement,
                    new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            }
            catch
            {
                return json;
            }
        }

        private static string? ToJson(Dictionary<string, object?>? estado)
        {
            if (estado == null || estado.Count == 0)
                return null;

            var limpio = new Dictionary<string, object?>();
            foreach (var dato in estado)
                limpio[dato.Key] = Normalizar(dato.Value);

            return JsonSerializer.Serialize(limpio, opcionesJson);
        }

        // Pasa los valores a tipos simples para compararlos y guardarlos igual.
        private static object? Normalizar(object? valor)
        {
            switch (valor)
            {
                case null:
                case DBNull:
                    return null;
                case string texto:
                    return texto.Trim();
                case bool booleano:
                    return booleano;
                case DateTime fecha:
                    return fecha.ToString("yyyy-MM-dd HH:mm:ss");
                case decimal or double or float:
                    return Convert.ToDecimal(valor);
                case int or long or short or byte:
                    return Convert.ToInt64(valor);
                default:
                    return valor.ToString();
            }
        }
    }
}
