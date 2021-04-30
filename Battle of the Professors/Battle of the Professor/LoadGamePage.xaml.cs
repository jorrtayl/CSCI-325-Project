using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Battle_of_the_Professor
{
    /// <summary>
    /// Interaction logic for LoadGamePage.xaml
    /// </summary>
    // display for the load function.
    public partial class LoadGamePage : Page
    {
        IGameState state = GameState.Instance;

        public LoadGamePage()
        {
            InitializeComponent();
        }

        // checks if the user press down on the Return key and executes the Load functions for the player and professor, then displays the StartMenu page.
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            Character player = state.Load(new Deprived(txtLoadEntry.Text));

            if (player == null)
            {
                MessageBox.Show("Invald Entry");
                return;
            }

            var professor = state.LoadBoss(player);

            NavigationService.Navigate(new StartMenu(player, professor));
        }

        // displays the Start page.
        private void btnBackToSelection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }
    }
}
