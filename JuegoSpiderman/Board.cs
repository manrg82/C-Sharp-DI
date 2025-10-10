

using System;
public class Board
{
	private Tile[][] gameBoard;
	public char[][] displayBoard;
	List<int[2]> lastPos;
	private int diff;
	public Board(int d)
	{
		this.gameBoard=new Tile[15][];
		this.displayBoard=new char[15][];
		this.lastPos=new List<int[2]> ();
		this.diff=d;
    }
	public Tile[][] getGameBoard()
	{
		return this.gameBoard;
	}
    public char[][] getDisplayBoard()
    {
        return this.displayBoard;
    }
    public void printArray(char[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                console.Write(" "+arr[i][j]);
            }
            Console.WriteLine();
        }
    }
    public void generateBoards()
	{
		for(int i=0;i<gameBoard.length();i++)
		{
			int e = null;
			this.visualBoard[i]=new Tile[15];
			this.displayBoard[i]=new char[15];
			for(int j=0;j<15;j++)
			{
				e=Random.RandomNumberGenerator.GetInt32(0, 3)
				case (e):
					0:
						this.visualBoard[i][j] = new Octopus();
						this.displayBoard[i][j] = visualBoard[i][j].getDispayChar();
                    break;
					1:
						this.visualBoard[i][j] = new Goblin();
						this.displayBoard[i][j] = visualBoard[i][j].getDispayChar();
                    break;
					2:
						this.visualBoard[i][j] = new Mysterio();
						this.displayBoard[i][j] = visualBoard[i][j].getDispayChar();
                    break;
					3:
						this.visualBoard[i][j] = new Civil();
						this.displayBoard[i][j] = visualBoard[i][j].getDispayChar();
                    break;
					4:
						this.visualBoard[i][j] = new Empty();
						this.displayBoard[i][j] = visualBoard[i][j].getDispayChar();
                    break;
					5:
						this.visualBoard[i][j] = new Bonus();
						this.displayBoard[i][j] = visualBoard[i][j].getDispayChar();
                    break;
                    this.visualBoard[i][j]=new Tile();
			}
        }
    }
	
}
