using System;
using System.IO;
using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    class GameState : IGameState
    {
        private TextBox _stats;

        public GameState()
        {

        }

        public void SetStats(TextBox stats)
        {
            _stats = stats;
        }
        
        public void Save(Character player) // needs to pass in health, intellect and sanity
        {
            int[] lines = { player.Health, (int)player.Sanity, player.Intellect }; // stores these values into lines, these values will be the stats and position of the player.
            string[] stringLines = new string[3];

            for (int i = 0; i < 3; i++)
            {
                stringLines[i] = Convert.ToString(lines[i]);
            }

            // had to use a StreamWriter because the buffer was not closing for File.WriteAllLines
            using (var sw = new StreamWriter("PlayerData.txt"))
            {
                if (!File.Exists("PlayerData.txt"))
                {
                    File.CreateText("PlayerData.txt");
                }
            }

            File.WriteAllLines("PlayerData.txt", stringLines); // writes all of these values to the text file.
        }

        public Character Load()
        {
            if (!File.Exists("PlayerData.txt"))
            {
                return new Deprived(100, 1, 1);
            }

            string[] lines = File.ReadAllLines("PlayerData.txt");

            int[] intLines = new int[3];

            for (int i = 0; i < 3; i++)
            {
                intLines[i] = Convert.ToInt32(lines[i]);
            }

            return new Deprived(intLines[0], intLines[1], intLines[2]);
        }

        public void UpdateStats(Character player)
        {
            _stats.Text = $"Health: {player.Health}\nSanity: {player.Sanity}\nIntellect: {player.Intellect}";
        }
    }
}
