using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ejemplomasterslave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Person? _selectedPerson;
        private const string DataFile = "people.json";

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public Person? SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            LoadFromFile();

            PeopleDataGrid.ItemsSource = People;

            DataContext = this;
        }

        private void PeopleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPerson = PeopleDataGrid.SelectedItem as Person;
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(IdTextBox.Text, out var id))
            {
                MessageBox.Show("Id debe ser un número entero", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var name = NameTextBox.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name no puede estar vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(AgeTextBox.Text, out var age))
            {
                MessageBox.Show("Age debe ser un número entero", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Avoid duplicate ids
            foreach (var p in People)
            {
                if (p.Id == id)
                {
                    MessageBox.Show("Ya existe una persona con ese Id", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            var person = new Person { Id = id, Name = name, Age = age };
            People.Add(person);

            // clear inputs
            IdTextBox.Text = string.Empty;
            NameTextBox.Text = string.Empty;
            AgeTextBox.Text = string.Empty;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
            MessageBox.Show("Datos guardados", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadFromFile()
        {
            try
            {
                if (!File.Exists(DataFile))
                {
                    // create file with sample data
                    People.Add(new Person { Id = 1, Name = "Alice", Age = 30 });
                    People.Add(new Person { Id = 2, Name = "Bob", Age = 25 });
                    People.Add(new Person { Id = 3, Name = "Carol", Age = 28 });
                    SaveToFile();
                    return;
                }

                var json = File.ReadAllText(DataFile);
                var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var list = JsonSerializer.Deserialize<ObservableCollection<Person>>(json, opts);
                if (list != null)
                {
                    foreach (var p in list) People.Add(p);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error leyendo archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveToFile()
        {
            try
            {
                var opts = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(People, opts);
                File.WriteAllText(DataFile, json);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error guardando archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}