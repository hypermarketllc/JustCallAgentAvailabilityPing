using System.Text.Json.Serialization;

namespace JustCallNew.Models
{
    public class AvailabiliyStatus
    {
        [JsonPropertyName("on_call")]
        public string? OnCall { get; set; }

        [JsonPropertyName("available")]
        public string? Available { get; set; }
    }
}
