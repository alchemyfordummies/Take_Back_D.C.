using System;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter
{
    /// <summary>
    /// Contains all the types of enemies, and when called, it will initiate a new enemy
    /// in any given room.
    /// </summary>
    public class Enemy: ICharacter
    {
	    /// <summary>Max number of hitpoints</summary>
	    protected int Health;
        /// <summary>Determines how likely it is for the character to mutate</summary>
	    protected int Mutability;
        /// <summary>Part of the damage formula</summary>
	    protected int Intelligence;
        /// <summary>Bigger part of the damage formula</summary>
	    protected int Brutishness;
        /// <summary>Right now unused</summary>
	    protected int Willpower;
        /// <summary>Also unused right now</summary>
	    protected int Endurance;
        /// <summary>Sets the enemy's level, used in damage as well</summary>
	    protected int Level;

        /// <summary>Starts as health, goes down with attacks</summary>
	    public int Hitpoints;

        /// <summary>This enemy's random number generator</summary>
        protected Random RandNum;

        /// <summary>Selects the type of enemy this instance is</summary>
        public string Type;

	    /// <summary>Initializes a default, lowest level enemy</summary>
        public Enemy()
        {
            Type = "Private";
            Health = Mutability = Intelligence =
                Brutishness = Willpower = Endurance =
                    Hitpoints = 6;
            Level = 1;
            RandNum = new Random();
        }

	    /// <summary>Initializes a new enemy, given a name, a point, and the human's level
	    /// to determine its attributes, as well as the name of the type of enemy</summary>
	    /// <param name="hLevel">User's level</param>
	    /// <param name="loc">Enemy's location</param>
	    /// <param name="name">Name of Enemy type</param>
        public Enemy(int hLevel, Point loc, string name = "Private")
        {
            RandNum = new Random();
            //put into subroutine, too long for constructor
            switch (name)
            {
                case "General":
                    Type = name;
                    Health = Hitpoints = 90;
                    Intelligence = 90;
                    Brutishness = 50;
                    Willpower = 90;
                    Endurance = 40;
                    Level = RandNum.Next(hLevel - 1, Level + 2);
                    break;
                case "Major":
                    Type = name;
                    Health = Hitpoints = 55;
                    Intelligence = 60;
                    Brutishness = 25;
                    Willpower = 30;
                    Endurance = 50;
                    Level = RandNum.Next(Level - 1, Level + 3);
                    break;
                case "Lieutenant":
                    Type = name;
                    Health = Hitpoints = 50;
                    Intelligence = 35;
                    Brutishness = 20;
                    Willpower = 25;
                    Endurance = 25;
                    Level = RandNum.Next(Level - 2, Level + 1);
                    break;
                case "Sergeant":
                    Type = name;
                    Health = Hitpoints = 20;
                    Intelligence = 25;
                    Brutishness = 10;
                    Willpower = 25;
                    Endurance = 15;
                    Level = RandNum.Next(Level - 4, Level + 4);
                    break;
                default:
                    Type = name;
                    Health = Mutability = Intelligence =
                        Brutishness = Willpower = Endurance =
                            Hitpoints = 6;
                    Level = hLevel < 3 ? 1 : RandNum.Next(hLevel - 2, hLevel + 2);
                    break;
            }
        }

	    /// <summary>Executes an attack by the human</summary>
	    /// <param name="h">Takes a human to carry out the attack</param>
        public void Attack(Human h)
        {
            int damage = DamageDone();
	        h.Hitpoints -= damage;
            Console.WriteLine("You took " + damage + " points of damage");
            if (h.Hitpoints < 0) h.Hitpoints = 0;
        }

        /// <summary>Yet to be determined</summary>
        public void Mutate()
        {

        }

	    /// <summary>Uses intelligence, Brutishness, and level to determine damage</summary>
	    /// <returns>A random number between zero and the max damage</returns>
        public int DamageDone()
        {
            var max = (Intelligence*0.075) + (Brutishness*0.2) + (Level);
            return RandNum.Next(0, (int) max + 1);
        }
    }
}