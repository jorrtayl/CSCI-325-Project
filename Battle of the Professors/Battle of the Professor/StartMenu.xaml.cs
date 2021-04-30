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
        Character _professor = new Professor();

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

        private void ApplyAffects(bool isCorrect, bool isBoss)
        {
            if (isBoss && isCorrect)
            {
                _professor.Health -= _player.Sanity + _player.Intellect;
            }

            if (isBoss && !isCorrect)
            {
                _player.Health -= _professor.Intellect - _player.Sanity;
                return;
            }

            Affect[] affects = isCorrect ? currentQuestion.Gain : currentQuestion.Penalty;

            if (affects == null) return;

            foreach (var affect in affects)
            {
                if (affect.AffectType == Stat.Health)
                    _player.Health += affect.Amount;

                if (affect.AffectType == Stat.Intellect)
                    _player.Intellect += affect.Amount;

                if (affect.AffectType == Stat.Sanity)
                    _player.Sanity += affect.Amount;
            }
        }

        private void Dialogue_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = text.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void SetEvent()
        {
            if (_player.IsDead)
            {
                MessageBox.Show("You Lost! You failed the class. Your progress has been deleted but feel free to try again.");
                state.Delete(_player);
                NavigationService.Navigate(new Start());
            }

            if (_professor.IsDead)
            {
                MessageBox.Show("You Won! You completed the class. You progress has been deleted but feel free to try again.");
                state.Delete(_player);
                NavigationService.Navigate(new Start());
            }

            TextAnswer.Text = null;

            currentQuestion = state.Questions.FirstOrDefault(ev => ev.ShouldTrigger(state.Map.Row, state.Map.Col));
            if (currentQuestion != null)
            {
                classroom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\Map\classroom.jfif", UriKind.Absolute));
                text.Text = $"{currentQuestion.Question}{string.Join("\n", currentQuestion.Answers)}";

                if (currentQuestion.Answers.Length == 1)
                {
                    Answer1.IsEnabled = false;
                    Answer2.IsEnabled = false;
                    Answer3.IsEnabled = false;

                    CheckAnswer.IsEnabled = true;
                    TextAnswer.IsEnabled = true;

                    return;
                }
                else
                {
                    Answer1.IsEnabled = true;
                    Answer2.IsEnabled = true;
                    Answer3.IsEnabled = true;

                    CheckAnswer.IsEnabled = false;
                    TextAnswer.IsEnabled = false;

                    return;
                }
            }

            classroom.Source = null;
            Answer1.IsEnabled = false;
            Answer2.IsEnabled = false;
            Answer3.IsEnabled = false;

            CheckAnswer.IsEnabled = false;
            TextAnswer.IsEnabled = false;
        }
        private void CheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            var correct = currentQuestion.IsCorrect(TextAnswer.Text);
            ApplyAffects(correct, currentQuestion.IsBossQuestion);

            Dialogue.Text = correct ? currentQuestion.CorrectReply : currentQuestion.WrongReply;

            if (currentQuestion.IsBossQuestion)
                Dialogue.Text += $"\nBoss Health: {_professor.Health}";

            currentQuestion.IsTriggered = true;
            SetEvent();
            state.Save(_player, _professor);
        }
        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            var correct = currentQuestion.IsCorrect("1");
            ApplyAffects(correct, currentQuestion.IsBossQuestion);

            Dialogue.Text = correct ? currentQuestion.CorrectReply : currentQuestion.WrongReply;

            if (currentQuestion.IsBossQuestion)
                Dialogue.Text += $"\nBoss Health: {_professor.Health}";

            currentQuestion.IsTriggered = true;
            SetEvent();
            state.Save(_player, _professor);
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            var correct = currentQuestion.IsCorrect("2");
            ApplyAffects(correct, currentQuestion.IsBossQuestion);

            Dialogue.Text = correct ? currentQuestion.CorrectReply : currentQuestion.WrongReply;

            if (currentQuestion.IsBossQuestion)
                Dialogue.Text += $"\nBoss Health: {_professor.Health}";

            currentQuestion.IsTriggered = true;
            SetEvent();
            state.Save(_player, _professor);
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            var correct = currentQuestion.IsCorrect("3");
            ApplyAffects(correct, currentQuestion.IsBossQuestion);

            Dialogue.Text = correct ? currentQuestion.CorrectReply : currentQuestion.WrongReply;

            if (currentQuestion.IsBossQuestion)
                Dialogue.Text += $"\nBoss Health: {_professor.Health}";

            currentQuestion.IsTriggered = true;
            SetEvent();
            state.Save(_player, _professor);
        }

        // these are the button presses, which perform checks and change the pictures accordingly
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (!state.Map.RightCheck)
            {
                Dialogue.Text = "You can't move that way!";
                return;
            }

            state.Map.Col = state.Map.Col + 1;

            UpdateTiles();

            Dialogue.Text = "You have moved right!";

            TextAnswer.Text = null;
            SetEvent();
            state.Save(_player, _professor);
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (!state.Map.UpCheck)
            {
                Dialogue.Text = "You can't move that way!";
                return;
            }

            state.Map.Row = state.Map.Row - 1;
            UpdateTiles();
            Dialogue.Text = "You have moved up!";

            TextAnswer.Text = null;
            SetEvent();
            state.Save(_player, _professor);
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (!state.Map.LeftCheck)
            {
                Dialogue.Text = "You can't move that way!";
                return;
            }

            state.Map.Col = state.Map.Col - 1;

            UpdateTiles();

            Dialogue.Text = "You have moved left!";

            TextAnswer.Text = null;
            SetEvent();
            state.Save(_player, _professor);
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (!state.Map.DownCheck)
            {
                Dialogue.Text = "You can't move that way!";
                return;
            }

            state.Map.Row = state.Map.Row + 1;

            UpdateTiles();

            Dialogue.Text = "You have moved down!";

            TextAnswer.Text = null;
            SetEvent();
            state.Save(_player, _professor);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }
    }
}
