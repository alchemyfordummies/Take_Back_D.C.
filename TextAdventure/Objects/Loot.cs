using System;
using TextAdventure.Living_Critter;
using TextAdventure.Objects.Equippable_Item.Weapon;

namespace TextAdventure.Objects
{
    /// <summary>
    /// Helper class for deciding what loot to generated based 
    /// on a random number passed to it
    /// </summary>
    public static class Loot
    {
        //these are flags for which weapon was created
        static bool gun;
        static bool sword;
        static bool pencil;

        static Random randGen = new Random();

        /// <summary>
        /// Chooses the loot from a chest
        /// </summary>
        /// <param name="h">Player character</param>
        /// <param name="n">Random number passed to it</param>
        public static object chooseChestLoot(Human h, int n)
        {
            //if (n > )
            if (n > 549) return generateSword(h, randGen.Next(0, 1000));
            else if (n > 249) return generateGun(h, randGen.Next(0, 1000));
            else return generatePencil(h);
        }

        /// <summary>
        /// Chooses the loot from a barrel
        /// </summary>
        /// <param name="h">Player character</param>
        /// <param name="n">Random number passed to it</param>
        public static object chooseBarrelLoot(Human h, int n)
        {
            //here n is 874 at most
            if (n > 499) return null;
            else if (n > 399) return generatePencil(h);
            else if (n > 249) return generateGun(h, randGen.Next(0, 1000));
            else return generateSword(h, randGen.Next(0, 1000));
        }

        /*THIS SUMMARY APPLIES FOR ALL THREE GENERATE FUNCTIONS
         (slight exception for pencil which doesn't get an int)*/

        /// <summary>
        /// Generates the specified weapon and adds its stats to the 
        /// player character
        /// </summary>
        /// <param name="h">The player character</param>
        /// <param name="n"> the random number passed to it</param>
        /// <returns></returns>
        static object generateGun(Human h, int n)
        {
            Gun gen;
            if (n > 929)
            {
                gen = new Gun("wild", h);
            } else if (n > 804)
            {
                gen = new Gun("gold", h);
            } else
            {
                gen = new Gun("normal_gun", h);
            }

            gun = true;
            return gen;
        }

        static object generateSword(Human h, int n)
        {
            Sword gen;
            if (n > 799)
            {
                gen = new Sword("katana", h);
            } else if (n > 499)
            {
                gen = new Sword("machete", h);
            } else
            {
                gen = new Sword("normal_sword", h);
            }

            sword = true;
            return gen;
        }

        static object generatePencil(Human h)
        {
            pencil = true;
            return new Pencil(h);
        }

        /*THIS SECTION IS GETTERS*/

        public static bool getGun()
        {
            return gun;
        }

        public static bool getSword()
        {
            return sword;
        }

        public static bool getPencil()
        {
            return pencil;
        }
    }
}
