using System;

namespace TextAdventure.Numers
{
    /// <summary>This class is an attempt at a slightly more random number</summary>
    public class RandomRand
    {
        private readonly double number;
        private readonly double exponent;

	    /// <summary>New number, which is a random of a random</summary>
        public RandomRand()
        {
            var temp1    = new Random();
            var temp2    = new Random();
            number       = temp1.Next();
            exponent     = temp2.Next();
        }

	    /// <summary>Alternate constructor, using essentially a seed</summary>
	    /// <param name="x">The RandomRand's seed</param>
        public RandomRand(int x)
        {
            number       = x % 100;
            var temp2    = new Random();
            exponent     = temp2.Next();
        }

	    /// <returns>Returns a number which is easily turned into a percentage</returns>
        public double MakeRandomPercentage()
        {
            return Math.Pow(number, exponent) % 100;
        }
    }
}