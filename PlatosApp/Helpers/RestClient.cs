using PlatosApp.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace PlatosApp.Helpers
{
    public class RestClient : IRestClient
    {
        private const string URL = "https://tomcat.fullbyte.store/platos_api-1.0/";
        private const string RESOURCE = "api/platos";

        public readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task AddPlatoAsync(AddOrModifyPlato plato)
        {
            string json = JsonSerializer.Serialize(plato, _jsonSerializerOptions);
                
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync($"{URL}{RESOURCE}", content);

            Debug.WriteLine($"[RED]: {response.StatusCode} at {nameof(AddPlatoAsync)}");
        }

        public async Task DeletePlatoAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{URL}{RESOURCE}/{id}");

            Debug.WriteLine($"[RED]: {response.StatusCode} at {nameof(AddPlatoAsync)}");
        }

        public async Task<ICollection<Plato>> GetPlatos()
        {
            var platos = new List<Plato>();

            var response = await _httpClient.GetAsync($"{URL}{RESOURCE}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                platos = JsonSerializer.Deserialize<List<Plato>>(json, _jsonSerializerOptions) ?? new List<Plato>();

                platos = platos.OrderBy(x => Guid.NewGuid()).ToList();
            }
            else
            {
                Debug.WriteLine($"[RED]: LA respuesta no es exitosa (no es código 2XX)");
            }

            return platos;
        }

        public async Task UpdatePlatoAsync(Plato plato)
        {
            string json = JsonSerializer.Serialize(plato, _jsonSerializerOptions);
            
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _httpClient.PutAsync($"{URL}{RESOURCE}/{plato.Id}", content);
            
            Debug.WriteLine($"[RED]: {response.StatusCode} at {nameof(AddPlatoAsync)}");
        }
    }
}
