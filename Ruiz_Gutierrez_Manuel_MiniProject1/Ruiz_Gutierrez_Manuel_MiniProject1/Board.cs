using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Board
{
	public bool[][] dataBoard;
	private int maxSize;
    private int amt=5;//amt of boats
    public Board(){
		this.dataBoard = new bool[15][];//bi-dimensional array that is where all of the boats are going to be placed in
		for (int i = 0; i < dataBoard.Length; i++)
		{
			this.dataBoard[i] = new bool[15];
		}
        Console.WriteLine("Write the max size of the boats: ");
		this.maxSize = int.Parse(Console.ReadLine());//max size of the boats (asks for itself whenever an object of the "Boat" class is instanced
		this.placeBoats();//places boats in the grid
        this.printBoard();//prints out the resulting board
    }
	private void assingBoatAtSpot(int x, int y, int actualSize)//assigns the boat the coordinates given in the params, actualSize is the size of the boat, generated at random between 0 and maxSize which is asked for in the constructor
	{
        dataBoard[x][y] = true;
        int direction = RandomNumberGenerator.GetInt32(1, 5);//this determines in which direction the boat is going to generate in depending on what number from 1-4 is generated (I use 1,5 because its minInclusive and MaxInclusive
        switch (direction)
        {
            case 1://boat is generated towards the right of the initial tile
                for (int j = 0; j < actualSize; j++)
                {
                    if (x < maxSize - j && !dataBoard[x + j][y])
                    {
                        dataBoard[x + j][y] = true;
                    }
                }
                break;
            case 2://boat is generated towards the left of the initial tile
                for (int j = 0; j < actualSize; j++)
                {
                    if (x > maxSize - j && !dataBoard[x - j][y])
                    {
                        dataBoard[x - j][y] = true;
                    }
                }
                break;
            case 3://boat is generated upwards starting from the initial tile
                for (int j = 0; j < actualSize; j++)
                {
                    if (y < maxSize - j && !dataBoard[x][y + j])
                    {
                        dataBoard[x][y + j] = true;
                    }
                }
                break;
            case 4://boat is generated downwards starting from the initial tile
                for (int j = 0; j < actualSize; j++)
                {
                    if (y > maxSize - j && !dataBoard[x][y - j])
                    {
                        dataBoard[x][y - j] = true;
                    }
                }
                break;
            default:
                Console.WriteLine("ERROR");//default line in case of any errors
                break;
        }
    }
	private void placeBoats()//places the boat in the coordinates using assignBoatAtSpot()
	{
		Console.WriteLine();
        for (int i = 0; i < amt; i++)
		{
			int x=RandomNumberGenerator.GetInt32(0, 14);
			int y = RandomNumberGenerator.GetInt32(0, 14);
			int actualSize = RandomNumberGenerator.GetInt32(1, maxSize);
			if (!dataBoard[x][y])
			{
                assingBoatAtSpot(x, y, actualSize);
            }else//this part activates whenever an overlap is detected and the boat has to be relocated to prevent ships from spawning on top of eachotherf
			{
				while (!dataBoard[x][y])
				{
                    x = RandomNumberGenerator.GetInt32(0, 14);
                    y = RandomNumberGenerator.GetInt32(0, 14);
                }
                assingBoatAtSpot(x, y, actualSize); 

            }
        }
	}
    public void printBoard()//prints out the board for the user to see the result
    {
        for (int i = 0; i < 15; i++)
        {
            String linea = "";
            for (int j = 0; j < 15; j++)
            {

                if (this.dataBoard[i][j])
                {
                    linea = linea + ("B ");
                }
                else
                {
                    linea = linea + (". ");
                }

            }
            Console.WriteLine(linea);
        }
    }
}
