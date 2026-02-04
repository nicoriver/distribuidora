using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_TipoComprobante
    {
        public List<TipoComprobante> Listar()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdTipoComprobante, Codigo, Descripcion, IdListaPrecio,");
                    query.AppendLine("DiscriminaIVA, EsNotaCredito, Estado, FechaRegistro");
                    query.AppendLine("FROM TipoComprobante");
                    query.AppendLine("WHERE Estado = 1");
                    query.AppendLine("ORDER BY IdTipoComprobante");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TipoComprobante()
                            {
                                IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                Codigo = dr["Codigo"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                IdListaPrecio = Convert.ToInt32(dr["IdListaPrecio"]),
                                DiscriminaIVA = Convert.ToBoolean(dr["DiscriminaIVA"]),
                                EsNotaCredito = Convert.ToBoolean(dr["EsNotaCredito"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<TipoComprobante>();
                }
            }
            return lista;
        }

        public TipoComprobante ObtenerPorId(int idTipoComprobante)
        {
            TipoComprobante obj = null;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdTipoComprobante, Codigo, Descripcion, IdListaPrecio,");
                    query.AppendLine("DiscriminaIVA, EsNotaCredito, Estado, FechaRegistro");
                    query.AppendLine("FROM TipoComprobante");
                    query.AppendLine("WHERE IdTipoComprobante = @IdTipoComprobante");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdTipoComprobante", idTipoComprobante);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new TipoComprobante()
                            {
                                IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                Codigo = dr["Codigo"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                IdListaPrecio = Convert.ToInt32(dr["IdListaPrecio"]),
                                DiscriminaIVA = Convert.ToBoolean(dr["DiscriminaIVA"]),
                                EsNotaCredito = Convert.ToBoolean(dr["EsNotaCredito"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = null;
                }
            }
            return obj;
        }

        public List<TipoComprobante> ListarParaVentas()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdTipoComprobante, Codigo, Descripcion, IdListaPrecio,");
                    query.AppendLine("DiscriminaIVA, EsNotaCredito, Estado, FechaRegistro");
                    query.AppendLine("FROM TipoComprobante");
                    query.AppendLine("WHERE Estado = 1 AND EsNotaCredito = 0");
                    query.AppendLine("ORDER BY IdTipoComprobante");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TipoComprobante()
                            {
                                IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]),
                                Codigo = dr["Codigo"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                IdListaPrecio = Convert.ToInt32(dr["IdListaPrecio"]),
                                DiscriminaIVA = Convert.ToBoolean(dr["DiscriminaIVA"]),
                                EsNotaCredito = Convert.ToBoolean(dr["EsNotaCredito"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<TipoComprobante>();
                }
            }
            return lista;
        }
    }
}

