using JustCallNew.Client;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JustCallController : ControllerBase
{
    private readonly JustCallApiClient _justCallClient;

    public JustCallController()
    {
        string apiKey = "b36b33026766f7a158ba65d8d30caec98f18bb84";
        string apiSecret = "74fd783a422926f7cadc20b9ebc52b791aa93737";
        _justCallClient = new JustCallApiClient(apiKey, apiSecret);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUser()
    {
        try
        {
            var result = await _justCallClient.GetUserAsync(0);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
}