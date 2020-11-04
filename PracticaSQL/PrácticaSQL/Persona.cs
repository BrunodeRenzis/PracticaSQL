using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrácticaSQL
{
    public class Persona
    {
        string apellido;
        int dni;
        int id;
        string nombre;

        public Persona()
        {

        }

        public Persona(string apellido, int dni, int id, string nombre):this()
        {
            this.Apellido = apellido;
            this.Dni = dni;
            this.Id = id;
            this.Nombre = nombre;
        }

        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre del seleccionado {this.Nombre}");
            sb.AppendLine($"Apellido del seleccionado {this.Apellido}");
            sb.AppendLine($"Dni del seleccionado {this.Dni}");
            sb.AppendLine($"ID del seleccionado {this.Id}");
            
            return sb.ToString();
        }
    }
}
