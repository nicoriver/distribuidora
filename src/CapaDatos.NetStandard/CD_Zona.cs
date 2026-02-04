using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Zona
    {
        public List<Zona> Listar()
        {
            List<Zona> lista = new List<Zona>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT id_Zona, Descripción FROM ZONA ORDER BY Descripción");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Zona()
                            {
                                IdZona = Convert.ToInt32(dr["id_Zona"]),
                                Nombre = dr["Descripción"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Zona>();
                }
            }

            return lista;
        }
    }
}

