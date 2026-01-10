using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string Dni { get; set; }
        public int IdTipoDni { get; set; } // FK
        public int IdCodigoIva { get; set; } // FK
        public string Cuit { get; set; }
        public int IdZona { get; set; } // FK
        public int IdLocalidad { get; set; } // FK
        public int IdProvincia { get; set; } // FK
        public int IdPais { get; set; } // FK
        public string Telefono { get; set; }
        public string TelefonoAlt { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Contacto { get; set; }
        public int IdVendedor { get; set; } // FK
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; } // Mapear a Longitug si es necesario en SQL
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
