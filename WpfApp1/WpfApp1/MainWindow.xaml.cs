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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
        /// 
    private void BtnCambiarTexto_Click(object sender, RoutedEventArgs e)
    {
        string textoUsuario = txtEntrada.Text;
        if(!string.IsNullOrWhiteSpace(textoUsuario))
        {
            txtHola.Text = textoUsuario;
        }
        else
        {
            txtHola.Text.Content = "Hola mundo";
        }

    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnCambiarTexto_Click(object sender, RoutedEventArgs e)
        {
            string textoUsuario = txtEntrada.Text;
        }
    }
}