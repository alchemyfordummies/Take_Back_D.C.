using System;
using System.IO;
using TextAdventure.Living_Critter;
using TextAdventure.Map;
using TextAdventure.Objects;
using TextAdventure.Objects.Consumable.Container;

namespace TextAdventure.Main_Files
{
    /// <summary>Parses the input</summary>
	public static class InputReader
	{
        private static bool _printed;
        private static bool _exiting;

        /// <summary>Takes a string, a human, and a room and checks the input</summary>
        /// <returns>True if we're switching rooms, otherwise is false</returns>
        public static bool StartReading(string s, Human h, Room r)
		{
			return CheckInput(s, h, r);
		}

		/// <summary>Checks the input and performs the corresponing action</summary>
		/// <param name="str">The user input, any type of command</param>
		/// <param name="h">The user's character</param>
		/// <param name="r">The room the user is in</param>
		private static bool CheckInput(string str, Human h, Room r)
		{
            _exiting = false;
		    bool checkAgain = false;
			var point = h.GetLocation();
			switch (str.ToLower())
			{
                //looks if the move is legal, has the program check surroundings 
                //again if a move occurred
                case "w":
					CheckLegalForwardMove(h, r, point);
			        checkAgain = true;
					break;
				case "s":
					CheckLegalBackwardMove(h, r, point);
                    checkAgain = true;
                    break;
				case "a":
					CheckLegalLeftMove(h, r, point);
                    checkAgain = true;
                    break;
				case "d":
					CheckLegalRightMove(h, r, point);
                    checkAgain = true;
                    break;
				case "map":
					//Calls the Mapreader printmap function
					MapReader.PrintMap(r.GetFileName(), r, h);
					break;
				case "quit":
					QuitProgram();
					break;
				case "level":
					//Just prints out the user's level
					Console.WriteLine(Globals.UserLevel);
					break;
                case "health":
                    //prints the user's health
                    Console.WriteLine(h.Hitpoints);
			        break;
                case "stamina":
                    //prints the user's stamina
                    Console.WriteLine(h.GetStamina());
			        break;
                case "help":
			        PrintHelpFile();
			        break;
			}

            //checks all surrounding points for items and the exit, then if the user is at the exit, goes
            //to the next room
		    if (checkAgain) LookAround(point, r);
            CheckForExit(r, h);
		    if (_exiting)
		    {
		        NextRoom(r, h);
		        return true;
		    }

		    return false;
		}

		/// <summary>Looks to see if it's possible to move forward</summary>
		/// <param name="h">The user's character</param>
		/// <param name="r">The room the user is in</param>
		/// <param name="p">The human's location</param>
		public static void CheckLegalForwardMove(Human h, Room r, Point p)
		{
			var x = p.GetX();
			var y = p.GetY();
			var locations = r.GetLocations();
            object location = locations[x, y + 1];

            if (x == r.GetExit().GetX() && (y == r.GetExit().GetY() - 1)) _exiting = true;
            if (y + 1 >= r.GetHeight() - 1) return;
            if (location is Enemy) Fight(x, y + 1, h, locations);
            else if (location is Barrel) Open(x, y + 1, h, locations, "barrel");
            else if (location is Chest) Open(x, y + 1, h, locations, "chest");
            else if (((Point)location).IsAccessible()) p.Forward();
		}

		/// <summary>Looks to see if it's possible to move backward</summary>
		/// <param name="h">The user's character</param>
		/// <param name="r">The room the user is in</param>
		/// <param name="p">The human's location</param>
		public static void CheckLegalBackwardMove(Human h, Room r, Point p)
		{
			var x = p.GetX();
			var y = p.GetY();
			var locations = r.GetLocations();
            object location = locations[x, y - 1];

            if (x == r.GetExit().GetX() && (y == r.GetExit().GetY() + 1)) _exiting = true;
            if (y - 1 <= 0) return;
			if (location is Enemy) Fight(x, y - 1, h, locations);
            else if (location is Barrel) Open(x, y - 1, h, locations, "barrel");
            else if (location is Chest) Open(x, y - 1, h, locations, "chest");
            else if (((Point) location).IsAccessible()) p.Back();
		}

