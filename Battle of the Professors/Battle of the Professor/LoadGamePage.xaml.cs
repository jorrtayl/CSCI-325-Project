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

            NavigationService.Navigate(new StartMenu(player));
        }

        private void btnBackToSelection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }
    }
}
