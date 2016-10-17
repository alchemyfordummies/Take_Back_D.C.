using System;
using TextAdventure.Living_Critter;

namespace TextAdventure.Objects
{
    class Explosion
    {
        public Explosion(Human h, string s)
        {
            int ceiling = h.Hitpoints/2;
            int damage = explosionDamage(s, ceiling);
        }

        protected int explosionDamage(string s, int ceiling)
        {
            var rand = new Random();
            int temp = rand.Next(0, ceiling+1);
            return 0;
        }
    }
}
