using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Iva
    {
        private CD_Iva objcd_Iva = new CD_Iva();

        public List<Iva> Listar()
        {
            return objcd_Iva.Listar();
        }
    }
}
