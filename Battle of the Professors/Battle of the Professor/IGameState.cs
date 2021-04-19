using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    public interface IGameState
    {
        void Save(Character player);

        void SetStats(TextBox stats);

        Character Load();

        void UpdateStats(Character player);
    }
}
