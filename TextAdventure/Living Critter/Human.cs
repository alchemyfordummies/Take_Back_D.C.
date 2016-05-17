using System;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter
{
    /// <summary>
    /// Initiates a user Character with default attributes. This is who the user will control through the game.
    /// </summary>
    public class Human: ICharacter
    {
        /// <summary>Max number of hitpoints</summary>
        protected int Health;
        /// <summary>Determines how likely it is for the character to mutate</summary>
	    protected int Mutability;
        /// <summary>Part of the damage formula</summary>
	    protected int Intelligence;
        /// <summary>Bigger part of the damage formula</summary>
	    protected int Brutishness;
        /// <summary>Right now unused</summary>
	    protected int Willpower;
        /// <summary>Also unused right now</summary>
	    protected int Endurance;
        /// <summary>Helps damage, drops after each fight</summary>
        protected double Stamina;
        /// <summary>Sets the enemy's level, used in damage as well</summary>
	    public int Hitpoints;

        /// <summary>Starts as health, goes down with attacks</summary>
        protected Random RandNum;

        /// <summary>This enemy's random number generator</summary>
	    protected readonly string Name;

        /// <summary>Selects the type of enemy this instance is</summary>
	    protected Point Location;

	    /// <summary>Initiates a human with default attributes</summary>
	    /// <param name="s">The name the user inputted</param>
        public Human(string s)
        {
            Health = Mutability = Intelligence =
            Brutishness = Willpower = Endurance =
            Hitpoints = 10;
            Globals.UserLevel = 1;
            RandNum = new Random();
	        Name = s;
        }

	    /// <returns>User's location</returns>
	    public Point GetLocation()
	    {
		    return Location;
	    }

	    /// <param name="p">Changes the human's location to p</param>
	    public void SetLocation(Point p)
	    {
		    Location = p;
	    }

        /// <summary>
        /// Sets the user's stamina
        /// </summary>
        /// <param name="i">The value of the stamina to set to</param>
        public void SetStamina(double i)
        {
            Stamina = i;
        }

	    /// <summary>Increments the user's level</summary>
        public void LevelUp()
        {
            Globals.UserLevel++;
        }

        /// <summary>
        /// Increments the user's health and hitpoints
        /// </summary>
        public void HealthUp()
        {
            Health++;
            Hitpoints++;
        }

        /// <summary>
        /// Increments the user's mutability
        /// </summary>
        public void MutabilityUp()
        {
            Mutability++;
        }

        /// <summary>
        /// Increments the user's intelligence
        /// </summary>
        public void IntelligenceUp()
        {
            Intelligence++;
        }

        /// <summary>
        /// Increments the user's brutishness
        /// </summary>
        public void BrutishnessUp()
        {
            Brutishness++;
        }

        /// <summary>
        /// Increments the user's willpower
        /// </summary>
        public void WillpowerUp()
        {
            Willpower++;
        }

        /// <summary>
        /// Increments the user's endurance
        /// </summary>
        public void EnduranceUp()
        {
            Endurance++;
        }

        /// <summary>
        /// Increments the user's stamina
        /// </summary>
        public void StaminaUp()
        {
            Stamina++;
        }

        /// <summary>
        /// Lowers the human's stamina after a fight
        /// </summary>
        public void StaminaDown()
        {
            double up = Math.Round(0.1*Willpower);
            if (Stamina > 0)
            {
                Stamina = Stamina - 2 + up;
            }
        }

        /// <summary>
        /// Getter for health
        /// </summary>
        /// <returns>Returns the user's health</returns>
        public int GetHealth()
        {
            return Health;
        }

        /// <summary>
        /// Getter for mutability
        /// </summary>
        /// <returns>Returns the user's mutability</returns>
        public int GetMutability()
        {
            return Mutability;
        }

        /// <summary>
        /// Getter for intelligence
        /// </summary>
        /// <returns>Returns the user's intelligence</returns>
        public int GetIntelligence()
        {
            return Intelligence;
        }

        /// <summary>
        /// Getter for brutishness
        /// </summary>
        /// <returns>Returns the user's brutishness</returns>
        public int GetBrutishness()
        {
            return Brutishness;
        }

        /// <summary>
        /// Getter for willpower
        /// </summary>
        /// <returns>Returns the user's willpower</returns>
        public int GetWillpower()
        {
            return Willpower;
        }

        /// <summary>
        /// Getter for endurance
        /// </summary>
        /// <returns>Returns the user's endurance</returns>
        public int GetEndurance()
        {
            return Endurance;
        }

        /// <summary>
        /// Returns the user's stamina
        /// </summary>
        /// <returns></returns>
        public double GetStamina()
        {
            return Stamina;
        }

	    /// <summary>Performs an attack by the human on an enemy</summary>
	    /// <param name="e">The enemy being attacked</param>
        public void Attack(Enemy e)
        {
	        e.Hitpoints -= DamageDone();
	        if (e.Hitpoints < 0) e.Hitpoints = 0;
        }

        /// <summary>Yet to be determined</summary>
        public void Mutate()
        {

        }

	    /// <summary>Uses Intelligence, Brutishness, and Level to determine damage</summary>
	    /// <returns>A number between 0 and the max calculated damage</returns>
        public int DamageDone()
	    {
	        var chance = HitChance();
            var max = (Intelligence*0.075) + (Brutishness*0.2) + (Globals.UserLevel)
                            +(Endurance*0.15) + (Willpower*0.05);
	        if (RandNum.Next(0, 100) < ((int) chance*100)) return 0;
	        return Stamina > 0 ? RandNum.Next(2, (int) max + 1) : RandNum.Next(0, (int)max - 1);
	    }

        /// <summary>
        /// Calculates the chance for the user to hit
        /// </summary>
        /// <returns>Returns a double as a percentage for the chance</returns>
        public double HitChance()
        {
            return 0.65 + (0.012*Intelligence) + (0.005*Willpower);
        }
    }
}