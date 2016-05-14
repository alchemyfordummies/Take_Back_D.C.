using TextAdventure.Living_Critter;
using TextAdventure.Objects;

namespace TextAdventure.Map.Rooms {
    public class RoomOne {
        /// <summary>
        /// A method which defines each point in room one, done to shorten the main method
        /// </summary>
        /// <param name="h">Current user character</param>
        /// <param name="_height">Height of the room</param>
        /// <param name="_width">Width of the room</param>
        /// <param name="_locations">Array of points in the room</param>
        /// <param name="_roomOneWalls">Array of walls in the room</param>
        /// <param name="_fileName">Room's file name</param>
        /// <returns>The updated walls</returns>
        public static Point[] MakeRoomOne(Human h, int _height, int _width, object[,] _locations,
            Point[] _roomOneWalls, string _fileName)
            {
                //Each wall in the array
                _roomOneWalls = new Point[46]
                {
                    new Point(5, 0, 'P'), new Point(4, 1, '|'), new Point(1, 2, '-'), new Point(2, 2, '-'),
                    new Point(3, 2, '-'), new Point(4, 2, '-'), new Point(1, 3, '|'), new Point(1, 4, '|'),
                    new Point(1, 5, '-'), new Point(0, 5, '-'), new Point(0, 6, '|'), new Point(0, 7, '|'),
                    new Point(0, 8, '|'), new Point(15, 8, '|'), new Point(15, 7, '|'), new Point(15, 6, '-'),
                    new Point(14, 6, '-'), new Point(13, 6, '-'), new Point(12, 6, '-'), new Point(10, 6, '-'),
                    new Point(9, 6, '-'), new Point(8, 6, '-'), new Point(8, 5, '|'), new Point(7, 4, '|'),
                    new Point(7, 3, '|'), new Point(7, 2, '|'), new Point(7, 1, '|'), new Point(7, 0, '-'),
                    new Point(6, 0, '-'), new Point(4, 0, '-'), new Point(0, 9, '-'), new Point(1, 9, '-'),
                    new Point(2, 9, '-'), new Point(3, 9, '-'), new Point(4, 9, '-'), new Point(5, 9, '-'),
                    new Point(6, 9, '-'), new Point(7, 9, '-'), new Point(8, 9, '-'), new Point(9, 9, '-'),
                    new Point(10, 9, '-'), new Point(11, 9, '-'), new Point(12, 9, '-'), new Point(13, 9, '-'),
                    new Point(14, 9, '-'), new Point(15, 9, '-'),
                };

                return _roomOneWalls;
            }
    }
}
