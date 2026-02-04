using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Lista
    {
        public List<Lista> Listar(int idProducto)
        {
            List<Lista> lista = new List<Lista>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Id_Lista, Id_articulo, Descripcion, id_Tipolistas, Importe, Fecha_Modificacion, Iva, Recargo, Descuento");
                    query.AppendLine("FROM Lista");
                    query.AppendLine("WHERE Id_articulo = @idProducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Lista()
                            {
                                Id_Lista = Convert.ToInt32(dr["Id_Lista"]),
                                Id_articulo = Convert.ToInt32(dr["Id_articulo"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                id_Tipolistas = Convert.ToInt32(dr["id_Tipolistas"]),
                                Importe = Convert.ToDecimal(dr["Importe"]),
                                Fecha_Modificacion = dr["Fecha_Modificacion"].ToString(),
                                Iva = Convert.ToDecimal(dr["Iva"]),
                                Recargo = Convert.ToDecimal(dr["Recargo"]),
                                Descuento = Convert.ToDecimal(dr["Descuento"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Lista>();
                }
            }
            return lista;
        }

        public int Registrar(Lista obj, out string Mensaje)
        {
            int idGenerado = 0;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Lista (Id_articulo, Descripcion, id_Tipolistas, Importe, Fecha_Modificacion, Iva, Recargo, Descuento)");
                    query.AppendLine("VALUES (@Id_articulo, @Descripcion, @id_Tipolistas, @Importe, GETDATE(), @Iva, @Recargo, @Descuento);");
                    query.AppendLine("SELECT SCOPE_IDENTITY();");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Id_articulo", obj.Id_articulo);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@id_Tipolistas", obj.id_Tipolistas);
                    cmd.Parameters.AddWithValue("@Importe", obj.Importe);
                    cmd.Parameters.AddWithValue("@Iva", obj.Iva);
                    cmd.Parameters.AddWithValue("@Recargo", obj.Recargo);
                    cmd.Parameters.AddWithValue("@Descuento", obj.Descuento);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idGenerado = 0;
                    Mensaje = ex.Message;
                }
            }
            return idGenerado;
        }

        public bool Editar(Lista obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Lista SET");
                    query.AppendLine("Descripcion = @Descripcion,");
                    query.AppendLine("id_Tipolistas = @id_Tipolistas,");
                    query.AppendLine("Importe = @Importe,");
                    query.AppendLine("Fecha_Modificacion = GETDATE(),");
                    query.AppendLine("Iva = @Iva,");
                    query.AppendLine("Recargo = @Recargo,");
                    query.AppendLine("Descuento = @Descuento");
                    query.AppendLine("WHERE Id_Lista = @Id_Lista");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Id_Lista", obj.Id_Lista);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@id_Tipolistas", obj.id_Tipolistas);
                    cmd.Parameters.AddWithValue("@Importe", obj.Importe);
                    cmd.Parameters.AddWithValue("@Iva", obj.Iva);
                    cmd.Parameters.AddWithValue("@Recargo", obj.Recargo);
                    cmd.Parameters.AddWithValue("@Descuento", obj.Descuento);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return respuesta;
        }

        public bool Eliminar(int idLista, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Lista WHERE Id_Lista = @Id_Lista");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Id_Lista", idLista);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return respuesta;
        }
    }
}

