using ExamenManuelRuizEj3.domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenManuelRuizEj3.persistence.manage
{
    class JugadorPersistence
    {
        private DataTable jugadorTable { get; set; }
        public JugadorPersistence()
        {
            jugadorTable = new DataTable();

        }
        public static List<Jugador> leerPersonas()
        {
            Jugador j = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from examen.jugador;");
            List<Jugador> jugadores = new List<Jugador>();
            foreach (List<Object> fila in aux)
            {
                DateTime fechaDB = Convert.ToDateTime(fila[3]);
                string fechaFormateada = fechaDB.ToString("dd/MM/yyyy");
                j = new Jugador(Convert.ToInt32(fila[0]), fila[1].ToString(), Convert.ToInt32(fila[2]), fechaFormateada, Convert.ToInt32(fila[4]));
                jugadores.Add(j);
                Console.WriteLine(j.ToString());
            }
            return jugadores;
        }

        public void insertarPersona(Jugador jugador)
        {
            string sql = "INSERT INTO examen.jugador (nickname, punt, fecha, nivel) VALUES ('" +
                         jugador.Nick + "', '" +
                         jugador.Puntuacion + "', '" +
                         jugador.Fecha + "', '" +
                         jugador.Nivel + "');";
            int a = DBBroker.obtenerAgente().modificar(sql);
        }

        public void actualizarPersona(Jugador jugador)
        {
            string sql = "UPDATE examen.jugador SET " +
                         "nickname = '" + jugador.Nick+ "', " +
                         "punt = '" + jugador.Puntuacion+ "', " +
                         "fecha = '" + jugador.Fecha + "', " +
                         "nivel = '" + jugador.Nivel+ "' " +
                         "WHERE idpersona = " + jugador.Id + ";";
            int a = DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarPersona(int id)
        {
            string sql = "DELETE FROM examen.jugador WHERE id = " + id + ";";
            int a = DBBroker.obtenerAgente().modificar(sql);
        }
    }
}
