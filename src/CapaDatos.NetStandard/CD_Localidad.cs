using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Localidad
    {
        public List<Localidad> Listar()
        {
            List<Localidad> lista = new List<Localidad>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT id_localidad, Descripción, id_provincia FROM LOCALIDAD ORDER BY Descripción");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Localidad()
                            {
                                IdLocalidad = Convert.ToInt32(dr["id_localidad"]),
                                Nombre = dr["Descripción"].ToString(),
                                IdProvincia = Convert.ToInt32(dr["id_provincia"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Localidad>();
                }
            }

            return lista;
        }

        public List<Localidad> ListarPorProvincia(int idProvincia)
        {
            List<Localidad> lista = new List<Localidad>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT id_localidad, Descripción, id_provincia FROM LOCALIDAD");
                    query.AppendLine("WHERE id_provincia = @IdProvincia");
                    query.AppendLine("ORDER BY Descripción");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Localidad()
                            {
                                IdLocalidad = Convert.ToInt32(dr["id_localidad"]),
                                Nombre = dr["Descripción"].ToString(),
                                IdProvincia = Convert.ToInt32(dr["id_provincia"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Localidad>();
                }
            }

            return lista;
        }
    }
}

