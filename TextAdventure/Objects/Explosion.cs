using System;
using TextAdventure.Living_Critter;

namespace TextAdventure.Objects
{
    class Explosion
    {
        int damage;

        public Explosion()
        {
            int ceiling = 0; //= Hitpoints/2;
            damage = explosionDamage(ceiling);
        }

        protected int explosionDamage(int ceiling)
        {
            var rand = new Random();
            return rand.Next(0, ceiling+1);
        }
    }
}
