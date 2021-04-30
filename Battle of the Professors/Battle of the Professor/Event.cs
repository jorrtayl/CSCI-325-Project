using System.Linq;

namespace Battle_of_the_Professor
{
    public class Event
    {
        public string[] Answers { get; set; } // A list of possible answers for the question
        public string CorrectAnswer { get; set; } // The correct answer for this question
        public Affect[] Penalty { get; set; }
        public Affect[] Gain { get; set; }
        public string CorrectReply => IsBossQuestion ?
                                        "Argh can't believe you got that one right!\n Boss lost health!" :
                                        $"Right Answer!\nYou have gained {string.Join(", ", Gain.Select(a => $"{a.Amount} {a.AffectType}"))}!";
        public string WrongReply => IsBossQuestion ?
                                        "Ooh so close but nope!\n You lost health!" :
                                        $"Wrong Answer!\nYou have lost {string.Join(", ", Gain.Select(a => $"{a.Amount} {a.AffectType}"))}!";
        public string Question { get; set; } // Asks the player a question

        public bool IsBossQuestion { get; set; } = false;
        public bool IsTriggered { get; set; } = false; // Triggers the event to ask the question if the player steps on the TriggerLocation
        public (int Row, int Col) TriggerLocation { get; set; } // Triggers once the player's row and col matches
        public bool ShouldTrigger(int row, int col) => (TriggerLocation.Row == row && TriggerLocation.Col == col) && !IsTriggered; // Checks if it should trigger or not
        // Handle different cases, etc. Hello vs hello
        public bool IsCorrect(string answer) => answer.ToUpper() == CorrectAnswer.ToUpper();
    }
}
