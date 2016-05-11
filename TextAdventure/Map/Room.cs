using System;
using TextAdventure.Living_Critter.Enemy_Types;
using TextAdventure.Living_Critter.User_Character_Types;
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

        private Point roomOneExit;
        private Point roomTwoExit;
        private Point roomThreeExit;
        private Point roomFourExit;
        private Point roomFiveExit;

        private Point[] _roomOneWalls;
		private int[,] _roomTwoWalls;
		private int[,] _roomThreeWalls;
		private int[,] _roomFourWalls;
		private int[,] _roomFiveWalls;
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

            roomOneExit = new Point(11, 6);
		}

		private void MakeRoomTwo(Human h)
		{
		}

		private void MakeRoomThree(Human h)
		{
		}

		private void MakeRoomFour(Human h)
		{
		}

		private void MakeRoomFive(Human h)
		{
		}

		/// <returns>The filename</returns>
		public string GetFileType()
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
	}
}