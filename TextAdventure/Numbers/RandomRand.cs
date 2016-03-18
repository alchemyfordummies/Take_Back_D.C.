using System;

namespace TextAdventure.Numers
{
    public class RandomRand
    {
        private readonly double number;
        private readonly double exponent;

        public RandomRand()
        {
            var temp1    = new Random();
            var temp2    = new Random();
            number       = temp1.Next();
            exponent     = temp2.Next();
        }

        public RandomRand(int x)
        {
            number       = x % 100;
            var temp2    = new Random();
            exponent     = temp2.Next();
        }

        public double MakeRandomPercentage()
        {
            return Math.Pow(number, exponent) % 100;
        }
    }
}