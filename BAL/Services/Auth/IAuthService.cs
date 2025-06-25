using DAL.DTOs.Auth;

namespace BAL.Services.Interfaces;

public interface IAuthService
{
    Task<string> Authorize(AuthRequestDto dto);
}