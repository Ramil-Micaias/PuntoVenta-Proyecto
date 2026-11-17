using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Logica
{
    // todo lo de la bitacora: registrar movimientos, listarlos y filtrarlos
    public static class GestorBitacora
    {
        // niveles de criticidad
        public const string CRITICA = "Crítica";
        public const string ADVERTENCIA = "Advertencia";
        public const string INFORMATIVA = "Informativa";

        // modulos del sistema
        public const string SEGURIDAD = "Seguridad";
        public const string USUARIOS = "Usuarios";
        public const string PRODUCTOS = "Productos";
        public const string PROVEEDORES = "Proveedores";
        public const string VENTAS = "Ventas";
        public const string COMPRAS = "Compras";
        public const string CAJA = "Caja";
        public const string CONFIGURACION = "Configuración";
        public const string BACKUP = "Backup";

        // criticidades para el combo del filtro de la bitacora
        public static readonly string[] CRITICIDADES = { CRITICA, ADVERTENCIA, INFORMATIVA };

        // permiso que hace falta para ver la bitacora
        public const string PERMISO_VER_BITACORA = "VER_BITACORA";

        // columnas que no se guardan en los estados
        private static readonly HashSet<string> COLUMNAS_IGNORADAS = new HashSet<string>
        {
            "Fecha_Alta", "Ultimo_Login", "Intentos_Fallidos", "PasswordHash"
        };

        private static readonly JsonSerializerOptions opcionesJson = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private static readonly BitacoraDAO bitacoraDAO = new BitacoraDAO();

        // registra con el usuario logueado
        public static void Registrar(string modulo, string operacion, string criticidad,
            Dictionary<string, object?>? estadoAnterior = null, Dictionary<string, object?>? estadoPosterior = null)
        {
            var usuario = Sesion.UsuarioActual;
            RegistrarParaUsuario(usuario?.Nombre_Usuario ?? "(sin sesión)", modulo, operacion, criticidad, estadoAnterior, estadoPosterior);
        }

        // registra a nombre de un usuario (sirve en el login, donde todavia no hay sesion)
        public static void RegistrarParaUsuario(string nombreUsuario, string modulo, string operacion, string criticidad,
            Dictionary<string, object?>? estadoAnterior = null, Dictionary<string, object?>? estadoPosterior = null)
        {
            if (operacion.EndsWith(".."))
                operacion = operacion.Substring(0, operacion.Length - 1);

            try
            {
                bitacoraDAO.Registrar(nombreUsuario, null, null, modulo, operacion, criticidad,
                    ToJson(estadoAnterior), ToJson(estadoPosterior));
            }
            // si falla la bitacora no cortamos la operacion del usuario
            catch
            {
            }
        }

        // guarda solo los datos que cambiaron, si no cambio nada no registra
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

        // arma el estado de una fila de una tabla (sin los Id)
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

        // arma el estado de un objeto con sus propiedades
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

        // todos los movimientos
        public static DataTable ListarTodo()
        {
            return bitacoraDAO.Listar(new DateTime(2000, 1, 1), DateTime.Today, null, null, null);
        }

        // usuarios distintos que aparecen, para el combo del filtro
        public static List<string> UsuariosDe(DataTable movimientos)
        {
            return movimientos.AsEnumerable()
                .Select(fila => (fila["Usuario"] as string ?? string.Empty).Trim())
                .Where(usuario => usuario != string.Empty)
                .Distinct()
                .OrderBy(usuario => usuario)
                .ToList();
        }

        // filtra los movimientos ya cargados por usuario, fecha, hora, movimiento y criticidad
        public static DataTable Filtrar(DataTable movimientos, string? usuario, DateTime? fecha,
            TimeSpan? horaDesde, TimeSpan? horaHasta, string? movimiento, string? criticidad)
        {
            if (horaDesde.HasValue && horaHasta.HasValue && horaDesde.Value > horaHasta.Value)
                throw new Exception("La hora desde no puede ser posterior a la hora hasta.");

            string texto = (movimiento ?? string.Empty).Trim();
            DataTable resultado = movimientos.Clone();

            foreach (DataRow fila in movimientos.Rows)
            {
                DateTime fechaHora = Convert.ToDateTime(fila["Fecha_Hora"]);
                TimeSpan hora = new TimeSpan(fechaHora.Hour, fechaHora.Minute, 0);

                if (!string.IsNullOrEmpty(usuario) && (fila["Usuario"] as string ?? string.Empty).Trim() != usuario)
                    continue;
                if (fecha.HasValue && fechaHora.Date != fecha.Value.Date)
                    continue;
                if (horaDesde.HasValue && hora < horaDesde.Value)
                    continue;
                if (horaHasta.HasValue && hora > horaHasta.Value)
                    continue;
                if (!string.IsNullOrEmpty(criticidad) && (fila["Criticidad"] as string) != criticidad)
                    continue;
                if (texto != string.Empty
                    && !Contiene(fila["Operacion"] as string, texto)
                    && !Contiene(fila["Modulo"] as string, texto))
                    continue;

                resultado.ImportRow(fila);
            }

            return resultado;
        }

        // busca el texto sin importar mayusculas
        private static bool Contiene(string? valor, string texto)
        {
            return valor != null && valor.Contains(texto, StringComparison.OrdinalIgnoreCase);
        }

        // pasa el json del estado a texto, ej: "Activo: Si; Nombre: Pepe"
        public static string TextoEstado(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            try
            {
                using JsonDocument documento = JsonDocument.Parse(json);
                var partes = new List<string>();

                foreach (JsonProperty dato in documento.RootElement.EnumerateObject())
                {
                    string valor = dato.Value.ValueKind switch
                    {
                        JsonValueKind.True => "Sí",
                        JsonValueKind.False => "No",
                        JsonValueKind.Null => "-",
                        JsonValueKind.String => dato.Value.GetString() ?? "",
                        _ => dato.Value.ToString(),
                    };

                    partes.Add(dato.Name.Replace("_", " ") + ": " + valor);
                }

                return string.Join("; ", partes);
            }
            catch
            {
                return json;
            }
        }

        // consulta el permiso, si falla devuelve false
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

        // convierte el estado a json para guardarlo
        private static string? ToJson(Dictionary<string, object?>? estado)
        {
            if (estado == null || estado.Count == 0)
                return null;

            var limpio = new Dictionary<string, object?>();
            foreach (var dato in estado)
                limpio[dato.Key] = Normalizar(dato.Value);

            return JsonSerializer.Serialize(limpio, opcionesJson);
        }

        // deja los valores en un formato comun para poder compararlos
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
