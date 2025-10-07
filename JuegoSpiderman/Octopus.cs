using System;

public class Octopus extends Enemy
{
	public Octopus()
    {
    this.displayChar = 'O;
    this.dmg = 1;
    }
    public int getDmg() {
        return this.dmg;
    }
}
