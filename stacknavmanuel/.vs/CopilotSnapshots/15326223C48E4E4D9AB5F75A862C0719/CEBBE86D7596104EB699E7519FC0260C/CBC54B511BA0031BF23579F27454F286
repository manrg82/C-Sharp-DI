using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stacknavmanuel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // sample data
            Users.Add(new User { Name = "Juan", Email = "juan@example.com", Password = "***" });
            Users.Add(new User { Name = "Ana", Email = "ana@example.com", Password = "***" });

            // navigate to initial blank page in frame
            MainFrame.Content = new StartPage();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            // start navigation stack with name page
            var namePage = new NamePage();
            namePage.NextRequested += (s, args) =>
            {
                var pwdPage = new PasswordPage { User = new User { Name = args.Name } };
                pwdPage.PreviousRequested += (o, ev) => MainFrame.Navigate(namePage);
                pwdPage.NextRequested += (o, ev2) =>
                {
                    var emailPage = new EmailPage { User = ev2.User };
                    emailPage.PreviousRequested += (oo, ee) => MainFrame.Navigate(pwdPage);
                    emailPage.SaveRequested += (oo, ee) =>
                    {
                        Users.Add(ee.User);
                        MainFrame.Navigate(new StartPage());
                    };
                    MainFrame.Navigate(emailPage);
                };
                MainFrame.Navigate(pwdPage);
            };

            MainFrame.Navigate(namePage);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = UsersDataGrid.SelectedItem as User;
            if (selected == null)
            {
                MessageBox.Show("Seleccione un usuario para borrar.", "Borrar", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var res = MessageBox.Show($"¿Eliminar usuario '{selected.Name}'?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                Users.Remove(selected);
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}