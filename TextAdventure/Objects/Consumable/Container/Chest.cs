using System;
using TextAdventure.Objects.Consumable.Container;

namespace TextAdventure.Objects.Consumable.Container
{
    /// <summary>A new container with less storage but can't be booby-trapped</summary>
    public class Chest: IContainer
    {
        /// <summary>The type of container, barrel in this case</summary>
        private readonly string type;
        /// <summary>Says how many items the </summary>
        private readonly int capacity;
        /// <summary></summary>
        private readonly Point location;

        /// <summary>Initializes a new chest at a specific point in the context of a room</summary>
        /// <param name="p">The spot where the chest will be put</param>
        public Chest(Point p)
        {
            type = "chest";
            capacity = 4;
            location = p;
            Explosion ex = new Explosion();

            Random rand = new Random();
            int chance = rand.Next(0, 100);
            if (chance > 92)
            {

            }
        }
    }
}