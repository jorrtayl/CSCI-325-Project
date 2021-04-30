namespace Battle_of_the_Professor
{
    //  player's implementation constructors.
    public class Deprived : Character
    {
        public Deprived(string name) : base(name, 100, 5, 5)
        {

        }
        public Deprived(string name, int health, int sanity, int intellect) : base(name, health, sanity, intellect)
        {

        }
    }
}
