using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.Mono;
using DAL.Entities;
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

    public async Task<BalanceDto> CreateOrUpdateClientFromMonoAsync(List<Client> clientsFromApi)
    {
        
        if (clientsFromApi == null || clientsFromApi.Count == 0)
            throw new CustomException("Не вдалось отримати банківські дані!");

        foreach (var clientFromApi in clientsFromApi)
        {
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
        }

        var userIds = await GetReferralUserIds();
        userIds.Add(_accessor.GetUserId().Value);
        
        var clients = await GetClientsWithAccountsAsync(userIds);
        var accounts = GetFilteredAccounts(clients, "black");
        
        var balance = BuildBalanceDto(clients, accounts);
        
        return balance;
    }
    
    private async Task<List<Client>> GetClientsWithAccountsAsync(List<Guid> userIds)
    {
        return await _dbContext.Clients
            .Where(cl => userIds.Contains(cl.UserId) && cl.User.IsVisibleInGroup == true)
            .Include(cl => cl.Accounts)
            .ThenInclude(acc => acc.CardMaskedPans)
            .ToListAsync();
    }

    private async Task<List<Guid>> GetReferralUserIds()
    {
        var userIds = await _dbContext.UserFamilyGroups
            .Where(ufg => ufg.FamilyGroup.IsEnabledGroup == true && ufg.FamilyGroup.Code != "Personal")
            .Select(ufg => ufg.UserId)
            .ToListAsync();


        return await _dbContext.Users
            .Where(u => userIds.Contains(u.Id))
            .Select(u => u.Id)
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
            TotalBalance = accounts.Sum(a => a.Balance - a.CreditLimit) / 100.0,
            BalanceClients = accounts.Select(acc => new BalanceClientDto
            {
                Id = acc.Id,
                Balance = (acc.Balance - acc.CreditLimit) / 100.0,
                ClientName = clients
                    .FirstOrDefault(cl => cl.Accounts.Any(p => p.Id == acc.Id))?.Name,
                Cards = acc.CardMaskedPans
                    .Select(c => c.MaskedPan).ToList()
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