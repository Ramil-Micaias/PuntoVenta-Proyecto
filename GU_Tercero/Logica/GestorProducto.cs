using Datos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Logica
{
    // logica de productos y categorias
    public class GestorProducto
    {
        private readonly ProductoDAO productoDAO = new ProductoDAO();

        // valida y da de alta el producto
        public void RegistrarProducto(Producto producto)
        {
            ValidarProducto(producto);
            productoDAO.RegistrarProducto(producto);

            GestorBitacora.Registrar(GestorBitacora.PRODUCTOS, "Alta del producto " + producto.Nombre_Producto + ".",
                GestorBitacora.INFORMATIVA, null, EstadoProducto(producto));
        }

        // arma los datos del producto para guardar en la bitacora
        private static Dictionary<string, object?> EstadoProducto(Producto producto)
        {
            return new Dictionary<string, object?>
            {
                ["Nombre_Producto"] = producto.Nombre_Producto,
                ["Descripcion"] = producto.Descripcion,
                ["Precio_Venta"] = producto.Precio_Venta,
                ["Stock_Actual"] = producto.Stock_Actual,
                ["Stock_Minimo"] = producto.Stock_Minimo,
                ["Id_Categoria"] = producto.Id_Categoria,
            };
        }

        // valida, modifica y guarda en la bitacora solo lo que cambio
        public void ModificarProducto(Producto producto)
        {
            if (producto.Id_Producto <= 0)
                throw new Exception("Debe seleccionar un producto válido para modificar.");

            ValidarProducto(producto);

            var antes = GestorBitacora.EstadoDeFila(productoDAO.ObtenerProductos(), "Id_Producto", producto.Id_Producto);

            productoDAO.ModificarProducto(producto);

            GestorBitacora.RegistrarCambios(GestorBitacora.PRODUCTOS, "Modificación del producto " + producto.Nombre_Producto + ".",
                GestorBitacora.ADVERTENCIA, antes, GestorBitacora.EstadoDeFila(productoDAO.ObtenerProductos(), "Id_Producto", producto.Id_Producto));
        }

        // da de baja el producto
        public void InactivarProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new Exception("Debe seleccionar un producto válido.");

            var antes = GestorBitacora.EstadoDeFila(productoDAO.ObtenerProductos(), "Id_Producto", idProducto);

            productoDAO.InactivarProducto(idProducto);

            GestorBitacora.Registrar(GestorBitacora.PRODUCTOS, "Baja del producto " + antes?["Nombre_Producto"] + ".",
                GestorBitacora.ADVERTENCIA,
                new Dictionary<string, object?> { ["Activo"] = true }, new Dictionary<string, object?> { ["Activo"] = false });
        }

        // vuelve a activar el producto
        public void ActivarProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new Exception("Debe seleccionar un producto válido.");

            var antes = GestorBitacora.EstadoDeFila(productoDAO.ObtenerProductos(), "Id_Producto", idProducto);

            productoDAO.ReactivarProducto(idProducto);

            GestorBitacora.Registrar(GestorBitacora.PRODUCTOS, "Activación del producto " + antes?["Nombre_Producto"] + ".",
                GestorBitacora.ADVERTENCIA,
                new Dictionary<string, object?> { ["Activo"] = false }, new Dictionary<string, object?> { ["Activo"] = true });
        }

        // todos los productos
        public DataTable ObtenerProductos()
        {
            return productoDAO.ObtenerProductos();
        }

        // categorias
        public DataTable ObtenerCategorias()
        {
            return productoDAO.ObtenerCategorias();
        }

        // busqueda por nombre o codigo
        public DataTable BuscarProductos(string filtro)
        {
            return productoDAO.BuscarProductos(filtro);
        }

        // stock con los filtros de la pantalla de consulta
        public DataTable ConsultarStock(string filtro, int? idCategoria, bool soloBajoMinimo)
        {
            return productoDAO.ConsultarStock(filtro, idCategoria, soloBajoMinimo);
        }

        // alta de categoria
        public void RegistrarCategoria(string nombreCategoria)
        {
            productoDAO.RegistrarCategoria(ValidarNombreCategoria(nombreCategoria));

            GestorBitacora.Registrar(GestorBitacora.PRODUCTOS, "Alta de la categoría " + nombreCategoria.Trim() + ".",
                GestorBitacora.INFORMATIVA);
        }

        // cambia el nombre de la categoria
        public void ModificarCategoria(int idCategoria, string nombreCategoria)
        {
            if (idCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría válida para modificar.");

            var antes = GestorBitacora.EstadoDeFila(productoDAO.ObtenerCategorias(), "Id_Categoria", idCategoria);

            productoDAO.ModificarCategoria(idCategoria, ValidarNombreCategoria(nombreCategoria));

            GestorBitacora.RegistrarCambios(GestorBitacora.PRODUCTOS, "Modificación de la categoría " + nombreCategoria.Trim() + ".",
                GestorBitacora.ADVERTENCIA, antes, GestorBitacora.EstadoDeFila(productoDAO.ObtenerCategorias(), "Id_Categoria", idCategoria));
        }

        // baja logica de la categoria
        public void InactivarCategoria(int idCategoria)
        {
            if (idCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría válida.");

            var antes = GestorBitacora.EstadoDeFila(productoDAO.ObtenerCategorias(), "Id_Categoria", idCategoria);

            productoDAO.InactivarCategoria(idCategoria);

            GestorBitacora.Registrar(GestorBitacora.PRODUCTOS, "Baja de la categoría " + antes?["Nombre_Categoria"] + ".",
                GestorBitacora.ADVERTENCIA,
                new Dictionary<string, object?> { ["Activo"] = true }, new Dictionary<string, object?> { ["Activo"] = false });
        }

        // el nombre es obligatorio y tiene un largo maximo
        private static string ValidarNombreCategoria(string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
                throw new Exception("El nombre de la categoría es obligatorio.");

            nombreCategoria = nombreCategoria.Trim();

            if (nombreCategoria.Length > 50)
                throw new Exception("El nombre de la categoría no puede superar los 50 caracteres.");

            return nombreCategoria;
        }

        // controla los datos del producto: nombre, codigo, precios y stock
        private void ValidarProducto(Producto producto)
        {
            if (producto == null)
                throw new Exception("El producto no puede ser nulo.");

            if (producto.Id_Categoria <= 0)
                throw new Exception("Debe seleccionar una categoría.");

            if (string.IsNullOrWhiteSpace(producto.Nombre_Producto))
                throw new Exception("El nombre del producto es obligatorio.");

            producto.Nombre_Producto = producto.Nombre_Producto.Trim();

            if (producto.Nombre_Producto.Length < 3 || producto.Nombre_Producto.Length > 50)
                throw new Exception("El nombre del producto debe tener entre 3 y 50 caracteres.");

            if (!producto.Nombre_Producto.Any(char.IsLetter))
                throw new Exception("El nombre del producto debe contener letras.");

            if (string.IsNullOrWhiteSpace(producto.Descripcion))
                throw new Exception("La descripción del producto es obligatoria.");

            producto.Descripcion = producto.Descripcion.Trim();

            if (producto.Descripcion.Length > 120)
                throw new Exception("La descripción no puede superar los 120 caracteres.");

            if (producto.Id_Proveedor == null || producto.Id_Proveedor <= 0)
                throw new Exception("Debe seleccionar el proveedor del producto.");

            if (producto.Precio_Venta <= 0)
                throw new Exception("El precio de venta debe ser mayor a cero.");

            if (producto.Stock_Actual < 0)
                throw new Exception("El stock actual no puede ser negativo.");

            if (producto.Stock_Minimo < 0)
                throw new Exception("El stock mínimo no puede ser negativo.");
        }
    }
}