using DAL.DTOs.Mono;
using DAL.Entities.Mono;

namespace BAL.Services.Interfaces;

public interface IClientService
{
    Task<BalanceDto> CreateOrUpdateClientFromMonoAsync(List<Client> clients);
}