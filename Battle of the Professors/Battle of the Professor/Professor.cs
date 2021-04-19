using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_of_the_Professor
{
    class Professor : Character
    {
        public Professor(int _health, int _intellect, float _sanity) : base(_health, _sanity, _intellect)
        {
            _health = 100;
            _sanity = .40f; // 40% sanity
            _intellect = (int)(10 * _sanity); // sanity makes you insane, lose intellect
        }
    }
}
