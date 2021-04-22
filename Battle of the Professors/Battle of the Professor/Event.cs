using System.Collections.Generic;

namespace Battle_of_the_Professor
{
    public class Event
    {
        public string[] Answers { get; set; } // A list of possible answers for the question
        public string StringAnswers { get; set; } //test for answers based on user input
        public int CorrectAnswer { get; set; } // The correct answer for this question
        public int Penalty { get; set; }
        public int Perk { get; set; }
        public string CorrectAnswerReply { get => $"Right Answer!\nYou have gained {Perk} intellect!"; }
        public string WrongAnswerReply { get => $"Wrong Answer!\nYou have lost {Penalty} health!"; }
        public string Question { get; set; } // Asks the player a question
        public bool IsTriggered { get; set; } // Triggers the event to ask the question if the player steps on the TriggerLocation
        public (int Row, int Col) TriggerLocation { get; set; } // Triggers once the player's row and col matches
        public bool ShouldTrigger(int row, int col) => (TriggerLocation.Row == row && TriggerLocation.Col == col) && !IsTriggered; // Checks if it should trigger or not
    }
}
