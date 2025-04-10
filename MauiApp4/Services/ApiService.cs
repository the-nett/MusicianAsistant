using Newtonsoft.Json;
using System.Net.Http.Headers;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://36ck5wvh-7014.use2.devtunnels.ms/";

    public ApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl)
        };
    }

    public async Task<T> GetAsync<T>(string endpoint, string accessToken)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Error en la API: {error}");
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en GetAsync: {ex.Message}");
            throw;
        }
    }
}
