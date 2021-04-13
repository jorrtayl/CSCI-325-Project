using System.IO;

namespace Battle_of_the_Professor
{
    class Save_Load
    {
        public Save_Load()
        {

        }

        public void SaveData() // needs to pass in health, intellect and sanity
        {
            File.CreateText("PlayerData.txt"); // creates a base text file for the event if someone does not have the file.
            string[] lines = { "123", "456" }; // stores these values into lines, these values will be the stats and position of the player.
            File.WriteAllLines("PlayerData.txt",  lines); // writes all of these values to the text file.
        }

        public void LoadData()
        {
            // string[] lines = File.ReadAllLines("PlayerData.txt"); // reads all lines of the text file.
        }
    }
}
