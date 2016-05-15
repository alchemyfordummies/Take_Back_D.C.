using System;
using TextAdventure.Living_Critter;

namespace TextAdventure.Main_Files {
    class LevelUp 
    {
        public static void Level(Human h)
        {
            Console.WriteLine("Level Up! What attribute would you like to increase? You have" +
            " two points (health, mutability, intelligence, brutishness, willpower, endurance).");
            var readLine = Console.ReadLine();
            if (readLine != null) Increment(readLine.ToLower(), h);
            readLine = Console.ReadLine();
            if (readLine != null) Increment(readLine.ToLower(), h);
        }

        private static void Increment(string s, Human h)
        {
            switch (s)
            {
                case "health":
                    h.HealthUp();
                    if (h.GetHealth() % 5 == 0) h.HealthUp();
                    Console.WriteLine("Health: " + h.GetHealth());
                    break;
                case "mutability":
                    h.MutabilityUp();
                    Console.WriteLine("Mutability: " + h.GetMutability());
                    break;
                case "intelligence":
                    h.IntelligenceUp();
                    Console.WriteLine("Intelligence: " + h.GetIntelligence());
                    break;
                case "brutishness":
                    h.BrutishnessUp();
                    Console.WriteLine("Brutishness: " + h.GetBrutishness());
                    break;
                case "willpower":
                    h.WillpowerUp();
                    Console.WriteLine("Willpower: " + h.GetWillpower());
                    break;
                case "endurance":
                    h.EnduranceUp();
                    Console.WriteLine("Endurance: " + h.GetEndurance());
                    break;
                default: 
                    Console.WriteLine("That's not an attribute.");
                    Increment(Console.ReadLine(), h);
                    break;
            }     
        }
    }
}
