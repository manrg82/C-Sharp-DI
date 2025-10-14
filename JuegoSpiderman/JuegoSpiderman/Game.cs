using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    internal class Game
    {
        public void startGame(int diff)
        {
            Tile[][] tl = new Tile[15][];
            char[][] ch = new char[15][];
            List<int[]> lastpos = new List<int[]>();
            Board bd = new Board(diff, tl, ch, lastpos);//dificultad va de 1-5 mayor a menor
            bd.generateBoards();
            bd.printArray(bd.getDisplayBoard());
            Console.WriteLine();
            bd.printArray(bd.getDisplayBoard());
        }
    }
}
