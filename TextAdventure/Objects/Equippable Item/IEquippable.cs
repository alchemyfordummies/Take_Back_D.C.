using TextAdventure.Living_Critter;

namespace TextAdventure.Objects.Equippable_Item
{
    interface IEquippable
    {
        void addDamage(Human h);
        void adjustStats(Human h);
        void printMessage();
    }
}
