using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPF_LoginForm.DAL;
using WPF_LoginForm.Helpers;
using WPF_LoginForm.Model;

namespace WPF_LoginForm.ViewModel
{
    public class AlumnadoViewModel : INotifyPropertyChanged
    {
        private readonly DbBroker _dbBroker;
        private ObservableCollection<Alumnado> _alumnos;
        private Alumnado? _selectedAlumno;
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private string _curso = "SCI1";
        private string _searchText = string.Empty;

        public ObservableCollection<Alumnado> Alumnos
        {
            get => _alumnos;
            set
            {
                _alumnos = value;
                OnPropertyChanged();
            }
        }

        public Alumnado? SelectedAlumno
        {
            get => _selectedAlumno;
            set
            {
                _selectedAlumno = value;
                OnPropertyChanged();
                if (value != null)
                {
                    Nombre = value.Nombre;
                    Apellidos = value.Apellidos;
                    Curso = value.Curso;
                }
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public string Apellidos
        {
            get => _apellidos;
            set
            {
                _apellidos = value;
                OnPropertyChanged();
            }
        }

        public string Curso
        {
            get => _curso;
            set
            {
                _curso = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterAlumnos();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public AlumnadoViewModel()
        {
            _dbBroker = DbBroker.Instance;
            _alumnos = new ObservableCollection<Alumnado>();

            AddCommand = new RelayCommand(Add);
            UpdateCommand = new RelayCommand(Update, _ => SelectedAlumno != null);
            DeleteCommand = new RelayCommand(Delete, _ => SelectedAlumno != null);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var alumnos = _dbBroker.GetAllAlumnos();
                Alumnos.Clear();
                foreach (var alumno in alumnos)
                {
                    Alumnos.Add(alumno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Add(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellidos))
            {
                MessageBox.Show("Nombre y Apellidos son obligatorios", "Validacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var nuevoAlumno = new Alumnado
            {
                Nombre = Nombre,
                Apellidos = Apellidos,
                Curso = Curso
            };

            try
            {
                if (_dbBroker.InsertAlumno(nuevoAlumno))
                {
                    LoadData();
                    ClearForm();
                    MessageBox.Show("Alumno anadido correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anadir alumno: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Update(object? parameter)
        {
            if (SelectedAlumno == null) return;

            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellidos))
            {
                MessageBox.Show("Nombre y Apellidos son obligatorios", "Validacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SelectedAlumno.Nombre = Nombre;
            SelectedAlumno.Apellidos = Apellidos;
            SelectedAlumno.Curso = Curso;

            try
            {
                if (_dbBroker.UpdateAlumno(SelectedAlumno))
                {
                    LoadData();
                    ClearForm();
                    MessageBox.Show("Alumno modificado correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar alumno: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete(object? parameter)
        {
            if (SelectedAlumno == null) return;

            var result = MessageBox.Show(
                $"Esta seguro de eliminar a {SelectedAlumno.Nombre} {SelectedAlumno.Apellidos}?",
                "Confirmar eliminacion",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (_dbBroker.DeleteAlumno(SelectedAlumno.IdAlumnado))
                    {
                        Alumnos.Remove(SelectedAlumno);
                        ClearForm();
                        MessageBox.Show("Alumno eliminado correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar alumno: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void FilterAlumnos()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadData();
                return;
            }

            var filtered = _dbBroker.GetAllAlumnos()
                .Where(a => a.Nombre.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                           a.Apellidos.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                           a.Curso.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Alumnos.Clear();
            foreach (var alumno in filtered)
            {
                Alumnos.Add(alumno);
            }
        }

        private void ClearForm()
        {
            Nombre = string.Empty;
            Apellidos = string.Empty;
            Curso = "SCI1";
            SelectedAlumno = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
