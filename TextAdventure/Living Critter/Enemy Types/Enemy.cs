using System;
using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter.Enemy_Types
{
    public class Enemy
    {
        protected int health;
        protected int mutability;
        protected int intelligence;
        protected int brutishness;
        protected int willpower;
        protected int endurance;
        protected int hitpoints;
        protected int level;

        protected Random randNum;

        public string type;

        public static readonly string[] enemyTypes =
        {"General", "Major", "Lieutenant", "Sergeant", "Private"};

        public Enemy()
        {
            type = "Private";
            health = mutability = intelligence =
                brutishness = willpower = endurance =
                    hitpoints = 10;
            level = 1;
            randNum = new Random();
        }

        public Enemy(string name, int hLevel)
        {
            randNum = new Random();
            switch (name)
            {
                case "General":
                    type = name;
                    health = hitpoints = 100;
                    intelligence = 100;
                    brutishness = 50;
                    willpower = 90;
                    endurance = 40;
                    level = randNum.Next(hLevel - 1, level + 2);
                    break;
                case "Major":
                    type = name;
                    health = hitpoints = 85;
                    intelligence = 80;
                    brutishness = 45;
                    willpower = 60;
                    endurance = 50;
                    level = randNum.Next(level - 1, level + 3);
                    break;
                case "Lieutenant":
                    type = name;
                    health = hitpoints = 70;
                    intelligence = 65;
                    brutishness = 40;
                    willpower = 55;
                    endurance = 65;
                    level = randNum.Next(level - 2, level + 1);
                    break;
                case "Sergeant":
                    type = name;
                    health = hitpoints = 70;
                    intelligence = 65;
                    brutishness = 40;
                    willpower = 55;
                    endurance = 65;
                    level = randNum.Next(level - 4, level + 4);
                    break;
                default:
                    type = name;
                    health = mutability = intelligence =
                        brutishness = willpower = endurance =
                            hitpoints = 10;
                    level = hLevel < 3 ? 1 : randNum.Next(hLevel - 2, hLevel + 2);
                    break;
            }
        }

        public void GenerateType(string name, int hLevel)
        {
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int h)
        {
            health = h;
        }

        public int GetMutability()
        {
            return mutability;
        }

        public void SetMutability(int m)
        {
            mutability = m;
        }

        public int GetIntelligence()
        {
            return intelligence;
        }

        public void SetIntelligence(int i)
        {
            intelligence = i;
        }

        public int GetBrutishness()
        {
            return brutishness;
        }

        public void SetBrutishness(int b)
        {
            brutishness = b;
        }

        public int GetWillpower()
        {
            return willpower;
        }

        public void SetWillpower(int w)
        {
            willpower = w;
        }

        public int GetEndurance()
        {
            return endurance;
        }

        public void SetEndurance(int e)
        {
            endurance = e;
        }

        public void LevelUp()
        {
            level++;
        }

        public int Attack()
        {
            var hitChance = HitChance();
            var damage = DamageDone();
            return hitChance >= randNum.Next(100) ? damage : 0;
        }

        public void Explore(Point p)
        {
        }

        public void Mutate()
        {
        }

        public int HitChance()
        {
            var percent = (willpower*0.1) + (intelligence*0.15) + (0.5 + level*0.1);
            return (percent < 1.00) ? (int) percent*100 : 100;
        }

        public int DamageDone()
        {
            var max = (intelligence*0.05) + (brutishness*0.1) + (level*0.5);
            return randNum.Next(0, (int) max);
        }

        public int DamageTaken(Human h)
        {
            var temp = h.Attack();
            hitpoints = ((hitpoints - temp) < 0) ? 0 : hitpoints - temp;
            return temp;
        }
    }
}