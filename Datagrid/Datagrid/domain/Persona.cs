using Datagrid.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datagrid.domain
{
    class Persona
    {
        private String nombre;
        private String apellidos;
        private int edad;
        private List<Persona> lsPersonas;
        public Persona(String nombre, String apellidos, int edad)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }
        public Persona() { 
            lsPersonas=new List<Persona>();
        }

        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public List<Persona> getPersonas()
        {
            lsPersonas=PersonaPersistence.leerPersonas();
            return lsPersonas;
            
        }
    }
}
