using System.Collections.Generic;

namespace Battle_of_the_Professor {
    public abstract class Character
    {
        private List<IGameState> _observers = new List<IGameState>();
        private int _sanity, _intellect, _health;

        public int Sanity { get => _sanity; set { _sanity = value; Notify(); } }
        public int Intellect { get => _intellect; set { _intellect = value; Notify(); } }
        public int Health { get => _health; set { _health = value; Notify(); } }

        public Character(int health, int sanity, int intellect)
        {
            _sanity = sanity;
            _intellect = intellect;
            _health = health;
        }

        public void Attach(IGameState observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Save(this);
            }
        }
    }
}
