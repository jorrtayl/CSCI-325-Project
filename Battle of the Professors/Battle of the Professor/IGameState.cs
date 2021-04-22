using System.Collections.Generic;
using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    public interface IGameState
    {
        void Save(Character player);

        void SetStats(TextBox stats);

        Character Load();

        void UpdateStats(Character player);

        List<Event> Events { get; }
    }
}
