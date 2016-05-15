using System;
using TextAdventure.Living_Critter;
using TextAdventure.Map.Rooms;
using TextAdventure.Objects;
using TextAdventure.Objects.Consumable.Container;

namespace TextAdventure.Map
{
    /// <summary>Makes a new room, the main playing area</summary>
	public class Room
	{
		//Room attributes
		private int _height;
		private int _width;

		private object[,] _locations;

        //exit spot and the user's start location
        private Point _exit;
        private Point _userLocation;

        private Point[] _roomOneWalls;
		private Point[] _roomTwoWalls;
		private Point[] _roomThreeWalls;
		private Point[] _roomFourWalls;
		private Point[] _roomFiveWalls;
		//Text file with the room specification
		private string _fileName;

		/// <param name="i">Room number to be created</param>
		/// <param name="h">The user's character</param>
		public Room(int i, Human h)
		{
			switch (i)
			{
				case 1:
					MakeRoomOne(h);
					break;
				case 2:
					MakeRoomTwo(h);
					break;
				case 3:
					MakeRoomThree(h);
					break;
				case 4:
					MakeRoomFour(h);
					break;
				case 5:
					MakeRoomFive(h);
					break;
                default:
                    Console.WriteLine("Invalid room number. Exiting.");
                    Environment.Exit(1);
			        break;
			}
		}

		/// <summary>Creates the first room</summary>
		/// <param name="h">The user's character</param>
		private void MakeRoomOne(Human h)
		{
            _roomOneWalls = RoomOne.MakeRoomOne(h, _height, _width, _locations,
            _roomOneWalls, _fileName);
            _fileName = "RoomOneMap.txt";
            //Sets the start point
            _userLocation = new Point(5, 0);

            _height = 10;
            _width = 16;
		    _locations = SetUpLocations(_locations);

		    SetInaccessibleWalls(_roomOneWalls);

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

            _exit = new Point(11, 6);
		}

        /// <summary>Creates the second room</summary>
		/// <param name="h">The user's character</param>
		private void MakeRoomTwo(Human h)
		{
            _roomTwoWalls = RoomTwo.MakeRoomTwo(h, _height, _width, _locations,
            _roomTwoWalls, _fileName);
		    _fileName = "RoomTwoMap.txt";
            //sets user's location
            _userLocation = new Point(1, 0);

            _height = 5;
            _width = 20;
            _locations = SetUpLocations(_locations);

            SetInaccessibleWalls(_roomTwoWalls);

            //set enemy spawns
		    _locations[2, 1] = new Enemy(Globals.UserLevel, new Point(2, 1), "Sergeant");
            _locations[5, 1] = new Enemy(Globals.UserLevel, new Point(5, 1));
            _locations[11, 1] = new Enemy(Globals.UserLevel, new Point(11, 1));
            _locations[12, 1] = new Enemy(Globals.UserLevel, new Point(12, 1));
            _locations[13, 1] = new Enemy(Globals.UserLevel, new Point(13, 1));
            _locations[12, 2] = new Enemy(Globals.UserLevel, new Point(12, 2));
            _locations[1, 3] = new Enemy(Globals.UserLevel, new Point(1, 3), "Sergeant");
            _locations[2, 3] = new Enemy(Globals.UserLevel, new Point(2, 3), "Sergeant");
            _locations[5, 3] = new Enemy(Globals.UserLevel, new Point(5, 3));
            _locations[14, 3] = new Enemy(Globals.UserLevel, new Point(14, 3));
            //set treasure spawns
            _locations[18, 3] = new Enemy(Globals.UserLevel, new Point(18, 3), "Lieutenant");

            _exit = new Point(4, 4);
        }

		private void MakeRoomThree(Human h)
		{
		    _roomThreeWalls = RoomThree.MakeRoomThree(h, _height, _width, _locations,
		    _roomThreeWalls, _fileName);
		    _fileName = "RoomThreeMap.txt";
            //sets user's location
            _userLocation = new Point(7, 0);

		    _height = 9;
		    _width = 15;
		    _locations = SetUpLocations(_locations);

            SetInaccessibleWalls(_roomThreeWalls);

            //set Enemy spawns
		    _locations[7, 2] = new Enemy(Globals.UserLevel, new Point(7, 2), "Major");
            _locations[7, 7] = new Enemy(Globals.UserLevel, new Point(7, 7), "Sergeant");
            _locations[1, 4] = new Enemy(Globals.UserLevel, new Point(1, 4));
            _locations[2, 4] = new Enemy(Globals.UserLevel, new Point(2, 4), "Sergeant");
            _locations[13, 4] = new Enemy(Globals.UserLevel, new Point(13, 4), "Sergeant");
            _locations[2, 5] = new Enemy(Globals.UserLevel, new Point(2, 5), "Sergeant");
            _locations[12, 5] = new Enemy(Globals.UserLevel, new Point(12, 5), "Major");
            _locations[2, 6] = new Enemy(Globals.UserLevel, new Point(2, 6), "Sergeant");

            _exit = new Point(3, 4);
        }

		private void MakeRoomFour(Human h)
		{
		}

		private void MakeRoomFive(Human h)
		{
		}

        /// <summary>
        /// Initializes the object array given to it as a bunch of points
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public object[,] SetUpLocations(object[,] objs)
        {
            objs = new object[_width, _height];

            //Initializes each point in the array
            for (var i = 0; i < _height; i++) {
                for (var j = 0; j < _width; j++) {
                    objs[j, i] = new Point(j, i);
                }
            }

            return objs;
        }

        /// <summary>
        /// Takes the given array of points and makes those walls inaccessable
        /// </summary>
        /// <param name="points"></param>
        private void SetInaccessibleWalls(Point[] points)
        {
            //Makes each wall inaccessible
            foreach (var i in points) {
                ((Point)_locations[i.GetX(), i.GetY()]).SetAccessible(false);
            }
        }

		/// <returns>The filename</returns>
		public string GetFileName()
		{
			return _fileName;
		}

		/// <returns>The location array</returns>
		public object[,] GetLocations()
		{
			return _locations;
		}

		/// <returns>The room's height</returns>
		public int GetHeight()
		{
			return _height;
		}

		/// <returns>The room's width</returns>
		public int GetWidth()
		{
			return _width;
		}

        /// <returns>Room one's exit</returns>
        public Point GetExit()
        {
            return _exit;
        }

        /// <summary>
        /// Getter for the _userLocation attribute
        /// </summary>
        /// <returns>_userLocation</returns>
        public Point GetUserLocation()
        {
            return _userLocation;
        }
	}
}