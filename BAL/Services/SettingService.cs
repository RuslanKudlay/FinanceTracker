using AutoMapper;
using BAL.Services.Base;
using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.Setting;
using DAL.Entities;
using FinanceTracking.Extentions;
using Microsoft.AspNetCore.Http;

namespace BAL.Services;

public class SettingService : BaseService<Setting, SettingDto>, ISettingService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    
    
    public SettingService(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor accessor) : base(dbContext, mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _accessor = accessor;
    }

    public override async Task<bool> CreateAsync(SettingDto item)
    {
        var entity = new Setting()
        {
            Key = item.Key,
            Value = item.Value,
            Description = item.Description,
            DataType = item.DataType,
            DateCreate = DateTime.Now,
            DateUpdate = DateTime.Now,
            UserId = Guid.Parse(_accessor.GetUserId())
        };
        await _dbContext.Settings.AddAsync(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}