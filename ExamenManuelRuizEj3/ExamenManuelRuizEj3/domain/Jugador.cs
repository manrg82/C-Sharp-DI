using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenManuelRuizEj3.domain
{
    class Jugador
    {
        public int Id { get; set; }
        public String Nick { get; set; }
        public int Puntuacion { get; set; }
        public String Fecha { get; set; }
        public int Nivel { get; set; }
        public Jugador(String nick, int puntuacion, String fecha, int nivel)
        {
            Nick = nick;
            Puntuacion = puntuacion;
            Fecha = fecha;
            Nivel = nivel;
        }
        public Jugador(int id,String nick, int puntuacion, String fecha, int nivel)
        {
            Id = id;
            Nick = nick;
            Puntuacion = puntuacion;
            Fecha = fecha;
            Nivel = nivel;
        }
        public Jugador()
        {
            Nick = "";
            Puntuacion = 0;
            Fecha = "";
            Nivel = 0;
        }
        
    }
}
