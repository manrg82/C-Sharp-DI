using System;

public class Goblin : Enemy
{
	public Goblin()
    {
    this.displayChar = 'G';
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
