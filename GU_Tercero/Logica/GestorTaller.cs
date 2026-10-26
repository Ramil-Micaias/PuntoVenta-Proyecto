using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    // Reglas de negocio del taller (CU05, CU08 y CU09).
    public class GestorTaller
    {
        private readonly TallerDAO tallerDAO = new TallerDAO();

        public DataTable ObtenerClientes()
        {
            return tallerDAO.ObtenerClientes();
        }

        public int RegistrarCliente(string apellido, string nombre, string dni, string telefono)
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

            return tallerDAO.InsertarCliente(apellido, nombre, dni, telefono);
        }

        public DataTable ObtenerEquipos(int idCliente)
        {
            return tallerDAO.ObtenerEquipos(idCliente);
        }

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

        public DataTable ObtenerTecnicos()
        {
            return tallerDAO.ObtenerTecnicos();
        }

        public DataTable ObtenerEstados()
        {
            return tallerDAO.ObtenerEstados();
        }

        public DataTable ObtenerRepuestos()
        {
            return tallerDAO.ObtenerRepuestos();
        }

        public ResultadoOperacion GuardarOrden(OrdenReparacion orden)
        {
            ValidarOrden(orden);
            return tallerDAO.GuardarOrden(orden);
        }

        public DataTable ConsultarOrdenes(string filtro, int? idEstado, int? idTecnico, bool soloPendientes)
        {
            return tallerDAO.ConsultarOrdenes(filtro, idEstado, idTecnico, soloPendientes);
        }

        public DataTable ObtenerOrden(int idOrden)
        {
            return tallerDAO.ObtenerOrden(idOrden);
        }

        public DataTable ObtenerRepuestosOrden(int idOrden)
        {
            return tallerDAO.ObtenerRepuestosOrden(idOrden);
        }

        public DataTable ObtenerHistorialOrden(int idOrden)
        {
            return tallerDAO.ObtenerHistorialOrden(idOrden);
        }

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

            if (orden.Fecha_Prometida.HasValue && orden.Fecha_Prometida.Value.Date < DateTime.Today && orden.Id_Orden == 0)
                throw new Exception("La fecha prometida no puede ser anterior a hoy.");

            foreach (DetalleOrdenRepuesto item in orden.Repuestos)
            {
                if (item.Cantidad <= 0)
                    throw new Exception("La cantidad de " + item.Repuesto + " debe ser mayor a cero.");

                if (item.Precio_Unitario < 0)
                    throw new Exception("El precio de " + item.Repuesto + " no puede ser negativo.");
            }
        }

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
