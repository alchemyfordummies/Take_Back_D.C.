using System;
using System.IO;
using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Map;

namespace TextAdventure
{
    internal class Program
    {
        /// <summary>
        /// Simple format function
        /// </summary>
        /// <param name="x">Number of empty lines to print</param>
        public static void PrintLines(int x)
        {
            for (var i = 0; i < x; i++)
            {
                Console.WriteLine();
            }
        }

	    /// <returns>If the game is finished</returns>
	    private static bool End() 
        {
		    return Globals.IsGameDone;
	    }

	    /// <summary>Executes what's done at the end of the game</summary>
	    private static void EndGame()
	    {
		    Console.WriteLine("GAME OVER");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("you suck");
            System.Threading.Thread.Sleep(100);
	    }

	    /// <summary>Executes the program. First prompts for the character name.
	    /// Next, it starts a reader for dialog and narration and prints those
	    /// with some formatting. After that, it initializes room one, then
	    /// parses the user input</summary>
        private static void Main(string[] args)
        {
	        Console.WriteLine("What is your name?");
	        var user = new Human(Console.ReadLine());

            var narration = new StreamReader("Narration.txt");
            DialogReader.PrintDialog("Dialogue.txt");

            //format, then prints some lines of narration
            PrintLines(2);
            var counter = 0;
            while (counter < 7)
            {
                Console.WriteLine(narration.ReadLine());
                counter++;
            }

            /*Sets up each room and the user's location in each*/
	        Room one, two, three, four, five;
	        var room = new[]
	        {
                (five = new Room(5, user)), (four = new Room(4, user)),
                (three = new Room(3, user)), (two = new Room(2, user)),
                (one = new Room(1, user))
	        };

	        var location = new[]
	        {
                five.GetUserLocation(), four.GetUserLocation(),
                three.GetUserLocation(), two.GetUserLocation(),
                one.GetUserLocation()
	        };
            /*End setup*/

            //sets up room one
	        var roomIndex = 4;
            user.SetLocation(location[roomIndex]);
            MapReader.PrintMap("RoomOneMap.txt", room[roomIndex],  user);

            //For my purposes to keep track of movement
            Console.WriteLine(user.GetLocation().GetX());
	        Console.WriteLine(user.GetLocation().GetY());
	        while (!End())
	        {
                //if it hits an exit, goes to the next room, sets the new starting location, 
                //and prints the map, adding a couple lines of space
	            if (InputReader.StartReading(Console.ReadLine(), user, room[roomIndex]))
	            {
	                roomIndex--;
                    user.SetLocation(location[roomIndex]);
                    MapReader.PrintMap(room[roomIndex].GetFileName(), room[roomIndex], user);
                    PrintLines(2);
                }

		        Console.WriteLine(user.GetLocation().GetX());
		        Console.WriteLine(user.GetLocation().GetY());
	        }

	        EndGame();
        }
    }
}


