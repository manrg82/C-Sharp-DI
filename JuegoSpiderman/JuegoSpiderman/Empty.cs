using System;

public class Empty :Tile
{
	protected bool isVisited;
	protected bool isExit;
	public Empty()
	{
		this.displayChar = ('#');
		this.isExit = false;
		this.isVisited = false;
	}
	public void visit()
	{
		if (!isExit)
		{
			this.displayChar = ('X');
		}
		this.isVisited = true;
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
