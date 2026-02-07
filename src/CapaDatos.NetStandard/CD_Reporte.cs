using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteCompras", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.Parameters.AddWithValue("idproveedor", idproveedor);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DocumentoProveedor"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = dr["PrecioCompra"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<ReporteCompra>();
                }
            }

            return lista;

        }

        public List<Venta> ObtenerVentas(string fechaInicio, string fechaFin, int? idTipoComprobante, int? puntoVenta)
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "sp_ReporteVentas";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@IdTipoComprobante", idTipoComprobante ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PuntoVenta", puntoVenta ?? (object)DBNull.Value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oTipoComprobante = new TipoComprobante()
                                {
                                    IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                    Descripcion = dr["TipoComprobante"].ToString()
                                },
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                // Obtener detalle
                                //oDetalle_Venta = new Detalle_Venta()
                                //{
                                //    oDetalle_Venta.ObtenerDetalleVentaCompleto(Convert.ToInt32(dr["IdVenta"])),
                                //}
                                    
                                // Propiedad auxiliar para mostrar cantidad en grilla (puedes agregarla a Venta o ignorarla)
                                // CantidadProductos = Convert.ToInt32(dr["CantidadProductos"]) 
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Venta>();
                }
            }
            return lista;
        }


    }
}

