using System.Text.Json;
using BAL.Services.Interfaces;
using DAL;
using DAL.Entities.Mono;
using FinanceTracking.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class MonoService : IMonoService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _contextAccessor;
    private const string Address = "https://api.monobank.ua";
    private const string PersonalData = "/personal/client-info";

    public MonoService(IHttpClientFactory httpClientFactory, ApplicationDbContext dbContext, IHttpContextAccessor contextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _dbContext = dbContext;
        _contextAccessor = contextAccessor;
    }

    public async Task<Client?> GetBalanceAsync()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var userId = _contextAccessor.GetUserId();
        var setting = await _dbContext.Settings.FirstOrDefaultAsync(s => s.Key == "MonoToken" && s.UserId == Guid.Parse(userId));

        if (setting == null)
            return null;

        httpClient.DefaultRequestHeaders.Add("X-Token", setting.Value);
        var response = await httpClient.GetAsync(Address + PersonalData);

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadAsStringAsync();
        var client = JsonSerializer.Deserialize<Client>(result);
        client.UserId = Guid.Parse(userId);
        return client;
    }
}