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

namespace DataGridConLinq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persona> listaPersonas;
        public MainWindow()
        {
            InitializeComponent();
            listaPersonas=new List<Persona>
            {
                new Persona("Gabriel","Hernandez",3456),
                new Persona("Ana","Lopez",23),
                new Persona("Luis","Martinez",15),
                new Persona("Marta","Gomez",34),
                new Persona("Sofia","Diaz",87),
                new Persona("Carlos","Sanchez",17),
                new Persona("Lucia","Ramirez",2)
            };
            dataGridPersonas.ItemsSource = listaPersonas;
        }


        private void Filtrar_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txtEdadMinima.Text, out int edadMin))
            {
                var filtradas = from p in listaPersonas
                                where p.Edad >= edadMin
                                select p;//listaPersonas.Where(persona => persona.Edad >= edadMin); con lambdas
                dataGridPersonas.ItemsSource = filtradas.ToList();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una edad válida.");
            }
        }

        private void Mostrar_Todos_Click(object sender, RoutedEventArgs e)
        {
            dataGridPersonas.ItemsSource = listaPersonas;

        }
    }
}