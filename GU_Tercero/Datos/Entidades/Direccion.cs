using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Direccion
    {
        public int Id_Direccion { get; set; }
        public int Id_Localidad { get; set; }
        public int Id_Persona { get; set; }
        public string Calle {  get; set; }
        public string Numero_Calle {  get; set; }
        public string Entre_Calles {  get; set; }
        public string Departamento {  get; set; }
        public string Piso {  get; set; }
        public string Referencia {  get; set; }
        public bool Activo {  get; set; }
    }
}
