using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services.Base;

public class BaseService<T, D> : IBaseService<T, D> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public BaseService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public virtual async Task<List<D>> GetAllASync()
    {
        return _mapper.Map<List<D>>(await _dbContext.Set<T>().AsNoTracking().ToListAsync());
    }

    public virtual async Task<bool> CreateAsync(D item)
    {
        await _dbContext.Set<T>().AddAsync(_mapper.Map<T>(item));
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> UpdateAsync(D item)
    {
        var entity = _mapper.Map<T>(item);
        entity.DateUpdate = DateTime.Now;
        _dbContext.Set<T>().Update(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(Guid Id)
    {
        return await _dbContext.Set<T>().Where(ent => ent.Id == Id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(d => d.IsDeleted, true)) > 0;
    }

    public async Task<D> GetByIdAsync(Guid Id)
    {
        return _mapper.Map<D>(await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == Id));
    }
}