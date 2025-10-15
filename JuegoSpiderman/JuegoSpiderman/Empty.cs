using System;

public class Empty : Tile
{
	protected bool isVisited;
	public bool isExit;
	public Empty()
	{
		this.displayChar = ('#');
		this.isExit = false;
	}
	
	public override char getDisplayChar()
	{
		return this.displayChar;
	}

    public void setExit()
	{
		this.displayChar=('E');
		this.isExit = true;
	}
}
