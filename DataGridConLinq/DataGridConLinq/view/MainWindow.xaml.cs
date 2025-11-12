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
using DataGridConLinq;
using Datagrid.persistence;

namespace Datagrid
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Persona> lsPersonas;
        Persona persona;
        
        public MainWindow()
        {
            InitializeComponent();
            lsPersonas = new ObservableCollection<Persona>();
            persona = new Persona();
            cargarPersonas();
        }
        private void cargarPersonas()
        {
            lsPersonas= new ObservableCollection<Persona>();
            var personas = PersonaPersistence.leerPersonas();
            foreach (var p in personas)
            {
                lsPersonas.Add(p);
            }
            dataGridPersonas.ItemsSource = lsPersonas;
        }
        public void start() 
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            btnModificar.IsEnabled = false;
            dataGridPersonas.SelectedItem = null;
        }
        
        private void dataGridPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Persona p = dataGridPersonas.SelectedItem as Persona;
           if (p != null) 
           {
                txtNombre.Text = p.Nombre;
                txtApellido.Text = p.Apellidos;
                txtEdad.Text = p.Edad.ToString();
                btnModificar.IsEnabled = true;
            }
            else
            {
                btnModificar.IsEnabled = false;
            }
        }
        
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Persona p = dataGridPersonas.SelectedItem as Persona;
            if (p != null)
            {
                lsPersonas.Remove(p);
                start();
            }
        }
        
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || 
                string.IsNullOrWhiteSpace(txtApellido.Text) || 
                string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Persona existente = lsPersonas.FirstOrDefault(p => 
                p.Nombre == txtNombre.Text && 
                p.Apellidos == txtApellido.Text && 
                p.Edad == edad);

            if (existente != null)
            {
                MessageBox.Show("La persona ya existe", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Persona psnew = new Persona(txtNombre.Text, txtApellido.Text, edad);
                psnew.insertar();
                lsPersonas.Add(psnew);
                
                start();
                cargarPersonas();
            }
            
        }
        
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Persona p = dataGridPersonas.SelectedItem as Persona;
            if (p == null)
            {
                btnModificar.IsEnabled = false;
                MessageBox.Show("Por favor, seleccione una persona", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || 
                string.IsNullOrWhiteSpace(txtApellido.Text) || 
                string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            p.Nombre = txtNombre.Text;
            p.Apellidos = txtApellido.Text;
            p.Edad = edad;
            start();
        }
    }
}