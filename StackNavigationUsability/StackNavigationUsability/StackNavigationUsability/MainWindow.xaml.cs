using System.Windows;
using StackNavigationUsability.view;

namespace StackNavigationUsability
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Start the application in a known and predictable place (MainPage).
            // This avoids undefined or confusing initial states.
            MainFrame.Navigate(new MainPage());

            // Update the Back button state at startup.
            // At this point, there is no navigation history, so Back should be disabled.
            UpdateBackButton();

            // Subscribe to the Navigated event of the Frame.
            // This event is fired every time the Frame navigates to a new Page
            // (forward navigation or back navigation).
            MainFrame.Navigated += MainFrame_Navigated;
        }

        /// <summary>
        /// This method is called automatically every time navigation occurs
        /// inside the Frame (Navigate, GoBack, etc.).
        /// Its only responsibility is to keep the Back button state in sync
        /// with the navigation history.
        /// </summary>
        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            UpdateBackButton();
        }

        /// <summary>
        /// Handles the click on the Back button in the top bar.
        /// The user can only go back if there is navigation history.
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // only go back if it is actually possible: this prevents errors and useless actions.
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }

            // Update the Back button after the action,so the UI always reflects the current navigation state.
            UpdateBackButton();
        }

        /// <summary>
        /// Enables or disables the Back button depending on
        /// whether the Frame can navigate back.
        /// </summary>
        private void UpdateBackButton()
        {
            // If there is navigation history, Back is enabled.
            // If not, Back is disabled to prevent dead actions.
            BackButton.IsEnabled = MainFrame.CanGoBack;
        }
    }
}
