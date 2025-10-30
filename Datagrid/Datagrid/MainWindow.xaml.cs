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
/*
  Interaction logic for MainWindow.xaml
namespace Datagrid
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
    }
}*/
namespace Datagrid
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Usuario> usuarios;

        public MainWindow()
        {
            InitializeComponent();
            usuarios = new ObservableCollection<Usuario>();
            dataGridUsuarios.ItemsSource = usuarios;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text?.Trim() ?? string.Empty;
            string apellido = txtApellido.Text?.Trim() ?? string.Empty;
            string edadTxt = txtEdad.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido) && string.IsNullOrEmpty(edadTxt))
            {
                MessageBox.Show("Rellena al menos un campo para agregar.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!int.TryParse(edadTxt, out int edad))
                edad = 0;

            usuarios.Add(new Usuario { Nombre = nombre, Apellido = apellido, Edad = edad });

            // Opcional: limpiar TextBlocks
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEdad.Text = string.Empty;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsuarios.SelectedItem is not Usuario seleccionado)
            {
                MessageBox.Show("Selecciona una fila para modificar.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string nombre = txtNombre.Text?.Trim() ?? seleccionado.Nombre;
            string apellido = txtApellido.Text?.Trim() ?? seleccionado.Apellido;
            string edadTxt = txtEdad.Text?.Trim() ?? seleccionado.Edad.ToString();

            if (!int.TryParse(edadTxt, out int edad))
                edad = seleccionado.Edad;

            seleccionado.Nombre = nombre;
            seleccionado.Apellido = apellido;
            seleccionado.Edad = edad;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsuarios.SelectedItem is not Usuario seleccionado)
            {
                MessageBox.Show("Selecciona una fila para eliminar.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            usuarios.Remove(seleccionado);

            // Opcional: limpiar TextBlocks
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEdad.Text = string.Empty;
        }

        private void dataGridUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridUsuarios.SelectedItem is Usuario seleccionado)
            {
                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellido;
                txtEdad.Text = seleccionado.Edad.ToString();
            }
            else
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEdad.Text = string.Empty;
            }
        }
    }

    public class Usuario : INotifyPropertyChanged
    {
        private string nombre;
        private string apellido;
        private int edad;

        public string Nombre
        {
            get => nombre;
            set
            {
                if (value == nombre) return;
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Apellido
        {
            get => apellido;
            set
            {
                if (value == apellido) return;
                apellido = value;
                OnPropertyChanged(nameof(Apellido));
            }
        }

        public int Edad
        {
            get => edad;
            set
            {
                if (value == edad) return;
                edad = value;
                OnPropertyChanged(nameof(Edad));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}