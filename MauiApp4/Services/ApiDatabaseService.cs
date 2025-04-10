using MauiApp4.Services;

public class ApiDatabaseService
{
    private readonly ApiService _apiService;
    private readonly DatabaseService _databaseService;
    private const string Endpoint = "api/Genders";

    public ApiDatabaseService(ApiService apiService, DatabaseService databaseService)
    {
        _apiService = apiService;
        _databaseService = databaseService;
    }

    public async Task SyncGendersAsync(string accessToken)
    {
        var genders = await _apiService.GetAsync<List<Gender>>(Endpoint, accessToken);

        if (genders != null && genders.Any())
        {
            await _databaseService.SaveGendersAsync(genders);
        }
    }
}
