using BAL.Services.Base;
using DAL.DTOs;
using DAL.Entities;

namespace BAL.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<bool> Register(RegisterDto dto);
}