using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataGridConLinq
{
    public partial class MainWindow : Window
    {
        List<Persona> listaPersonas;
        public MainWindow()
        {
            InitializeComponent();
            listaPersonas = new List<Persona>
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
            // Mostrar mensaje solo si el campo edad no está vacío pero no es un número válido
            if (!string.IsNullOrWhiteSpace(txtEdadMinima.Text) && !int.TryParse(txtEdadMinima.Text, out _))
            {
                MessageBox.Show("Por favor, ingrese una edad válida.");
                return;
            }

            ApplyFilters();
        }

        private void TxtApellidoBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            IEnumerable<Persona> filtered = listaPersonas;

            // Filtro por edad mínima si se proporciona
            if (int.TryParse(txtEdadMinima.Text, out int edadMin))
            {
                filtered = filtered.Where(p => p.Edad >= edadMin);
            }

            // Filtro por apellido (contiene, case-insensitive) si se proporciona
            var apBuscar = txtApellidoBusqueda.Text?.Trim();
            if (!string.IsNullOrEmpty(apBuscar))
            {
                filtered = filtered.Where(p => p.Apellidos?.IndexOf(apBuscar, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }

            dataGridPersonas.ItemsSource = filtered.ToList();
        }

        private void Mostrar_Todos_Click(object sender, RoutedEventArgs e)
        {
            txtEdadMinima.Clear();
            txtApellidoBusqueda.Clear();
            dataGridPersonas.ItemsSource = listaPersonas;
        }
    }
}