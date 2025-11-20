using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenManuelRuizEj1
{
    internal class Snake
    {
        List<Position> body;
        public Snake()
        {
            body = new List<Position>{new Position(0, 0, false, true), new Position(0, 1, false, true) , new Position(0, 2, false, true) , new Position(0, 3, false, true)};
        }
        public List<Position> getBody()
        {
            return body;
        }
        
        public void move(Position pos)
        {
            List<Position> newBody = new List<Position>();
            newBody.Add(pos);
            for (int i = 0; i < 3; i++)
            {
                newBody.Add(body[i]);
            }
            body = newBody;
        }
        public Position getLastPos()
        {
            return body[body.Count - 1];
        }
        }

    }

