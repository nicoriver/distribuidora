using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Zona
    {
        private CD_Zona objcd_Zona = new CD_Zona();

        public List<Zona> Listar()
        {
            return objcd_Zona.Listar();
        }
    }
}
