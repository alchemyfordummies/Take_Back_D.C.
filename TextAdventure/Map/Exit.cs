using TextAdventure.Objects;

namespace TextAdventure.Map
{
    /// <summary>Defines the attributes of the exit</summary>
    public class Exit
    {
        private readonly Point location;
        private readonly int roomNum;

        /// <summary>Places a new exit</summary>
        /// <param name="p">Specifies the Exit's location</param>
        /// <param name="r">Says which room to place the exit in</param>
        public Exit(Point p, int r)
        {
            location = p;
            roomNum  = r;
        }
    }
}