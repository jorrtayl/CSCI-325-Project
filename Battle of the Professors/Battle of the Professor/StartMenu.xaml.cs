using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Battle_of_the_Professor
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Page
    {
        BitmapImage GetImage(string location) => new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + location, UriKind.Absolute));

        IGameState state = GameState.Instance;
        Event currentQuestion;
        Character _player;
        Character _professor;
        
        int trig = 1;

        public StartMenu(Character player, Character professor)
        {
            InitializeComponent();

            state.SetStats(Stats); // sets player stats in the TextBox

            _player = player;
            _professor = professor;

            _player.Attach(state);
            _professor.Attach(state);

            Middle.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\Map\middle.PNG", UriKind.Absolute));

            UpdateTiles();

            state.UpdateStats(_player);
            state.UpdateStats(_professor);
        }

        private void UpdateTiles()
        {
            Top.Source = GetImage(state.Map.Top());
            TopLeft.Source = GetImage(state.Map.TopLeft());
            TopRight.Source = GetImage(state.Map.TopRight());
            Left.Source = GetImage(state.Map.Left());
            Right.Source = GetImage(state.Map.Right());
            Bottom.Source = GetImage(state.Map.Bottom());
            BottomLeft.Source = GetImage(state.Map.BottomLeft());
            BottomRight.Source = GetImage(state.Map.BottomRight());
        }

        private void Dialogue_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = text.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void SetEvent(int row, int col)
        {
            currentQuestion = state.Events.FirstOrDefault(ev => ev.ShouldTrigger(row, col));
            if (currentQuestion != null)
            {
                classroom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\classroom.jfif", UriKind.Absolute));
                string answerText = "";
                foreach (var answer in currentQuestion.Answers)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Question}{answerText}";
            }
        }
        private void BossEvent(int trig)
        {
            if(trig == 1) {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb1)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb1}{answerText}";
                currentQuestion.CorrectAnswerb1 = currentQuestion.CorrectAnswerb1;
            }
            if (trig == 2)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb2)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb2}{answerText}";
                currentQuestion.CorrectAnswerb2 = currentQuestion.CorrectAnswerb2;
            }
            if (trig == 3)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb3)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb3}{answerText}";
                currentQuestion.CorrectAnswerb3 = currentQuestion.CorrectAnswerb3;
            }
            if (trig == 4)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb4)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb4}{answerText}";
                currentQuestion.CorrectAnswerb4 = currentQuestion.CorrectAnswerb4;
            }
            if (trig == 5)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb5)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb5}{answerText}";
                currentQuestion.CorrectAnswerb5 = currentQuestion.CorrectAnswerb5;
            }
            if (trig == 6)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb6)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb6}{answerText}";
                currentQuestion.CorrectAnswerb6 = currentQuestion.CorrectAnswerb6;
            }
            if (trig == 7)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb7)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb7}{answerText}";
                currentQuestion.CorrectAnswerb7 = currentQuestion.CorrectAnswerb7;
            }
            if (trig == 8)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb8)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb8}{answerText}";
                currentQuestion.CorrectAnswerb8 = currentQuestion.CorrectAnswerb8;
            }
            if (trig == 9)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb9)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb9}{answerText}";
                currentQuestion.CorrectAnswerb9 = currentQuestion.CorrectAnswerb9;
            }
            if (trig == 10)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answersb10)
                {
                    answerText += $"{answer}\n";
                }
                text.Text = $"{currentQuestion.Questionb10}{answerText}";
                currentQuestion.CorrectAnswerb10 = currentQuestion.CorrectAnswerb10;
            }
        }

        private void TextChecker_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            if (currentQuestion?.StringAnswers == TextAnswers.Text)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.CorrectInt;
                    _player.Intellect += currentQuestion.Gain;
                }
                else if(currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.CorrectSanity;
                    _player.Sanity += currentQuestion.Penalty;
                }
                else if (currentQuestion.TriggerLocation == (7, 18)) { TextAnswers.Text = currentQuestion.Rightboss + "Boss's health: " + _professor.Health; _professor.Health -= (10 + _player.Intellect); }
            }
            else if (currentQuestion?.StringAnswers != TextAnswers.Text)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.WrongInt;
                    _player.Intellect -= currentQuestion.Gain;
                    _player.Health -= 5;
                    
                }
                else if (currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.WrongSanity;
                    _player.Sanity -= currentQuestion.Penalty;
                    _player.Health -= 5;
                    
                }
                else if (currentQuestion.TriggerLocation == (7, 18)) { TextAnswers.Text = currentQuestion.Wrongboss; _player.Health -= (15 - _player.Sanity);
                   
                    
                }
            }
            if (_player.IsDead)
            {
                MessageBox.Show("You Lost! File deleted.");
                state.Delete(_player);
                NavigationService.Navigate(new Start());
            }

            currentQuestion.IsTriggered = true;
            if(currentQuestion.TriggerLocation == (7, 18)){ BossEvent(trig); trig++; return; }
            currentQuestion = null;
            classroom.Source = null;
        }
        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion?.CorrectAnswer == 1)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.CorrectInt;
                    _player.Intellect += currentQuestion.Gain;
                }
                else if (currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.CorrectSanity;
                    _player.Sanity += currentQuestion.Penalty;
                }
                else if (currentQuestion.TriggerLocation == (7, 18)) { TextAnswers.Text = currentQuestion.Rightboss + "Boss's health: " + _professor.Health; _professor.Health -= 10 + _player.Intellect; }
            }
            else if (currentQuestion?.CorrectAnswer != 1)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.WrongInt;
                    _player.Intellect -= currentQuestion.Gain;
                    _player.Health -= 5;
                    
                }
                else if (currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.WrongSanity;
                    _player.Sanity -= currentQuestion.Penalty;
                    _player.Health -= 5;
                   
                }
                else if(currentQuestion.TriggerLocation ==(7, 18)) { TextAnswers.Text = currentQuestion.Wrongboss; _player.Health -= 15 - _player.Sanity;
                    
                }
            }
            if (_player.IsDead)
            {
                MessageBox.Show("You Lost! File deleted.");
                state.Delete(_player);
                NavigationService.Navigate(new Start());
            }
            currentQuestion.IsTriggered = true;
            if (currentQuestion.TriggerLocation == (7, 18)) { BossEvent(trig); trig++; return; }
            currentQuestion = null;
            classroom.Source = null;
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion?.CorrectAnswer == 2)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.CorrectInt;
                    _player.Intellect += currentQuestion.Gain;
                }
                else if (currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.CorrectSanity;
                    _player.Sanity += currentQuestion.Penalty;
                }
                else if (currentQuestion.TriggerLocation == (7, 18)) { TextAnswers.Text = currentQuestion.Rightboss + "Boss's health: " + _professor.Health; _professor.Health -= 10 + _player.Intellect; }
            }
            else if (currentQuestion?.CorrectAnswer != 2)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.WrongInt;
                    _player.Intellect -= currentQuestion.Gain;
                    _player.Health -= 5;
                    
                }
                else if (currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.WrongSanity;
                    _player.Sanity -= currentQuestion.Penalty;
                    _player.Health -= 5;
                    
                }
                else if (currentQuestion.TriggerLocation == (7, 18)) { TextAnswers.Text = currentQuestion.Wrongboss; _player.Health -= 15 - _player.Sanity; }
            }
            if (_player.IsDead)
            {
                MessageBox.Show("You Lost! File deleted.");
                state.Delete(_player);
                NavigationService.Navigate(new Start());
            }
            currentQuestion.IsTriggered = true;
            if (currentQuestion.TriggerLocation == (7, 18)) { BossEvent(trig); trig++; return; }
            currentQuestion = null;
            classroom.Source = null;
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            if (currentQuestion?.CorrectAnswer == 3)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.CorrectInt;
                    _player.Intellect += currentQuestion.Gain;
                }
                else if (currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.CorrectSanity;
                    _player.Sanity += currentQuestion.Penalty;
                }
                else if (currentQuestion.TriggerLocation == (7, 18)) { TextAnswers.Text = currentQuestion.Rightboss + "Boss's health: " + _professor.Health; _professor.Health -= 10 + _player.Intellect; }
            }
            else if (currentQuestion?.CorrectAnswer != 3)
            {
                if (currentQuestion.TriggerLocation == (1, 2) || currentQuestion.TriggerLocation == (7, 2) || currentQuestion.TriggerLocation == (9, 7) || currentQuestion.TriggerLocation == (7, 15) || currentQuestion.TriggerLocation == (10, 12))
                {
                    TextAnswers.Text = currentQuestion.WrongInt;
                    _player.Intellect -= currentQuestion.Gain;
                    _player.Health -= 5;
                }
                else if (currentQuestion.TriggerLocation == (13, 3) || currentQuestion.TriggerLocation == (1, 8) || currentQuestion.TriggerLocation == (7, 8) || currentQuestion.TriggerLocation == (13, 17) || currentQuestion.TriggerLocation == (1, 17))
                {
                    TextAnswers.Text = currentQuestion.WrongSanity;
                    _player.Sanity -= currentQuestion.Penalty;
                    _player.Health -= 5;
                }
                else if (currentQuestion.TriggerLocation == (7, 18)) { TextAnswers.Text = currentQuestion.Wrongboss; _player.Health -= 15 - _player.Sanity; }
            }
            if (_player.IsDead)
            {
                MessageBox.Show("You Lost! File deleted.");
                state.Delete(_player);
                NavigationService.Navigate(new Start());
            }
            currentQuestion.IsTriggered = true;
            if (currentQuestion.TriggerLocation == (7, 18)) { BossEvent(trig); trig++; return; }
            currentQuestion = null;
            classroom.Source = null;
        }

        // these are the button presses, which perform checks and change the pictures accordingly
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (state.Map.RightCheck(state.Map.Row, state.Map.Col) == true)
            {
                state.Map.Col = state.Map.Col + 1;

                UpdateTiles();

                text.Text = "You have moved right!";
            }
            else
            {
                text.Text = "You can't move that way!";
            }
            classroom.Source = null;
            TextAnswers.Text = null;
            SetEvent(state.Map.Row, state.Map.Col);
            state.Save(_player);
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (state.Map.UpCheck(state.Map.Row, state.Map.Col) == true)
            {
                state.Map.Row = state.Map.Row - 1;
                UpdateTiles();
                text.Text = "You have moved up!";
            }
            else
            {
                text.Text = "You can't move that way!";
            }
            classroom.Source = null;
            TextAnswers.Text = null;
            SetEvent(state.Map.Row, state.Map.Col);
            state.Save(_player);
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (state.Map.LeftCheck(state.Map.Row, state.Map.Col) == true)
            {
                state.Map.Col = state.Map.Col - 1;

                UpdateTiles();

                text.Text = "You have moved left!";
            }
            else
            {
                text.Text = "You can't move that way!";
            }
            classroom.Source = null;
            TextAnswers.Text = null;
            SetEvent(state.Map.Row, state.Map.Col);
            state.Save(_player);
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (state.Map.DownCheck(state.Map.Row, state.Map.Col) == true)
            {
                state.Map.Row = state.Map.Row + 1;

                UpdateTiles();

                text.Text = "You have moved down!";
            }
            else
            {
                text.Text = "You can't move that way!";
            }
            classroom.Source = null;
            TextAnswers.Text = null;
            SetEvent(state.Map.Row, state.Map.Col);
            state.Save(_player);
        }

        private void TextAnswers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }
    }
}
