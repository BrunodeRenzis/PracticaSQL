using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        string nombre;
        string apellido;
        double dni;
        int id;

        //Llevar datos a la base
        public Persona(string nombre, string apellido, double dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }

        //Traer datos de la base
        public Persona(string nombre, string apellido, double dni, int id) : this(nombre, apellido, dni)
        {
            this.Id = id;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public double Dni { get => dni; set => dni = value; }
        public int Id { get => id; set => id = value; }
    }
}
