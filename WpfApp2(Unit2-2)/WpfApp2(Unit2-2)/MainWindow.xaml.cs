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

namespace WpfApp2_Unit2_2_
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

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre=txtNombre.Text;
            string edad=txtEdad.Text;
            string sexo;
            if (rbMasculino.IsChecked == true)
            {
                sexo = "Masculino";
            }
            else if (rbFemenino.IsChecked == true)
            {
                sexo = "Femenino";
            }
            else
            {
                sexo = "No Especificado";
            }
            string curso=(cbCurso.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "No seleccionado";
            string horario = (cbHorario.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "No seleccionado";
            string ti = chkTI.IsChecked==true ? "Si" : "No";
            string otroDoc = chkOtroDoc.IsChecked == true ? txtOtroDoc.Text : "Ninguno";
            string mensaje = $"Nombre: {nombre}\nSexo: {sexo}\nCurso: {curso}\nHorario: {horario}\nT.I.: {ti}\nOtro Documento: {otroDoc}";
            MessageBox.Show(mensaje, "Datos del alumno", MessageBoxButton.OK,MessageBoxImage.Information);
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void txtOtroDoc_TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}