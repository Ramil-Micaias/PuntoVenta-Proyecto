using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    public class GestorProducto
    {
        private readonly ProductoDAO productoDAO = new ProductoDAO();

        public void RegistrarProducto(Producto producto)
        {
            ValidarProducto(producto);
            productoDAO.RegistrarProducto(producto);
        }

        public void ModificarProducto(Producto producto)
        {
            if (producto.Id_Producto <= 0)
                throw new Exception("Debe seleccionar un producto válido para modificar.");

            ValidarProducto(producto);
            productoDAO.ModificarProducto(producto);
        }

        public void InactivarProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new Exception("Debe seleccionar un producto válido.");

            productoDAO.InactivarProducto(idProducto);
        }

        public DataTable ObtenerProductos()
        {
            return productoDAO.ObtenerProductos();
        }

        public DataTable ObtenerCategorias()
        {
            return productoDAO.ObtenerCategorias();
        }

        public DataTable BuscarProductos(string filtro)
        {
            return productoDAO.BuscarProductos(filtro);
        }

        private void ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre_Producto))
                throw new Exception("El nombre del producto es obligatorio.");

            producto.Nombre_Producto = producto.Nombre_Producto.Trim();

            if (producto.Id_Categoria <= 0)
                throw new Exception("Debe seleccionar una categoría.");

            if (producto.Precio_Venta < 0)
                throw new Exception("El precio de venta no puede ser negativo.");

            if (producto.Stock_Actual < 0)
                throw new Exception("El stock actual no puede ser negativo.");

            if (producto.Stock_Minimo < 0)
                throw new Exception("El stock mínimo no puede ser negativo.");
        }
    }
}