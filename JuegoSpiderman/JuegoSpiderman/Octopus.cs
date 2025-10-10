using System;

public class Octopus : Enemy
{
	public Octopus()
    {
    base();
    this.displayChar = 'O;
    this.dmg = 1;
    }
    public int getDmg() {
        return this.dmg;
    }
}
