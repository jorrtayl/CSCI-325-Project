using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Battle_of_the_Professor
{
    /// <summary>
    /// Interaction logic for LoadGamePage.xaml
    /// </summary>
    public partial class LoadGamePage : Page
    {
        IGameState state = GameState.Instance;

        public LoadGamePage()
        {
            InitializeComponent();
        }

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

        private void btnBackToSelection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }
    }
}
