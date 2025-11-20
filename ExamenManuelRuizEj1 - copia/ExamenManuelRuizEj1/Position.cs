using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenManuelRuizEj1
{
    internal class Position
    {
        int x { get; set; }
        int y { get; set; }
        bool isMouse { get; set; }
        bool isSnake { get; set; }
        public Position(int x, int y, bool isMouse, bool isSnake)
        {
            this.x = x;
            this.y = y;
            this.isMouse = isMouse;
            this.isSnake = isSnake;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public bool getIsMouse()
        {
            return isMouse;
        }
        public bool getIsSnake()
        {
            return isSnake;
        }
    }
}
