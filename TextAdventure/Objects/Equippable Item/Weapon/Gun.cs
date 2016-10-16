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

        /// <summary>Constructor for a gun</summary>
        /// <param name="s">The type of gun</param>
        /// <param name="h">Human character to modify</param>
        public Gun(string s, Human h)
        {
            switch(s)
            {
                case "gold":
                    damage = 12;
                    break;
                case "wild":
                    damage = 16;
                    brutishnessAdded = 5;
                    break;
                default:
                    damage = 9;
                    brutishnessAdded = 2;
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
            h.SetBrutishness(brutishnessAdded + 2);
        }
    }
}
