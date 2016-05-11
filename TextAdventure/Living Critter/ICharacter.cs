namespace TextAdventure.Living_Critter
{
    /// <summary>A character has to be able to mutate and amount of damage</summary>
    public interface ICharacter
    {
        /// <summary>Determines how much of an effect mutation has</summary>
        void Mutate();
        /// <summary>Describes how much damage was done by the character</summary>
        /// <returns>Returns the amount of damage done by the character</returns>
        int DamageDone();
    }
}
