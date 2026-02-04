using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// MÃ‰TODOS NUEVOS PARA DEVOLUCIONES/NOTAS DE CRÃ‰DITO
    /// Estos mÃ©todos deben agregarse a la clase CN_Venta existente
    /// </summary>
    public partial class CN_Venta_Extensiones
    {
        private CD_Venta_Extensiones objcd_venta = new CD_Venta_Extensiones();

        // =============================================
        // MÃ‰TODO 1: Obtener Venta por NÃºmero de Documento
        // =============================================
        public Venta ObtenerVentaPorNumeroDocumento(string numeroDocumento, out string mensaje)
        {
            mensaje = string.Empty;
            Venta venta = null;

            try
            {
                // Validar que el nÃºmero de documento no estÃ© vacÃ­o
                if (string.IsNullOrWhiteSpace(numeroDocumento))
                {
                    mensaje = "Debe ingresar un nÃºmero de documento";
                    return null;
                }

                // Obtener la venta
                venta = objcd_venta.ObtenerVentaPorNumeroDocumento(numeroDocumento);

                if (venta == null)
                {
                    mensaje = "No se encontrÃ³ el comprobante especificado";
                    return null;
                }

                // Validar que no sea una nota de crÃ©dito
                if (venta.oTipoComprobante != null && venta.oTipoComprobante.EsNotaCredito)
                {
                    mensaje = "No se puede crear una nota de crÃ©dito de otra nota de crÃ©dito";
                    return null;
                }

                mensaje = "Comprobante encontrado exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al buscar el comprobante: " + ex.Message;
                venta = null;
            }

            return venta;
        }

        public Venta ObtenerVentaPorNroDocTipoCompPtovta(string numeroDocumento, int tipoComprobante, int ptoVenta, out string mensaje)
        {
            mensaje = string.Empty;
            Venta venta = null;

            try
            {
                // Validar que el nÃºmero de documento no estÃ© vacÃ­o
                if (string.IsNullOrWhiteSpace(numeroDocumento))
                {
                    mensaje = "Debe ingresar un nÃºmero de documento";
                    return null;
                }

                // Obtener la venta
                venta = objcd_venta.ObtenerVentaPorNroDocTipoCompPtovta(numeroDocumento, tipoComprobante, ptoVenta);

                if (venta == null)
                {
                    mensaje = "No se encontrÃ³ el comprobante especificado";
                    return null;
                }

                // Validar que no sea una nota de crÃ©dito
                if (venta.oTipoComprobante != null && venta.oTipoComprobante.EsNotaCredito)
                {
                    mensaje = "No se puede crear una nota de crÃ©dito de otra nota de crÃ©dito";
                    return null;
                }

                mensaje = "Comprobante encontrado exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al buscar el comprobante: " + ex.Message;
                venta = null;
            }

            return venta;
        }

        // =============================================
        // MÃ‰TODO 2: Obtener Detalle de Venta
        // =============================================
        public List<Detalle_Venta> ObtenerDetalleVenta(int idVenta, out string mensaje)
        {
            mensaje = string.Empty;
            List<Detalle_Venta> detalle = new List<Detalle_Venta>();

            try
            {
                // Validar que el ID sea vÃ¡lido
                if (idVenta <= 0)
                {
                    mensaje = "El ID de venta no es vÃ¡lido";
                    return detalle;
                }

                // Obtener el detalle
                detalle = objcd_venta.ObtenerDetalleVentaPorId(idVenta);

                if (detalle == null || detalle.Count == 0)
                {
                    mensaje = "No se encontrÃ³ detalle para la venta especificada";
                    return new List<Detalle_Venta>();
                }

                mensaje = "Detalle obtenido exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al obtener el detalle: " + ex.Message;
                detalle = new List<Detalle_Venta>();
            }

            return detalle;
        }

        // =============================================
        // MÃ‰TODO 3: Registrar Nota de CrÃ©dito
        // =============================================
        public int RegistrarNotaCredito(Venta notaCredito, List<Detalle_Venta> detalle, out string mensaje)
        {
            mensaje = string.Empty;
            int idNotaCredito = 0;

            try
            {
                // Validaciones de negocio
                if (notaCredito == null)
                {
                    mensaje = "Los datos de la nota de crÃ©dito son requeridos";
                    return 0;
                }

                //if (notaCredito.IdVentaOriginal <= 0)
                //{
                //    mensaje = "Debe especificar la venta original";
                //    return 0;
                //}

                if (detalle == null || detalle.Count == 0)
                {
                    mensaje = "Debe especificar al menos un producto";
                    return 0;
                }

                // Validar que las cantidades sean vÃ¡lidas
                foreach (var item in detalle)
                {
                    if (item.Cantidad <= 0)
                    {
                        mensaje = $"La cantidad del producto {item.oProducto?.Nombre ?? "desconocido"} debe ser mayor a cero";
                        return 0;
                    }
                }

                // Validar totales
                if (notaCredito.MontoTotal <= 0)
                {
                    mensaje = "El monto total debe ser mayor a cero";
                    return 0;
                }

                // Convertir detalle a DataTable
                DataTable dtDetalle = objcd_venta.ConvertirDetalleADataTable(detalle);

                // Registrar la nota de crÃ©dito
                idNotaCredito = objcd_venta.RegistrarNotaCredito(notaCredito, dtDetalle, out mensaje);

                if (idNotaCredito == 0)
                {
                    // El mensaje ya viene del mÃ©todo de datos
                    return 0;
                }

                mensaje = "Nota de crÃ©dito registrada exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar la nota de crÃ©dito: " + ex.Message;
                idNotaCredito = 0;
            }

            return idNotaCredito;
        }

        // =============================================
        // MÃ‰TODO 4: Obtener PrÃ³ximo NÃºmero de NC
        // =============================================
        public string ObtenerProximoNumeroNC(int idTipoComprobante, out string mensaje)
        {
            mensaje = string.Empty;
            string numeroDocumento = string.Empty;

            try
            {
                if (idTipoComprobante <= 0)
                {
                    mensaje = "El tipo de comprobante no es vÃ¡lido";
                    //return "0001-00000001";
                    return "0000000001";
                }

                numeroDocumento = objcd_venta.ObtenerProximoNumeroNC(idTipoComprobante);

                if (string.IsNullOrWhiteSpace(numeroDocumento))
                {
                    //numeroDocumento = "0001-00000001";
                    numeroDocumento = "0000000001";
                }

                mensaje = "NÃºmero obtenido exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al obtener el nÃºmero: " + ex.Message;
                //numeroDocumento = "0001-00000001";
                numeroDocumento = "0000000001";
            }

            return numeroDocumento;
        }

        // =============================================
        // MÃ‰TODO 5: Determinar Tipo de Nota de CrÃ©dito
        // =============================================
        public int DeterminarTipoNotaCredito(int idTipoComprobanteOriginal, out string mensaje)
        {
            mensaje = string.Empty;
            int idTipoNC = 0;

            try
            {
                if (idTipoComprobanteOriginal <= 0)
                {
                    mensaje = "El tipo de comprobante original no es vÃ¡lido";
                    return 0;
                }

                idTipoNC = objcd_venta.DeterminarTipoNotaCredito(idTipoComprobanteOriginal);

                if (idTipoNC == 0)
                {
                    mensaje = "No se pudo determinar el tipo de nota de crÃ©dito";
                    return 0;
                }

                mensaje = "Tipo de nota de crÃ©dito determinado exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al determinar el tipo de NC: " + ex.Message;
                idTipoNC = 0;
            }

            return idTipoNC;
        }

        // =============================================
        // MÃ‰TODO 6: Validar Cantidades de DevoluciÃ³n
        // =============================================
        public bool ValidarCantidadesDevolucion(List<Detalle_Venta> detalleOriginal, List<Detalle_Venta> detalleDevolucion, out string mensaje)
        {
            mensaje = string.Empty;

            try
            {
                foreach (var itemDevolucion in detalleDevolucion)
                {
                    // Buscar el item original
                    var itemOriginal = 0;//detalleOriginal.FirstOrDefault(x => x.IdProducto == itemDevolucion.IdProducto);

                    if (itemOriginal == null)
                    {
                        mensaje = $"El producto {itemDevolucion.oProducto?.Nombre ?? "desconocido"} no existe en la venta original";
                        return false;
                    }

                    // Validar que la cantidad no supere la original
                    if (itemDevolucion.Cantidad > 0) //itemOriginal.Cantidad)
                    {
                        mensaje = $"La cantidad a devolver del producto {itemDevolucion.oProducto?.Nombre ?? "desconocido"} no puede ser mayor a la cantidad original ({0})";//itemOriginal.Cantidad})";
                        return false;
                    }
                }

                mensaje = "Cantidades validadas correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al validar cantidades: " + ex.Message;
                return false;
            }
        }

        // =============================================
        // MÃ‰TODO 7: Calcular Totales de NC
        // =============================================
        public void CalcularTotalesNC(List<Detalle_Venta> detalle, out decimal subTotal, out decimal totalIVA, out decimal totalDescuento, out decimal montoTotal)
        {
            subTotal = 0;
            totalIVA = 0;
            totalDescuento = 0;
            montoTotal = 0;

            try
            {
                foreach (var item in detalle)
                {
                    // Calcular subtotal del item (precio * cantidad)
                    decimal subtotalItem = item.PrecioVenta * item.Cantidad;

                    // Aplicar descuento si existe
                    decimal descuentoItem = subtotalItem * (item.PorcentajeDescuento / 100);
                    decimal baseImponible = subtotalItem - descuentoItem;

                    // Calcular IVA
                    decimal ivaItem = baseImponible * (item.PorcentajeIVA / 100);

                    // Actualizar el item con los valores calculados
                    item.SubTotal = baseImponible;
                    item.ImporteDescuento = descuentoItem;
                    item.ImporteIVA = ivaItem;

                    // Acumular totales
                    subTotal += baseImponible;
                    totalDescuento += descuentoItem;
                    totalIVA += ivaItem;
                }

                // Total = Subtotal + IVA
                montoTotal = subTotal + totalIVA;
            }
            catch (Exception ex)
            {
                // En caso de error, devolver ceros
                subTotal = 0;
                totalIVA = 0;
                totalDescuento = 0;
                montoTotal = 0;
            }
        }

        // =============================================
        // MÃ‰TODO 8: Obtener DescripciÃ³n de Tipo de NC
        // =============================================
        public string ObtenerDescripcionTipoNC(int idTipoComprobanteOriginal)
        {
            string descripcion = string.Empty;

            try
            {
                int idTipoNC = objcd_venta.DeterminarTipoNotaCredito(idTipoComprobanteOriginal);

                switch (idTipoNC)
                {
                    case 4:
                        descripcion = "Nota de CrÃ©dito A";
                        break;
                    case 5:
                        descripcion = "Nota de CrÃ©dito B";
                        break;
                    default:
                        descripcion = "Nota de CrÃ©dito";
                        break;
                }
            }
            catch (Exception ex)
            {
                descripcion = "Nota de CrÃ©dito";
            }

            return descripcion;
        }
    }
}

