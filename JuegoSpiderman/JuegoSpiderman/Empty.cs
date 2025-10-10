using System;

public class Empty private extends Tile
{
	protected bool isVisited;
	protected bool isExit;
	public Empty()
	{
		super('N')
		this.isExit = false;
		this.isVisited = false;
	}
	public void visit()
	{
		if (!isExit)
		{
			this.setDisplayChar('X');
		}
		this.isVisited = true;
	}
	public void setExit()
	{
		this.setDisplayChar('E');
		this.isExit = true;
	}
}
