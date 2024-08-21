using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackOverFlowController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public StackOverFlowController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("recent-questions")]
        public async Task<IActionResult> GetRecentQuestions()
        {

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");


            // https://api.stackexchange.com/2.3/questions?order=desc&sort=activity&site=stackoverflow
            var response = await _httpClient.GetAsync("https://api.stackexchange.com/2.3/questions?order=desc&sort=activity&site=stackoverflow&pagesize=50");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"Error retrieving data from Stack Overflow API. StatusCode: {response.StatusCode}, Response: {errorContent}");

            }
            
            var content = await response.Content.ReadAsStringAsync();
            return Ok(JsonSerializer.Deserialize<object>(content));
        }

        [HttpGet("question-details/{id}")]
        public async Task<IActionResult> GetQuestionDetails(int id)
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");


            var response = await _httpClient.GetAsync($"https://api.stackexchange.com/2.3/questions/{id}?order=desc&sort=activity&site=stackoverflow");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving data from Stack Overflow API.");
            }

            var content = await response.Content.ReadAsStringAsync();
            return Ok(JsonSerializer.Deserialize<object>(content));
        }

    }
}
