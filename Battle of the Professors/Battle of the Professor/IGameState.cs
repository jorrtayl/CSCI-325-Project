using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    public interface IGameState
    {
        void Save(Character player);
        Character Load(Character player);
        void Delete(Character player);
        void SetStats(TextBox stats);
        void UpdateStats(Character player);
        Event[] Events { get; }

        Map Map { get; }
    }
}
