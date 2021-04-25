using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public StartMenu(Character player)
        {
            InitializeComponent();

            state.SetStats(Stats); // sets player stats in the TextBox

            _player = player;

            _player.Attach(state);

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

        private void dialogue_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = text.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void SetEvent(int row, int col)
        {
            currentQuestion = state.Events.FirstOrDefault(ev => ev.ShouldTrigger(row, col));

            if (currentQuestion != null)
            {
                string answerText = "";
                foreach (var answer in currentQuestion.Answers)
                {
                    answerText += $"{answer}\n";
                }

                text.Text = $"{currentQuestion.Question}{answerText}";
            }
        }

        private void TextChecker_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            if (currentQuestion?.StringAnswers != TextAnswers.Text)
            {
                text.Text = currentQuestion.WrongAnswerReply;
                _player.Health = _player.Health - currentQuestion.Penalty;
            }
            else
            {
                text.Text = currentQuestion.CorrectAnswerReply;
                _player.Intellect = _player.Intellect + currentQuestion.Gain;
            }
            currentQuestion.IsTriggered = true;
            currentQuestion = null;
        }
        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            if (currentQuestion?.CorrectAnswer != 1)
            {
                text.Text = currentQuestion.WrongAnswerReply;
                _player.Health = _player.Health - currentQuestion.Penalty;
            }
            else
            {
                text.Text = currentQuestion.CorrectAnswerReply;
                _player.Intellect = _player.Intellect + currentQuestion.Gain;
            }

            currentQuestion.IsTriggered = true;
            currentQuestion = null;
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            if (currentQuestion?.CorrectAnswer != 2)
            {
                text.Text = currentQuestion.WrongAnswerReply;
                _player.Health = _player.Health - currentQuestion.Penalty;
            }
            else
            {
                text.Text = currentQuestion.CorrectAnswerReply;
                _player.Intellect = _player.Intellect + currentQuestion.Gain;
            }

            currentQuestion.IsTriggered = true;
            currentQuestion = null;
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            if (currentQuestion?.CorrectAnswer != 3)
            {
                text.Text = currentQuestion.WrongAnswerReply;
                _player.Health = _player.Health - currentQuestion.Penalty;
            }
            else
            {
                text.Text = currentQuestion.CorrectAnswerReply;
                _player.Intellect = _player.Intellect + currentQuestion.Gain;
            }

            currentQuestion.IsTriggered = true;
            currentQuestion = null;
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

            SetEvent(state.Map.Row, state.Map.Col);
            state.Save(_player);
        }

        private void TextAnswers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }
    }
}
