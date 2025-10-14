using System;

public class Octopus : Enemy
{
	public Octopus()
    {
    this.displayChar = 'O';
    this.dmg = 1;
    }
    public override char getDisplayChar()
    {
        return this.displayChar;
    }

    public override int GetDmg()
    {
        return this.dmg;
    }
}
