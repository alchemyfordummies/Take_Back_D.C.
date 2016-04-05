using System;
using TextAdventure.Living_Critter.Enemy_Types;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter.User_Character_Types
{
    public class Human: Character
    {
	    protected int Health;
	    protected int Mutability;
	    protected int Intelligence;
	    protected int Brutishness;
	    protected int Willpower;
	    protected int Endurance;
	    protected int Hitpoints;

        protected Random RandNum;

	    protected readonly string Name;

	    protected Point Location;

        public Human(string s)
        {
            Health = Mutability = Intelligence =
            Brutishness = Willpower = Endurance =
            Hitpoints = 10;
            Globals.UserLevel = 1;
            RandNum = new Random();
	        Name = s;
        }

	    public Point GetLocation()
	    {
		    return Location;
	    }

	    public void SetLocation(Point p)
	    {
		    Location = p;
	    }

        public void LevelUp()
        {
            Globals.UserLevel++;
        }

        public int Attack()
        {
            var hitChance = HitChance();
            var damage    = DamageDone();
            return hitChance >= RandNum.Next(100) ? damage : 0;
        }

        public void Explore(Point p)
        {

        }

        public void Mutate()
        {

        }

        public int HitChance()
        {
            var percent = (Willpower*0.1) + (Intelligence*0.15) + (0.5 + Globals.UserLevel*0.1);
            return (percent < 1.00) ? (int)percent*100 : 100;
        }

        public int DamageDone()
        {
            var max = (Intelligence*0.05) + (Brutishness*0.1) + (Globals.UserLevel*0.5);
            return RandNum.Next(0, (int)max);
        }

        public int DamageTaken(Enemy e)
        {
            var temp = e.Attack();
            Hitpoints = ((Hitpoints - temp) < 0) ? 0 : Hitpoints - temp;
            return temp;
        }
    }
}