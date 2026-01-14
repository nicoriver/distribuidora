using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Provincia
    {
        private CD_Provincia objcd_Provincia = new CD_Provincia();

        public List<Provincia> Listar()
        {
            return objcd_Provincia.Listar();
        }
    }
}
