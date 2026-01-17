using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Usuario oUsuario { get; set; }
        public TipoComprobante oTipoComprobante { get; set; }
        public Cliente oCliente { get; set; }
        public Venta oVentaOriginal { get; set; } // Para notas de crédito
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int PuntoVenta { get; set; }
        public string FormaPago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal MontoTotal { get; set; }
        public string Observaciones { get; set; }
        public List<Detalle_Venta> oDetalle_Venta { get; set; }
        public string FechaRegistro { get; set; }
    }
}
