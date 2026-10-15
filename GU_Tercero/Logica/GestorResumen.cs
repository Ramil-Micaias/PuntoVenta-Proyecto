using Datos;
using Datos.Entidades;

namespace Logica
{
    public class GestorResumen
    {
        // El técnico cobra el 10% del total de cada reparación que termina.
        public const decimal PORCENTAJE_COMISION_TECNICO = 0.10m;

        private readonly ResumenDAO resumenDAO = new ResumenDAO();

        public ResumenDiario ObtenerResumenDiario()
        {
            return resumenDAO.ObtenerResumenDiario();
        }

        public ResumenTecnico ObtenerResumenTecnico(int idTecnico)
        {
            return resumenDAO.ObtenerResumenTecnico(idTecnico);
        }

        public decimal CalcularComisionTecnico(decimal totalReparaciones)
        {
            return totalReparaciones * PORCENTAJE_COMISION_TECNICO;
        }
    }
}
