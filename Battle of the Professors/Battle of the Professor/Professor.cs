using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_of_the_Professor
{
    class Professor : Character
    {
        public Professor(int _health, int _intellect, int _sanity) : base(_health, _intellect, _sanity)
        {
            _health = 100;
            _intellect = 10;
            _sanity = 10;
        }
    }
}
