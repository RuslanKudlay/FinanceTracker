using DAL.Entities.Mono;

namespace BAL.Services.Interfaces;

public interface IClientService
{
    Task<bool> CreateOrUpdateClientFromMonoAsync(Client client);
}