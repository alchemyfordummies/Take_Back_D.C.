using TextAdventure.Living_Critter;

namespace TextAdventure.Objects.Equippable_Item.Weapon
{
    class Pencil
    {
        int damage;
        int brutishnessChanged;

        /// <summary>Constructor for a sword</summary>
        /// <param name="s">The type of sword</param>
        /// <param name="h">Human character to modify</param>
        public Pencil(Human h)
        {
            damage = 2;
            brutishnessChanged = 15;
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
            h.SetBrutishness(brutishnessChanged);
        }
    }
}
