using Datos;
using Datos.Entidades;

namespace Logica
{
    // logica de los paneles del menu principal
    public class GestorResumen
    {
        // el tecnico cobra el 10% de las reparaciones
        public const decimal PORCENTAJE_COMISION_TECNICO = 0.10m;

        private readonly ResumenDAO resumenDAO = new ResumenDAO();

        // resumen del dia para admin y vendedor
        public ResumenDiario ObtenerResumenDiario()
        {
            return resumenDAO.ObtenerResumenDiario();
        }

        // resumen del tecnico logueado
        public ResumenTecnico ObtenerResumenTecnico(int idTecnico)
        {
            return resumenDAO.ObtenerResumenTecnico(idTecnico);
        }

        // calcula la comision sobre el total de reparaciones
        public decimal CalcularComisionTecnico(decimal totalReparaciones)
        {
            return totalReparaciones * PORCENTAJE_COMISION_TECNICO;
        }
    }
}
