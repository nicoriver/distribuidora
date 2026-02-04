using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta();

        public bool RestarStock(int idproducto, int cantidad) {
            return objcd_venta.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad) {
            return objcd_venta.SumarStock(idproducto, cantidad);
        }

        public int ObtenerCorrelativo()
        {
            return objcd_venta.ObtenerCorrelativo();
        }
        //public int ObtenerCorrelativoPorTipo(int idTipoComprobante, int puntoVenta)
        //{
        //    return objcd_venta.ObtenerCorrelativoPorTipo(idTipoComprobante, puntoVenta);
        //}
        public Venta ObtenerVentaCompleta(string numeroDocumento)
        {
            try
            {
                // Obtener venta
                Venta venta = new CD_Venta().ObtenerVentaCompleta(numeroDocumento);

                if (venta == null || venta.IdVenta == 0)
                    return null;

                // Obtener detalle
                venta.oDetalle_Venta = new CD_Venta().ObtenerDetalleVenta(venta.IdVenta);

                // Obtener datos del cliente completos (con domicilio)
                if (venta.oCliente != null && venta.oCliente.IdCliente > 0)
                {
                    venta.oCliente = new CN_Cliente().ObtenerPorId(venta.oCliente.IdCliente);
                }

                // Obtener tipo de comprobante
                if (venta.oTipoComprobante != null && venta.oTipoComprobante.IdTipoComprobante > 0)
                {
                    venta.oTipoComprobante = new CN_TipoComprobante().ObtenerPorId(venta.oTipoComprobante.IdTipoComprobante);
                }
                else
                {
                    // Opcional: Inicializar para evitar null
                    venta.oTipoComprobante = new TipoComprobante();
                }
                return venta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener venta completa: {ex.Message}");
            }
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objcd_venta.Registrar(obj, DetalleVenta, out Mensaje);
        }

        public Venta ObtenerVenta(string numero) {
            Venta oVenta = objcd_venta.ObtenerVenta(numero);

            if (oVenta.IdVenta != 0) {
                List<Detalle_Venta> oDetalleVenta = objcd_venta.ObtenerDetalleVenta(oVenta.IdVenta);
                oVenta.oDetalle_Venta = oDetalleVenta;
            }

            return oVenta;
        }


        // =============================================
        // Métodos para Ventas Fiscales
        //// =============================================
        //public int ObtenerCorrelativoPorTipo(int idTipoComprobante, int puntoVenta)
        //{
        //    return objcd_venta.ObtenerCorrelativoPorTipo(idTipoComprobante, puntoVenta);
        //}


        public bool RegistrarVentaFiscal(Venta obj, DataTable DetalleVenta, out int idVentaGenerado, out string Mensaje)
        {
            return objcd_venta.RegistrarVentaFiscal(obj, DetalleVenta, out idVentaGenerado, out Mensaje);
        }
        public int ObtenerCorrelativoPorTipo(int idTipoComprobante, int puntoVenta)
        {
            return objcd_venta.ObtenerCorrelativoPorTipo(idTipoComprobante, puntoVenta);
        }


        public bool RegistrarNotaCredito(Venta obj, DataTable DetalleVenta, out int idNotaCreditoGenerado, out string Mensaje)
        {
            return objcd_venta.RegistrarNotaCredito(obj, DetalleVenta, out idNotaCreditoGenerado, out Mensaje);
        }

        //public Venta ObtenerVentaCompleta(string numeroDocumento)
        //{
        //    Venta oVenta = objcd_venta.ObtenerVentaCompleta(numeroDocumento);

        //    if (oVenta.IdVenta != 0)
        //    {
        //        List<Detalle_Venta> oDetalleVenta = objcd_venta.ObtenerDetalleVentaCompleto(oVenta.IdVenta);
        //        oVenta.oDetalle_Venta = oDetalleVenta;
        //    }

        //    return oVenta;
        //}

        public bool ValidarStockDisponible(int idProducto, int cantidadRequerida, out string mensaje)
        {
            return objcd_venta.ValidarStockDisponible(idProducto, cantidadRequerida, out mensaje);
        }

        /// <summary>
        /// Calcula los importes para Factura A (IVA discriminado)
        /// Retorna: SubTotal (neto), ImporteIVA, Total
        /// </summary>
        public (decimal SubTotal, decimal ImporteIVA, decimal Total) CalcularImportesConIVADiscriminado(
            decimal precioBase, 
            int cantidad, 
            decimal porcentajeIVA, 
            decimal porcentajeDescuento = 0)
        {
            // Precio base x cantidad
            decimal subtotal = precioBase * cantidad;

            // Aplicar descuento si existe
            if (porcentajeDescuento > 0)
            {
                decimal importeDescuento = subtotal * (porcentajeDescuento / 100);
                subtotal = subtotal - importeDescuento;
            }

            // Calcular IVA sobre el subtotal
            decimal importeIVA = subtotal * (porcentajeIVA / 100);

            // Total = Subtotal + IVA
            decimal total = subtotal + importeIVA;

            return (Math.Round(subtotal, 2), Math.Round(importeIVA, 2), Math.Round(total, 2));
        }

        /// <summary>
        /// Calcula los importes para Factura B/Recibo (IVA incluido)
        /// El precio ya incluye el IVA, solo se calcula el total
        /// </summary>
        public (decimal SubTotal, decimal ImporteIVA, decimal Total) CalcularImportesConIVAIncluido(
            decimal precioConIVA, 
            int cantidad, 
            decimal porcentajeIVA,
            decimal porcentajeDescuento = 0)
        {
            // Total con IVA incluido
            decimal total = precioConIVA * cantidad;

            // Aplicar descuento si existe
            if (porcentajeDescuento > 0)
            {
                decimal importeDescuento = total * (porcentajeDescuento / 100);
                total = total - importeDescuento;
            }

            // Calcular el neto (precio sin IVA) a partir del total
            decimal subtotal = total / (1 + (porcentajeIVA / 100));

            // IVA es la diferencia
            decimal importeIVA = total - subtotal;

            return (Math.Round(subtotal, 2), Math.Round(importeIVA, 2), Math.Round(total, 2));
        }

        public bool ValidarFechaNotaCredito(int idVentaOriginal, out string mensaje)
        {
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT FechaRegistro FROM VENTA WHERE IdVenta = @IdVenta",
                    conexion);

                cmd.Parameters.AddWithValue("@IdVenta", idVentaOriginal);

                conexion.Open();
                DateTime fechaVenta = (DateTime)cmd.ExecuteScalar();

                // Validar que no hayan pasado más de X días (ejemplo: 30 días)
                int diasMaximos = 30;
                TimeSpan diferencia = DateTime.Now - fechaVenta;

                if (diferencia.TotalDays > diasMaximos)
                {
                    mensaje = $"No se pueden crear notas de crédito para ventas con más de {diasMaximos} días de antigüedad";
                    return false;
                }
            }

            return true;
        }

        public bool ValidarPermisosNotaCredito(int idUsuario, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar que el usuario tenga permisos para crear notas de crédito
            // Ajusta según tu sistema de permisos

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM PERMISO WHERE IdUsuario = @IdUsuario " +
                    "AND NombreMenu = 'menuDevoluciones' AND Estado = 1",
                    conexion);

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();
                int tienePermiso = (int)cmd.ExecuteScalar();

                if (tienePermiso == 0)
                {
                    mensaje = "El usuario no tiene permisos para crear notas de crédito";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Valida que una venta tenga todos los datos necesarios antes de registrar
        /// </summary>
        public bool ValidarVenta(Venta obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.oUsuario == null || obj.oUsuario.IdUsuario == 0)
            {
                mensaje = "Debe seleccionar un usuario";
                return false;
            }

            if (obj.oTipoComprobante == null || obj.oTipoComprobante.IdTipoComprobante == 0)
            {
                mensaje = "Debe seleccionar un tipo de comprobante";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.NumeroDocumento))
            {
                mensaje = "Debe ingresar un número de documento";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.NombreCliente))
            {
                mensaje = "Debe ingresar el nombre del cliente";
                return false;
            }

            if (obj.oDetalle_Venta == null || obj.oDetalle_Venta.Count == 0)
            {
                mensaje = "Debe agregar al menos un producto a la venta";
                return false;
            }

            if (obj.MontoTotal <= 0)
            {
                mensaje = "El monto total debe ser mayor a cero";
                return false;
            }

            return true;
        }



    }
}

