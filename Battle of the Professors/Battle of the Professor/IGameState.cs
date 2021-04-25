using System.Collections.Generic;
using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    public interface IGameState
    {
        void Save(Character player);

        void SetStats(TextBox stats);

        Character Load(Character player);

        void UpdateStats(Character player);

        Event[] Events { get; }

        Map Map { get; }
    }
}
