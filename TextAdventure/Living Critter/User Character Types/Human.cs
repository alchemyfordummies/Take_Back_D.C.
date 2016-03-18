using System;
using TextAdventure.Living_Critter.Enemy_Types;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter.User_Character_Types
{
    public class Human: Character
    {
        protected int health;
        protected int mutability;
        protected int intelligence;
        protected int brutishness;
        protected int willpower;
        protected int endurance;
        protected int hitpoints;

        public static int userLevel;

        protected Random randNum;

        public Human()
        {
            health = mutability = intelligence =
            brutishness = willpower = endurance =
            hitpoints = 10;
            userLevel = 1;
            randNum = new Random();
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
            userLevel++;
        }

        public int Attack()
        {
            var hitChance = HitChance();
            var damage    = DamageDone();
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
            var percent = (willpower*0.1) + (intelligence*0.15) + (0.5 + userLevel*0.1);
            return (percent < 1.00) ? (int)percent*100 : 100;
        }

        public int DamageDone()
        {
            var max = (intelligence*0.05) + (brutishness*0.1) + (userLevel*0.5);
            return randNum.Next(0, (int)max);
        }

        public int DamageTaken(Enemy e)
        {
            var temp = e.Attack();
            hitpoints = ((hitpoints - temp) < 0) ? 0 : hitpoints - temp;
            return temp;
        }
    }
}