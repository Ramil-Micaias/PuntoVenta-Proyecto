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
            // Código de barras: Opcional (si no viene, se asigna SIN-CODIGO o vacío)
            if (string.IsNullOrWhiteSpace(producto.Codigo_Barras))
            {
                producto.Codigo_Barras = "SIN-CODIGO";
            }
            else
            {
                producto.Codigo_Barras = producto.Codigo_Barras.Trim();
            }

            if (string.IsNullOrWhiteSpace(producto.Nombre_Producto))
                throw new Exception("El nombre del producto es obligatorio.");

            producto.Nombre_Producto = producto.Nombre_Producto.Trim();

            // Validar que no se registre un producto activo con el mismo Nombre
            DataTable productosExistentes = productoDAO.ObtenerProductos();
            if (productosExistentes != null)
            {
                foreach (DataRow fila in productosExistentes.Rows)
                {
                    int idExistente = Convert.ToInt32(fila["Id_Producto"]);
                    string nombreExistente = fila["Nombre_Producto"]?.ToString()?.Trim() ?? "";

                    if (idExistente != producto.Id_Producto &&
                        string.Equals(nombreExistente, producto.Nombre_Producto, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception($"Ya existe un producto registrado con el nombre '{producto.Nombre_Producto}'.");
                    }
                }
            }

            if (producto.Id_Categoria <= 0)
                throw new Exception("Debe seleccionar una categoría.");

            if (producto.Precio_Costo < 0)
                throw new Exception("El precio de costo no puede ser negativo.");

            if (producto.Precio_Venta < 0)
                throw new Exception("El precio de venta no puede ser negativo.");

            if (producto.Stock_Actual < 0)
                throw new Exception("El stock actual no puede ser negativo.");

            if (producto.Stock_Minimo < 0)
                throw new Exception("El stock mínimo no puede ser negativo.");
        }
    }
}