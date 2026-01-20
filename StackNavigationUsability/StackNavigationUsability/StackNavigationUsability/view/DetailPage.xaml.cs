
using System.Windows;
using System.Windows.Controls;

namespace StackNavigationUsability.view
{
    public partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
