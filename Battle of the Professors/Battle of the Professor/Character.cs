using System.Collections.Generic;

namespace Battle_of_the_Professor
{
    public abstract class Character
    {
        private List<IGameState> _observers = new List<IGameState>();
        private int _intellect, _health, _sanity;

        public int Health { get => _health; set { _health = value; Notify(); } }
        public int Sanity { get => _sanity; set { _sanity = value; Notify(); } }
        public int Intellect { get => _intellect; set { _intellect = value; Notify(); } }
        public string Name { get; set; }

        public Character(string name, int health, int sanity, int intellect)
        {
            Name = name;
            _health = health;
            _sanity = sanity;
            _intellect = intellect;
        }

        public void Attach(IGameState observer)
        {
            _observers.Add(observer); // adds observer into the list of _observers
        }

        public virtual void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Save(this);
                observer.UpdateStats(this);
            }
        }
    }
}
