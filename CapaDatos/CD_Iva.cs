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
    public class CD_Iva
    {
        public List<Iva> Listar()
        {
            List<Iva> lista = new List<Iva>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT id_IVA, Valor FROM IVA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Iva()
                            {
                                id_IVA = Convert.ToInt32(dr["id_IVA"]),
                                Valor = Convert.ToDecimal(dr["Valor"])
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Iva>();
                }
            }
            return lista;
        }
    }
}
