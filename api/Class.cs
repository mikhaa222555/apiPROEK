using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace api
{
    public class ApiService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _http;
        public ApiService(string baseUrl)
        {
            _baseUrl = baseUrl;
            _http = new HttpClient();
        }
        public async Task UpdateTaskAsync(Task task)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl); // Replace with your API URL
                string data = JsonConvert.SerializeObject(task);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"api/Tasks/{task.Id}", content); //
                response.EnsureSuccessStatusCode(); 
                // К СЕРВЕРУ ПОДКЛЮЧЕНИЕ САМ ПОСМОТРИ
            }
        }
    }
}

