using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSpiderman
{
    public class Game
    {
        private int posx;
        private int posy;
        private int civ;
        // Game class constructor. Initializes player position and civilians rescued.

        public Game()
        {
            this.posx = 0;
            this.posy = 0;
            this.civ = 0;
        }

        // Starts the game: asks for difficulty and easy mode, generates the board, and starts the main game loop.

        public void startGame()
        {
            Tile[][] tl = new Tile[15][];
            char[][] ch = new char[15][];
            List<int[]> lastpos = new List<int[]>();
            Console.WriteLine("Select a dificulty from range-> 5-Easiest to 1-Hardest");
            int diff = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Board bd = new Board(diff, tl, ch);
            bd.generateBoards();
            
            bd.printArray(bd.getDisplayBoard());
            Console.WriteLine();
            this.posx = 0;
            this.posy = 0;
            startLoop(tl,ch,lastpos,bd);
        }

        // Checks the current tile and applies the corresponding logic (enemies, civilians, exit, empty).
        
        private void checkTile(List<int[]> lastpos,Tile[][] tl, char[][] ch, Board bd)
        {
            if (tl[this.posx][this.posy] is Goblin)
            {
                Console.WriteLine("You've found a Green Goblin in coords: " + this.posx + "|" + this.posy);
                Console.WriteLine("In fighting the Goblin you lose 1 HP");
                bd.setHp(bd.getHp() - 1);
                tl[this.posx][this.posy] = new Empty();
            }
            else if (tl[this.posx][this.posy] is Octopus)
            {
                Console.WriteLine("You've found a Dr Octopus in coords: " + this.posx + "|" + this.posy);
                Console.WriteLine("In fighting Dr Octopus you lose 1 HP and get sent back 2 tiles");
                bd.setHp(bd.getHp() - 1);
                tl[this.posx][this.posy] = new Empty();
                int[] lp = null;
                if (lastpos.Count >= 2)
                {
                    lp = lastpos[lastpos.Count - 2];
                }
                else
                {
                    lp = new int[]{0,0};
                }
                this.posx= lp[0];
                this.posy= lp[1];
            }
            else if (tl[this.posx][this.posy] is Mysterio)
            {
                Console.WriteLine("You've found a Mysterio in coords: " + this.posx + "|" + this.posy);
                tl[this.posx][this.posy] = new Empty();
                ch[this.posx][this.posy]= 'X';
                this.posx = new Random().Next(0, 14);
                this.posy = new Random().Next(0, 14);
                ch[this.posx][this.posy]= 'S';
                Console.WriteLine("You teleport to " + this.posx + "|" + this.posy);
            }
            else if (tl[this.posx][this.posy] is Civil)
            {
                Console.WriteLine("You've found a Civilian in coords: " + this.posx + "|" + this.posy + " and you've managed to rescue them!");
                Console.WriteLine("You gain 1 civilian point");
                this.civ += 1;
                tl[this.posx][this.posy] = new Empty();
            }
            else if (tl[this.posx][this.posy] is Empty && tl[this.posx][this.posy].getDisplayChar() == 'E')
            {
                if (this.civ >= 3)
                {
                    Console.WriteLine("You've found the exit in coords: " + this.posx + "|" + this.posy);
                    Console.WriteLine("You win the game, you rescued " + this.civ + " civilians");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You've found the exit in coords: " + this.posx + "|" + this.posy);
                    Console.WriteLine("You need at least 3 civilians to win, you only have " + this.civ);
                }
            }
            else if (tl[this.posx][this.posy] is Empty)
            {
                Console.WriteLine("Empty Tile in coords: " + this.posx + "|" + this.posy);
                Console.WriteLine("Nothing happens");
            }
        }

        // Main game loop. Shows the board, handles player movement, and calls checkTile after each action.
        
        private void startLoop(Tile[][] tl, char[][] ch, List<int[]> lastpos, Board bd)
        {
            if (bd.getHp() < 0)
            {
                Console.WriteLine("Game Over, you have no HP left");
                return;
            }
            Console.Clear();
            checkTile(lastpos,tl,ch, bd);
            Console.WriteLine("HP: " + bd.getHp() + " | Civilians Rescued: " + this.civ);
            bd.printArray(bd.getDisplayBoard());
            Console.WriteLine("Elige una opción:");
            Console.WriteLine("d. Move to the Right");
            Console.WriteLine("w. Move Upwards");
            Console.WriteLine("s. Move Downwards");
            Console.WriteLine("a. Move to the Left");
            Console.WriteLine("5. Salir");
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine();
            int limit= 15;
            
            switch (option)
            {
                case 'd': // Increase Y by 1
                    if (this.posy < limit - 1)
                    {
                        ch[this.posx][this.posy] = 'X';
                        lastpos.Add(new int[] { this.posx, this.posy });
                        this.posy++;
                        ch[this.posx][this.posy] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Out of bounds");
                    }
                    break;
                case 's': // Increase X by 1
                    if (this.posx < limit - 1)
                    {
                        ch[this.posx][this.posy] = 'X';
                        lastpos.Add(new int[] { this.posx, this.posy });
                        this.posx++;
                        ch[this.posx][this.posy] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Out of bounds");
                    }
                    break;
                case 'a': // Decrease Y by 1
                    if (this.posy > 0)
                    {
                        ch[this.posx][this.posy] = 'X';
                        lastpos.Add(new int[] { this.posx, this.posy });
                        this.posy--;
                        ch[this.posx][this.posy] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Out of bounds");
                    }
                    break;
                case 'w': // Decrease X by 1
                    if (this.posx > 0)
                    {
                        ch[this.posx][this.posy] = 'X';
                        lastpos.Add(new int[] { this.posx, this.posy });
                        this.posx--;
                        ch[this.posx][this.posy] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Out of bounds");
                    }
                    break;
                case '5':
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
            startLoop(tl,ch,lastpos,bd);

        }
    }
}
