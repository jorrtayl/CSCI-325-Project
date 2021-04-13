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
        public MainWindow()
        {
            InitializeComponent();
            leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Open.PNG", UriKind.Absolute));
            Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Open.PNG", UriKind.Absolute));
            Middle.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\middle.PNG", UriKind.Absolute));
            left1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            left2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            right1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            right2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            // Stats.Text = "Health "; Stats.AppendText(player.health.ToString()); Stats.AppendText(Environment.NewLine);
            // Stats.AppendText("Sanity "); Stats.AppendText(player.sanity.ToString()); Stats.AppendText(Environment.NewLine);
            // Stats.AppendText("Intellect "); Stats.AppendText(player.intellect.ToString());

        }
        int event1, event2, event3, event4, event5 = 0;
        bool choice;

        private void dialogue_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = text.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        public class Maptest
        {
            public int Row; //{ get; set; }
            public int Col; //{ get; set; }
            public Maptest(int Row, int Col) //this will be changed later, but for testing this is what i am using
            {
                this.Row = Row;
                this.Col = Col;
            }
            public int[,] map = new int[6, 8] { //initializes map, not official map just a test map for easy movement
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1 }
            };

            //these will check if the spaces are moveable and return true if they are
            public bool RightCheck(int Row, int Col)
            {
                if (map[Row, Col + 1] == 0) { return true; }
                else return false;
            }
            public bool LeftCheck(int Row, int Col)
            {
                if (map[Row, Col - 1] == 0) { return true; }
                else return false;
            }
            public bool UpCheck(int Row, int Col)
            {
                if (map[Row - 1, Col] == 0) { return true; }
                else return false;
            }
            public bool DownCheck(int Row, int Col)
            {
                if (map[Row + 1, Col] == 0) { return true; }
                else return false;
            }

        }
        public class Character
        {
            public int sanity, intellect, health;
            public Character(int sanity, int intellect, int health)
            {
                this.sanity = sanity;
                this.intellect = intellect;
                this.health = health;
            }
        }
        public void Events(int a, int b)
        {
            text.Text = "Row "; text.AppendText(save.Row.ToString()); text.AppendText(Environment.NewLine); text.AppendText("Col "); text.AppendText(save.Col.ToString());
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
        Maptest save = new Maptest(2, 1);
        Character player = new Character(5, 5, 10);

        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            if (event1 == 0)
            {
                text.Text = "Wrong Answer!"; text.AppendText(Environment.NewLine); text.AppendText("You have lost some health!  health - 1");
                player.health = player.health - 1;
                // Stats.Text = "Health "; Stats.AppendText(player.health.ToString()); Stats.AppendText(Environment.NewLine);
                // Stats.AppendText("Sanity "); Stats.AppendText(player.sanity.ToString()); Stats.AppendText(Environment.NewLine);
                // Stats.AppendText("Intellect "); Stats.AppendText(player.intellect.ToString());
            }
            event1 = 1;
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            if (event1 == 0)
            {
                text.Text = "Right Answer!"; text.AppendText(Environment.NewLine); text.AppendText("You have gained some intellect!  intellect + 1");
                player.intellect = player.intellect + 1;
                // Stats.Text = "Health "; Stats.AppendText(player.health.ToString()); Stats.AppendText(Environment.NewLine);
                // Stats.AppendText("Sanity "); Stats.AppendText(player.sanity.ToString()); Stats.AppendText(Environment.NewLine);
                // Stats.AppendText("Intellect "); Stats.AppendText(player.intellect.ToString());
            }
            event1 = 1;
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            if (event1 == 0)
            {
                text.Text = "Wrong Answer!"; text.AppendText(Environment.NewLine); text.AppendText("You have lost some health!  health - 1");
                player.health = player.health - 1;
                // Stats.Text = "Health "; Stats.AppendText(player.health.ToString()); Stats.AppendText(Environment.NewLine);
                // Stats.AppendText("Sanity "); Stats.AppendText(player.sanity.ToString()); Stats.AppendText(Environment.NewLine);
                // Stats.AppendText("Intellect "); Stats.AppendText(player.intellect.ToString());
            }
            event1 = 1;
        }

        /*private void Map_Click(object sender, RoutedEventArgs e) // this is a test to load from a file, not working yet
{
// using (StreamReader reader = new StreamReader("test.txt"))
//{
/*for (int i = 0; i < a; i++)
{
AppendTextBoxLine("Some text");
}*/
        //testbox.Text = b.ToString();
        //int[,] map = new int[save.row, save.col];
        /*for(int i = 0; i < a; i++){
            for(int j = 0; j < b; j++)
            {
                map[i, j] = reader.ReadInt32();
                testbox.Text = map[i, j].ToString();
                testbox.Text = " ";
            }
        }
        }
    }*/

        // these are the button presses, which perform checks and change the pictures accordingly
        private void Right_Click(object sender, RoutedEventArgs e)
        {

            if (save.RightCheck(save.Row, save.Col) == true)
            {
                save.Col = save.Col + 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            }
            else if (save.RightCheck(save.Row, save.Col) == false) { text.AppendText("can't move that way"); }
            Events(save.Row, save.Col);

        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (save.UpCheck(save.Row, save.Col) == true)
            {
                save.Row = save.Row - 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            }
            else if (save.UpCheck(save.Row, save.Col) == false) { text.AppendText("can't move that way"); }
            Events(save.Row, save.Col);
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {

            if (save.LeftCheck(save.Row, save.Col) == true)
            {
                save.Col = save.Col - 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));

            }
            else if (save.LeftCheck(save.Row, save.Col) == false) { text.AppendText("can't move that way"); }
            Events(save.Row, save.Col);

        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (save.DownCheck(save.Row, save.Col) == true)
            {
                save.Row = save.Row + 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            }
            else if (save.DownCheck(save.Row, save.Col) == false) { text.AppendText("can't move that way"); }
            Events(save.Row, save.Col);
        }
    }
}