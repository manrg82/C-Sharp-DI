using System.Text.Json.Serialization;

namespace TareaApiRestManuel.Models
{
    public class ApiResponse
    {
        [JsonPropertyName("data")]
        public List<AnimalModel> Data { get; set; } = new List<AnimalModel>();
    }
}
