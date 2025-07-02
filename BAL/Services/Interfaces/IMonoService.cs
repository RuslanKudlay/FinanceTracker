using DAL.Entities.Mono;

namespace BAL.Services.Interfaces;

public interface IMonoService
{
    Task<List<Client>> GetPersonalDataAsync();
}