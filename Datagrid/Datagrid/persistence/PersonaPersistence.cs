using Datagrid.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datagrid.persistence
{
    class PersonaPersistence
    {
        private DataTable personaTable { get; set;}//check back later
        public PersonaPersistence()
        {
            personaTable = new DataTable();
            
        }
        //simulates reading from a database
        public static List<Persona> leerPersonas()
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona("Luis", "Rodríguez", 40));
            personas.Add(new Persona("Pepe", "Sanchez", 60));
            personas.Add(new Persona("Jose", "Mondongo", 10));
            personas.Add(new Persona("Gabriel", "Hernandez", 86));
            personas.Add(new Persona("Asier", "Carretero", 32));
            personas.Add(new Persona("Cristobal", "Colon", 344));
            return personas;
        }
    }
}
