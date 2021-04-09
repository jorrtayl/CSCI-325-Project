/*
 * Author: Mason and Jordan
 * Date: 03 / 28 / 2021
 * Description: 
 */
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
using Microsoft.Win32;
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
                if (map[Row + 1, Col] == 0) { return true; }
                else return false;
            }
            public bool DownCheck(int Row, int Col)
            {
                if (map[Row - 1, Col] == 0) { return true; }
                else return false;
            }

        }


        /*private void AppendTextBoxLine(string myStr)
        {
            if (testbox.Text.Length > 0)
            {
                testbox.AppendText(Environment.NewLine);
            }
            testbox.AppendText(myStr);
        }*/

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

        private void Map_Click(object sender, RoutedEventArgs e) // this is a test to load from a file, not working yet
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
            }*/
            //}
        }

        // these are the button presses, which perform checks and change the pictures accordingly
        private void Right_Click(object sender, RoutedEventArgs e)
        {

            if (save.RightCheck(save.Row, save.Col) == true)
            {
                save.Col = save.Col + 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            }
            else if (save.RightCheck(save.Row, save.Col) == false) { text.Text = "can't move that way"; }

        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (save.UpCheck(save.Row, save.Col) == true)
            {
                save.Row = save.Row + 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            }
            else if (save.UpCheck(save.Row, save.Col) == false) { text.Text = "can't move that way"; }
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (save.LeftCheck(save.Row, save.Col) == true)
            {
                save.Col = save.Col - 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            }
            else if (save.LeftCheck(save.Row, save.Col) == false) { text.Text = "can't move that way"; }

        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (save.DownCheck(save.Row, save.Col) == true)
            {
                save.Row = save.Row - 1;
                if (save.map[save.Row + 1, save.Col] == 0) { Top.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Top.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
                if (save.map[save.Row - 1, save.Col] == 0) { Bottom.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else Bottom.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute)); 
                if (save.map[save.Row, save.Col + 1] == 0) { rightside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else rightside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute)); 
                if (save.map[save.Row, save.Col - 1] == 0) { leftside.Source = new BitmapImage(new Uri(@"\Map\Open.PNG", UriKind.Relative)); } else leftside.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Map\\Closed.PNG", UriKind.Absolute));
            }
            else if (save.DownCheck(save.Row, save.Col) == false) { text.Text = "can't move that way"; }
        }
    }
}