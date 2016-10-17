using System;
using TextAdventure.Living_Critter;

namespace TextAdventure.Objects
{
    class Explosion
    {
        int damage;

        public Explosion(Human h)
        {
            int ceiling = h.Hitpoints/2;
            damage = explosionDamage(ceiling);
        }

        protected int explosionDamage(int ceiling)
        {
            var rand = new Random();
            return rand.Next(0, ceiling+1);
        }
    }
}
