using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Board
{
	private Tile[][] gameBoard;
	private char[][] displayBoard;
	private List<int[]> lastPos;
	private int diff;
	public Board(int d, Tile[][] tl, char[][] ch, List<int[]> lastpos)
	{
		this.gameBoard = tl;
		this.displayBoard = ch;
		this.lastPos = new List<int[]>();
		this.diff = d;
	}
	public char[][] getDisplayBoard()
	{
		return this.displayBoard;
	}
	public Tile[][] getGameBoard()
	{
		return this.gameBoard;
	}
	public void printArray(char[][] arr)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			for (int j = 0; j < arr[i].Length; j++)
			{
				Console.Write(" " + arr[i][j]);
			}
			Console.WriteLine();
		}
	}
	public void generateBoards()
	{
        for (int j = 0; j < 15; j++)
        {
            for (int k = 0; k < 15; k++)
            {
                
            }
        }
            for (int i = 0; i < gameBoard.Length; i++)
            {
                int e;
                this.gameBoard[i] = new Tile[15];
                this.displayBoard[i] = new char[15];
                int genEnemy;
                for (int j = 0; j < 15; j++)
                {
                    genEnemy = RandomNumberGenerator.GetInt32(0, diff);
                    if (genEnemy == 0)
                    {
                        e = RandomNumberGenerator.GetInt32(0, 6);
                        switch (e)
                        {
                            case 0:
                                this.gameBoard[i][j] = (Tile)(new Octopus());
                                this.displayBoard[i][j] = gameBoard[i][j].getDisplayChar();
                                break;
                            case 1:
                                this.gameBoard[i][j] = new Goblin();
                                this.displayBoard[i][j] = gameBoard[i][j].getDisplayChar();
                                break;
                            case 2:
                                this.gameBoard[i][j] = new Mysterio();
                                this.displayBoard[i][j] = gameBoard[i][j].getDisplayChar();
                                break;
                            case 3:
                                this.gameBoard[i][j] = new Civil();
                                this.displayBoard[i][j] = gameBoard[i][j].getDisplayChar();
                                break;
                            case 4:
                                this.gameBoard[i][j] = new Empty();
                                this.displayBoard[i][j] = gameBoard[i][j].getDisplayChar();
                                break;
                            case 5:
                                this.gameBoard[i][j] = new Bonus();
                                this.displayBoard[i][j] = gameBoard[i][j].getDisplayChar();
                                break;
                        }
                    }
                    else
                    {
                        this.gameBoard[i][j] = new Empty();
                        this.displayBoard[i][j] = gameBoard[i][j].getDisplayChar();
                    }
            }
        }
    }
    /**public void startGame(int hp,int civ,int posy,int posx
        )
    {   
        
        Console.WriteLine("Elige una opción:");
        Console.WriteLine("d. Mover a la Derecha");
        Console.WriteLine("w. Mover hacia arriba");
        Console.WriteLine("s. Mover hacia abajo");
        Console.WriteLine("a. Mover a la Izquierda");
        Console.WriteLine("5. Salir");
        char option = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch (option)
        {
            case 'd': // Incrementar Y por 1
                if (posy < limit - 1)
                {
                    arrBool[posx][posy] = false;
                    posy++;
                    arrBool[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                hp = checkPosHp(hp, arrInt[posx][posy]);
                mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);

                break;
            case 's': // Incrementar X por 1
                if (posx < limit - 1)
                {
                    arrBool[posx][posy] = false;
                    posx++;
                    arrBool[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                hp = checkPosHp(hp, arrInt[posx][posy]);
                mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);
                break;
            case 'a': // Decrementar Y por 1
                if (posy > 0)
                {
                    arrBool[posx][posy] = false;
                    posy--;
                    arrBool[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                hp = checkPosHp(hp, arrInt[posx][posy]);
                mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);
                break;
            case 'w': // Decrementar X por 1
                if (posx > 0)
                {
                    arrBool[posx][posy] = false;
                    posx--;
                    arrBool[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                hp = checkPosHp(hp, arrInt[posx][posy]);
                mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);
                break;
            case '5':
                Console.WriteLine("Adiós!");
                return;
                break;
            default:
                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                break;
        }
    }**/
}
