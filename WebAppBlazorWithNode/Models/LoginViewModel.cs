using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAppBlazorWithNode.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
