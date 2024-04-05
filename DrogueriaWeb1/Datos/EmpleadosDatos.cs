using DrogueriaWeb1.Models;
using System.Data.SqlClient;
using System.Data;

namespace DrogueriaWeb1.Datos
{
    public class EmpleadosDatos
    {
        public List<EmpleadosModel> Listar()
        {
            var oLista = new List<EmpleadosModel>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAREMPLEADOS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadosModel()
                        {
                            Id_empleado = dr["Id_empleado"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString()  
                        });
                    }
                }
            }
            return oLista;
        }

        public EmpleadosModel Obtener(String Id_empleado)
        {
            var oEmpleado = new EmpleadosModel();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENEREMPLEADO", conexion);
                cmd.Parameters.AddWithValue("Id_empleado",Id_empleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEmpleado.Id_empleado = dr["Id_empleado"].ToString();
                        oEmpleado.Nombre = dr["Nombre"].ToString();
                        oEmpleado.Telefono = dr["Telefono"].ToString(); 

                    }
                }
            }
            return oEmpleado;
        }

        public bool Guardar(EmpleadosModel oEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GUARDARCONTACTO", conexion);
                    cmd.Parameters.AddWithValue("Id_empleado", oEmpleado.Id_empleado);
                    cmd.Parameters.AddWithValue("Nombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oEmpleado.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    
                }
                rpta = true;

            } catch (Exception e)
            {
                string error= e.Message;
                rpta=false;
            }

            return rpta;

        }

        public bool Editar(EmpleadosModel oEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITAREMPLEADO", conexion);
                    cmd.Parameters.AddWithValue("Id_empleado", oEmpleado.Id_empleado);
                    cmd.Parameters.AddWithValue("Nombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oEmpleado.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;

        }

        public bool Eliminar(int Id_empleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAREMPLEADO", conexion);
                    cmd.Parameters.AddWithValue("Id_empleado", Id_empleado);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;

        }

    }
}
