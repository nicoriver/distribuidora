using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Lista
    {
        public int Id_Lista { get; set; }
        public int Id_articulo { get; set; } // Asumiendo relación directa por ID, o podría ser objeto Producto
        public string Descripcion { get; set; }
        public int id_Tipolistas { get; set; }
        public decimal Importe { get; set; }
        public string Fecha_Modificacion { get; set; }
        public decimal Iva { get; set; }
        public decimal Recargo { get; set; }
        public decimal Descuento { get; set; }

        // Propiedad de navegación opcional
        public Producto oProducto { get; set; }
    }
}