		/// <summary>Looks to see if it's possible to move left</summary>
		/// <param name="h">The user's character</param>
		/// <param name="r">The room the user is in</param>
		/// <param name="p">The human's location</param>
		public static void CheckLegalLeftMove(Human h, Room r, Point p)
		{
			var x = p.GetX();
			var y = p.GetY();
			var locations = r.GetLocations();
            var location = locations[x - 1, y];

            if (x == r.GetExit().GetX() + 1 && (y == r.GetExit().GetY())) _exiting = true;
            if (x - 1 <= 0) return;
			if (location is Enemy) Fight(x - 1, y, h, locations);
            else if (location is Barrel) Open(x - 1, y, h, locations, "barrel");
            else if (location is Chest) Open(x -1, y, h, locations, "chest");
            else if (((Point) location).IsAccessible()) p.Left();
		}

		/// <summary>Looks to see if it's possible to move right</summary>
		/// <param name="h">The user's character</param>
		/// <param name="r">The room the user is in</param>
		/// <param name="p">The human's location</param>
		public static void CheckLegalRightMove(Human h, Room r, Point p)
		{
			var x = p.GetX();
			var y = p.GetY();
			var locations = r.GetLocations();
            object location = locations[x + 1, y];

            if (x == r.GetExit().GetX() - 1 && (y == r.GetExit().GetY())) _exiting = true;
            if (x + 1 >= r.GetWidth() - 1) return;
			if (location is Enemy) Fight(x + 1, y, h, locations);
            else if (location is Barrel) Open(x + 1, y, h, locations, "barrel");
            else if (location is Chest) Open(x + 1, y, h, locations, "chest");
            else if (((Point) location).IsAccessible()) p.Right();
		}

		/// <summary>Prompts the user for quitting, then quits on "yes"</summary>
		private static void QuitProgram()
		{
			Console.WriteLine("Do you want to quit? (yes or no)");
			var s = Console.ReadLine();

			if (s == null) return;
			if (s.ToLower().Equals("yes")) Environment.Exit(0);
		}

        /// <summary>
        /// Looks around the user to see if there's an exit
        /// </summary>
        /// <param name="r">Current room</param>
        /// <param name="h"></param>
        public static void CheckForExit(Room r, Human h)
        {
            if (h.GetLocation().GetX() == r.GetExit().GetX() &&
                h.GetLocation().GetY() == r.GetExit().GetY() - 1) Console.WriteLine("I think I see the exit");
            else if (h.GetLocation().GetX() == r.GetExit().GetX() &&
                h.GetLocation().GetY() == r.GetExit().GetY() + 1) Console.WriteLine("I think I see the exit");
            else if (h.GetLocation().GetX() == r.GetExit().GetX() - 1 &&
                h.GetLocation().GetY() == r.GetExit().GetY()) Console.WriteLine("I think I see the exit");
            else if (h.GetLocation().GetX() == r.GetExit().GetX() + 1 &&
                h.GetLocation().GetY() == r.GetExit().GetY()) Console.WriteLine("I think I see the exit");
        }

		/// <summary>Checks user surroundings for treasure or enemies</summary>
		/// <param name="r">The room the user is in</param>
		/// <param name="p">The human's location</param>
		public static void LookAround(Point p, Room r)
		{
		    _printed = false;
			var x = p.GetX();
			var y = p.GetY();

            CheckEnemies(r, x, y);
		    if (!_printed)
		    {
		        CheckContainers(r, x, y);
		    }
			
			if (!_printed)
			{
			    Console.WriteLine("Seems safe for now...");
			}

		    _printed = false;
		}

        /// <summary>
        /// Checks the four locations around the user and sees if that one is an enemy
        /// </summary>
        /// <param name="r">Current room</param>
        /// <param name="x">x-coordinate of the point</param>
        /// <param name="y">y-coordinate of the point</param>
        public static void CheckEnemies(Room r, int x, int y)
        {
            var point = r.GetLocations()[x + 1, y];
            CastEnemies(point);

            point = r.GetLocations()[x - 1, y];
            CastEnemies(point);

            point = r.GetLocations()[x, y + 1];
            CastEnemies(point);

            point = r.GetLocations()[x, y - 1];
            CastEnemies(point);
        }

