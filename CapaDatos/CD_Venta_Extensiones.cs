using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    /// <summary>
    /// MÉTODOS NUEVOS PARA DEVOLUCIONES/NOTAS DE CRÉDITO
    /// Estos métodos deben agregarse a la clase CD_Venta existente
    /// </summary>
    public partial class CD_Venta_Extensiones
    {
        // =============================================
        // MÉTODO 1: Obtener Venta por Número de Documento
        // =============================================
        public Venta ObtenerVentaPorNumeroDocumento(string numeroDocumento)
        {
            Venta venta = null;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT v.IdVenta, v.IdUsuario, v.IdTipoComprobante, v.IdCliente, v.IdVentaOriginal,");
                    query.AppendLine("       v.TipoDocumento, v.NumeroDocumento, v.DocumentoCliente, v.NombreCliente,");
                    query.AppendLine("       v.MontoPago, v.MontoCambio, v.SubTotal, v.TotalIVA, v.TotalDescuento,");
                    query.AppendLine("       v.MontoTotal, v.Observaciones, v.FechaRegistro,");
                    query.AppendLine("       tc.IdTipoComprobante, tc.Codigo, tc.Descripcion, tc.IdListaPrecio,");
                    query.AppendLine("       tc.DiscriminaIVA, tc.EsNotaCredito, tc.Estado as EstadoTipoComprobante");
                    query.AppendLine("FROM VENTA v");
                    query.AppendLine("INNER JOIN TipoComprobante tc ON tc.IdTipoComprobante = v.IdTipoComprobante");
                    //query.AppendLine("WHERE v.NumeroDocumento = @NumeroDocumento");
                    query.AppendLine("WHERE TRY_CONVERT(BIGINT, v.NumeroDocumento) = TRY_CONVERT(BIGINT, @NumeroDocumento)");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            venta = new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oUsuario = new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                },
                                
                                oCliente = dr["IdCliente"] != DBNull.Value
                                ? new Cliente { IdCliente = Convert.ToInt32(dr["IdCliente"]) }
                                : null,
                                //IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                //IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                //IdCliente = dr["IdCliente"] != DBNull.Value ? Convert.ToInt32(dr["IdCliente"]) : 0,
                                

                                //IdVentaOriginal = dr["IdVentaOriginal"] != DBNull.Value ? Convert.ToInt32(dr["IdVentaOriginal"]) : 0,
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"]),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                TotalIVA = Convert.ToDecimal(dr["TotalIVA"]),
                                TotalDescuento = Convert.ToDecimal(dr["TotalDescuento"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                Observaciones = dr["Observaciones"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                oTipoComprobante = new TipoComprobante()
                                {
                                    IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    IdListaPrecio = Convert.ToInt32(dr["IdListaPrecio"]),
                                    DiscriminaIVA = Convert.ToBoolean(dr["DiscriminaIVA"]),
                                    EsNotaCredito = Convert.ToBoolean(dr["EsNotaCredito"]),
                                    Estado = Convert.ToBoolean(dr["EstadoTipoComprobante"])
                                }
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    venta = null;
                    // Log error: ex.Message
                }
            }

            return venta;
        }

        public Venta ObtenerVentaPorNroDocTipoCompPtovta(string numeroDocumento, int tipoComprobante, int ptoVenta)
        {
            Venta venta = null;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT v.IdVenta, v.IdUsuario, v.IdTipoComprobante, v.IdCliente, v.IdVentaOriginal,");
                    query.AppendLine("       v.TipoDocumento, v.NumeroDocumento, v.DocumentoCliente, v.NombreCliente,");
                    query.AppendLine("       v.MontoPago, v.MontoCambio, v.SubTotal, v.TotalIVA, v.TotalDescuento,");
                    query.AppendLine("       v.MontoTotal, v.Observaciones, v.FechaRegistro, v.PuntoVenta, ");
                    query.AppendLine("       tc.IdTipoComprobante, tc.Codigo, tc.Descripcion, tc.IdListaPrecio,");
                    query.AppendLine("       tc.DiscriminaIVA, tc.EsNotaCredito, tc.Estado as EstadoTipoComprobante");
                    query.AppendLine("FROM VENTA v");
                    query.AppendLine("INNER JOIN TipoComprobante tc ON tc.IdTipoComprobante = v.IdTipoComprobante");
                   // query.AppendLine("WHERE v.NumeroDocumento = @NumeroDocumento AND v.IdTipoComprobante = @tipoComprobante and v.PuntoVenta = @ptoVenta ");
                    query.AppendLine(" WHERE TRY_CONVERT(BIGINT, v.NumeroDocumento) = TRY_CONVERT(BIGINT, @NumeroDocumento) AND v.IdTipoComprobante = @tipoComprobante and v.PuntoVenta = @ptoVenta ");

                   

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    cmd.Parameters.AddWithValue("@tipoComprobante", tipoComprobante);
                    cmd.Parameters.AddWithValue("@ptoVenta", ptoVenta);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            venta = new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oUsuario = new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                },

                                oCliente = dr["IdCliente"] != DBNull.Value
                                ? new Cliente { IdCliente = Convert.ToInt32(dr["IdCliente"]) }
                                : null,

                               
                               // oTipoComprobante = _TipoComprobanteSeleccionado,

                               //public TipoComprobante ObtenerPorId(int idTipoComprobante)


                                //IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                //IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                //IdCliente = dr["IdCliente"] != DBNull.Value ? Convert.ToInt32(dr["IdCliente"]) : 0,


        //IdVentaOriginal = dr["IdVentaOriginal"] != DBNull.Value ? Convert.ToInt32(dr["IdVentaOriginal"]) : 0,
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"]),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                TotalIVA = Convert.ToDecimal(dr["TotalIVA"]),
                                TotalDescuento = Convert.ToDecimal(dr["TotalDescuento"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                Observaciones = dr["Observaciones"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                oTipoComprobante = new TipoComprobante()
                                {
                                    IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    IdListaPrecio = Convert.ToInt32(dr["IdListaPrecio"]),
                                    DiscriminaIVA = Convert.ToBoolean(dr["DiscriminaIVA"]),
                                    EsNotaCredito = Convert.ToBoolean(dr["EsNotaCredito"]),
                                    Estado = Convert.ToBoolean(dr["EstadoTipoComprobante"])
                                }
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    venta = null;
                    // Log error: ex.Message
                }
            }

            return venta;
        }

        // =============================================
        // MÉTODO 2: Obtener Detalle de Venta por IdVenta
        // =============================================
        public List<Detalle_Venta> ObtenerDetalleVentaPorId(int idVenta)
        {
            List<Detalle_Venta> lista = new List<Detalle_Venta>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT dv.IdDetalleVenta, dv.IdVenta, dv.IdProducto, dv.PrecioCosto,");
                    query.AppendLine("       dv.PrecioVenta, dv.Cantidad, dv.PorcentajeIVA, dv.ImporteIVA,");
                    query.AppendLine("       dv.PorcentajeDescuento, dv.ImporteDescuento, dv.SubTotal,");
                    query.AppendLine("       dv.IdListaPrecio, dv.Observaciones,");
                    query.AppendLine("       p.IdProducto, p.Codigo, p.Nombre, p.Descripcion, p.Stock,");
                    query.AppendLine("       p.PrecioCompra, p.PrecioVenta as PrecioVentaProducto, p.ControlaStock");
                    query.AppendLine("FROM DETALLE_VENTA dv");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto");
                    query.AppendLine("WHERE dv.IdVenta = @IdVenta");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Detalle_Venta()
                            {
                                IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"]),
                                //IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                //IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                PrecioCosto = Convert.ToDecimal(dr["PrecioCosto"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PorcentajeIVA = Convert.ToDecimal(dr["PorcentajeIVA"]),
                                ImporteIVA = Convert.ToDecimal(dr["ImporteIVA"]),
                                PorcentajeDescuento = Convert.ToDecimal(dr["PorcentajeDescuento"]),
                                ImporteDescuento = Convert.ToDecimal(dr["ImporteDescuento"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                IdListaPrecio = dr["IdListaPrecio"] != DBNull.Value ? Convert.ToInt32(dr["IdListaPrecio"]) : 0,
                                Observaciones = dr["Observaciones"].ToString(),
                                oProducto = new Producto()
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Stock = Convert.ToInt32(dr["Stock"]),
                                    PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVentaProducto"]),
                                    ControlaStock = Convert.ToBoolean(dr["ControlaStock"])
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Detalle_Venta>();
                    // Log error: ex.Message
                }
            }

            return lista;
        }

        // =============================================
        // MÉTODO 3: Registrar Nota de Crédito
        // =============================================
        public int RegistrarNotaCredito(Venta notaCredito, DataTable detalleVenta, out string mensaje)
        {
            int idNotaCreditoGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarNotaCredito", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@IdUsuario", notaCredito.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdTipoComprobante", notaCredito.oTipoComprobante.IdTipoComprobante);
                    //cmd.Parameters.AddWithValue("@IdCliente", notaCredito.oCliente?.IdCliente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdVentaOriginal", notaCredito.IdVentaOriginal);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", notaCredito.NumeroDocumento);
                   // cmd.Parameters.AddWithValue("@DocumentoCliente", notaCredito.DocumentoCliente);
                    //cmd.Parameters.AddWithValue("@NombreCliente", notaCredito.NombreCliente);
                    //cmd.Parameters.AddWithValue("@MontoPago", notaCredito.MontoPago);
                    cmd.Parameters.AddWithValue("@MontoCambio", notaCredito.MontoCambio);
                    cmd.Parameters.AddWithValue("@SubTotal", notaCredito.SubTotal);
                    cmd.Parameters.AddWithValue("@TotalIVA", notaCredito.TotalIVA);
                    cmd.Parameters.AddWithValue("@TotalDescuento", notaCredito.TotalDescuento);
                    cmd.Parameters.AddWithValue("@PorcentajeDescuento", notaCredito.PorcentajeDescuento);
                    cmd.Parameters.AddWithValue("@MontoTotal", notaCredito.MontoTotal);
                    cmd.Parameters.AddWithValue("@Observaciones", notaCredito.Observaciones ?? (object)DBNull.Value);

                    // Parámetro de tabla (detalle de venta)
                    SqlParameter paramDetalle = new SqlParameter("@DetalleVenta", SqlDbType.Structured);
                    paramDetalle.TypeName = "dbo.EDetalle_VentaFiscal";
                    paramDetalle.Value = detalleVenta;
                    cmd.Parameters.Add(paramDetalle);

                    // Parámetros de salida
                    cmd.Parameters.Add("@IdNotaCreditoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener resultados
                    bool resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    if (resultado)
                    {
                        idNotaCreditoGenerado = Convert.ToInt32(cmd.Parameters["@IdNotaCreditoResultado"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                idNotaCreditoGenerado = 0;
                mensaje = ex.Message;
            }

            return idNotaCreditoGenerado;
        }

        // =============================================
        // MÉTODO 4: Obtener Próximo Número de NC
        // =============================================
        public string ObtenerProximoNumeroNC(int idTipoComprobante)
        {
            string numeroDocumento = string.Empty;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ISNULL(MAX(CAST(SUBSTRING(NumeroDocumento, CHARINDEX('-', NumeroDocumento) + 1, LEN(NumeroDocumento)) AS INT)), 0) + 1 AS ProximoNumero");
                    query.AppendLine("FROM VENTA");
                    query.AppendLine("WHERE IdTipoComprobante = @IdTipoComprobante");
                    //query.AppendLine("AND NumeroDocumento LIKE '%-%'");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdTipoComprobante", idTipoComprobante);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    object result = cmd.ExecuteScalar();
                    int proximoNumero = result != null ? Convert.ToInt32(result) : 1;

                    // Formato: 0001-00000001
                    //numeroDocumento = string.Format("0001-{0:D10}", proximoNumero);
                    numeroDocumento = string.Format("{0:D10}", proximoNumero);
                }
                catch (Exception ex)
                {
                    //numeroDocumento = "0001-0000000001";
                    numeroDocumento = "0000000001";
                    // Log error: ex.Message
                }
            }

            return numeroDocumento;
        }

        // =============================================
        // MÉTODO 5: Determinar Tipo de Nota de Crédito
        // =============================================
        public int DeterminarTipoNotaCredito(int idTipoComprobanteOriginal)
        {
            int idTipoNC = 0;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    // Según el stored procedure:
                    // Factura A (1) -> NC A (4)
                    // Factura B (2) -> NC B (5)
                    // Remito (3) -> NC B (5)
                    
                    if (idTipoComprobanteOriginal == 1)
                    {
                        idTipoNC = 4; // Nota de Crédito A
                    }
                    if (idTipoComprobanteOriginal == 2)
                    {
                        idTipoNC = 5; // Nota de Crédito B
                    }
                    if (idTipoComprobanteOriginal == 3)
                    {
                        idTipoNC = 6; // Nota de R
                    }
                }
                catch (Exception ex)
                {
                    idTipoNC = 6; // Por defecto NC R
                    // Log error: ex.Message
                }
            }

            return idTipoNC;
        }

        // =============================================
        // MÉTODO 6: Convertir Lista a DataTable para SP
        // =============================================
        public DataTable ConvertirDetalleADataTable(List<Detalle_Venta> detalle)
        {
            DataTable dt = new DataTable();

            // Definir columnas según el tipo EDetalle_VentaFiscal
            dt.Columns.Add("IdProducto", typeof(int));
            dt.Columns.Add("PrecioCosto", typeof(decimal));
            dt.Columns.Add("PrecioVenta", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("PorcentajeIVA", typeof(decimal));
            dt.Columns.Add("ImporteIVA", typeof(decimal));
            dt.Columns.Add("PorcentajeDescuento", typeof(decimal));
            dt.Columns.Add("ImporteDescuento", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));
            dt.Columns.Add("IdListaPrecio", typeof(int));
            dt.Columns.Add("Observaciones", typeof(string));

            // Agregar filas
            foreach (var item in detalle)
            {
                dt.Rows.Add(
                    item.oProducto.IdProducto,
                    item.PrecioCosto,
                    item.PrecioVenta,
                    item.Cantidad,
                    item.PorcentajeIVA,
                    item.ImporteIVA,
                    item.PorcentajeDescuento,
                    item.ImporteDescuento,
                    item.SubTotal,
                    item.IdListaPrecio,
                    item.Observaciones ?? string.Empty
                );
            }

            return dt;
        }
    }
}
