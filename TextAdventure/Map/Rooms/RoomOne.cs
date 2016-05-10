using TextAdventure.Living_Critter.Enemy_Types;
using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Objects;
using TextAdventure.Objects.Consumable.Container;

namespace TextAdventure.Map.Rooms {
    public class RoomOne {
        public RoomOne(Human h, int _height, int _width, object[,] _locations,
            Point[] _roomOneWalls, string _fileName)
        {
            //Each wall in the array
            _roomOneWalls = new[]
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

            _fileName = "RoomOneMap.txt";
            //Sets the start point
            h.SetLocation(new Point(5, 0));

            _height = 10;
            _width = 16;
            _locations = new object[_width, _height];

            //Initializes each point in the array
            for (var i = 0; i < _height; i++) {
                for (var j = 0; j < _width; j++) {
                    _locations[j, i] = new Point(j, i);
                }
            }

            //Makes each wall inaccessible
            foreach (var i in _roomOneWalls) {
                ((Point)_locations[i.GetX(), i.GetY()]).SetAccessible(false);
            }

            //Sets spawns for the enemies
            _locations[6, 1] = new Enemy(Globals.UserLevel, new Point(6, 1));
            _locations[6, 4] = new Enemy(Globals.UserLevel, new Point(6, 4));
            _locations[2, 7] = new Enemy(Globals.UserLevel, new Point(2, 7));
            _locations[10, 7] = new Enemy(Globals.UserLevel, new Point(10, 7), "Sergeant");
            _locations[14, 8] = new Enemy(Globals.UserLevel, new Point(14, 8));
            //sets spawns for the treasures
            _locations[3, 3] = new Barrel(new Point(3, 3));
            _locations[5, 8] = new Barrel(new Point(5, 8));
            _locations[1, 8] = new Chest(new Point(1, 8));

            //_locations[]
        }
    }
}
