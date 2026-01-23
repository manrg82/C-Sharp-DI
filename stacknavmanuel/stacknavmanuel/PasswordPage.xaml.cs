using System;
using System.Windows;
using System.Windows.Controls;

namespace stacknavmanuel
{
    public partial class PasswordPage : Page
    {
        public event EventHandler<PasswordEventArgs> NextRequested;
        public event EventHandler PreviousRequested;

        public User User { get; set; }

        public PasswordPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PreviousRequested?.Invoke(this, EventArgs.Empty);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (User == null) User = new User();
            User.Password = PasswordBox.Password;
            NextRequested?.Invoke(this, new PasswordEventArgs { User = User });
        }
    }

    public class PasswordEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}