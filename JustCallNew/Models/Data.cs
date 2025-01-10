using System.Text.Json.Serialization;

namespace JustCallNew.Models
{
    public class Data
    {
        [JsonPropertyName("id")] 
        public int Id { get; set; }

        [JsonPropertyName("role")] 
        public string? Role { get; set; }

        [JsonPropertyName("name")] 
        public string? Name { get; set; }

        [JsonPropertyName("email")] 
        public string? Email { get; set; }

        [JsonPropertyName("extension")] 
        public int Extension { get; set; }

        [JsonPropertyName("groups")] 
        public List<string>? Groups { get; set; }

        [JsonPropertyName("owned_numbers")] 
        public List<string>? OwnedNumbers { get; set; }

        [JsonPropertyName("shared_numbers")] 
        public List<string>? SharedNumbers { get; set; }

        [JsonPropertyName("created_at")] 
        public string? CreatedAt { get; set; }

        [JsonPropertyName("last_login_timestamp")] 
        public string? LastLoginTimestamp { get; set; }

        [JsonPropertyName("timezone")] 
        public string? Timezone { get; set; }

        [JsonPropertyName("working_hours_type")] 
        public string? WorkingHoursType { get; set; }

        [JsonPropertyName("available")] 
        public string? Available { get; set; }

        [JsonPropertyName("unavailability_reason")] 
        public string? UnavailabilityReason { get; set; }

        [JsonPropertyName("on_call")] 
        public string? OnCall { get; set; }
    }

}
