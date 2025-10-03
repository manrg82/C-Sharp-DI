using System;

public class Player
{
	public Player(){
		private int hp;
		public Player(int diff){
			switch (diff)
			{
				case 0: 
					hp = 1;
					break;
				case 1: 
					hp = 2; 
					break;
				case 2:
					hp = 3;
					break;
			}
		}
	
	public int getHp(){ 
		return hp; 
	}

	public void setHp(int diff) {
		this.hp=diff;
	}

	public void addHP(int amt) {
		this.hp += amt;
	}
}
