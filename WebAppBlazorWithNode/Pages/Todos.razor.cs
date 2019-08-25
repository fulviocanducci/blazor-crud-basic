using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text;

namespace WebAppBlazorWithNode.Pages
{
    public class TodosComponent : ComponentBase
    {
        [Inject]
        HttpClient Client { get; set; }
        protected Todo[] Todos { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadTodosAsync();
        }

        async Task LoadTodosAsync()
        {
            string json = await Client.GetStringAsync("http://localhost:3000/todos");
            Todos = JsonSerializer.Deserialize<Todo[]>(json);
        }

        public async Task ChangeDoneAsync(Todo todo)
        {
            if (todo.Done == 0)
            {
                todo.Done = 1;
            }
            StringContent stringContent = 
                new StringContent(
                    JsonSerializer.Serialize(todo), 
                    Encoding.UTF8, 
                    "application/json");
            await Client.PutAsync($"http://localhost:3000/todo/{todo.Id}", stringContent);
            await LoadTodosAsync();
        }

        public async Task DeleteDoneAsync(Todo todo)
        {           
            await Client.DeleteAsync($"http://localhost:3000/todo/{todo.Id}");
            await LoadTodosAsync();
        }

    }

    public class Todo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("done")]
        public int Done { get; set; }
    }
}