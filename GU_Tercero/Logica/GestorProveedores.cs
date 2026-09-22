using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    public class GestorProveedores
    {
        private readonly ProveedoresDAO proveedoresDAO = new ProveedoresDAO();

        public void RegistrarProveedor(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);
            proveedoresDAO.RegistrarProveedor(proveedor);
        }

        public void ModificarProveedor(Proveedor proveedor)
        {
            if (proveedor.Id_Proveedor <= 0)
                throw new Exception("Debe seleccionar un proveedor válido para modificar.");

            ValidarProveedor(proveedor);
            proveedoresDAO.ModificarProveedor(proveedor);
        }

        public void InactivarProveedor(int idProveedor)
        {
            if (idProveedor <= 0)
                throw new Exception("Debe seleccionar un proveedor válido.");

            proveedoresDAO.InactivarProveedor(idProveedor);
        }

        public DataTable ObtenerProveedores()
        {
            return proveedoresDAO.ObtenerProveedores();
        }

        public DataTable ObtenerTodosProveedores()
        {
            return proveedoresDAO.ObtenerTodosProveedores();
        }

        public DataTable BuscarProveedores(string filtro)
        {
            return proveedoresDAO.BuscarProveedores(filtro);
        }

        private void ValidarProveedor(Proveedor proveedor)
        {
            if (proveedor == null)
                throw new Exception("El proveedor no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(proveedor.Razon_Social))
                throw new Exception("La razón social es obligatoria.");

            proveedor.Razon_Social = proveedor.Razon_Social.Trim();

            if (proveedor.Razon_Social.Length > 100)
                throw new Exception("La razón social no puede exceder los 100 caracteres.");

            if (!string.IsNullOrWhiteSpace(proveedor.CUIT))
            {
                proveedor.CUIT = proveedor.CUIT.Trim();
                if (proveedor.CUIT.Length > 20)
                    throw new Exception("El CUIT no puede exceder los 20 caracteres.");
            }
            else
            {
                proveedor.CUIT = null;
            }

            if (!string.IsNullOrWhiteSpace(proveedor.Telefono))
            {
                proveedor.Telefono = proveedor.Telefono.Trim();
                if (proveedor.Telefono.Length > 30)
                    throw new Exception("El teléfono no puede exceder los 30 caracteres.");
            }
            else
            {
                proveedor.Telefono = null;
            }

            if (!string.IsNullOrWhiteSpace(proveedor.Email))
            {
                proveedor.Email = proveedor.Email.Trim();
                if (proveedor.Email.Length > 100)
                    throw new Exception("El email no puede exceder los 100 caracteres.");
            }
            else
            {
                proveedor.Email = null;
            }

            if (!string.IsNullOrWhiteSpace(proveedor.Direccion))
            {
                proveedor.Direccion = proveedor.Direccion.Trim();
                if (proveedor.Direccion.Length > 150)
                    throw new Exception("La dirección no puede exceder los 150 caracteres.");
            }
            else
            {
                proveedor.Direccion = null;
            }
        }
    }
}
