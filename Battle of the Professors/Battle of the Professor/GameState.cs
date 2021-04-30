using System;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Battle_of_the_Professor
{
    public sealed class GameState : Page, IGameState
    {
        private TextBox _stats;

        public Event[] Questions { get; private set; }

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
            Questions = new[]
            {
                new Event() //1
                {
                    Question = "Pop Quiz Time!\nwhat is the purpose of 'for' in programming?\nChoose your answer wisely\n",
                    Answers = new []{ "1. A loop of the number 4", "2. A loop that does an action a cerain amount of times", "3. I think I am in the wrong class" },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "2",
                    TriggerLocation = (1, 2)
                },
                new Event() //2
                {
                    Question = "Pop Quiz Time!\nWhich of the following can be used to define the member of a class externally?\nChoose your answer wisely\n",
                    Answers = new []{ "1. :", "2. ::", "3. #" },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "2",
                    TriggerLocation = (13, 3)
                },
                new Event() //3
                {
                    Question = "Pop Quiz Time!\nWhich of these is a part that makes a computer run faster?\nChoose your answer wisely\n",
                    Answers = new []{ "1. Using an SSD", "2. RGB Everything!", "3. Yelling and Hitting it" },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "1",
                    TriggerLocation = (7, 2)
                },
                 new Event() //4
                {
                    Question = "Pop Quiz Time!\nWhat method is used to print text to the screen in C#?\nChoose your answer wisely\n",
                    Answers = new []{ "1. cout <<", "2. printf ", "3. Console.WriteLine " },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "3",
                    TriggerLocation = (1, 8)
                },
                  new Event() //5
                {
                    Question = "Pop Quiz Time!\nOf the following, what statement is only triggered if requirements are met?\nChoose your answer wisely\n",
                    Answers = new []{ "1. if ", "2. for ", "3. Console.WriteLine " },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "1",
                    TriggerLocation = (7, 8)
                },
                  new Event() //6
                {
                    Question = "Pop Quiz Time!\nWhat computer language are we using in this class?\n",
                    Answers = new []{ "Please enter answer to the right and click check." },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "C#",
                    TriggerLocation = (9, 7)
                },
                   new Event() //7
                {
                    Question = "Pop Quiz Time!\nDBC stands for?\n",
                    Answers = new []{ "1. Design By Contract", "2. Digital Bond Consulting", "3. Design by Basic Contracts" },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "1",
                    TriggerLocation = (13, 17)
                },
                    new Event() //8
                {
                    Question = "Pop Quiz Time!\nWhich of the below is not a structural pattern?\n",
                    Answers = new []{ "1. Composite", "2. Decorator", "3. Abstract Factory" },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "3",
                    TriggerLocation = (7, 15)
                },
                     new Event() //9
                {
                    Question = "Pop Quiz Time!\nThe ____ keyword in C# means that only a portion of a class is defined in a given file.?\n",
                    Answers = new []{ "Please enter answer to the right and click check." },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "Abstract",

                    TriggerLocation = (1, 17)
                },
                      new Event() //10
                {
                    Question = "Pop Quiz Time!\nThe Factory pattern is an ____ type of design pattern?\n",
                    Answers = new []{ "Please enter answer to the right and click check." },
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "Creational",

                    TriggerLocation = (10, 12)
                },
                // BOSS QUESTIONS
                new Event()
                {
                    Question = "Hello my student, I see you have managed to get this far! The question is can you go all the way?\n",
                    Answers = new[]{"1. Of course!", "2. No Way!", "3. Seriously I am in the wrong class"},
                    Penalty = new[] { new Affect(5, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "1",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                     Question = "Ready for the first question? Too bad here it comes!\nAn ____ is a set of all signatures?\n",
                    Answers = new[]{"Please enter answer to the righta and click check."},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "interface",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "2nd question!\nWhat increments an int to the next positive value?\n",
                    Answers = new[]{"1. ++", "2. ==", "3. /"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "1",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "3rd question!\nWhat pattern is a Decorator?\n",
                    Answers = new[]{"1. Behavioral", "2. Creational", "3. Structural"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "3",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "4th question!\nWhat pattern does an Adapter belong to?\n",
                    Answers = new[]{"1. Creational", "2. Behavioral", "3. Structural"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "3",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "5th question!\nWhat does UML stands for?\n",
                    Answers = new[]{"Please enter answer to the right and click check."},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "Unified Modeling Language",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "6th question!\nWhat variable type stores numbers?\n",
                    Answers = new[]{"1. char", "2. int", "3. string"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "2",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "7th question!\nWhat file is included to give information on the project, such as instructions or designs?\n",
                    Answers = new[]{"1. README", "2. Personal Memoirs", "3. IGNOREME"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "1",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "8th question!\nWhat type of variable can store an entire sentence?\n",
                    Answers = new[]{"1. double", "2. int", "3. string"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "3",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "9th question!\nTo get user input via the console in C#, you would use?\n",
                    Answers = new[]{"Please enter answer to the right and click check"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "Console.ReadLine();",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                },
                new Event()
                {
                    Question = "10th question!\nWhat is Dr. Ericson's first name?\n",
                    Answers = new[]{"1. Ericson", "2. Dr.", "3. Kathleen"},
                    Penalty = new[] { new Affect(1, Stat.Health) },
                    Gain = new[] { new Affect(1, Stat.Health) },
                    CorrectAnswer = "3",
                    IsBossQuestion = true,
                    TriggerLocation = (7, 18)
                }
            };
        }

        public void SetStats(TextBox stats)
        {
            _stats = stats;
        }

        public void Save(Character player, Character boss = null)
        {
            if (boss == null) boss = new Professor();

            int[] playerStats = { player.Health, player.Sanity, player.Intellect, Map.Row, Map.Col }; // stores these values into lines, these values will be the stats and position of the player.
            int[] bossStats = { boss.Health, boss.Sanity, boss.Intellect };

            string[] stringLines = new string[7];

            for (int i = 0; i < 5; i++)
            {
                stringLines[i] = Convert.ToString(playerStats[i]);
            }
            stringLines[5] = string.Join(",", Questions.Select(e => e.IsTriggered));
            stringLines[6] = string.Join(",", bossStats);

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

                var questionsAnswered = lines[5].Split(',');

                for (int i = 0; i < questionsAnswered.Length; i++)
                {
                    Questions[i].IsTriggered = Convert.ToBoolean(questionsAnswered[i]);
                }

                Map = new Map(intLines[3], intLines[4]);

                return new Deprived(player.Name, intLines[0], intLines[1], intLines[2]);
            }
            Reset();

            return null;
        }
        public Character LoadBoss(Character player) // optional parameter
        {
            int health, sanity, intellect;

            string[] lines = File.ReadAllLines($"{player.Name}.txt");

            var bossStats = lines[6].Split(',');

            health = int.Parse(bossStats[0]);
            sanity = int.Parse(bossStats[1]);
            intellect = int.Parse(bossStats[2]);

            return new Professor(health, sanity, intellect);
        }
        public void Delete(Character player)
        {
            File.Delete($"{player.Name}.txt");
        }

        public void UpdateStats(Character player)
        {
            _stats.Text = $"Health: {player.Health}\nSanity: {player.Sanity}\nIntellect: {player.Intellect}";
        }
    }
}
