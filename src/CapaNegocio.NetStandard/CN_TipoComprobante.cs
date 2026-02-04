using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TipoComprobante
    {
        private CD_TipoComprobante objcd_TipoComprobante = new CD_TipoComprobante();

        public List<TipoComprobante> Listar()
        {
            return objcd_TipoComprobante.Listar();
        }

        public List<TipoComprobante> ListarParaVentas()
        {
            return objcd_TipoComprobante.ListarParaVentas();
        }

        public TipoComprobante ObtenerPorId(int idTipoComprobante)
        {
            return objcd_TipoComprobante.ObtenerPorId(idTipoComprobante);
        }

        public int ObtenerIdListaPrecio(int idTipoComprobante)
        {
            TipoComprobante obj = objcd_TipoComprobante.ObtenerPorId(idTipoComprobante);
            return obj != null ? obj.IdListaPrecio : 0;
        }

        public bool DiscriminaIVA(int idTipoComprobante)
        {
            TipoComprobante obj = objcd_TipoComprobante.ObtenerPorId(idTipoComprobante);
            return obj != null && obj.DiscriminaIVA;
        }
    }
}

