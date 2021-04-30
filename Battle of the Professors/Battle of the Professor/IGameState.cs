using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    public interface IGameState
    {
        void Save(Character player, Character boss = null);
        Character Load(Character player);
        Character LoadBoss(Character player);
        void Delete(Character player);
        void SetStats(TextBox stats);
        void UpdateStats(Character player);
        Event[] Questions { get; }

        Map Map { get; }
    }
}
