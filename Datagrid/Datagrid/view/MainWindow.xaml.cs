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
using Datagrid.domain;
using Datagrid.persistence;
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
        List<Persona> lsPersonas;
        Persona persona;
        public MainWindow()
        {
            InitializeComponent();
            persona=new Persona();
            lsPersonas =persona.getPersonas();
            dataGridPersonas.ItemsSource = lsPersonas;//syncs the list with the datagrid
        }
        public void start() {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
        }
        private void dataGridPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //txtNombre.Text = "Ha cambiado la seleccion";
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            lsPersonas.Remove((Persona)dataGridPersonas.SelectedItem);
            dataGridPersonas.Items.Refresh();
            start();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            lsPersonas.Add(new Persona(txtNombre.Text, txtApellido.Text, int.Parse(txtEdad.Text)));
            dataGridPersonas.Items.Refresh();
            start();
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Persona p = (Persona)dataGridPersonas.SelectedItem;
            p.Nombre = txtNombre.Text;
            p.Apellidos = txtApellido.Text;
            p.Edad = int.Parse(txtEdad.Text);
            dataGridPersonas.Items.Refresh();
            start();
        }
    }
}