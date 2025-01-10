using System.Text.Json;
using System.Text.Json.Serialization;

namespace JustCallNew.Models
{
    // Add this class to format the response
    public class UserStatusResponse
    {
        public string available { get; set; }

        [JsonPropertyName("on call")]  // This will make it appear as "on call" in the JSON
        public string onCall { get; set; }
    }

    public class JustCallApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.justcall.io/v2.1/users/351073";

        public JustCallApiClient(string apiKey, string apiSecret)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"{apiKey}:{apiSecret}");
        }

        public async Task<UserStatusResponse> GetUserAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status: {response.StatusCode}, Error: {errorContent}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(jsonString);
                var data = jsonDoc.RootElement.GetProperty("data");

                // Create our custom response
                return new UserStatusResponse
                {
                    available = data.GetProperty("available").GetString(),
                    onCall = data.GetProperty("on_call").GetString()
                };
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error calling JustCall API: {ex.Message}", ex);
            }
        }
    }
}