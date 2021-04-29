using System;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    public sealed class GameState : IGameState
    {
        private TextBox _stats;

        public Event[] Events { get; private set; }

        public Map Map { get; set; } // every time you have a public variable do a getter and setter. Also, try not to name it the same as the class.

        // Singleton Implementation
        private static readonly IGameState _instance = new GameState();

        public static IGameState Instance { get => _instance; }

        private GameState()
        {
            Reset();
        }

        private void Reset()
        {
            Map = new Map(7, 1);
            Events = new[]
            {
                new Event() //1
                {
                    Question = "Pop Quiz Time!\nwhat is the purpose of 'for' in programming?\nChoose your answer wisely\n",
                    Answers = new []{ "1. A loop of the number 4", "2. A loop that does an action a cerain amount of times", "3. I think I am in the wrong class" },
                    Penalty = 2,
                    Gain = 1,
                    CorrectAnswer = 2,
                    IsTriggered = false,
                    TriggerLocation = (5, 2)
                },
                new Event() //2
                {
                    Question = "Pop Quiz Time!\nWhich of the following can be used to define the member of a class externally?\nChoose your answer wisely\n",
                    Answers = new []{ "1. :", "2. ::", "3. #" },
                    Penalty = 2,
                    Gain = 1,
                    CorrectAnswer = 2,
                    IsTriggered = false,
                    TriggerLocation = (9, 2)
                },
                new Event() //3
                {
                    Question = "Pop Quiz Time!\nWhich of these is a part that makes a computer run faster?\nChoose your answer wisely\n",
                    Answers = new []{ "1. Using an SSD", "2. RGB Everything!", "3. Yelling and Hitting it" },
                    Penalty = 2,
                    Gain = 1,
                    CorrectAnswer = 1,
                    IsTriggered = false,
                    TriggerLocation = (3, 4)
                },
                 new Event() //4
                {
                    Question = "Pop Quiz Time!\nWhat method is used to print text to the screen in C#?\nChoose your answer wisely\n",
                    Answers = new []{ "1. cout <<", "2. printf ", "3. Console.WriteLine " },
                    Penalty = 2,
                    Gain = 1,
                    CorrectAnswer = 3,
                    IsTriggered = false,
                    TriggerLocation = (11, 6)
                },
                  new Event() //5
                {
                    Question = "Pop Quiz Time!\nOf the following, what statement is only triggered if requirements are met?\nChoose your answer wisely\n",
                    Answers = new []{ "1. if ", "2. for ", "3. Console.WriteLine " },
                    Penalty = 2,
                    Gain = 1,
                    CorrectAnswer = 1,
                    IsTriggered = false,
                    TriggerLocation = (4, 6)
                },
                  new Event() //6
                {
                    Question = "Pop Quiz Time!\nWhat computer language are we using in this class?\n",
                    Answers = new []{ "Please enter answer to the right and click check" },
                    Penalty = 2,
                    Gain = 1,
                    StringAnswers = "C#",
                    IsTriggered = false,
                    TriggerLocation = (7, 2)
                },
                  new Event() //Boss Test
                {
                    Question = "Hello my student, I see you have managed to get this far! The question is can you go all the way?\n",
                    Answers = new[]{"1. Of course!", "2. No Way!", "3. Seriously I am in the wrong class"},
                    CorrectAnswer = 1,
                    Questionb1 = "Ready for the first question? Too bad here it comes!\n generic question?\n",
                    Answersb1 = new[]{"1. answer!", "answer!", "answer"},
                    CorrectAnswerb1 = 2,
                    Questionb2 = "2nd questiion!\n generic question?\n",
                    Answersb2 = new[]{"1. answer!", "answer!", "answer"},
                    CorrectAnswerb2 = 2,
                    Questionb3 = "3rd questiion!\n generic question?\n",
                    Answersb3 = new[]{"1. answer!", "answer!", "answer"},
                    CorrectAnswerb3 = 2,
                    Questionb4 = "4th questiion!\n generic question?\n",
                    Answersb4 = new[]{"1. answer!", "answer!", "answer"},
                    CorrectAnswerb4 = 2,
                    Questionb5 = "5th questiion!\n generic question?\n",
                    Answersb5 = new[]{"1. answer!", "answer!", "answer"},
                    CorrectAnswerb5 = 2,
                    IsTriggered = false,
                    TriggerLocation = (7, 18)
                }
            };
        }

        public void SetStats(TextBox stats)
        {
            _stats = stats;
        }

        public void Save(Character player)
        {
            int[] lines = { player.Health, (int)player.Sanity, player.Intellect, Map.Row, Map.Col }; // stores these values into lines, these values will be the stats and position of the player.
            string[] stringLines = new string[6];

            for (int i = 0; i < 5; i++)
            {
                stringLines[i] = Convert.ToString(lines[i]);
            }
            stringLines[5] = string.Join(",", Events.Select(e => e.IsTriggered));

            // had to use a StreamWriter because the buffer was not closing for File.WriteAllLines
            using (var sw = new StreamWriter($"{player.Name}.txt"))
            {
                if (!File.Exists($"{player.Name}.txt"))
                {
                    File.CreateText($"{player.Name}.txt");
                }
            }

            File.WriteAllLines($"{player.Name}.txt", stringLines); // writes all of these values to the text file.
        }

        public Character Load(Character player = null) // optional parameter
        {
            if (player != null && File.Exists($"{player.Name}.txt"))
            {
                string[] lines = File.ReadAllLines($"{player.Name}.txt");

                int[] intLines = new int[5];

                for (int i = 0; i < 5; i++)
                {
                    intLines[i] = Convert.ToInt32(lines[i]);
                }

                var eventsTriggered = lines[5].Split(',');

                for (int i = 0; i < eventsTriggered.Length; i++)
                {
                    Events[i].IsTriggered = Convert.ToBoolean(eventsTriggered[i]);
                }

                Map = new Map(intLines[3], intLines[4]);

                return new Deprived(player.Name, intLines[0], intLines[1], intLines[2]);
            }
            Reset();

            return null;
        }

        public void UpdateStats(Character player)
        {
            _stats.Text = $"Health: {player.Health}\nSanity: {player.Sanity}\nIntellect: {player.Intellect}";
        }
    }
}
