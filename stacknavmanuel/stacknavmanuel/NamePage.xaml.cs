using System;
using System.Windows;
using System.Windows.Controls;

namespace stacknavmanuel
{
    public partial class NamePage : Page
    {
        public event EventHandler<NameEventArgs> NextRequested;

        public NamePage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
                NavigationService.GoBack();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NextRequested?.Invoke(this, new NameEventArgs { Name = NameTextBox.Text });
        }
    }

    public class NameEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}