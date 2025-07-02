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

    public async Task<List<Client>> GetPersonalDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var userId = _contextAccessor.GetUserId();
        var myGroup = await _dbContext.UserFamilyGroups.FirstOrDefaultAsync(ufg => ufg.UserId == userId);
        var userGroups = await _dbContext.UserFamilyGroups.Where(ufg => ufg.FamilyGroupId == myGroup.FamilyGroupId).ToListAsync();
        var userGroupIds = userGroups.Select(ug => ug.UserId).ToList();
        var users = await _dbContext.Users.Where(u => userGroupIds.Contains(u.Id)).ToListAsync();
        var userIds = users.Select(u => u.Id).ToList();
        
        var settings = await _dbContext.UserSettings.Where(s => s.Key == "MonoToken" && userIds.Contains(s.UserId.Value)).ToListAsync();

        if (settings == null || settings.Count == 0)
            return new List<Client>();

        var clients = new List<Client>();

        foreach (var setting in settings)
        {
            httpClient.DefaultRequestHeaders.Add("X-Token", setting.Value);
            var response = await httpClient.GetAsync(Address + PersonalData);
            httpClient.DefaultRequestHeaders.Remove("X-Token");

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadAsStringAsync();
            var client = JsonSerializer.Deserialize<ClientDto>(result);
            client.UserId = setting.UserId.Value;
        
            foreach (var account in client.Accounts)
            {
                if (account.MaskedPansRaw != null)
                {
                    account.CardMaskedPans = account.MaskedPansRaw
                        .Select(pan => new CardMaskedPan { MaskedPan = pan })
                        .ToList();
                }
            }
        
            clients.Add(_mapper.Map<Client>(client));
        }

        return clients;
    }
}