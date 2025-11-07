using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridConLinq
{
    class Persona
    {
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public int Edad { get; set; }
        
        public Persona(String nombre, String apellidos, int edad)
        {
            Nombre = nombre;
            Edad = edad;
            Apellidos = apellidos;
        }



    }
}
