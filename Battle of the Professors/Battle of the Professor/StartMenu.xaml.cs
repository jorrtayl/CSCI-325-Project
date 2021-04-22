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
        Map map = new Map(7, 1);
        IGameState state = new GameState();
        Event currentQuestion;
        Character player;

        public StartMenu()
        {
            InitializeComponent();

            state.SetStats(Stats);

            player = state.Load();
            player.Attach(state);

            leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Open.PNG", UriKind.Absolute));
            Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            Middle.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\middle.PNG", UriKind.Absolute));
            left1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            left2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            right1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            right2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));

            state.UpdateStats(player);
        }
        private void dialogue_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = text.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e) // This was a test to try and load images, not currently used
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
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

        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            if (currentQuestion?.CorrectAnswer != 1)
            {
                text.Text = currentQuestion.WrongAnswerReply;
                player.Health = player.Health - currentQuestion.Penalty;
            }
            else
            {
                text.Text = currentQuestion.CorrectAnswerReply;
                player.Intellect = player.Intellect + currentQuestion.Perk;
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
                player.Health = player.Health - currentQuestion.Penalty;
            }
            else
            {
                text.Text = currentQuestion.CorrectAnswerReply;
                player.Intellect = player.Intellect + currentQuestion.Perk;
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
                player.Health = player.Health - currentQuestion.Penalty;
            }
            else
            {
                text.Text = currentQuestion.CorrectAnswerReply;
                player.Intellect = player.Intellect + currentQuestion.Perk;
            }

            currentQuestion.IsTriggered = true;
            currentQuestion = null;
        }

        // these are the button presses, which perform checks and change the pictures accordingly
        private void Right_Click(object sender, RoutedEventArgs e)
        {

            if (map.RightCheck(map.Row, map.Col) == true)
            {
                map.Col = map.Col + 1;
                if (map.map[map.Row + 1, map.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row - 1, map.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));

                text.Text = "You have moved right!";
            }
            else if (map.RightCheck(map.Row, map.Col) == false)
            {
                text.Text = "You can't move that way!";
            }

            SetEvent(map.Row, map.Col);
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (map.UpCheck(map.Row, map.Col) == true)
            {
                map.Row = map.Row - 1;
                if (map.map[map.Row + 1, map.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row - 1, map.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));

                text.Text = "You have moved up!";
            }
            else if (map.UpCheck(map.Row, map.Col) == false)
            {
                text.Text = "You can't move that way!";
            }

            SetEvent(map.Row, map.Col);
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {

            if (map.LeftCheck(map.Row, map.Col) == true)
            {
                map.Col = map.Col - 1;
                if (map.map[map.Row + 1, map.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row - 1, map.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));

                text.Text = "You have moved left!";
            }
            else if (map.LeftCheck(map.Row, map.Col) == false)
            {
                text.Text = "You can't move that way!";
            }

            SetEvent(map.Row, map.Col);

        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (map.DownCheck(map.Row, map.Col) == true)
            {
                map.Row = map.Row + 1;
                if (map.map[map.Row + 1, map.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row - 1, map.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (map.map[map.Row, map.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));

                text.Text = "You have moved down!";
            }
            else if (map.DownCheck(map.Row, map.Col) == false) 
            {
                text.Text = "You can't move that way!";
            }

            SetEvent(map.Row, map.Col);
        }
    }
}
