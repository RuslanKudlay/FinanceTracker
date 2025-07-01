using BAL.Services.Interfaces;
using DAL;
using DAL.Entities.Mono;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _dbContext;

    public ClientService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateOrUpdateClientFromMonoAsync(Client clientFromApi)
    {
        if (clientFromApi == null)
            return false;

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

        return await _dbContext.SaveChangesAsync() > 0;
    }

    private async Task<Client?> GetExistingClientAsync(Guid userId)
    {
        return await _dbContext.Clients
            .Include(c => c.Accounts)
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
        existingClient.DateUpdate = DateTime.UtcNow;

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
        account.DateCreate = DateTime.UtcNow;
    }

    private void UpdateExistingAccount(Account existingAccount, Account apiAccount)
    {
        existingAccount.CurrencyCode = apiAccount.CurrencyCode;
        existingAccount.CashbackType = apiAccount.CashbackType;
        existingAccount.Balance = apiAccount.Balance;
        existingAccount.CreditLimit = apiAccount.CreditLimit;
        existingAccount.MaskedPan = apiAccount.MaskedPan;
        existingAccount.Type = apiAccount.Type;
        existingAccount.Iban = apiAccount.Iban;
        existingAccount.DateUpdate = DateTime.UtcNow;
        existingAccount.IsDeleted = false;
    }
}