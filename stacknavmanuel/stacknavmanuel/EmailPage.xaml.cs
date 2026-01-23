using System;
using System.Windows;
using System.Windows.Controls;

namespace stacknavmanuel
{
    public partial class EmailPage : Page
    {
        public event EventHandler<EmailEventArgs> SaveRequested;
        public event EventHandler PreviousRequested;

        public User User { get; set; }

        public EmailPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PreviousRequested?.Invoke(this, EventArgs.Empty);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (User == null) User = new User();
            User.Email = EmailTextBox.Text;
            SaveRequested?.Invoke(this, new EmailEventArgs { User = User });
        }
    }

    public class EmailEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}