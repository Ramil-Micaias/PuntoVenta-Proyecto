using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class CategoriaProducto
    {
        public int Id_Categoria { get; set; }
        public string Nombre_Categoria { get; set; }
        public bool Activo { get; set; }
    }
}
