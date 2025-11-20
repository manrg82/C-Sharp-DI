using ExamenManuelRuizEj3.domain;
using ExamenManuelRuizEj3.persistence.manage;
using Org.BouncyCastle.Utilities;
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

namespace ExamenManuelRuizEj3
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Jugador> lsJugador;
        Jugador jugador;
        public MainWindow()
        {
            InitializeComponent();
            lsJugador = new ObservableCollection<Jugador>();
            jugador = new Jugador();
            txtPar.Text = "0";
            txtRat.Text = "0";
            txtNm.Text = "JugadorEjemplo";
            cargarJugadores();
        }
        private void cargarJugadores()
        {
            dgvJugadores.ItemsSource = null;

            var jugs = JugadorPersistence.leerPersonas();
            foreach (var jug in jugs)
            {
                lsJugador.Add(jug);
            }
            dgvJugadores.ItemsSource = lsJugador;
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNickname.Text) ||
                string.IsNullOrWhiteSpace(txtPunt.Text) ||
                !dpkFecha.SelectedDate.HasValue)
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtPunt.Text, out int puntuacion))
            {
                MessageBox.Show("La puntuación debe ser un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Jugador existente = lsJugador.FirstOrDefault(j =>
                j.Nick == txtNickname.Text &&
                j.Puntuacion == puntuacion &&
                j.Fecha == dpkFecha.SelectedDate.Value.ToString("dd/MM/yyyy"));

            if (existente != null)
            {
                MessageBox.Show("El jugador ya existe", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    int nivel = 0;
                    if (cbxItPrinc.IsSelected)
                        nivel = 1;
                    else if (cbxItInter.IsSelected)
                        nivel = 2;
                    else if (cbxItAdvan.IsSelected)
                        nivel = 3;

                    Jugador jugadorNuevo = new Jugador(
                        txtNickname.Text,
                        puntuacion,
                        dpkFecha.SelectedDate.Value.ToString("yyyy-MM-dd"),
                        nivel);

                    JugadorPersistence persistence = new JugadorPersistence();
                    persistence.insertarPersona(jugadorNuevo);

                    MessageBox.Show("Jugador agregado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    lsJugador.Clear();
                    cargarJugadores();
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar el jugador: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void dgvJugadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Jugador j = dgvJugadores.SelectedItem as Jugador;
            if (j != null)
            {
                txtNickname.Text = j.Nick;
                txtPunt.Text = j.Puntuacion.ToString();
                if (!string.IsNullOrWhiteSpace(j.Fecha))
                {
                    if (DateTime.TryParse(j.Fecha, out DateTime fecha))
                    {
                        dpkFecha.SelectedDate = fecha;
                    }
                }
                cbxNivel.SelectedIndex = -1;
                switch (j.Nivel)
                {
                    case 1:
                        cbxItPrinc.IsSelected = true;
                        cbxNivel.SelectedItem = cbxItPrinc;
                        break;
                    case 2:
                        cbxItInter.IsSelected = true;
                        cbxNivel.SelectedItem = cbxItInter;
                        break;
                    case 3:
                        cbxItAdvan.IsSelected = true;
                        cbxNivel.SelectedItem = cbxItAdvan;
                        break;
                }

                btnMod.IsEnabled = true;
                btnElim.IsEnabled = true;
            }
            else
            {
                btnMod.IsEnabled = false;
                btnElim.IsEnabled = false;
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Jugador j = dgvJugadores.SelectedItem as Jugador;
            if (j != null)
            {
                if (string.IsNullOrWhiteSpace(txtNickname.Text) ||
                    string.IsNullOrWhiteSpace(txtPunt.Text) ||
                    !dpkFecha.SelectedDate.HasValue)
                {
                    MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(txtPunt.Text, out int puntuacion))
                {
                    MessageBox.Show("La puntuación debe ser un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    int nivel = 0;
                    if (cbxItPrinc.IsSelected)
                        nivel = 1;
                    else if (cbxItInter.IsSelected)
                        nivel = 2;
                    else if (cbxItAdvan.IsSelected)
                        nivel = 3;
                    j.Nick = txtNickname.Text;
                    j.Puntuacion = puntuacion;
                    j.Fecha = dpkFecha.SelectedDate.Value.ToString("yyyy-MM-dd");
                    j.Nivel = nivel;

                    JugadorPersistence persistence = new JugadorPersistence();
                    persistence.actualizarPersona(j);

                    MessageBox.Show("Jugador modificado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    lsJugador.Clear();
                    cargarJugadores();
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el jugador: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un jugador para modificar", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Jugador j = dgvJugadores.SelectedItem as Jugador;
            if (j != null)
            {
                var result = MessageBox.Show($"¿Está seguro de eliminar al jugador '{j.Nick}'?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        JugadorPersistence persistence = new JugadorPersistence();
                        persistence.eliminarPersona(j.Id);
                        cargarJugadores();

                        MessageBox.Show("Jugador eliminado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        limpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el jugador: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un jugador para eliminar", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void limpiarCampos()
        {
            txtNickname.Clear();// aqui limpio los campos despues de agregar,modificar o eliminar
            txtPunt.Clear();
            dpkFecha.SelectedDate = null;
            cbxNivel.SelectedIndex = -1;
            dgvJugadores.SelectedItem = null;
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Jugador> filtradas;
            switch (cbxFiltro.SelectedIndex)
            {
                case 0:
                    filtradas = lsJugador.Where(j => j.Nick.Contains(txtBuscar.Text));//aqui implemento linq para la busqueda
                    dgvJugadores.ItemsSource = filtradas;
                    break;
                case 1:
                    filtradas = lsJugador.Where(j => j.Puntuacion == int.Parse(txtBuscar.Text));
                    dgvJugadores.ItemsSource = filtradas;
                    break;
                case 2:
                    filtradas = lsJugador.Where(j => j.Fecha.Contains(txtBuscar.Text));
                    dgvJugadores.ItemsSource = filtradas;
                    break;
                case 3:
                    filtradas = lsJugador.Where(j => j.Nivel == int.Parse(txtBuscar.Text));
                    dgvJugadores.ItemsSource = filtradas;
                    break;
                default:
                    MessageBox.Show("Seleccione un criterio de búsqueda válido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
            }

        }
        private void btnAddPar_Click(object sender, RoutedEventArgs e)
        {
            txtPar.Text = Convert.ToString(int.Parse(txtPar.Text) + 1);
        }
        private void btnResPar_Click(object sender, RoutedEventArgs e)
        {
            txtPar.Text = Convert.ToString(int.Parse(txtPar.Text) - 1);
        }
        private void btnAddRat_Click(object sender, RoutedEventArgs e)
        {
            txtRat.Text = Convert.ToString(int.Parse(txtRat.Text) + 1);
        }
        private void btnResRat_Click(object sender, RoutedEventArgs e)
        {
            txtRat.Text = Convert.ToString(int.Parse(txtRat.Text) - 1);
        }
    }
}