using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using BAL.Helpers;
using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.Auth;
using DAL.Entities;
using DAL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BAL.Services;

public class AuthService : IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _context;

    public AuthService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }
    
    public async Task<string> Authorize(AuthRequestDto dto)
    {
        var hash = PasswordHesher.GetHash(dto.Password);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && u.PasswordHash == hash);
        
        await ValidateLogin(dto, user);

        ClaimsIdentity claimsIdentity = GetByUser(user);
        
        var key = AuthOptions.GetSymmetricSecurityKey();
        var now = DateTime.Now;
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: claimsIdentity.Claims,
            expires: now.AddMinutes(AuthOptions.LIFETIME),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
    
    private ClaimsIdentity GetByUser(User user)
    {
        string ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("session", Guid.NewGuid().ToString())
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }

    private async Task ValidateLogin(AuthRequestDto dto, User user)
    {
        var isExistUser = await _context.Users.AnyAsync(u => u.Email == dto.Email);

        if (!isExistUser)
        {
            throw new CustomException($"Користувача з таким Email: {dto.Email} не знайдемо!");
        }
        

        if (user is null)
        {
            throw new CustomException("Не вірний логін або пароль!");
        }
    }
}