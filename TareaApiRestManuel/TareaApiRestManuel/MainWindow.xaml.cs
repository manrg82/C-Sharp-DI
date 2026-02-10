using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using TareaApiRestManuel.Models;

namespace TareaApiRestManuel
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly HttpClient _httpClient;
        /// <summary>
        /// All species URL
        /// </summary>
        private const string AllSpeciesUrl = "https://aes.shenlu.me/api/v1/species";

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Handles the Click event of the RefreshButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ObjectsListBox.Items.Clear();
            DetailsTextBox.Clear();
            CreateTextBox.Clear();

            try
            {
                var animals = await _httpClient.GetFromJsonAsync<List<AnimalModel>>(AllSpeciesUrl);
                if (animals != null)
                {
                    foreach (var animal in animals)
                    {
                        ObjectsListBox.Items.Add(new { _display = animal.ToString(), _json = System.Text.Json.JsonSerializer.Serialize(animal, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }), _obj = animal });
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error fetching objects: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the ObjectsListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void ObjectsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ObjectsListBox.SelectedItem == null) return;
            var item = ObjectsListBox.SelectedItem;
            var jsonProp = item.GetType().GetProperty("_json");
            if (jsonProp != null)
            {
                var json = jsonProp.GetValue(item) as string;
                DetailsTextBox.Text = json;
            }
        }

        /// <summary>
        /// Handles the Click event of the CreateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var json = CreateTextBox.Text?.Trim();
            if (string.IsNullOrEmpty(json))
            {
                MessageBox.Show("Please enter JSON to create.");
                return;
            }

            try
            {
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://aes.shenlu.me/api/v1/species";
                var response = await _httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Object created successfully.");
                    RefreshButton_Click(null, null);
                }
                else
                {
                    var resp = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error creating object: {response.StatusCode}\n{resp}");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error creating object: {ex.Message}");
            }
        }
    }
}