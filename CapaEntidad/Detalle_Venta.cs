using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Venta
    {
        public int IdDetalleVenta { get; set; }
        public Producto oProducto { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PorcentajeIVA { get; set; }
        public decimal ImporteIVA { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public decimal ImporteDescuento { get; set; }
        public decimal SubTotal { get; set; }
        public int IdListaPrecio { get; set; }
        public string Observaciones { get; set; }
        public string FechaRegistro { get; set; }
    }
}
