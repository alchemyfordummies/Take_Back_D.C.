using System;
using TextAdventure.Living_Critter;

namespace TextAdventure.Objects.Equippable_Item.Weapon
{
    class Sword : IEquippable
    {
        //Basic variables for the class
        int damage;
        int brutishnessChanged;
        string type;

        /// <summary>Constructor for a sword</summary>
        /// <param name="s">The type of sword</param>
        /// <param name="h">Human character to modify</param>
        public Sword(string s, Human h)
        {
            switch (s)
            {
                case "machete":
                    damage = 6;
                    brutishnessChanged = 8;
                    type = "machete";
                    break;
                case "katana":
                    damage = 10;
                    brutishnessChanged = 1;
                    type = "katana";
                    break;
                case "normal_sword":
                    damage = 5;
                    brutishnessChanged = 6;
                    type = "sword";
                    break;
            }

            addDamage(h);
        }

        /// <summary>Adds that amount of damage to the character</summary>
        public void addDamage(Human h)
        {
            h.SetAddedDamage(damage);
        }

        /// <summary>Changes the specified stats by the specified amount</summary>
        public void adjustStats(Human h)
        {
            h.SetBrutishness(brutishnessChanged + 5);
        }

        /// <summary>
        /// Prints to the user what item they've received
        /// </summary>
        public void printMessage()
        {
            Console.WriteLine("You've received a new " + type + "!");
        }
    }
}
