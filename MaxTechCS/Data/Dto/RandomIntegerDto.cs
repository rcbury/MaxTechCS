using System.Text.Json.Serialization;

namespace MaxTechCS.Data.Dto
{
    public class RandomIntegerDto
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
        [JsonPropertyName("min")]
        public int Min { get; set; }
        [JsonPropertyName("max")]
        public int Max { get; set; }
        [JsonPropertyName("random")]
        public int Random { get; set; }
    }
}
