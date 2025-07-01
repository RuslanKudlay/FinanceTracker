using BAL.Services.Base;
using DAL.DTOs.Setting;
using DAL.DTOs.UserSetting;
using DAL.Entities;

namespace BAL.Services.Interfaces;

public interface IUserSettingService
{
    Task<bool> CreateUserSettingAsync(CreateUserSettingDto dto);
}