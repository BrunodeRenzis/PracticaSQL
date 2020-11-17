using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PersonaDAO
    {
        public static List<Persona> TraerPersonas()
        {
            string conexion = "Data Source=agasoluciones.dynamic-dns.net\\mssqlserver2; Initial Catalog = Mensajes; User Id=Alumno;Password=FraUtn;";
            SqlConnection miConexion = new SqlConnection();
            try
            {
                List<Persona> listaPersonas = new List<Persona>();
                
                
                miConexion.ConnectionString = conexion;
                SqlCommand comando = new SqlCommand();
                comando.Connection = miConexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from Personas";
                miConexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    listaPersonas.Add(new Persona(lector["Nombre"].ToString(), lector["Apellido"].ToString(), (double)((decimal)(lector["dni"])), (int)((decimal)(lector["id"]))));
                }
                return listaPersonas;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                miConexion.Close();
            }
          
        }
    }
}
