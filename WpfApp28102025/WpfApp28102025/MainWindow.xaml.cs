using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp28102025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public MainWindow()
        {
            InitializeComponent();
            users.Add(new User { Name = "Alice"});
            users.Add(new User { Name = "Bob"});
            UserListBox.ItemsSource = users;
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            users.Add(new User { Name = "Charlie"});
        }
        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            if (UserListBox.SelectedItem != null)
            {
                (UserListBox.SelectedItem as User).Name = "Random Name";
            }
        }
        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            if (UserListBox.SelectedItem != null)
            {
                users.Remove(UserListBox.SelectedItem as User);
                UserListBox.Items.Refresh();
            }
        }
        public class User : INotifyPropertyChanged
        {
            private string name;
            public string Name
            {
                get { return this.name; }
                set
                {
                    if (this.name != value)
                    {
                        this.name = value;
                        NotifyPropertyChanged(Name);
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }/**
        public void AddUser()
        {
            InitializeComponent();
        }
        public void ChangeUser()
        {
            InitializeComponent();
        }
        public void RemoveUser()
        {
            InitializeComponent();
        }**/
        
    }
}