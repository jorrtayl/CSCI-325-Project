using System.Linq;

namespace Battle_of_the_Professor
{
    // model for an event that the player will experience.
    public class Event
    {
        public string[] Answers { get; set; }
        public string CorrectAnswer { get; set; }
        public Affect[] Penalty { get; set; }
        public Affect[] Gain { get; set; }
        public string CorrectReply => IsBossQuestion ?
                                        "Argh can't believe you got that one right!\n Boss lost health!" :
                                        $"Right Answer!\nYou have gained {string.Join(", and ", Gain.Select(a => $"{a.Amount} {a.AffectType}"))}!";
        public string WrongReply => IsBossQuestion ?
                                        "Ooh so close but nope!\n You lost health!" :
                                        $"Wrong Answer!\nYou have lost {string.Join(", and ", Penalty.Select(a => $"{a.Amount * -1} {a.AffectType}"))}!";
        public string Question { get; set; }

        public bool IsBossQuestion { get; set; } = false;
        public bool IsTriggered { get; set; } = false;
        public (int Row, int Col) TriggerLocation { get; set; }
        public bool ShouldTrigger(int row, int col) => (TriggerLocation.Row == row && TriggerLocation.Col == col) && !IsTriggered;
        public bool IsCorrect(string answer) => answer.ToUpper() == CorrectAnswer.ToUpper();
    }
}
