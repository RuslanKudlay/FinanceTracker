using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.Mono;
using DAL.Entities.Mono;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _dbContext;

    public ClientService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
        
        var balance = clientFromApi.Accounts.FirstOrDefault(account => account.Type == "black");
        return new BalanceDto(balance.Balance / 100.0, balance.CardMaskedPans.FirstOrDefault().MaskedPan);
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