using System;
using System.IO;
using System.Threading;
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
		    return false;
	    }

        private static void Main(string[] args)
        {
	        Console.WriteLine("What is your name?");
	        var user = new Human(Console.ReadLine());

            var narration = new StreamReader("Narration.txt");
            DialogReader.PrintDialog("Dialogue.txt");

            PrintLines(2);
            //Thread.Sleep(10000);
            var counter = 0;
            while (counter < 5)
            {
                Console.WriteLine(narration.ReadLine());
                counter++;
            }

            MapReader.PrintMap("RoomOneMap.txt");
	        var one  = new Room(1);

	        while (! End())
	        {

	        }
        }
    }
}


