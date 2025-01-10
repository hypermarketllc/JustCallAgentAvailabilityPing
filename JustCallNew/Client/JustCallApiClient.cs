using System.Text.Json;
using System.Text.Json.Serialization;
using JustCallNew.Models;

namespace JustCallNew.Client
{
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

        public async Task<AvailabiliyStatus> GetUserAsync(int userId)
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
                var responseData = JsonSerializer.Deserialize<UserStatusResponse>(jsonString);

                var status = new AvailabiliyStatus
                {
                    Available =  string.IsNullOrEmpty(responseData.Data.Available) ? "" : responseData.Data.Available,
                    OnCall = responseData.Data.OnCall
                };

                if (responseData != null)
                {
                    return status;
                }
                else
                {
                    return new AvailabiliyStatus();
                }
                // Create our custom response
                
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error calling JustCall API: {ex.Message}", ex);
            }
        }
    }
}