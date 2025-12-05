using System.Windows;

namespace WPF_LoginForm.View
{
    public partial class GruposView : Window
    {
        public GruposView()
        {
            InitializeComponent();
        }

        private void BtnVolverAlumnado_Click(object sender, RoutedEventArgs e)
        {
            var alumnadoView = new AlumnadoView();
            alumnadoView.Show();
            this.Close();
        }
    }
}
