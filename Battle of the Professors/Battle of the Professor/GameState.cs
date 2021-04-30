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
                    Penalty = 1,
                    Gain = 1,
                    CorrectAnswer = 2,
                    IsTriggered = false,
                    TriggerLocation = (1, 2)
                },
                new Event() //2
                {
                    Question = "Pop Quiz Time!\nWhich of the following can be used to define the member of a class externally?\nChoose your answer wisely\n",
                    Answers = new []{ "1. :", "2. ::", "3. #" },
                    Penalty = 1,
                    Gain = 1,
                    CorrectAnswer = 2,
                    IsTriggered = false,
                    TriggerLocation = (13, 3)
                },
                new Event() //3
                {
                    Question = "Pop Quiz Time!\nWhich of these is a part that makes a computer run faster?\nChoose your answer wisely\n",
                    Answers = new []{ "1. Using an SSD", "2. RGB Everything!", "3. Yelling and Hitting it" },
                    Penalty = 1,
                    Gain = 1,
                    CorrectAnswer = 1,
                    IsTriggered = false,
                    TriggerLocation = (7, 2)
                },
                 new Event() //4
                {
                    Question = "Pop Quiz Time!\nWhat method is used to print text to the screen in C#?\nChoose your answer wisely\n",
                    Answers = new []{ "1. cout <<", "2. printf ", "3. Console.WriteLine " },
                    Penalty = 1,
                    Gain = 1,
                    CorrectAnswer = 3,
                    IsTriggered = false,
                    TriggerLocation = (1, 8)
                },
                  new Event() //5
                {
                    Question = "Pop Quiz Time!\nOf the following, what statement is only triggered if requirements are met?\nChoose your answer wisely\n",
                    Answers = new []{ "1. if ", "2. for ", "3. Console.WriteLine " },
                    Penalty = 1,
                    Gain = 1,
                    CorrectAnswer = 1,
                    IsTriggered = false,
                    TriggerLocation = (7, 8)
                },
                  new Event() //6
                {
                    Question = "Pop Quiz Time!\nWhat computer language are we using in this class?\n",
                    Answers = new []{ "Please enter answer to the right and click check" },
                    Penalty = 1,
                    Gain = 1,
                    StringAnswers = "C#",
                    IsTriggered = false,
                    TriggerLocation = (9, 7)
                },
                   new Event() //7
                {
                    Question = "Pop Quiz Time!\nDBC stands for?\n",
                    Answers = new []{ "1. Design By Contract", "2. Digital Bond Consulting", "3. Design by Basic Contracts" },
                    Penalty = 1,
                    Gain = 1,
                    CorrectAnswer = 1,
                    IsTriggered = false,
                    TriggerLocation = (13, 17)
                },
                    new Event() //8
                {
                    Question = "Pop Quiz Time!\nWhich of the below is not a structural pattern?\n",
                    Answers = new []{ "1. Composite", "2. Decorator", "3. Abstract Factory" },
                    Penalty = 1,
                    Gain = 1,
                    CorrectAnswer = 3,
                    IsTriggered = false,
                    TriggerLocation = (7, 15)
                },
                     new Event() //9
                {
                    Question = "Pop Quiz Time!\nThe ____ keyword in C# means that only a portion of a class is defined in a given file.?\n",
                    Answers = new []{ "Please enter answer to the right and click check, First letter should capitalized." },
                    Penalty = 1,
                    Gain = 1,
                    StringAnswers = "Abstract",
                    IsTriggered = false,
                    TriggerLocation = (1, 17)
                },
                      new Event() //10
                {
                    Question = "Pop Quiz Time!\nThe Factory pattern is an ____ type of design pattern?\n",
                    Answers = new []{ "Please enter answer to the right and click check, First letter should capitalized." },
                    Penalty = 1,
                    Gain = 1,
                    StringAnswers = "Creational",
                    IsTriggered = false,
                    TriggerLocation = (10, 12)
                },
                  new Event() //Boss Test
                {
                    Question = "Hello my student, I see you have managed to get this far! The question is can you go all the way?\n",
                    Answers = new[]{"1. Of course!", "2. No Way!", "3. Seriously I am in the wrong class"},
                    CorrectAnswer = 1,
                    Questionb1 = "Ready for the first question? Too bad here it comes!\nA ____ is a set of all signatures?\n",
                    Answersb1 = new[]{"Please enter answer to the righta and click check, First letter should be capitalized."},
                    StringAnswers = "Interface",
                    Questionb2 = "2nd questiion!\nWhat increments an int to the next positive value?\n",
                    Answersb2 = new[]{"1. ++", "2. ==", "3. /"},
                    CorrectAnswerb2 = 1,
                    Questionb3 = "3rd questiion!\n?What pattern is a Decorator?\n",
                    Answersb3 = new[]{"1. Behaviroal", "2. Creational", "3. Structural"},
                    CorrectAnswerb3 = 3,
                    Questionb4 = "4th questiion!\nWhat pattern does an Adapter belong to?\n",
                    Answersb4 = new[]{"1. Creational", "2. Behavioral", "3. Structural"},
                    CorrectAnswerb4 = 3,
                    Questionb5 = "5th questiion!\nUML stands for?\n",
                    Answersb5 = new[]{"Please enter answer to the right and click check, All first letters should be capitalized"},
                    StringAnswersb1 = "Unified Modeling Language",
                    Questionb6 = "6th question!\nWhat variable type stores numbers?\n",
                    Answersb6 = new[]{"1. char", "2. int", "3. string"},
                    CorrectAnswerb6 = 2,
                    Questionb7 = "7th questiion!\nWhat file is included to give information on the project, such as instrucitons or designs?\n",
                    Answersb7 = new[]{"1. README", "2. Personal Memoirs", "3. IGNOREME"},
                    CorrectAnswerb7 = 1,
                    Questionb8 = "8th questiion!\nWhat type of variable can store an entire sentence?\n",
                    Answersb8 = new[]{"1. double", "2. int", "3. string"},
                    CorrectAnswerb8 = 3,
                    Questionb9 = "9th questiion!\nTo get user input via the console in C#, you would use?\n",
                    Answersb9 = new[]{"Please enter answer to the right and click check"},
                    StringAnswersb2 = "Console.ReadLine();",
                    Questionb10 = "10th questiion!\nWhat is Dr. Ericksons first name?\n",
                    Answersb10 = new[]{"1. Erickson", "2. Dr.", "3. Kathleen"},
                    CorrectAnswerb10 = 3,
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
