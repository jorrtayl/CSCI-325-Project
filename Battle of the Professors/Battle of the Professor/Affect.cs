namespace Battle_of_the_Professor
{
    // modifies the stat changes for the events in GameState.
    public class Affect
    {
        public int Amount { get; set; }

        public Stat AffectType { get; set; }

        public Affect(int amount, Stat type) 
        {
            Amount = amount;
            AffectType = type;
        }
    }

    // only used in this class.
    public enum Stat
    {
        Health,
        Sanity,
        Intellect
    }
}
