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

        var userId = clientFromApi.UserId;

        var existingClient = await _dbContext.Clients
            .Include(c => c.Accounts)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (existingClient == null)
        {
            var newClientId = Guid.NewGuid();
            clientFromApi.Id = newClientId;

            foreach (var account in clientFromApi.Accounts)
            {
                account.Id = Guid.NewGuid();
                account.ClientGuidId = newClientId;
                account.DateCreate = DateTime.UtcNow;
            }

            clientFromApi.DateCreate = DateTime.UtcNow;

            await _dbContext.Clients.AddAsync(clientFromApi);
        }
        else
        {
            existingClient.Name = clientFromApi.Name;
            existingClient.WebHookUrl = clientFromApi.WebHookUrl;
            existingClient.Permissions = clientFromApi.Permissions;
            existingClient.DateUpdate = DateTime.UtcNow;

            foreach (var apiAccount in clientFromApi.Accounts)
            {
                var existingAccount = existingClient.Accounts
                    .FirstOrDefault(acc => acc.MonoId == apiAccount.MonoId);

                if (existingAccount != null)
                {
                    existingAccount.SendId = apiAccount.SendId;
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
                else
                {
                    apiAccount.Id = Guid.NewGuid();
                    apiAccount.ClientGuidId = existingClient.Id;
                    apiAccount.DateCreate = DateTime.UtcNow;

                    existingClient.Accounts.Add(apiAccount);
                }
            }

            _dbContext.Clients.Update(existingClient);
        }

        return await _dbContext.SaveChangesAsync() > 0;
    }
}