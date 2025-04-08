using System.Net.Http.Headers;
using Newtonsoft.Json; // <- Aquí
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://gnl4c5r6-7014.use2.devtunnels.ms/"); // Tu URL base de la API
    }

    public async Task<T> GetAsync<T>(string endpoint, string accessToken)
    {
        try
        {
            // Agregar token de autorización
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Error en la API: {error}");
            }

            var json = await response.Content.ReadAsStringAsync();

            // Aquí usamos Newtonsoft.Json
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            // Manejo de errores
            Console.WriteLine($"Error en GetAsync: {ex.Message}");
            throw;
        }
    }
}
