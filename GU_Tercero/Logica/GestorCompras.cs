using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    public class GestorCompras
    {
        private readonly CompraDAO compraDAO = new CompraDAO();
        private readonly MetodoPagoDAO metodoPagoDAO = new MetodoPagoDAO();
        private readonly ProductoDAO productoDAO = new ProductoDAO();
        private readonly ProveedoresDAO proveedoresDAO = new ProveedoresDAO();

        public ResultadoOperacion RegistrarCompra(Compra compra)
        {
            ValidarCompra(compra);
            return compraDAO.RegistrarCompra(compra);
        }

        public DataTable ObtenerMetodosPago()
        {
            return metodoPagoDAO.ObtenerMetodosPago();
        }

        public DataTable ObtenerProveedores()
        {
            return proveedoresDAO.ObtenerProveedores();
        }

        public DataTable BuscarProductos(string filtro, int? idCategoria)
        {
            return productoDAO.BuscarProductosPOS(filtro, idCategoria);
        }

        private void ValidarCompra(Compra compra)
        {
            if (compra == null)
                throw new Exception("La compra no puede ser nula.");

            if (compra.Detalle == null || compra.Detalle.Count == 0)
                throw new Exception("Debe agregar al menos un producto al detalle de la compra.");

            if (compra.Id_Usuario <= 0)
                throw new Exception("Debe iniciar sesión para registrar una compra.");

            if (compra.Id_Proveedor <= 0)
                throw new Exception("Debe seleccionar un proveedor.");

            if (compra.Id_MetodoPago.HasValue && compra.Id_MetodoPago.Value <= 0)
                throw new Exception("Debe seleccionar un método de pago.");

            foreach (DetalleCompra item in compra.Detalle)
            {
                if (item.Id_Producto <= 0)
                    throw new Exception("La compra contiene un producto inválido.");

                if (item.Cantidad <= 0)
                    throw new Exception("La cantidad de " + item.Producto + " debe ser mayor a cero.");

                if (item.Precio_Costo_Unitario <= 0)
                    throw new Exception("El costo unitario de " + item.Producto + " debe ser mayor a cero.");

                if (item.Precio_Venta_Sugerido.HasValue && item.Precio_Venta_Sugerido.Value <= 0)
                    throw new Exception("El precio de venta sugerido de " + item.Producto + " debe ser mayor a cero.");
            }

            if (compra.Subtotal <= 0)
                throw new Exception("El total de la compra debe ser mayor a cero.");
        }
    }
}