        /// <summary>
        /// Tries casting the object into an enemy, then checks for null to determine
        /// if the object is an enemy
        /// </summary>
        /// <param name="point">The point to be checked</param>
        private static void CastEnemies(object point)
        {
            var enemy = point as Enemy;
            if (enemy == null) return;
            if (_printed) return;
            Console.WriteLine("You feel uneasy...");
            _printed = true;
        }

        /// <summary>
        /// Checks the four locations around the user and sees if that one is a container
        /// </summary>
        /// <param name="r">Current room</param>
        /// <param name="x">-x-coordinate of the point</param>
        /// <param name="y">y-coordinate of the point</param>
        public static void CheckContainers(Room r, int x, int y)
        {
            var point = r.GetLocations()[x + 1, y];
            CastContainers(point);

            point = r.GetLocations()[x - 1, y];
            CastContainers(point);

            point = r.GetLocations()[x, y + 1];
            CastContainers(point);

            point = r.GetLocations()[x, y - 1];
            CastContainers(point);
        }

        /// <summary>
        /// Tries casting the object as a container, then checks for null to determine if it is
        /// a container
        /// </summary>
        /// <param name="point">The point to be checked</param>
        private static void CastContainers(object point)
        {
            var container= point as IContainer;
            if (container == null) return;
            if (_printed) return;
            Console.WriteLine("Is that treasure?");
            _printed = true;
        }

		/// <summary>Carries out the combat</summary>
		/// <param name="x">x-coordinate of the point</param>
		/// <param name="y">y-coordinate of the point</param>
		/// <param name="h">The user's character</param>
		/// <param name="locations">The object array from the current room</param>
		private static void Fight(int x, int y, Human h, object[,] locations)
		{
			var enemy = (Enemy) locations[x, y];
			while (h.Hitpoints > 0 && enemy.Hitpoints > 0)
			{
                Console.WriteLine(enemy.Hitpoints + ", " + h.Hitpoints);
                h.Attack(enemy);
			    if (enemy.Hitpoints > 0) enemy.Attack(h);
			    System.Threading.Thread.Sleep(1000);
			}

			if (h.Hitpoints > 0 && enemy.Hitpoints == 0)
			{
				Globals.UserLevel++;
                h.StaminaDown();
				locations[x, y] = new Point(x, y);
                Console.WriteLine(enemy.Hitpoints + ", " + h.Hitpoints);
                LevelUp.Level(h);
			}

			else Globals.IsGameDone = true;
        }

        /// <summary>Handles opening a container</summary>
		/// <param name="x">x-coordinate of the point</param>
		/// <param name="y">y-coordinate of the point</param>
		/// <param name="h">The user's character</param>
		/// <param name="locations">The object array from the current room</param>
        public static void Open(int x, int y, Human h, object[,] locations, string str)
        {
            var randGen = new Random();
            int rand = randGen.Next(0, 1000);
            var container = (IContainer)locations[x, y];
            if (str == "barrel")
            {
                int temp = randGen.Next(0, 1000);
                if (temp > 874)
                {
                    Explosion exp = new Explosion(h);
                    int damage = exp.getDamage();
                    h.Hitpoints -= damage;
                    Console.WriteLine("It was a trap! The barrel exploded for " +
                                      damage + " damage");
                }
                else
                {
                    Loot.chooseBarrelLoot(h, temp);
                    //gotta do something after this
                }
            }
            else
            {
                Loot.chooseChestLoot(h, randGen.Next(0, 1000));
                //gotta do something here too
            }
        }

        /// <summary>
        /// Sets up the next room for the player to get into
        /// </summary>
        public static bool NextRoom(Room r, Human h)
        {
            Console.WriteLine("Made it to the next floor. Let's hope this one goes as smoothly as " +
                              "the first one...");
            return true;
        }

        /// <summary>
        /// Prints the help file containing all the help commands the user can type
        /// </summary>
        public static void PrintHelpFile()
        {
            var read = new StreamReader("Help.txt");
            Console.WriteLine(read.ReadToEnd());
        }
	}
}