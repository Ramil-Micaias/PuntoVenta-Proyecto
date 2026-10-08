using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    public class GestorVentas
    {
        private readonly VentaDAO ventaDAO = new VentaDAO();
        private readonly MetodoPagoDAO metodoPagoDAO = new MetodoPagoDAO();
        private readonly ClienteDAO clienteDAO = new ClienteDAO();
        private readonly ProductoDAO productoDAO = new ProductoDAO();

        public ResultadoOperacion RegistrarVenta(Venta venta)
        {
            ValidarVenta(venta);
            return ventaDAO.RegistrarVenta(venta);
        }

        public DataTable ObtenerMetodosPago()
        {
            return metodoPagoDAO.ObtenerMetodosPago();
        }

        public DataTable ObtenerCategorias()
        {
            return productoDAO.ObtenerCategorias();
        }

        public DataTable BuscarProductos(string filtro, int? idCategoria)
        {
            return productoDAO.BuscarProductosPOS(filtro, idCategoria);
        }

        public DataTable BuscarClientes(string filtro)
        {
            return clienteDAO.BuscarClientes(filtro);
        }

        private void ValidarVenta(Venta venta)
        {
            if (venta == null)
                throw new Exception("La venta no puede ser nula.");

            if (venta.Detalle == null || venta.Detalle.Count == 0)
                throw new Exception("Debe agregar al menos un producto al carrito.");

            if (venta.Id_Usuario_Vendedor <= 0)
                throw new Exception("Debe iniciar sesión para registrar una venta.");

            if (venta.Id_MetodoPago <= 0)
                throw new Exception("Debe seleccionar un método de pago.");

            if (venta.DescuentoPorcentaje < 0 || venta.DescuentoPorcentaje > 100)
                throw new Exception("El descuento debe estar entre 0 y 100 por ciento.");

            foreach (DetalleVenta item in venta.Detalle)
            {
                if (item.Id_Producto <= 0)
                    throw new Exception("El carrito contiene un producto inválido.");

                if (item.Cantidad <= 0)
                    throw new Exception("La cantidad de " + item.Producto + " debe ser mayor a cero.");

                if (item.Precio_Unitario < 0)
                    throw new Exception("El precio de " + item.Producto + " no puede ser negativo.");
            }

            if (venta.TotalNeto <= 0)
                throw new Exception("El total de la venta debe ser mayor a cero.");
        }
    }
}
