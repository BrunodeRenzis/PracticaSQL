using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace PrácticaSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string conexion = "Data Source=agasoluciones.dynamic-dns.net\\mssqlserver2; Initial Catalog = Mensajes; User Id=Alumno;Password=FraUtn;";
            SqlConnection miConexion = new SqlConnection();
            string nombreAlumno = String.Empty;
            string apellidoAlumno= String.Empty;
            string dniAlumno=String.Empty;
            string idAlumno=String.Empty;
            miConexion.ConnectionString=conexion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = miConexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from Personas where apellido='Noguera'";
            miConexion.Open();
            SqlDataReader lector = comando.ExecuteReader();
            while(lector.Read())
            {
                nombreAlumno = lector["Nombre"].ToString();
                apellidoAlumno = lector["Apellido"].ToString();
                dniAlumno = lector["DNI"].ToString();
                idAlumno  = lector["Id"].ToString();
            }
            Persona unaPersona = new Persona(apellidoAlumno,int.Parse(dniAlumno),int.Parse(idAlumno),nombreAlumno);
            lector.Close();
            comando.CommandText = "insert into Personas (Nombre,Apellido,DNI) values('Bruno', 'de Renzis',39104689)";
            comando.ExecuteNonQuery();

            Console.WriteLine(unaPersona.ToString());
            Console.ReadKey();
            
        }
    }
}
