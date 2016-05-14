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
            var max = (Intelligence*0.075) + (Brutishness*0.2) + (Globals.UserLevel);
            return RandNum.Next(0, (int)max + 1);
        }
    }
}