using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoComprobante
    {
        public int IdTipoComprobante { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdListaPrecio { get; set; }
        public bool DiscriminaIVA { get; set; }
        public bool EsNotaCredito { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
