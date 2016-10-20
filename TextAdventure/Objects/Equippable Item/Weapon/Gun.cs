using System;
using TextAdventure.Living_Critter;

namespace TextAdventure.Objects.Equippable_Item.Weapon
{
    /// <summary>
    /// Defines the gun weapon. Has three different types to do different
    /// amounts of damage. Causes a slight increase in brutishness.
    /// </summary>
    public class Gun : IEquippable
    {
        int damage;
        int brutishnessAdded;
        string type;

        /// <summary>Constructor for a gun</summary>
        /// <param name="s">The type of gun</param>
        /// <param name="h">Human character to modify</param>
        public Gun(string s, Human h)
        {
            switch(s)
            {
                case "gold":
                    damage = 12;
                    type = "golden gun";
                    break;
                case "wild":
                    damage = 16;
                    brutishnessAdded = 5;
                    type = "wild gun";
                    break;
                case "normal_gun":
                    damage = 9;
                    brutishnessAdded = 2;
                    type = "gun";
                    break;
            }

            //Don't do this automatically, call this somewhere else
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
            h.SetBrutishness(brutishnessAdded + 2);
        }

        /// <summary>
        /// Prints to the user what item they've received
        /// </summary>
        public void printMessage()
        {
            Console.WriteLine("You've received a new " + type + "!");
        }

        public string getType()
        {
            return type;
        }
    }
}
