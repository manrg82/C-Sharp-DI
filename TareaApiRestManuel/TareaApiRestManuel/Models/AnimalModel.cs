using System.Text.Json.Serialization;

namespace TareaApiRestManuel.Models
{
    public class AnimalModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; } = string.Empty;

        [JsonPropertyName("conservation_status")]
        public string ConservationStatus { get; set; } = string.Empty;

        [JsonPropertyName("group")]
        public string Group { get; set; } = string.Empty;

        [JsonPropertyName("iso_code")]
        public string IsoCode { get; set; } = string.Empty;

        [JsonPropertyName("common_name")]
        public string CommonName { get; set; } = string.Empty;

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[{Id}] {CommonName} ({ScientificName})";
        }
    }
}
