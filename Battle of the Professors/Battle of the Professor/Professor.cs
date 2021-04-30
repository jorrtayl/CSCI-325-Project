namespace Battle_of_the_Professor
{
     public class Professor : Character
    {
        public override bool IsDead { get => Health <= 0; }

        public Professor() : base("Dr. Ericson", 100, 1, 15)
        {

        }

        public Professor(int health, int sanity, int intellect) : base("Dr.Ericson", health, sanity, intellect) { }
        public override void Notify()
        {

        }
    }
}
