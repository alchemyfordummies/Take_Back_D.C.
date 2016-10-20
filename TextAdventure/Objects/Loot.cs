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
        static bool equipped;

        static Random randGen = new Random();

        /// <summary>
        /// Chooses the loot from a chest
        /// </summary>
        /// <param name="h">Player character</param>
        /// <param name="n">Random number passed to it</param>
        public static object chooseChestLoot(Human h, int n)
        {
            object item;
            string name;
            if (n > 549)
            {
                item = generateSword(h, randGen.Next(0, 1000));
                name = ((Sword)item).getType();
            }
            else if (n > 249)
            {
                item = generateGun(h, randGen.Next(0, 1000));
                name = ((Gun)item).getType();
            }
            else
            {
                item = generatePencil(h);
                name = "pencil";
            }

            if (checkEquipped(name)) return null;
            else unequip(name, h);
            return item;
        }

        /// <summary>
        /// Chooses the loot from a barrel
        /// </summary>
        /// <param name="h">Player character</param>
        /// <param name="n">Random number passed to it</param>
        public static object chooseBarrelLoot(Human h, int n)
        {
            object item;
            string name;
            //here n is 874 at most
            if (n > 499) return null;
            else if (n > 399)
            {
                item = generatePencil(h);
                name = "pencil";
            }
            else if (n > 249)
            {
                item = generateGun(h, randGen.Next(0, 1000));
                name = ((Gun)item).getType();
            }
            else
            {
                item = generateSword(h, randGen.Next(0, 1000));
                name = ((Sword)item).getType();
            }

            if (checkEquipped(name)) return null;
            else unequip(name, h);
            return item;
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
            equipped = true;
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
            equipped = true;
            return gen;
        }

        static object generatePencil(Human h)
        {
            pencil = true;
            equipped = true;
            return new Pencil(h);
        }

        static void doesPlayerWant(bool wants, string name)
        {
            Console.WriteLine("You have a weapon equipped. Do you want to replace it with a " 
                + name + "? (y/n)");
            string response = Console.ReadLine();
            if (response != "y" && response != "n")
            {
                Console.WriteLine("Please type y or n");
                while (true)
                {
                    response = Console.ReadLine();
                    if (response == "y" || response == "n") break;
                }
            }
            if (response == "y") wants = true;
            else wants = false;
        }

        static bool checkEquipped(string name)
        {
            if (equipped)
            {
                bool wants = true;
                doesPlayerWant(wants, name);
                if (!wants)
                {
                    return true;
                }
                return false;
            }
            else return false;
        }

        static void unequip(string name, Human h)
        {
            switch (name)
            {
                case "golden gun":
                    h.SetAddedDamage(-12);
                    h.SetBrutishness(-2);
                    break;
                case "wild gun":
                    h.SetAddedDamage(-16);
                    h.SetBrutishness(-7);
                    break;
                case "normal gun":
                    h.SetAddedDamage(-9);
                    h.SetBrutishness(-4);
                    break;
                case "machete":
                    h.SetAddedDamage(-6);
                    h.SetBrutishness(-13);
                    break;
                case "katana":
                    h.SetAddedDamage(-10);
                    h.SetBrutishness(-6);
                    break;
                case "normal sword":
                    h.SetAddedDamage(-5);
                    h.SetBrutishness(-11);
                    break;
                case "pencil":
                    h.SetAddedDamage(-2);
                    h.SetBrutishness(-15);
                    break;
            }
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
