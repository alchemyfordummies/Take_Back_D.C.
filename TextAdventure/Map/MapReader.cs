using System;
using System.IO;
using TextAdventure.Living_Critter.User_Character_Types;

namespace TextAdventure.Map
{
    /// <summary>Prints out a map</summary>
    public static class MapReader
    {
        private static char[][] _map;

        /// <summary>
        /// Reads the map into an array of arrays to be printed
        /// </summary>
        /// <param name="s">String of the file to open</param>
        /// <param name="h">Height of the selected room</param>
        public static void StoreMap(string s, int h)
        {
            _map = new char[h][];
            var roomReader = new StreamReader(s);
            string line;
            for (var i = 0; i < h; i++)
            {
                if ((line = roomReader.ReadLine()) != null) _map[i] = line.ToCharArray();
            }
        }

        /// <summary>Prints a specified map with a tiny bit of formatting</summary>
        /// <param name="s">The name of the file to be printed</param>
        /// <param name="r">Current room</param>
        /// <param name="h">Human character, only for location</param>
        public static void PrintMap(string s, Room r, Human h)
        {
            int height = r.GetHeight();
            StoreMap(s, height);
            Console.WriteLine();
            //this finds the location of the person, changes that spot to X
            //STILL BREAKS SOMETIMES (11, 7) on room 1
            _map[r.GetHeight() - h.GetLocation().GetY() - 1][h.GetLocation().GetX()] = 'X';
            //Prints out the lines of the file character by character
            foreach (char[] t in _map)
            {
                foreach (var c in t)
                {
                    Console.Write(c);
                }

                Console.WriteLine();
            }
        }
    }
}