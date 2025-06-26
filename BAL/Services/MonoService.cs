using System.Text.Json;
using BAL.Services.Interfaces;
using DAL;
using DAL.Entities.Mono;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class MonoService : IMonoService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApplicationDbContext _dbContext;
    private const string Address = "https://api.monobank.ua";
    private const string PersonalData = "/personal/client-info";

    public MonoService(IHttpClientFactory httpClientFactory, ApplicationDbContext dbContext)
    {
        _httpClientFactory = httpClientFactory;
        _dbContext = dbContext;
    }

    public async Task<Client> GetBalance()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var setting = await _dbContext.Settings.FirstOrDefaultAsync(s => s.Key == "MonoToken");
        httpClient.DefaultRequestHeaders.Add("X-Token", setting.Value);
        var response = await httpClient.GetAsync(Address + PersonalData);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var client = JsonSerializer.Deserialize<Client>(result);
        }

        return new Client();
    }
}