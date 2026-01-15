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
    public class CD_Venta
    {

        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from VENTA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
            }
            return idcorrelativo;
        }

        public bool RestarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update producto set stock = stock - @cantidad where idproducto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;

        }


        public bool SumarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update producto set stock = stock + @cantidad where idproducto = @idproducto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;

        }



        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;
        }


        public Venta ObtenerVenta(string numero) {

            Venta obj = new Venta();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena)) {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select v.IdVenta,u.NombreCompleto,");
                    query.AppendLine("v.DocumentoCliente,v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento,v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago,v.MontoCambio,v.MontoTotal,");
                    query.AppendLine("convert(char(10),v.FechaRegistro,103)[FechaRegistro]");
                    query.AppendLine("from VENTA v");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = v.IdUsuario");
                    query.AppendLine("where v.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader()) {

                        while (dr.Read()) {
                            obj = new Venta()
                            {
                                IdVenta = int.Parse(dr["IdVenta"].ToString()),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }

                }
                catch {
                    obj = new Venta();
                }

            }
            return obj;

        }


        public List<Detalle_Venta> ObtenerDetalleVenta(int idVenta) {
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena)) {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.Nombre,dv.PrecioVenta,dv.Cantidad,dv.SubTotal from DETALLE_VENTA dv");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dv.IdProducto");
                    query.AppendLine(" where dv.IdVenta = @idventa");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idventa", idVenta);
                    cmd.CommandType = System.Data.CommandType.Text;


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Venta()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString()),
                            });
                        }
                    }

                }
                catch {
                    oLista = new List<Detalle_Venta>();
                }
            }
            return oLista;
        }


        // =============================================
        // Métodos para Ventas Fiscales
        // =============================================

        public bool RegistrarVentaFiscal(Venta obj, DataTable DetalleVenta, out int idVentaGenerado, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            idVentaGenerado = 0;

            try
            {
                using (SqlConnection oconexion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarVentaFiscal", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdTipoComprobante", obj.oTipoComprobante.IdTipoComprobante);
                    cmd.Parameters.AddWithValue("IdCliente", obj.oCliente != null ? (object)obj.oCliente.IdCliente : DBNull.Value);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("SubTotal", obj.SubTotal);
                    cmd.Parameters.AddWithValue("TotalIVA", obj.TotalIVA);
                    cmd.Parameters.AddWithValue("TotalDescuento", obj.TotalDescuento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("Observaciones", obj.Observaciones ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("IdVentaResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    idVentaGenerado = Convert.ToInt32(cmd.Parameters["IdVentaResultado"].Value);
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
                idVentaGenerado = 0;
            }

            return Respuesta;
        }

        public bool RegistrarNotaCredito(Venta obj, DataTable DetalleVenta, out int idNotaCreditoGenerado, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            idNotaCreditoGenerado = 0;

            try
            {
                using (SqlConnection oconexion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarNotaCredito", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdVentaOriginal", obj.oVentaOriginal.IdVenta);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("SubTotal", obj.SubTotal);
                    cmd.Parameters.AddWithValue("TotalIVA", obj.TotalIVA);
                    cmd.Parameters.AddWithValue("TotalDescuento", obj.TotalDescuento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("Observaciones", obj.Observaciones ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("IdNotaCreditoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    idNotaCreditoGenerado = Convert.ToInt32(cmd.Parameters["IdNotaCreditoResultado"].Value);
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
                idNotaCreditoGenerado = 0;
            }

            return Respuesta;
        }

        public Venta ObtenerVentaCompleta(string numeroDocumento)
        {
            Venta obj = new Venta();

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT v.IdVenta, v.IdTipoComprobante, v.IdCliente, v.IdVentaOriginal,");
                    query.AppendLine("u.IdUsuario, u.NombreCompleto,");
                    query.AppendLine("tc.Codigo, tc.Descripcion AS TipoComprobanteDesc, tc.IdListaPrecio, tc.DiscriminaIVA,");
                    query.AppendLine("v.DocumentoCliente, v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento, v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago, v.MontoCambio, v.SubTotal, v.TotalIVA, v.TotalDescuento, v.MontoTotal,");
                    query.AppendLine("v.Observaciones,");
                    query.AppendLine("CONVERT(CHAR(10), v.FechaRegistro, 103) AS FechaRegistro");
                    query.AppendLine("FROM VENTA v");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = v.IdUsuario");
                    query.AppendLine("LEFT JOIN TipoComprobante tc ON tc.IdTipoComprobante = v.IdTipoComprobante");
                    query.AppendLine("WHERE v.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@numero", numeroDocumento);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oUsuario = new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    NombreCompleto = dr["NombreCompleto"].ToString()
                                },
                                oTipoComprobante = dr["IdTipoComprobante"] != DBNull.Value ? new TipoComprobante()
                                {
                                    IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Descripcion = dr["TipoComprobanteDesc"].ToString(),
                                    IdListaPrecio = Convert.ToInt32(dr["IdListaPrecio"]),
                                    DiscriminaIVA = Convert.ToBoolean(dr["DiscriminaIVA"])
                                } : null,
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"]),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                TotalIVA = Convert.ToDecimal(dr["TotalIVA"]),
                                TotalDescuento = Convert.ToDecimal(dr["TotalDescuento"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                Observaciones = dr["Observaciones"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch
                {
                    obj = new Venta();
                }
            }
            return obj;
        }

        public List<Detalle_Venta> ObtenerDetalleVentaCompleto(int idVenta)
        {
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT dv.IdDetalleVenta, dv.IdProducto,");
                    query.AppendLine("p.Codigo, p.Nombre,");
                    query.AppendLine("dv.PrecioCosto, dv.PrecioVenta, dv.Cantidad,");
                    query.AppendLine("dv.PorcentajeIVA, dv.ImporteIVA,");
                    query.AppendLine("dv.PorcentajeDescuento, dv.ImporteDescuento,");
                    query.AppendLine("dv.SubTotal, dv.IdListaPrecio, dv.Observaciones");
                    query.AppendLine("FROM DETALLE_VENTA dv");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto");
                    query.AppendLine("WHERE dv.IdVenta = @idventa");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idventa", idVenta);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Venta()
                            {
                                IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"]),
                                oProducto = new Producto()
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString()
                                },
                                PrecioCosto = Convert.ToDecimal(dr["PrecioCosto"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PorcentajeIVA = Convert.ToDecimal(dr["PorcentajeIVA"]),
                                ImporteIVA = Convert.ToDecimal(dr["ImporteIVA"]),
                                PorcentajeDescuento = Convert.ToDecimal(dr["PorcentajeDescuento"]),
                                ImporteDescuento = Convert.ToDecimal(dr["ImporteDescuento"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                IdListaPrecio = Convert.ToInt32(dr["IdListaPrecio"]),
                                Observaciones = dr["Observaciones"].ToString()
                            });
                        }
                    }
                }
                catch
                {
                    oLista = new List<Detalle_Venta>();
                }
            }
            return oLista;
        }

        public bool ValidarStockDisponible(int idProducto, int cantidadRequerida, out string mensaje)
        {
            bool hayStock = false;
            mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Nombre, p.Stock, p.ControlaStock");
                    query.AppendLine("FROM PRODUCTO p");
                    query.AppendLine("WHERE p.IdProducto = @idProducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            bool controlaStock = Convert.ToBoolean(dr["ControlaStock"]);
                            
                            if (!controlaStock)
                            {
                                // Si no controla stock, siempre hay disponible
                                hayStock = true;
                            }
                            else
                            {
                                int stockActual = Convert.ToInt32(dr["Stock"]);
                                string nombreProducto = dr["Nombre"].ToString();

                                if (stockActual >= cantidadRequerida)
                                {
                                    hayStock = true;
                                }
                                else
                                {
                                    mensaje = $"Stock insuficiente para {nombreProducto}. Disponible: {stockActual}, Requerido: {cantidadRequerida}";
                                }
                            }
                        }
                        else
                        {
                            mensaje = "Producto no encontrado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    hayStock = false;
                    mensaje = ex.Message;
                }
            }
            return hayStock;
        }

    }
}
