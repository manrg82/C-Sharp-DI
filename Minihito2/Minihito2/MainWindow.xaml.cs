using System.Collections.ObjectModel;
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

namespace Minihito2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Alumno alumno;
        private List<Alumno> listaAlumnos;
        private const string OPCION_1_CURSO = "1";
        private const string OPCION_2_CURSO = "2";

        public MainWindow()
        {
            InitializeComponent();

            listaAlumnos = new List<Alumno>();
            cmbEspecialidadContent = new ObservableCollection<string>()
            {
                OPCION_1_CURSO, OPCION_2_CURSO
            };
            //Descargar los registros de la base de datos
            alumno = new Alumno();
            listaAlumnos = alumno.GetAlumnos();
            dgAlumnos.ItemsSource = listaAlumnos;
            cmbEspecialidad.ItemsSource = cmbEspecialidadContent;

        }

        private ObservableCollection<string> cmbEspecialidadContent {  get; set; }

        public void clear()
        {
            btnAnadir.Content = "Agregar";
            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbEspecialidad.Text = "";
            dgAlumnos.SelectedItem = null;
            listaAlumnos = alumno.GetAlumnos();
            dgAlumnos.ItemsSource = listaAlumnos;
        }

        private void dgAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAlumnos.SelectedValue != null)
            {
                alumno = (Alumno)dgAlumnos.SelectedValue;
                txtNombre.Text = alumno.Nombre;
                txtApellido.Text = alumno.Apellidos;
                cmbEspecialidad.Text = alumno.Especialidad.ToString();
                btnAnadir.IsEnabled = false;
                btnModificar.IsEnabled = true;
                btnBorrar.IsEnabled = true;
            }
            else
            {
                btnAnadir.IsEnabled = true;
                btnModificar.IsEnabled = false;
                btnBorrar.IsEnabled = false;
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            alumno = (Alumno)dgAlumnos.SelectedItem;
            alumno.Eliminar();
            clear();

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            alumno = (Alumno)dgAlumnos.SelectedItem;
            btnAnadir.Content = "Actualizar";
            btnAnadir.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnBorrar.IsEnabled = false;

        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {

            if (btnAnadir.Content == "Actualizar" && formatoCorrecto())
            {
                alumno.Nombre = txtNombre.Text;
                alumno.Apellidos = txtApellido.Text;
                alumno.Especialidad = int.Parse(cmbEspecialidad.SelectedItem.ToString());
                alumno.Modificar();
                clear();
            }
            else
            {
                if (formatoCorrecto())
                {
                    alumno = new Alumno(alumno.Id, txtNombre.Text, txtApellido.Text, int.Parse(cmbEspecialidad.Text), alumno.Grupo);
                    alumno.Insertar();
                    clear();
                }
                else
                {
                    MessageBox.Show("Formato incorrecto");
                    clear();
                }
            }
        }

        private bool formatoCorrecto()
        {
            return txtNombre.Text != string.Empty &&
                txtNombre.Text.All(Char.IsLetter) &&
                txtApellido.Text != string.Empty &&
                txtApellido.Text.All(Char.IsLetter) &&
                cmbEspecialidad.Text != string.Empty &&
                cmbEspecialidad.Text.All(Char.IsNumber);
        }

        /*
        private void cmbEspecialidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Filtro, no necesario dgAlumnos.ItemsSource = listaAlumnos.Where(a => a.Especialidad.Equals(int.Parse(cmbEspecialidad.SelectedItem.ToString())));

        }
        */

        private void txtBarraBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Alumno> filtradas;
            filtradas = listaAlumnos.Where(p => p.Nombre.Contains(txtBarraBusqueda.Text) || p.Apellidos.Contains(txtBarraBusqueda.Text));
            dgAlumnos.ItemsSource = filtradas;
        }

    }

}