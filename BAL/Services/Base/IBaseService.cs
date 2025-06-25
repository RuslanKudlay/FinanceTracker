using DAL;

namespace BAL.Services.Base;

public interface IBaseService<T, D> where T : BaseEntity
{
    Task<List<D>> GetAllASync();
    Task<bool> CreateAsync(D item);
    Task<bool> UpdateAsync(D item);
    Task<bool> DeleteAsync(Guid Id);
    Task<D> GetByIdAsync(Guid Id);
}