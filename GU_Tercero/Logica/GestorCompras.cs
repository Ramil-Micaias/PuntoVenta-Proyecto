using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    // logica de compras a proveedores
    public class GestorCompras
    {
        private readonly CompraDAO compraDAO = new CompraDAO();
        private readonly MetodoPagoDAO metodoPagoDAO = new MetodoPagoDAO();
        private readonly ProductoDAO productoDAO = new ProductoDAO();
        private readonly ProveedoresDAO proveedoresDAO = new ProveedoresDAO();

        // valida y guarda la compra, despues la registra en la bitacora
        public ResultadoOperacion RegistrarCompra(Compra compra)
        {
            ValidarCompra(compra);
            ResultadoOperacion resultado = compraDAO.RegistrarCompra(compra);

            GestorBitacora.Registrar(GestorBitacora.COMPRAS, "Compra " + resultado.Comprobante + ".", GestorBitacora.INFORMATIVA, null,
                new System.Collections.Generic.Dictionary<string, object?>
                {
                    ["Comprobante"] = resultado.Comprobante,
                    ["Productos"] = compra.Detalles.Count,
                    ["Total"] = resultado.Total,
                });

            return resultado;
        }

        // metodos de pago para el combo
        public DataTable ObtenerMetodosPago()
        {
            return metodoPagoDAO.ObtenerMetodosPago();
        }

        // proveedores activos
        public DataTable ObtenerProveedores()
        {
            return proveedoresDAO.ObtenerProveedores();
        }

        // productos que se pueden comprar
        public DataTable BuscarProductos()
        {
            return compraDAO.BuscarProductosCompra();
        }

        // valida un producto antes de agregarlo al detalle, devuelve el error o null si esta bien
        public static string? ValidarRenglon(DataRow producto, decimal costo)
        {
            if (producto["Id_Proveedor"] == DBNull.Value)
                return "El producto " + producto["Producto"] + " no tiene proveedor asignado. Asígnelo en Producto y Stock > Productos y Categorías.";

            if (!Convert.ToBoolean(producto["Proveedor_Activo"]))
                return "El proveedor de " + producto["Producto"] + " (" + producto["Proveedor"] + ") está dado de baja.";

            decimal precioVenta = Convert.ToDecimal(producto["Precio_Venta"]);
            if (costo > precioVenta)
                return "El costo unitario ($" + costo.ToString("N2") + ") no puede ser mayor al precio de venta del producto ($" + precioVenta.ToString("N2") + ").";

            return null;
        }

        // controla el detalle y que los pagos sumen el total
        private void ValidarCompra(Compra compra)
        {
            if (compra == null)
                throw new Exception("La compra no puede ser nula.");

            if (compra.Detalles == null || compra.Detalles.Count == 0)
                throw new Exception("Debe agregar al menos un producto al detalle de la compra.");

            if (compra.Id_Usuario <= 0)
                throw new Exception("Debe iniciar sesión para registrar una compra.");

            if (compra.Id_Proveedor <= 0)
                throw new Exception("Debe seleccionar un proveedor.");

            if (compra.Id_MetodoPago <= 0)
                throw new Exception("Debe seleccionar un método de pago.");

            foreach (DetalleCompra item in compra.Detalles)
            {
                if (item.Id_Producto <= 0)
                    throw new Exception("La compra contiene un producto inválido.");

                if (item.Cantidad <= 0)
                    throw new Exception("La cantidad de " + item.Producto + " debe ser mayor a cero.");

                if (item.Precio_Costo_Unitario <= 0)
                    throw new Exception("El costo unitario de " + item.Producto + " debe ser mayor a cero.");
            }

            if (compra.Subtotal <= 0)
                throw new Exception("El total de la compra debe ser mayor a cero.");

            if (compra.Pagos.Count == 0)
                throw new Exception("Debe indicar cómo se paga la compra.");

            foreach (PagoCompra pago in compra.Pagos)
            {
                if (pago.Id_MetodoPago <= 0)
                    throw new Exception("Hay un pago sin método de pago.");

                if (pago.Importe <= 0)
                    throw new Exception("El importe de cada pago debe ser mayor a cero.");
            }

            if (compra.TotalPagos != compra.Total)
                throw new Exception("La suma de los pagos ($" + compra.TotalPagos.ToString("N2") + ") no coincide con el total de la compra ($" + compra.Total.ToString("N2") + ").");
        }
    }
}