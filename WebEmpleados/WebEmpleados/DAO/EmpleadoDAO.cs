using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebEmpleados.Models;

namespace WebEmpleados.DAO
{
    public class EmpleadoDAO
    {
        string cadena = ConfigurationManager.ConnectionStrings["cadenaConex"].ConnectionString;

        public List<Empleado> ListarTodos()
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select idEmp,nombres,apellidos,correo,fechaNac,sueldo " +
                        " from tbl_Empleados", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new Empleado()
                        {
                            idEmp = dr.GetInt32(0),
                            nombres = dr.GetString(1),
                            apellidos = dr.GetString(2),
                            correo = dr.GetString(3),
                            fechaNac = dr.GetDateTime(4),
                            sueldo = dr.GetDecimal(5)
                        });
                    }
                }
                catch (Exception ex){}
                finally
                {
                    cn.Close();
                }
            }
            return lista;
        }

        public string Agregar(Empleado obj)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("insert into tbl_Empleados(nombres,apellidos,correo,fechaNac,sueldo) " +
                        " values(@nombres,@apellidos,@correo,@fechaNac,@sueldo)", cn);
                    cmd.Parameters.AddWithValue("@nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", obj.apellidos);
                    cmd.Parameters.AddWithValue("@correo", obj.correo);
                    cmd.Parameters.AddWithValue("@fechaNac", obj.fechaNac);
                    cmd.Parameters.AddWithValue("@sueldo", obj.sueldo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        mensaje = "OK";
                    }
                    else
                    {
                        mensaje = "Lo sentimos no se pudieron guardaron datos.";
                    }
 
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    cn.Close();
                }
            }
            return mensaje;
        }

        public string Editar(Empleado obj)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update tbl_Empleados set nombres=@nombres,apellidos=@apellidos," +
                        " correo=@correo,fechaNac=@fechaNac,sueldo=@sueldo where idEmp=@id", cn);
                    cmd.Parameters.AddWithValue("@nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", obj.apellidos);
                    cmd.Parameters.AddWithValue("@correo", obj.correo);
                    cmd.Parameters.AddWithValue("@fechaNac", obj.fechaNac);
                    cmd.Parameters.AddWithValue("@sueldo", obj.sueldo);
                    cmd.Parameters.AddWithValue("@id", obj.idEmp);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        mensaje = "OK";
                    }
                    else
                    {
                        mensaje = "Lo sentimos no se pudieron editar datos.";
                    }

                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    cn.Close();
                }
            }
            return mensaje;
        }

        public string Eliminar(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from tbl_Empleados where idEmp = @id", cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        mensaje = "OK";
                    }
                    else
                    {
                        mensaje = "Lo sentimos no se pudieron eliminar datos.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    cn.Close();
                }
            }
            return mensaje;
        }

        public Empleado Buscar(int id)
        {
            Empleado obj = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select idEmp,nombres,apellidos,correo,fechaNac,sueldo " +
                        " from tbl_Empleados where idEmp = @id", cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        obj = new Empleado()
                        {
                            idEmp = dr.GetInt32(0),
                            nombres = dr.GetString(1),
                            apellidos = dr.GetString(2),
                            correo = dr.GetString(3),
                            fechaNac = dr.GetDateTime(4),
                            sueldo = dr.GetDecimal(5)
                        };
                    }
                }
                catch (Exception ex) { }
                finally
                {
                    cn.Close();
                }
            }
            return obj;
        }
    }
}