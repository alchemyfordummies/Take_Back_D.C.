using System;
using System.IO;

namespace TextAdventure.Map
{
    /// <summary>Reads the dialog file</summary>
    public static class DialogReader
    {
        private static StreamReader _dialogReader;

        /// <summary>Prints the whole file right now. Will be modified to print specific
        /// sections of the file.</summary>
        public static void PrintDialog(string s)
        {
            string line;
            _dialogReader = new StreamReader(s);
	        //Prints all lines in the file
            while ((line = _dialogReader.ReadLine()) != "" && line != null)
            {
                Console.Write(line);
            }

        }
    }
}