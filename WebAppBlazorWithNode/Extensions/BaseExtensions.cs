using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAppBlazorWithNode.Extensions
{
    public static class BaseExtensions
    {
        public static StringContent GetStringContent(this object _c) 
        {
            return new StringContent(JsonSerializer.Serialize(_c), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetAsync<T>(this HttpClient client, string url)
        {
            string json = await client.GetStringAsync(url);            
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
