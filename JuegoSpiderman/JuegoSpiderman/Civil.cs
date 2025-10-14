using System;

public class Civil : Tile
{
	public Civil(){
		this.displayChar=('C');
	}
	public override char getDisplayChar()
	{
		return this.displayChar;
	}

}
