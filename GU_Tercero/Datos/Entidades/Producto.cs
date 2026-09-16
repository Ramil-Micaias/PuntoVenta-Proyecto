using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public int Id_Categoria { get; set; }
        public int? Id_Proveedor { get; set; }
        public string Codigo_Barras { get; set; }
        public string Nombre_Producto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio_Costo { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Stock_Actual { get; set; }
        public int Stock_Minimo { get; set; }
        public bool Es_Repuesto { get; set; }
        public bool Activo { get; set; }

        // Propiedad auxiliar para mostrar el nombre de la categoría en la grilla
        public string NombreCategoria { get; set; }
    }
}