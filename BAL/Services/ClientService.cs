using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.Mono;
using DAL.Entities.Mono;
using DAL.Exceptions;
using FinanceTracking.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _accessor;

    public ClientService(ApplicationDbContext dbContext, IHttpContextAccessor accessor)
    {
        _dbContext = dbContext;
        _accessor = accessor;
    }

    public async Task<BalanceDto> CreateOrUpdateClientFromMonoAsync(Client clientFromApi)
    {
        if (clientFromApi == null)
            throw new CustomException("Не вдалось отримати банківські дані за токеном!");

        var existingClient = await GetExistingClientAsync(clientFromApi.UserId);

        if (existingClient == null)
        {
            await AddNewClientAsync(clientFromApi);
        }
        else
        {
            UpdateExistingClient(existingClient, clientFromApi);
            _dbContext.Clients.Update(existingClient);
        }

        await _dbContext.SaveChangesAsync();

        var familyUserIds = await GetFamilyUserIdsAsync();
        var clients = await GetClientsWithAccountsAsync(familyUserIds);
        var accounts = GetFilteredAccounts(clients, "black");

        var balance = BuildBalanceDto(clients, accounts);

        return balance;
    }
    
    private async Task<List<Guid>> GetFamilyUserIdsAsync()
    {
        var group = await _dbContext.UserFamilyGroups
            .FirstOrDefaultAsync(ug => ug.UserId == _accessor.GetUserId().Value);

        if (group == null)
            throw new CustomException("Сімейна група не знайдена");

        return await _dbContext.UserFamilyGroups
            .Where(g => g.FamilyGroupId == group.FamilyGroupId)
            .Select(g => g.UserId)
            .ToListAsync();
    }
    
    private async Task<List<Client>> GetClientsWithAccountsAsync(List<Guid> userIds)
    {
        return await _dbContext.Clients
            .Where(cl => userIds.Contains(cl.UserId))
            .Include(cl => cl.Accounts)
            .ThenInclude(acc => acc.CardMaskedPans)
            .ToListAsync();
    }
    
    private List<Account> GetFilteredAccounts(List<Client> clients, string type)
    {
        return clients
            .SelectMany(cl => cl.Accounts.Where(acc => acc.Type == type))
            .ToList();
    }
    
    private BalanceDto BuildBalanceDto(List<Client> clients, List<Account> accounts)
    {
        return new BalanceDto
        {
            TotalBalance = accounts.Sum(a => a.Balance) / 100.0,
            BalanceClients = accounts.Select(acc => new BalanceClientDto
            {
                Id = acc.Id,
                Balance = acc.Balance / 100.0,
                ClientName = clients
                    .FirstOrDefault(cl => cl.Accounts.Any(p => p.Id == acc.Id))?.Name,
                Card = acc.CardMaskedPans
                    .FirstOrDefault(card => card.MaskedPan.EndsWith("9784"))?.MaskedPan
            }).ToList()
        };
    }

    private async Task<Client?> GetExistingClientAsync(Guid userId)
    {
        return await _dbContext.Clients
            .Include(c => c.Accounts)
            .ThenInclude(account => account.CardMaskedPans)
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    private async Task AddNewClientAsync(Client newClient)
    {
        var newClientId = Guid.NewGuid();
        newClient.Id = newClientId;
        newClient.DateCreate = DateTime.UtcNow;

        foreach (var account in newClient.Accounts)
        {
            InitializeNewAccount(account, newClientId);
        }

        await _dbContext.Clients.AddAsync(newClient);
    }

    private void UpdateExistingClient(Client existingClient, Client clientFromApi)
    {
        existingClient.Name = clientFromApi.Name;
        existingClient.WebHookUrl = clientFromApi.WebHookUrl;
        existingClient.Permissions = clientFromApi.Permissions;
        existingClient.DateUpdate = DateTime.Now;

        foreach (var apiAccount in clientFromApi.Accounts)
        {
            var existingAccount = existingClient.Accounts
                .FirstOrDefault(acc => acc.Iban == apiAccount.Iban);

            if (existingAccount != null)
            {
                UpdateExistingAccount(existingAccount, apiAccount);
            }
            else
            {
                InitializeNewAccount(apiAccount, existingClient.Id);
                existingClient.Accounts.Add(apiAccount);
            }
        }
    }

    private void InitializeNewAccount(Account account, Guid clientId)
    {
        account.Id = Guid.NewGuid();
        account.ClientId = clientId;
        account.DateCreate = DateTime.Now;
        account.CardMaskedPans.ForEach(card =>
        {
            card.Id = Guid.NewGuid();
            card.DateCreate = DateTime.Now;
            card.AccountId = account.Id;
        });
    }

    private void UpdateExistingAccount(Account existingAccount, Account apiAccount)
    {
        existingAccount.CurrencyCode = apiAccount.CurrencyCode;
        existingAccount.CashbackType = apiAccount.CashbackType;
        existingAccount.Balance = apiAccount.Balance;
        existingAccount.CreditLimit = apiAccount.CreditLimit;
        existingAccount.Type = apiAccount.Type;
        existingAccount.Iban = apiAccount.Iban;
        existingAccount.DateUpdate = DateTime.Now;
        existingAccount.IsDeleted = false;
    }
}