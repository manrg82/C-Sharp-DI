using System;

public class Board
{
	private Tile[][] visualBoard;
	private char[][] displayBoard;
	List<int[2]> lastPos;
	public Board()
	{
		this.visualBoard=new Tile[15][];
		this.displayBoard=new char[15][];
		this.lastPos=new List<int[2]> ();
	}
	public void generateBoards()
	{

	}
}
