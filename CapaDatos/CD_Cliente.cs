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
    public class CD_Cliente
    {

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Id_Cliente, Apellido, Nombre, Razon_Social, Domicilio, Dni, id_Tipo_dni, Id_Codigo_Iva, Cuit, Id_Zona, Id_Localidad, Id_Provincia, Id_Pais, Telefono, Telefono_Alt, Fax, Email, Web, Contacto, Id_vendedor, Latitud, Longitug, Estado from CLIENTE");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["Id_Cliente"]),
                                Apellido = dr["Apellido"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                RazonSocial = dr["Razon_Social"].ToString(),
                                Domicilio = dr["Domicilio"].ToString(),
                                Dni = dr["Dni"].ToString(),
                                IdTipoDni = Convert.ToInt32(dr["id_Tipo_dni"]),
                                IdCodigoIva = Convert.ToInt32(dr["Id_Codigo_Iva"]),
                                Cuit = dr["Cuit"].ToString(),
                                IdZona = Convert.ToInt32(dr["Id_Zona"]),
                                IdLocalidad = Convert.ToInt32(dr["Id_Localidad"]),
                                IdProvincia = Convert.ToInt32(dr["Id_Provincia"]),
                                IdPais = Convert.ToInt32(dr["Id_Pais"]),
                                Telefono = dr["Telefono"].ToString(),
                                TelefonoAlt = dr["Telefono_Alt"].ToString(),
                                Fax = dr["Fax"].ToString(),
                                Email = dr["Email"].ToString(),
                                Web = dr["Web"].ToString(),
                                Contacto = dr["Contacto"].ToString(),
                                IdVendedor = Convert.ToInt32(dr["Id_vendedor"]),
                                Latitud = Convert.ToDecimal(dr["Latitud"]),
                                Longitud = Convert.ToDecimal(dr["Longitug"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }
        public Cliente ObtenerPorId(int idCliente)
        {
            Cliente oCliente = null;
            using (SqlConnection oconexion = Conexion.GetConnection())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Id_Cliente, Apellido, Nombre, Razon_Social, Domicilio, Dni, id_Tipo_dni, Id_Codigo_Iva, Cuit, Id_Zona, Id_Localidad, Id_Provincia, Id_Pais, Telefono, Telefono_Alt, Fax, Email, Web, Contacto, Id_vendedor, Latitud, Longitug, Estado");
                    query.AppendLine("FROM CLIENTE");
                    query.AppendLine("WHERE Id_Cliente = @IdCliente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oCliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["Id_Cliente"]),
                                Apellido = dr["Apellido"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                RazonSocial = dr["Razon_Social"].ToString(),
                                Domicilio = dr["Domicilio"].ToString(),
                                Dni = dr["Dni"].ToString(),
                                IdTipoDni = Convert.ToInt32(dr["id_Tipo_dni"]),
                                IdCodigoIva = Convert.ToInt32(dr["Id_Codigo_Iva"]),
                                Cuit = dr["Cuit"].ToString(),
                                IdZona = Convert.ToInt32(dr["Id_Zona"]),
                                IdLocalidad = Convert.ToInt32(dr["Id_Localidad"]),
                                IdProvincia = Convert.ToInt32(dr["Id_Provincia"]),
                                IdPais = Convert.ToInt32(dr["Id_Pais"]),
                                Telefono = dr["Telefono"].ToString(),
                                TelefonoAlt = dr["Telefono_Alt"].ToString(),
                                Fax = dr["Fax"].ToString(),
                                Email = dr["Email"].ToString(),
                                Web = dr["Web"].ToString(),
                                Contacto = dr["Contacto"].ToString(),
                                IdVendedor = Convert.ToInt32(dr["Id_vendedor"]),
                                Latitud = Convert.ToDecimal(dr["Latitud"]),
                                Longitud = Convert.ToDecimal(dr["Longitug"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    oCliente = null;
                }
            }
            return oCliente;
        }
        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", oconexion);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Razon_Social", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Domicilio", obj.Domicilio);
                    cmd.Parameters.AddWithValue("Dni", obj.Dni);
                    cmd.Parameters.AddWithValue("id_Tipo_dni", obj.IdTipoDni);
                    cmd.Parameters.AddWithValue("Id_Codigo_Iva", obj.IdCodigoIva);
                    cmd.Parameters.AddWithValue("Cuit", obj.Cuit);
                    cmd.Parameters.AddWithValue("Id_Zona", obj.IdZona);
                    cmd.Parameters.AddWithValue("Id_Localidad", obj.IdLocalidad);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.IdProvincia);
                    cmd.Parameters.AddWithValue("Id_Pais", obj.IdPais);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Telefono_Alt", obj.TelefonoAlt);
                    cmd.Parameters.AddWithValue("Fax", obj.Fax);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Web", obj.Web);
                    cmd.Parameters.AddWithValue("Contacto", obj.Contacto);
                    cmd.Parameters.AddWithValue("Id_vendedor", obj.IdVendedor);
                    cmd.Parameters.AddWithValue("Latitud", obj.Latitud);
                    cmd.Parameters.AddWithValue("Longitug", obj.Longitud);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }

            return idClientegenerado;
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarCliente", oconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Razon_Social", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Domicilio", obj.Domicilio);
                    cmd.Parameters.AddWithValue("Dni", obj.Dni);
                    cmd.Parameters.AddWithValue("id_Tipo_dni", obj.IdTipoDni);
                    cmd.Parameters.AddWithValue("Id_Codigo_Iva", obj.IdCodigoIva);
                    cmd.Parameters.AddWithValue("Cuit", obj.Cuit);
                    cmd.Parameters.AddWithValue("Id_Zona", obj.IdZona);
                    cmd.Parameters.AddWithValue("Id_Localidad", obj.IdLocalidad);
                    cmd.Parameters.AddWithValue("Id_Provincia", obj.IdProvincia);
                    cmd.Parameters.AddWithValue("Id_Pais", obj.IdPais);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Telefono_Alt", obj.TelefonoAlt);
                    cmd.Parameters.AddWithValue("Fax", obj.Fax);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Web", obj.Web);
                    cmd.Parameters.AddWithValue("Contacto", obj.Contacto);
                    cmd.Parameters.AddWithValue("Id_vendedor", obj.IdVendedor);
                    cmd.Parameters.AddWithValue("Latitud", obj.Latitud);
                    cmd.Parameters.AddWithValue("Longitug", obj.Longitud);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = Conexion.GetConnection())
                {
                    
                    SqlCommand cmd = new SqlCommand("delete from cliente where Id_Cliente = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


    }
}
