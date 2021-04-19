using System.Collections.Generic;

namespace Battle_of_the_Professor {
    public abstract class Character
    {
        private List<IGameState> _observers = new List<IGameState>();
        private int _intellect, _health;
        private float _sanity;

        public float Sanity { get => _sanity; set { _sanity = value; Notify(); } }
        public int Intellect { get => _intellect; set { _intellect = value; Notify(); } }
        public int Health { get => _health; set { _health = value; Notify(); } }

        public Character(int health, float sanity, int intellect)
        {
            _sanity = sanity;
            _intellect = (int)(intellect * sanity);
            _health = health;
        }

        public void Attach(IGameState observer)
        {
            _observers.Add(observer);
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
