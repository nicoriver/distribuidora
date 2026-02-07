using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objcd_reporte = new CD_Reporte();

        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            return objcd_reporte.Compra(fechainicio, fechafin, idproveedor);
        }

        public List<Venta> ObtenerVentas(string fechaInicio, string fechaFin, int? idTipoComprobante, int? puntoVenta)
        {
            return objcd_reporte.ObtenerVentas(fechaInicio, fechaFin, idTipoComprobante, puntoVenta);
        }
    }
}

