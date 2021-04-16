using System;
using System.IO;
using static Battle_of_the_Professor.MainWindow;

namespace Battle_of_the_Professor
{
    class Save_Load
    {
        int health, sanity, intellect;

        // the constructor will be a parameterized constructor that contains the object for getting the stats: health, sanity, intellect.
        public Save_Load(Character player)
        {
            health = player.health;
            sanity = player.sanity;
            intellect = player.intellect;
        }

        public void SaveData() // needs to pass in health, intellect and sanity
        {
            int[] lines = { health, intellect, sanity }; // stores these values into lines, these values will be the stats and position of the player.
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
                    File.CreateText("PlayerData.txt"); // creates a base text file for the event if someone does not have the file.
                }
            }

            File.WriteAllLines("PlayerData.txt", stringLines); // writes all of these values to the text file.
        }

        public void LoadData(ref Character player)
        {
            string[] lines = File.ReadAllLines("PlayerData.txt");
            int[] intLines = new int[3];
            for (int i = 0; i < 3; i++)
            {
                intLines[i] = Convert.ToInt32(lines[i]);
            }

            if (player != null)
            {
                player.health = intLines[0];
                player.intellect = intLines[1];
                player.sanity = intLines[2];
            }
            else
            {
                player = new Character(1, 1, 100)
                {
                    health = intLines[0],
                    intellect = intLines[1],
                    sanity = intLines[2]
                };
            }
        }
    }
}
