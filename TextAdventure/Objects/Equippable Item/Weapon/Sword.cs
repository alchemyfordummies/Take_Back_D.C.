using TextAdventure.Living_Critter;

namespace TextAdventure.Objects.Equippable_Item.Weapon
{
    class Sword
    {
        int damage;
        int brutishnessChanged;

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
                    break;
                case "katana":
                    damage = 10;
                    brutishnessChanged = 1;
                    break;
                case "normal_sword":
                    damage = 5;
                    brutishnessChanged = 6;
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
    }
}
