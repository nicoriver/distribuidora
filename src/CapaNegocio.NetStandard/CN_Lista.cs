using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Lista
    {
        private CD_Lista objcd_Lista = new CD_Lista();

        public List<Lista> Listar(int idProducto)
        {
            return objcd_Lista.Listar(idProducto);
        }

        public int Registrar(Lista obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Id_articulo == 0)
            {
                Mensaje = "El precio debe estar asociado a un producto.";
                return 0;
            }

            return objcd_Lista.Registrar(obj, out Mensaje);
        }

        public bool Editar(Lista obj, out string Mensaje)
        {
            return objcd_Lista.Editar(obj, out Mensaje);
        }

        /// <summary>
        /// Calcula el precio final basado en la especificaciÃ³n:
        /// 1. Recargo
        /// 2. IVA
        /// 3. Descuento
        /// </summary>
        public decimal CalcularPrecioVenta(decimal precioCosto, decimal porcentajeRecargo, decimal porcentajeIva, decimal porcentajeDescuento)
        {
            // Paso 1: AplicaciÃ³n del Recargo
            decimal precioConRecargo = precioCosto + (precioCosto * (porcentajeRecargo / 100));

            // Paso 2: AplicaciÃ³n del IVA
            decimal precioConIva = precioConRecargo + (precioConRecargo * (porcentajeIva / 100));

            // Paso 3: AplicaciÃ³n del Descuento
            decimal precioFinal = precioConIva - (precioConIva * (porcentajeDescuento / 100));

            return Math.Round(precioFinal, 2);
        }

        public bool Eliminar(int idLista, out string Mensaje)
        {
            return objcd_Lista.Eliminar(idLista, out Mensaje);
        }

        public decimal ObtenerPrecioProducto(int idProducto, int idTipoLista, out string mensaje)
        {
            mensaje = string.Empty;
            decimal precio = 0;

            try
            {
                List<Lista> listas = objcd_Lista.Listar(idProducto);
                Lista lista = listas.FirstOrDefault(l => l.id_Tipolistas == idTipoLista);

                if (lista != null)
                {
                    precio = lista.Importe;
                }
                else
                {
                    mensaje = $"No existe precio configurado para este producto en la lista seleccionada";
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return precio;
        }
    }
}

