using System;
using System.IO;

namespace Battle_of_the_Professor
{
    class Save_Load
    {
        // the constructor will be a parameterized constructor that contains the object for getting the stats: health, sanity, intellect.
        public Save_Load()
        {

        }

        public void SaveData() // needs to pass in health, intellect and sanity
        {
            string[] lines = { "Icy", "Goots" }; // stores these values into lines, these values will be the stats and position of the player.

            if (!File.Exists("PlayerData.txt"))
            {
                File.CreateText("PlayerData.txt"); // creates a base text file for the event if someone does not have the file.
            }
            
            File.WriteAllLines("PlayerData.txt", lines); // writes all of these values to the text file.
        }

        public void LoadData()
        {
            string[] lines = File.ReadAllLines("PlayerData.txt"); // reads all lines of the text file.
            // player.health = lines[0];
        }
    }
}
