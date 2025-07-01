using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.UserSetting;
using DAL.Entities;
using DAL.Exceptions;
using FinanceTracking.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class UserSettingService : IUserSettingService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _accessor;

    public UserSettingService(ApplicationDbContext dbContext, IHttpContextAccessor accessor)
    {
        _dbContext = dbContext;
        _accessor = accessor;
    }

    public async Task<bool> CreateUserSettingAsync(CreateUserSettingDto dto)
    {
        if (!await _dbContext.Settings.AnyAsync(set => set.Id == dto.SettingId))
        {
            throw new CustomException("Виникла помилка при спробі встановлення значення!");
        }

        var userSetting = await CreateUserSetting(dto);
        await _dbContext.UserSettings.AddAsync(userSetting);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    private async Task<UserSetting> CreateUserSetting(CreateUserSettingDto dto)
    {
        var setting = await _dbContext.Settings.FirstOrDefaultAsync(set => set.Id == dto.SettingId);
        return new UserSetting()
        {
            Id = Guid.NewGuid(),
            DataType = setting.DataType,
            Description = setting.Description,
            Key = setting.Key,
            Value = dto.Value,
            IsDeleted = setting.IsDeleted,
            DateCreate = DateTime.Now,
            UserId = _accessor.GetUserId(),
            SettingId = setting.Id
        };
    }
}