using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Localidad
    {
        private CD_Localidad objcd_Localidad = new CD_Localidad();

        public List<Localidad> Listar()
        {
            return objcd_Localidad.Listar();
        }

        public List<Localidad> ListarPorProvincia(int idProvincia)
        {
            return objcd_Localidad.ListarPorProvincia(idProvincia);
        }
    }
}
