using System;

namespace TextAdventure.Objects.Consumable.Container
{
    public class Barrel
    {
        private readonly string _type;
        private readonly int _capacity;
        private readonly bool _boobyTrapped;
        private readonly Point _location;

        public Barrel(Point p)
        {
            _type     = "barrel";
            _capacity = 4;
            _location = p;

            _boobyTrapped = IsTrapped();
        }

        public Boolean IsTrapped()
        {
            var rand = new Random();
            return rand.Next(3) == 0;
        }
    }
}