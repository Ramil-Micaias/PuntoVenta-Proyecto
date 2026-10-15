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

        public void RegistrarCategoria(string nombreCategoria)
        {
            productoDAO.RegistrarCategoria(ValidarNombreCategoria(nombreCategoria));
        }

        public void ModificarCategoria(int idCategoria, string nombreCategoria)
        {
            if (idCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría válida para modificar.");

            productoDAO.ModificarCategoria(idCategoria, ValidarNombreCategoria(nombreCategoria));
        }

        public void InactivarCategoria(int idCategoria)
        {
            if (idCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría válida.");

            productoDAO.InactivarCategoria(idCategoria);
        }

        private static string ValidarNombreCategoria(string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
                throw new Exception("El nombre de la categoría es obligatorio.");

            nombreCategoria = nombreCategoria.Trim();

            if (nombreCategoria.Length > 50)
                throw new Exception("El nombre de la categoría no puede superar los 50 caracteres.");

            return nombreCategoria;
        }

        private void ValidarProducto(Producto producto)
        {
            if (producto == null)
                throw new Exception("El producto no puede ser nulo.");

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