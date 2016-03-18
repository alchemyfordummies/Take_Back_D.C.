namespace TextAdventure.Objects.Consumable
{
    public class Effect
    {
        //Needs something to specify which attribute
        int buff;
        int curse;

        public Effect()
        {
            buff = 0;
            curse = 0;
        }

        public Effect(string s, int b = 0, int c = 0)
        {
            switch (s)
            {
                default:
                    SetBuffAndCurse(b, c);
                    break;
            }

        }

        public void SetBuffAndCurse(int b, int c)
        {
            buff = b;
            curse = c;
        }
    }
}