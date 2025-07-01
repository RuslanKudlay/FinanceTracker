using System.Text.Json;
using AutoMapper;
using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.Mono;
using DAL.Entities.Mono;
using FinanceTracking.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class MonoService : IMonoService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private const string Address = "https://api.monobank.ua";
    private const string PersonalData = "/personal/client-info";

    public MonoService(IHttpClientFactory httpClientFactory, ApplicationDbContext dbContext, IHttpContextAccessor contextAccessor, IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _dbContext = dbContext;
        _contextAccessor = contextAccessor;
        _mapper = mapper;
    }

    public async Task<Client?> GetPersonalDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var userId = _contextAccessor.GetUserId();
        var setting = await _dbContext.UserSettings.FirstOrDefaultAsync(s => s.Key == "MonoToken" && s.UserId == userId);

        if (setting == null)
            return null;

        httpClient.DefaultRequestHeaders.Add("X-Token", setting.Value);
        var response = await httpClient.GetAsync(Address + PersonalData);

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadAsStringAsync();
        var client = JsonSerializer.Deserialize<ClientDto>(result);
        client.UserId = userId.Value;
        
        foreach (var account in client.Accounts)
        {
            if (account.MaskedPansRaw != null)
            {
                account.CardMaskedPans = account.MaskedPansRaw
                    .Select(pan => new CardMaskedPan { MaskedPan = pan })
                    .ToList();
            }
        }
        
        return _mapper.Map<Client>(client);
    }
}