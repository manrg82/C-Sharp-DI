
using System.Windows;
using System.Windows.Controls;

namespace StackNavigationUsability.view
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToDetails_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DetailPage());
        }
    }
}
