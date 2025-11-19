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

namespace DatePickerEjemplo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        public void BtnMostrarFecha_Click(object sender, RoutedEventArgs e)
        {
            if (pckFecha.SelectedDate.HasValue)
            {
                MessageBox.Show("La fecha seleccionada es: " + pckFecha.SelectedDate.Value.ToShortDateString());
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fecha.");
            }
        }
    }
}