namespace TextAdventure.Objects.Consumable.Container
{
    /// <summary>A new container with less storage but can't be booby-trapped</summary>
    public class Chest: IContainer
    {
        /// <summary>The type of container, barrel in this case</summary>
        private readonly string _type;
        /// <summary>Says how many items the </summary>
        private readonly int _capacity;
        /// <summary></summary>
        private readonly Point _location;

        /// <summary>Initializes a new chest at a specific point in the context of a room</summary>
        /// <param name="p">The spot where the chest will be put</param>
        public Chest(Point p)
        {
            _type = "barrel";
            _capacity = 4;
            _location = p;
        }
    }
}