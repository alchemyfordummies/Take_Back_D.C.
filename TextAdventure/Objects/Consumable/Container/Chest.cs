using System;
using TextAdventure.Objects.Consumable.Container;

namespace TextAdventure.Objects.Consumable.Container
{
    /// <summary>A new container with less storage but can't be booby-trapped</summary>
    public class Chest: IContainer
    {
        /// <summary>The type of container, barrel in this case</summary>
        private readonly string type;
        /// <summary></summary>
        private readonly Point location;

        /// <summary>Initializes a new chest at a specific point in the context of a room</summary>
        /// <param name="p">The spot where the chest will be put</param>
        public Chest(Point p)
        {
            type = "chest";
            location = p;
        }
    }
}