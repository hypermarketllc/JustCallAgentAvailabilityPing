using System.Text.Json.Serialization;

namespace JustCallNew.Models
{
    public class UserStatusResponse {

        [JsonPropertyName("status")]
        public string? Status { get; set; } 

        [JsonPropertyName("data")] 
        public Data? Data { get; set; }
    }

}
