using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {

        private CD_Cliente objcd_Cliente = new CD_Cliente();


        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();
        }
        // Método para obtener un cliente por ID
        public Cliente ObtenerPorId(int idCliente)
        {
            return objcd_Cliente.ObtenerPorId(idCliente);
        }
        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje += "Es necesario el apellido del Cliente\n";
            }

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre del Cliente\n";
            }

            if (string.IsNullOrEmpty(obj.Dni) || string.IsNullOrWhiteSpace(obj.Dni))
            {
                Mensaje += "Es necesario el DNI del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Cliente.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje += "Es necesario el apellido del Cliente\n";
            }

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre del Cliente\n";
            }

            if (string.IsNullOrEmpty(obj.Dni) || string.IsNullOrWhiteSpace(obj.Dni))
            {
                Mensaje += "Es necesario el DNI del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            return objcd_Cliente.Eliminar(obj, out Mensaje);
        }

    }
}
