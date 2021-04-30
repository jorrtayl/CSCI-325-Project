using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Battle_of_the_Professor
{
    /// <summary>
    /// Interaction logic for NewGamePage.xaml
    /// </summary>
    // display for the creating a new save.
    public partial class NewGamePage : Page
    {
        IGameState state = GameState.Instance;

        public NewGamePage()
        {
            InitializeComponent();
        }

        // displays the Start page.
        private void btnBackToSelection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }

        // checks if the Return key was pressed and loads up a player based on the text entry from txtNewSaveEntry then displays the StartMenu page.
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
            var professor = new Professor();
            state.Save(player, professor);

            NavigationService.Navigate(new StartMenu(player, professor));
        }
    }
}
