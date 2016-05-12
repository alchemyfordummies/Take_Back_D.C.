using System;
using System.IO;
using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Map;

namespace TextAdventure
{
    internal class Program
    {
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

            PrintLines(2);
            var counter = 0;
            while (counter < 7)
            {
                Console.WriteLine(narration.ReadLine());
                counter++;
            }

	        var one  = new Room(1, user);
            MapReader.PrintMap("RoomOneMap.txt", one, user);

            //For my purposes to keep track of movement
            Console.WriteLine(user.GetLocation().GetX());
	        Console.WriteLine(user.GetLocation().GetY());
	        while (!End())
	        {
	            if (InputReader.StartReading(Console.ReadLine(), user, one))
	            {
	                
	            }
		        Console.WriteLine(user.GetLocation().GetX());
		        Console.WriteLine(user.GetLocation().GetY());
	        }

	        EndGame();
        }
    }
}


