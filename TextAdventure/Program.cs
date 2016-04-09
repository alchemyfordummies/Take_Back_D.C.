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

	    private static bool End()
	    {
		    return Globals.IsGameDone;
	    }

	    private static void EndGame()
	    {
		    Console.WriteLine("GAME OVER");

	    }

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

            MapReader.PrintMap("RoomOneMap.txt");
	        var one  = new Room(1, user);
	        Console.WriteLine(user.GetLocation().GetX());
	        Console.WriteLine(user.GetLocation().GetY());
	        while (!End())
	        {
		        InputReader.StartReading(Console.ReadLine(), user, one);
		        Console.WriteLine(user.GetLocation().GetX());
		        Console.WriteLine(user.GetLocation().GetY());
	        }

	        EndGame();
        }
    }
}


