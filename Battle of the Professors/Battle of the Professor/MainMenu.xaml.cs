using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Battle_of_the_Professor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Map map = new Map(2, 1);
        IGameState state = new GameState();
        Character player;

        int event1, event2, event3, event4, event5 = 0;
        bool choice;

        public MainWindow()
        {
            InitializeComponent();

            state.SetStats(Stats);

            player = state.Load();
            player.Attach(state);

            leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Open.PNG", UriKind.Absolute));
            Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Open.PNG", UriKind.Absolute));
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
        
        public void Events(int a, int b)
        {
            text.Text = "Row "; text.AppendText(map.Row.ToString()); text.AppendText(Environment.NewLine); text.AppendText("Col "); text.AppendText(map.Col.ToString());
            if (a == 2 && b == 6 && event1 == 0)
            {
                text.Text = "Pop Quiz Time!"; text.AppendText(Environment.NewLine); text.AppendText("what is the purpose of 'for' in programming?"); text.AppendText(Environment.NewLine);
                text.AppendText("Choose an answer."); text.AppendText(Environment.NewLine); text.AppendText("1. A loop of the number 4"); text.AppendText(Environment.NewLine); text.AppendText("2. A loop that does an action a cerain amount of times"); text.AppendText(Environment.NewLine); text.AppendText("3. I think I am in the wrong class");
            }
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

        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            if (event1 == 0)
            {
                text.Text = "Wrong Answer!"; text.AppendText(Environment.NewLine); text.AppendText("You have lost some health!  health - 1");
                player.Health = player.Health - 1;
            }
            event1 = 1;
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            if (event1 == 0)
            {
                text.Text = "Right Answer!"; text.AppendText(Environment.NewLine); text.AppendText("You have gained some intellect!  intellect + 1");
                player.Intellect = player.Intellect + 1;
            }
            event1 = 1;
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            if (event1 == 0)
            {
                text.Text = "Wrong Answer!"; text.AppendText(Environment.NewLine); text.AppendText("You have lost some health!  health - 1");
                player.Health = player.Health - 1;
            }
            event1 = 1;
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
            }
            else if (map.RightCheck(map.Row, map.Col) == false) { text.AppendText("can't move that way"); }
            Events(map.Row, map.Col);

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
            }
            else if (map.UpCheck(map.Row, map.Col) == false) { text.AppendText("can't move that way"); }
            Events(map.Row, map.Col);
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

            }
            else if (map.LeftCheck(map.Row, map.Col) == false) { text.AppendText("can't move that way"); }
            Events(map.Row, map.Col);

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
            }
            else if (map.DownCheck(map.Row, map.Col) == false) { text.AppendText("can't move that way"); }
            Events(map.Row, map.Col);
        }
    }
}