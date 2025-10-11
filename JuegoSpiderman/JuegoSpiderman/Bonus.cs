using System;

public class Bonus : Tile
{
	public Bonus()
	{
	this.displayChar = 'B';
	}
	public override char getDisplayChar()
	{
		return this.displayChar;
	}
}
