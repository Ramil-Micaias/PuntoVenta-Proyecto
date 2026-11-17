using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    // logica del taller: clientes, equipos y ordenes
    public class GestorTaller
    {
        private readonly TallerDAO tallerDAO = new TallerDAO();

        // clientes del taller
        public DataTable ObtenerClientes()
        {
            return tallerDAO.ObtenerClientes();
        }

        // valida y da de alta un cliente
        public int RegistrarCliente(string apellido, string nombre, string dni, string telefono)
        {
            ValidarCliente(ref apellido, ref nombre, ref dni, ref telefono);

            return tallerDAO.InsertarCliente(apellido, nombre, dni, telefono);
        }

        // datos de un cliente
        public DataTable ObtenerCliente(int idCliente)
        {
            return tallerDAO.ObtenerCliente(idCliente);
        }

        // valida y guarda los cambios del cliente
        public void ModificarCliente(int idCliente, string apellido, string nombre, string dni, string telefono)
        {
            if (idCliente <= 0)
                throw new Exception("Debe seleccionar un cliente.");

            ValidarCliente(ref apellido, ref nombre, ref dni, ref telefono);

            tallerDAO.ModificarCliente(idCliente, apellido, nombre, dni, telefono);
        }

        // valida apellido, nombre, DNI y telefono (los recibe por ref para dejarlos limpios)
        private static void ValidarCliente(ref string apellido, ref string nombre, ref string dni, ref string telefono)
        {
            apellido = (apellido ?? string.Empty).Trim();
            nombre = (nombre ?? string.Empty).Trim();
            dni = (dni ?? string.Empty).Trim();
            telefono = (telefono ?? string.Empty).Trim();

            if (apellido == "" || nombre == "")
                throw new Exception("El apellido y el nombre del cliente son obligatorios.");

            if (dni == "")
                throw new Exception("El DNI del cliente es obligatorio.");

            if (!SoloNumeros(dni) || dni.Length < 7 || dni.Length > 8)
                throw new Exception("El DNI debe tener 7 u 8 números, sin puntos.");

            if (telefono.Length > 15)
                throw new Exception("El teléfono no puede superar los 15 caracteres.");
        }

        // equipos del cliente
        public DataTable ObtenerEquipos(int idCliente)
        {
            return tallerDAO.ObtenerEquipos(idCliente);
        }

        // valida y da de alta un equipo
        public int RegistrarEquipo(int idCliente, string tipo, string marca, string modelo, string numeroSerie, string imei, string color)
        {
            if (idCliente <= 0)
                throw new Exception("Primero seleccione el cliente dueño del equipo.");

            tipo = (tipo ?? string.Empty).Trim();
            marca = (marca ?? string.Empty).Trim();
            modelo = (modelo ?? string.Empty).Trim();
            imei = (imei ?? string.Empty).Trim();

            if (tipo == "" || marca == "" || modelo == "")
                throw new Exception("El tipo, la marca y el modelo del equipo son obligatorios.");

            if (imei != "" && (!SoloNumeros(imei) || imei.Length != 15))
                throw new Exception("El IMEI debe tener 15 números.");

            return tallerDAO.InsertarEquipo(idCliente, tipo, marca, modelo, numeroSerie, imei, color);
        }

        // tecnicos para asignar
        public DataTable ObtenerTecnicos()
        {
            return tallerDAO.ObtenerTecnicos();
        }

        // estados de la orden
        public DataTable ObtenerEstados()
        {
            return tallerDAO.ObtenerEstados();
        }

        // repuestos disponibles
        public DataTable ObtenerRepuestos()
        {
            return tallerDAO.ObtenerRepuestos();
        }

        // valida y guarda la orden
        public ResultadoOperacion GuardarOrden(OrdenReparacion orden)
        {
            ValidarOrden(orden);
            return tallerDAO.GuardarOrden(orden);
        }

        // ordenes con filtros
        public DataTable ConsultarOrdenes(string filtro, int? idEstado, int? idTecnico, bool soloPendientes, int? idUsuarioPropio = null)
        {
            return tallerDAO.ConsultarOrdenes(filtro, idEstado, idTecnico, soloPendientes, idUsuarioPropio);
        }

        // una orden
        public DataTable ObtenerOrden(int idOrden)
        {
            return tallerDAO.ObtenerOrden(idOrden);
        }

        // repuestos de la orden
        public DataTable ObtenerRepuestosOrden(int idOrden)
        {
            return tallerDAO.ObtenerRepuestosOrden(idOrden);
        }

        // historial de la orden
        public DataTable ObtenerHistorialOrden(int idOrden)
        {
            return tallerDAO.ObtenerHistorialOrden(idOrden);
        }

        // controla equipo, falla, costos, fecha prometida y repuestos
        private void ValidarOrden(OrdenReparacion orden)
        {
            if (orden == null)
                throw new Exception("La orden no puede ser nula.");

            if (orden.Id_Equipo <= 0)
                throw new Exception("Debe seleccionar el cliente y el equipo.");

            if (orden.Id_Estado <= 0)
                throw new Exception("Debe seleccionar el estado de la orden.");

            if (orden.Id_Usuario <= 0)
                throw new Exception("Debe iniciar sesión para guardar la orden.");

            if (string.IsNullOrWhiteSpace(orden.Falla_Declarada))
                throw new Exception("Debe describir la falla que informa el cliente.");

            orden.Falla_Declarada = orden.Falla_Declarada.Trim();

            if (orden.Falla_Declarada.Length > 500)
                throw new Exception("La falla declarada no puede superar los 500 caracteres.");

            if (orden.Diagnostico != null && orden.Diagnostico.Trim().Length > 500)
                throw new Exception("El diagnóstico no puede superar los 500 caracteres.");

            if (orden.Patron_Clave != null && orden.Patron_Clave.Trim().Length > 50)
                throw new Exception("El patrón o clave no puede superar los 50 caracteres.");

            if (orden.Costo_Mano_Obra < 0)
                throw new Exception("La mano de obra no puede ser negativa.");

            if (orden.Fecha_Prometida.HasValue)
            {
                DateTime registro = DateTime.Today;

                if (orden.Id_Orden > 0)
                {
                    DataTable existente = tallerDAO.ObtenerOrden(orden.Id_Orden);
                    if (existente.Rows.Count > 0 && existente.Rows[0]["Fecha_Ingreso"] != DBNull.Value)
                        registro = Convert.ToDateTime(existente.Rows[0]["Fecha_Ingreso"]).Date;
                }

                if (orden.Fecha_Prometida.Value.Date < registro)
                    throw new Exception("La fecha prometida no puede ser anterior a la fecha de registro de la orden (" + registro.ToString("dd/MM/yyyy") + ").");
            }

            foreach (DetalleOrdenRepuesto item in orden.Repuestos)
            {
                if (item.Cantidad <= 0)
                    throw new Exception("La cantidad de " + item.Repuesto + " debe ser mayor a cero.");

                if (item.Precio_Unitario < 0)
                    throw new Exception("El precio de " + item.Repuesto + " no puede ser negativo.");
            }
        }

        // true si el texto tiene solo digitos
        private static bool SoloNumeros(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}
