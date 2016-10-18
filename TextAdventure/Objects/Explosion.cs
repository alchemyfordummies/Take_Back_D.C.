using System;
using TextAdventure.Living_Critter;

namespace TextAdventure.Objects
{
    class Explosion
    {
        int damage;

        public Explosion(Human h)
        {
            int ceiling = (int)(h.Hitpoints / 1.5);
            damage = explosionDamage(ceiling);
        }

        public int explosionDamage(int ceiling)
        {
            var rand = new Random();
            return rand.Next(0, ceiling+1);
        }

        public int getDamage()
        {
            return damage;
        }
    }
}
