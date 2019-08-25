using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebAppBlazorWithNode.Extensions;

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
            Todos = await Client.GetAsync<Todo[]>("http://localhost:3000/todos");
        }

        public async Task ChangeDoneAsync(Todo todo)
        {
            if (todo.Done == 0)
            {
                todo.Done = 1;
            }            
            await Client.PutAsync($"http://localhost:3000/todo/{todo.Id}", todo.GetStringContent());
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