using ExampleMVCnoDatabase.Persistence;
using Ruiz_Gutierrez_Manuel_MiniHito2.domain;
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

namespace Ruiz_Gutierrez_Manuel_MiniHito2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBBroker broker;
        public MainWindow()
        {
            InitializeComponent();
            broker = DBBroker.obtenerAgente();
            Alumno a = new Alumno("test", "asdf", 1, 2);
            this.InsertarAlumno(a);
        }
        void InsertarAlumno(Alumno alum)
        {
            string sql = "INSERT INTO aceptasreto.alumnado (nombre, apellidos, especialidad, grupo) VALUES ('" +
                         alum.Nombre + "', '" +
                         alum.Apellidos + "', '" +
                         alum.Especialidad + "', '"+
                         alum.Grupo+"');";
            int a = DBBroker.obtenerAgente().modificar(sql);
        }
    }
}