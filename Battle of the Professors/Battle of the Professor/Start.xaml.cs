using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Battle_of_the_Professor
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewGamePage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoadGamePage());

        }
    }
}
