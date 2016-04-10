using System;

namespace TextAdventure.Objects.Consumable.Container
{
    /// <summary>A new container type, a barrel, which will have more capacity but can be booby-trapped</summary>
    public class Barrel: IContainer
    {
        /// <summary>The type of container, barrel in this case</summary>
        private readonly string _type;
        private readonly int _capacity;
        private readonly bool _boobyTrapped;
        private readonly Point _location;

        /// <summary>Initializes a new barrel at a specific point in the context of a room</summary>
        /// <param name="p">The spot where the barrel will be put</param>
        public Barrel(Point p)
        {
            _type     = "barrel";
            _capacity = 4;
            _location = p;

            _boobyTrapped = IsTrapped();
        }

        /// <summary>Decides if the barrel will be trapped or not</summary>
        public Boolean IsTrapped()
        {
            var rand = new Random();
            return rand.Next(3) == 0;
        }
    }
}