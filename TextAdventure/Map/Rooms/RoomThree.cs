using TextAdventure.Living_Critter;
using TextAdventure.Objects;

namespace TextAdventure.Map.Rooms {
    class RoomThree 
    {
        public static Point[] MakeRoomThree(Human h, int _height, int _width, object[,] _locations,
            Point[] _roomThreeWalls, string _fileName)
        {
            _roomThreeWalls = new[]
            {
                new Point(6, 0), new Point(7, 0), new Point(8, 0), new Point(6, 1), new Point(8, 1), 
                new Point(6, 2), new Point(8, 2), new Point(0, 3), new Point(1, 3), new Point(2, 3),
                new Point(3, 3), new Point(6, 3), new Point(8, 3), new Point(11, 3), new Point(12, 3),
                new Point(13, 3), new Point(14, 3), new Point(0, 4), new Point(3, 4), new Point(6, 4),
                new Point(8, 4), new Point(11, 4), new Point(14, 4), new Point(0, 5), new Point(3, 5),
                new Point(6, 5), new Point(8, 5), new Point(11, 5), new Point(14, 5), new Point(0, 6),
                new Point(3, 6), new Point(4, 6), new Point(5, 6), new Point(6, 6), new Point(8, 6),
                new Point(9, 6), new Point(10, 6), new Point(11, 6), new Point(14, 6), new Point(0, 7),                                     
                new Point(14, 7), new Point(0, 8), new Point(1, 8), new Point(2, 8), new Point(3, 8),
                new Point(4, 8), new Point(5, 8), new Point(6, 8), new Point(7, 8), new Point(8, 8),
                new Point(9, 8), new Point(10, 8), new Point(11, 8), new Point(12, 8), new Point(13, 8),
                new Point(14, 8)
            };
            return _roomThreeWalls;
        }
    }
}
