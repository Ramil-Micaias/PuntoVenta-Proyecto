using Datos;
using Datos.Entidades;

namespace Logica
{
    public class GestorResumen
    {
        private readonly ResumenDAO resumenDAO = new ResumenDAO();

        public ResumenDiario ObtenerResumenDiario()
        {
            return resumenDAO.ObtenerResumenDiario();
        }
    }
}
