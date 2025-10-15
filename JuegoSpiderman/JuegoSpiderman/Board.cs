using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Board
{
	private Tile[][] gameBoard;
	private char[][] displayBoard;
	private List<int[]> lastPos;
	private int diff;
    private int hp;
    public Board(int d, Tile[][] tl, char[][] ch)
	{
        this.gameBoard = tl;
		this.displayBoard = ch;
		this.diff = d;
        this.hp = 3;
	}
	public char[][] getDisplayBoard()
	{
		return this.displayBoard;
	}
    public int getHp()
    {
        return this.hp;
    }
    public void setHp(int h)
    {
        this.hp = h;
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
                    
                    if (genEnemy == 0||genEnemy==1)
                    {
                    e = RandomNumberGenerator.GetInt32(0, 8);
                    switch (e)
                            {
                                case 0:
                                    this.gameBoard[i][j] = (Tile)(new Octopus());
                            break;
                                case 1:
                                    this.gameBoard[i][j] = new Goblin();
                            break;
                                case 2:
                                    this.gameBoard[i][j] = new Mysterio();
                            break;
                                case 3:
                                    this.gameBoard[i][j] = new Bonus();
                            break;
                                case 4:
                                    this.gameBoard[i][j] = new Empty();
                            break;
                                default:
                                    this.gameBoard[i][j] = new Civil();
                            break;
                    }
                    this.displayBoard[i][j] = '#';
                }
                else
                {
                    this.gameBoard[i][j] = new Empty();
                    this.displayBoard[i][j] = '#';
                }

                }
                        
            }
                        
                                
            this.gameBoard[14][14] = new Empty();
            ((Empty)this.gameBoard[14][14]).setExit();
            this.displayBoard[14][14] = gameBoard[14][14].getDisplayChar();
            this.displayBoard[0][0] = 'S';
    }
}