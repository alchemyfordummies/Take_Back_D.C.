namespace TextAdventure.Objects.Consumable
{
    /// <summary>Defines an effect for a potion</summary>
    public class Effect
    {
        //Needs something to specify which attribute
        int buff;
        int curse;

        /// <summary>Constructs a default empty effect</summary>
        public Effect()
        {
            buff = 0;
            curse = 0;
        }

        /// <summary>Constructs a specific effect</summary>
        /// <param name="s">The type of effect to be constructed</param>
        /// <param name="b">Changes the amount of the buff</param>
        /// <param name="c">Changes the amount of the curse</param>
        public Effect(string s, int b = 0, int c = 0)
        {
            switch (s)
            {
                default:
                    SetBuffAndCurse(b, c);
                    break;
            }

        }

        /// <summary>Takes the buff and curse value and initializes the effect</summary>
        /// <param name="c">Curse value</param>
        /// <param name="b">Buff value</param>
        public void SetBuffAndCurse(int b, int c)
        {
            buff = b;
            curse = c;
        }
    }
}