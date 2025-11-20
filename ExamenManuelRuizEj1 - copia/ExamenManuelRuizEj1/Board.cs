using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamenManuelRuizEj1
{
    internal class Board
    {
        int amtMice;
        int miceEaten;
        int size;
        Snake snake;
        Position[][] board;
        bool isEnd;
        int x;
        int y;
        public Board()
        {
            int y= 0;
            int x = 3;
            isEnd = false;
            this.amtMice = 0;
            miceEaten = 0;
            snake = new Snake();
            Console.WriteLine("Enter board size: ");
            size = Convert.ToInt32(Console.ReadLine());
            board = new Position[size][];
            populateBoard();
            startGame();
        }
        public void populateBoard()
        {
            int rdm;
            int i;
            for (i = 0; i < size; i++)
            {
                board[i] = new Position[size];
                for (int j = 0; j < size; j++)
                {
                    rdm = RandomNumberGenerator.GetInt32(0, size);
                    if (rdm < 1)
                    {
                        board[i][j] = new Position(i, j, true, false);
                        amtMice++;
                    }
                    else
                    {
                        board[i][j] = new Position(i, j, false, false);

                    }
                }
            }
            for(i = 0; i < 4; ++i)
            {
                if (board[0][i].getIsMouse())
                {
                    board[0][i] = new Position(0, 0, false, true);
                    amtMice--;
                }
                else
                {
                    board[0][i] = new Position(0, 0, false, true);
                }
            }
            
            
        }
        public void printBoard()
        {
            for(int i = 0; i < size; ++i)
            {
                for(int j = 0; j < size; ++j)
                {
                    if(board[i][j].getIsMouse())
                    {
                        Console.Write("M ");
                    }
                    else if (board[i][j].getIsSnake())
                    {
                        Console.Write("S ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Mice eaten: {miceEaten}/{amtMice}");
        }
        public void startGame()
        {
            while (!isEnd)
            {
                printBoard();
                isEnd = doMovement(Console.ReadKey().KeyChar);

            }
        }
        public bool doMovement(char c)
        {
            Console.WriteLine();
            Console.WriteLine("Enter your move (WASD): ");
            switch (c){ 
                case 'w':
                    if (x != size - 1)
                    {
                        foreach (Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()] = new Position(p.getX(), p.getY(), false, false);
                        }
                        y++;
                        snake.move(board[y][x]);
                        if (board[y][x].getIsMouse() && !board[y][x].getIsSnake())
                        {
                            amtMice--;
                        }
                        
                        if (board[y][x].getIsSnake())
                        {
                            Console.WriteLine("Te has chocado contigo mismo");
                            return true;
                        }
                        else
                        {
                            board[y][x] = new Position(x, y, false, true);
                        }
                        foreach (Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()] = new Position(p.getX(), p.getY(), false, true);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Te has chocado con el borde, prueba otro movimiento");
                    }
                    if (amtMice != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case 'a':
                    if (x != size - 1)
                    {
                        foreach (Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()] = new Position(p.getX(), p.getY(), false, false);
                        }
                        x--;
                        snake.move(board[y][x]);
                        if (board[y][x].getIsMouse() && !board[y][x].getIsSnake())
                        {
                            amtMice--;
                        }
                        if (board[y][x].getIsSnake())
                        {
                            Console.WriteLine("Te has chocado contigo mismo");
                            return true;
                        }
                        else
                        {
                            board[y][x] = new Position(x, y, false, true);
                        }
                        foreach (Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()] = new Position(p.getX(), p.getY(), false, true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Te has chocado con el borde, prueba otro movimiento");
                    }
                    if (amtMice != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case 's':
                    if (x != size - 1)
                    {
                        foreach (Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()] = new Position(p.getX(), p.getY(), false, false);
                        }
                        y++;
                        fsnake.move(board[y][x]);
                        if (board[y][x].getIsMouse() && !board[y][x].getIsSnake())
                        {
                            board[snake.getLastPos().getY()][snake.getLastPos().getX()] = new Position(snake.getLastPos().getX(), snake.getLastPos().getY(), false, false);
                            amtMice--;
                        }
                        if (board[y][x].getIsSnake())
                        {
                            Console.WriteLine("Te has chocado contigo mismo");
                            return true;
                        }
                        else
                        {
                            board[y][x] = new Position(x, y, false, true);
                        }
                        foreach (Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()] = new Position(p.getX(), p.getY(), false, true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Te has chocado con el borde, prueba otro movimiento");
                    }
                    if (amtMice != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case 'd':
                    if (x != size-1)
                    {
                        foreach(Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()]=new Position(p.getX(), p.getY(), false, false);
                        }
                        x++;
                        snake.move(board[y][x]);
                        if (board[y][x].getIsMouse()&& !board[y][x].getIsSnake())
                        {
                            board[snake.getLastPos().getY()][snake.getLastPos().getX()] = new Position(snake.getLastPos().getX(), snake.getLastPos().getY(), false, false);
                            amtMice--;
                        }
                        if (board[y][x].getIsSnake())
                        {
                            Console.WriteLine("Te has chocado contigo mismo");
                            return true;
                        }
                        else
                        {
                            board[y][x] = new Position(x, y, false, true);
                        }
                        foreach (Position p in snake.getBody())
                        {
                            board[p.getY()][p.getX()] = new Position(p.getX(), p.getY(), false, true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Te has chocado con el borde, prueba otro movimiento");
                    }
                    if (amtMice != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid move, please use WASD to move");
                    return false;
                    break;
            }
        }
    }
}

