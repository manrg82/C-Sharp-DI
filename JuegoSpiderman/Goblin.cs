using System;

public class Goblin extends Enemy
{
	public Goblin()
    {
    this.displayChar = 'G;
    this.dmg = 1;
    }
    public int getDmg()
    {
    return this.dmg;
    }
}
