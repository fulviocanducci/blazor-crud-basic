using System.Text.Json.Serialization;

namespace WebAppBlazorWithNode.Models
{
    public class StatusLogin
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
