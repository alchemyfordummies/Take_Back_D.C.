using System;
using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter.Enemy_Types
{
    public class Enemy
    {
        protected int Health { get; set; }
        protected int Mutability { get; set; }
        protected int Intelligence { get; set; }
        protected int Brutishness { get; set; }
        protected int Willpower { get; set; }
        protected int Endurance { get; set; }
        protected int Hitpoints { get; set; }
        protected int Level { get; set; }

        protected Random RandNum;

        public string Type;

        private Point _location;

        public static readonly string[] EnemyTypes =
        {"General", "Major", "Lieutenant", "Sergeant", "Private"};

        public Enemy()
        {
            Type = "Private";
            Health = Mutability = Intelligence =
                Brutishness = Willpower = Endurance =
                    Hitpoints = 10;
            Level = 1;
            RandNum = new Random();
        }

        public Enemy(int hLevel, Point loc, string name = "Private")
        {
            RandNum = new Random();
            _location = loc;
            //put into subroutine, too long for constructor
            switch (name)
            {
                case "General":
                    Type = name;
                    Health = Hitpoints = 100;
                    Intelligence = 100;
                    Brutishness = 50;
                    Willpower = 90;
                    Endurance = 40;
                    Level = RandNum.Next(hLevel - 1, Level + 2);
                    break;
                case "Major":
                    Type = name;
                    Health = Hitpoints = 85;
                    Intelligence = 80;
                    Brutishness = 45;
                    Willpower = 60;
                    Endurance = 50;
                    Level = RandNum.Next(Level - 1, Level + 3);
                    break;
                case "Lieutenant":
                    Type = name;
                    Health = Hitpoints = 70;
                    Intelligence = 65;
                    Brutishness = 40;
                    Willpower = 55;
                    Endurance = 65;
                    Level = RandNum.Next(Level - 2, Level + 1);
                    break;
                case "Sergeant":
                    Type = name;
                    Health = Hitpoints = 70;
                    Intelligence = 65;
                    Brutishness = 40;
                    Willpower = 55;
                    Endurance = 65;
                    Level = RandNum.Next(Level - 4, Level + 4);
                    break;
                default:
                    Type = name;
                    Health = Mutability = Intelligence =
                        Brutishness = Willpower = Endurance =
                            Hitpoints = 10;
                    Level = hLevel < 3 ? 1 : RandNum.Next(hLevel - 2, hLevel + 2);
                    break;
            }
        }

        public void GenerateType(string name, int hLevel)
        {
        }

        public int Attack()
        {
            var hitChance = HitChance();
            var damage = DamageDone();
            return hitChance >= RandNum.Next(100) ? damage : 0;
        }

        public void Mutate()
        {

        }

        public int HitChance()
        {
            var percent = (Willpower*0.1) + (Intelligence*0.15) + (0.5 + Level*0.1);
            return (percent < 1.00) ? (int) percent*100 : 100;
        }

        public int DamageDone()
        {
            var max = (Intelligence*0.05) + (Brutishness*0.1) + (Level*0.5);
            return RandNum.Next(0, (int) max);
        }

        public int DamageTaken(Human h)
        {
            var temp = h.Attack();
            Hitpoints = ((Hitpoints - temp) < 0) ? 0 : Hitpoints - temp;
            return temp;
        }
    }
}