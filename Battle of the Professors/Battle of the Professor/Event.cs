namespace Battle_of_the_Professor
{
    public class Event
    {
        public string[] Answers { get; set; } // A list of possible answers for the question
        public string StringAnswers { get; set; } //test for answers based on user input
        public int CorrectAnswer { get; set; } // The correct answer for this question
        public int Penalty { get; set; }
        public int Gain { get; set; }
        public int trig1, trig2, trig3, trig4 = 0;
        public string CorrectAnswerReply { get => $"Right Answer!\nYou have gained {Gain} intellect!"; }
        public string WrongAnswerReply { get => $"Wrong Answer!\nYou have lost {Penalty} health!"; }
        public string Question { get; set; } // Asks the player a question
        public bool IsTriggered { get; set; } // Triggers the event to ask the question if the player steps on the TriggerLocation
        public (int Row, int Col) TriggerLocation { get; set; } // Triggers once the player's row and col matches
        public bool ShouldTrigger(int row, int col) => (TriggerLocation.Row == row && TriggerLocation.Col == col) && !IsTriggered; // Checks if it should trigger or not
        // this is test stuff, may not be used
        public string Questionb1 { get; set; }
        public string Questionb2 { get; set; }
        public string Questionb3 { get; set; }
        public string Questionb4 { get; set; }
        public string Questionb5 { get; set; }
        public string Questionb6 { get; set; }
        public string Questionb7 { get; set; }
        public string Questionb8 { get; set; }
        public string Questionb9 { get; set; }
        public string Questionb10 { get; set; }
        public string[] Answersb1 { get; set; }
        public string[] Answersb2 { get; set; }
        public string[] Answersb3 { get; set; }
        public string[] Answersb4 { get; set; }
        public string[] Answersb5 { get; set; }
        public string[] Answersb6 { get; set; }
        public string[] Answersb7 { get; set; }
        public string[] Answersb8 { get; set; }
        public string[] Answersb9 { get; set; }
        public string[] Answersb10 { get; set; }
        public int CorrectAnswerb1 { get; set; }
        public int CorrectAnswerb2 { get; set; }
        public int CorrectAnswerb3 { get; set; }
        public int CorrectAnswerb4 { get; set; }
        public int CorrectAnswerb5 { get; set; }
        public int CorrectAnswerb6 { get; set; }
        public int CorrectAnswerb7 { get; set; }
        public int CorrectAnswerb8 { get; set; }
        public int CorrectAnswerb9 { get; set; }
        public int CorrectAnswerb10 { get; set; }
    }
}
