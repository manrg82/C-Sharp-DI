using DataGridConLinq;
using ExampleMVCnoDatabase.Persistence;
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
        private DataTable personaTable { get; set;}
        public PersonaPersistence()
        {
            personaTable = new DataTable();
            
        }
        public static List<Persona> leerPersonas()
        {
            Persona p = null;
            List<Object> aux =DBBroker.obtenerAgente().leer("Select * from mydb.persona;");
            List<Persona> personas = new List<Persona>();
            foreach (List<Object> fila in aux)
            {
                p = new Persona(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), Convert.ToInt32(fila[3]));//id,nombre,apellido,edad
                personas.Add(p);
                Console.WriteLine(p.ToString());
            }
            return personas;
        }

        public void insertarPersona(Persona persona)
        {
            DBBroker.obtenerAgente().modificar("Insert into mydb.persona (nombre, apellidos, edad) values ('" + persona.Nombre + "', '" + persona.Apellidos + "', " + persona.Edad + ");");
        }

        /*
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
        }*/
    }
}
