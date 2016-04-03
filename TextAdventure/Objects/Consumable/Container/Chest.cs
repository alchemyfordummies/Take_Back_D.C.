namespace TextAdventure.Objects.Consumable.Container
{
    public class Chest
    {
        private readonly string _type;
        private readonly int _capacity;
        private readonly Point _location;

        public Chest(Point p)
        {
            _type = "barrel";
            _capacity = 4;
            _location = p;
        }
    }
}