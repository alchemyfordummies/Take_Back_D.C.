using TextAdventure.Living_Critter;
using TextAdventure.Objects;

namespace TextAdventure.Map.Rooms {
    class RoomTwo {
        /// <summary>
        /// A method which defines each point in room two, done to shorten the main method
        /// </summary>
        /// <param name="h">Current user character</param>
        /// <param name="_height">Height of the room</param>
        /// <param name="_width">Width of the room</param>
        /// <param name="_locations">Array of points in the room</param>
        /// <param name="_roomTwoWalls">Array of walls in the room</param>
        /// <param name="_fileName">Room's file name</param>
        /// <returns>The updated walls</returns>
        public static Point[] MakeRoomTwo(Human h, int _height, int _width, object[,] _locations,
            Point[] _roomTwoWalls, string _fileName) 
            {
                //Each wall in the array
                _roomTwoWalls = new[]
                {
                    new Point(0, 0), new Point(1, 0, 'S'), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0),
                    new Point(6, 0), new Point(10, 0), new Point(11, 0), new Point(12, 0), new Point(13, 0), new Point(14, 0),
                    new Point(0, 1), new Point(6, 1), new Point(10, 1), new Point(14, 1), new Point(0, 2), new Point(6, 2),
                    new Point(7, 2), new Point(8, 2), new Point(9, 2), new Point(10, 2), new Point(15, 2), new Point(16, 2),
                    new Point(17, 2), new Point(18, 2), new Point(19, 2), new Point(0, 3), new Point(19, 3), new Point(0, 4),
                    new Point(1, 4), new Point(2, 4), new Point(3, 4), new Point(4, 4, 'E'), new Point(5, 4), new Point(6, 4),
                    new Point(7, 4), new Point(8, 4), new Point(9, 4), new Point(10, 4), new Point(11, 4), new Point(12, 4),
                    new Point(13, 4), new Point(14, 4), new Point(15, 4), new Point(16, 4), new Point(17, 4), new Point(18, 4),
                    new Point(19, 4)                                  
                };

                return _roomTwoWalls;
        }
    }
}
