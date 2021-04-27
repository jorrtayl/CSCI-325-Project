using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Battle_of_the_Professor
{
    /// <summary>
    /// Interaction logic for NewGamePage.xaml
    /// </summary>
    public partial class NewGamePage : Page
    {
        IGameState state = GameState.Instance;

        public NewGamePage()
        {
            InitializeComponent();
        }

        private void btnBackToSelection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            Character player = state.Load(new Deprived(txtNewSaveEntry.Text));

            if (player != null)
            {
                MessageBox.Show("File Already Exists!");
                return;
            }
            player = new Deprived(txtNewSaveEntry.Text);
            state.Save(player);

            NavigationService.Navigate(new StartMenu(player));
        }
    }
}
