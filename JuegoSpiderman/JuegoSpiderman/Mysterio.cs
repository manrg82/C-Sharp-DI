using System;

public class Mysterio : Enemy
{
	public Mysterio()
    {
    this.displayChar = 'M';
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
