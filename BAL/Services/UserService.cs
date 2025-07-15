using AutoMapper;
using BAL.Helpers;
using BAL.Services.Base;
using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs;
using DAL.Entities;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class UserService : IUserService//: BaseService<User, UserDto>, IUserService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        return _mapper.Map<List<UserDto>>(await _dbContext.Users.ToListAsync());
    }

    public async Task<bool> Register(RegisterDto dto)
    {
        var existUserByEmail = await _dbContext.Users.AnyAsync(u => u.Email == dto.Email);

        if (existUserByEmail)
        {
            throw new CustomException($"Користувач з email {dto.Email} вже існує!");
        }

        var hash = PasswordHesher.GetHash(dto.Password);

        var userId = Guid.NewGuid();
        var groupId = Guid.NewGuid();
        
        await _dbContext.FamilyGroups.AddAsync(new FamilyGroup() { Id = groupId, Name = "Моя персональная", Code = "Personal", DateCreate = DateTime.Now, IsDeleted = false});
        await _dbContext.Users.AddAsync(new User() { Id = userId, Email = dto.Email, PasswordHash = hash, FullName = dto.FullName, IsVisibleInGroup = true});
        await _dbContext.UserFamilyGroups.AddAsync(new UserFamilyGroup(){ UserId = userId, FamilyGroupId = groupId});
        return await _dbContext.SaveChangesAsync() > 0;

    }
}