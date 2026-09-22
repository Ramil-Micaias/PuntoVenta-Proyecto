using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class ProductoProveedor
    {
        public int Id_ProductoProveedor { get; set; }
        public int Id_Producto { get; set; }
        public int Id_Proveedor { get; set; }
        public bool Activo { get; set; }
    }
}
