using AutoMapper;
using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs.FamilyGroup;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services;

public class FamilyGroupService : IFamilyGroupService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IEmailService _emailService;

    public FamilyGroupService(ApplicationDbContext dbContext, IEmailService emailService)
    {
        _dbContext = dbContext;
        _emailService = emailService;
    }

    public async Task<bool> CreateAsync(CreateGroupDto item)
    {
        var familyGroup = CreateInstanceFamilyGroup(item);
        await _dbContext.FamilyGroups.AddAsync(familyGroup);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddUserToGroupAsync(AddUserToGroupDto dto)
    {
        var familyGroup = await _dbContext.FamilyGroups.FirstOrDefaultAsync(group => group.Id == dto.FamilyGroupId);
        
        var emailData = await GenarateBodyAndSubjectAsync(dto, familyGroup);
        
        var isSended = await _emailService.SendEmailAsync(dto.Email, emailData.Item1, emailData.Item2);
        if (isSended && !await _dbContext.Users.AnyAsync(user => user.Email == dto.Email))
        {
            return await AddUser(dto);
        }

        return false;
    }

    private async Task<(string, string)> GenarateBodyAndSubjectAsync(AddUserToGroupDto dto, FamilyGroup familyGroup)
    {
        string subject = $"Запрошення до групи: {familyGroup.Name}";
        string body = $"Привіт, тебе запросили до сімейного бюджету. Зареєструйся тут: http://localhost:4200/referal-link?email={dto.Email}" +
                      $"" +
                      $"" +
                      $"" +
                      $"Не переходь по посиланню, якщо не володієї інформацією!";
        return (subject, body);
    }

    private async Task<bool> AddUser(AddUserToGroupDto dto)
    {
        var userId = Guid.NewGuid();
        await _dbContext.Users.AddAsync(new User() { Id = userId, Email = dto.Email });
        await _dbContext.UserFamilyGroups.AddAsync(new UserFamilyGroup()
            { UserId = userId, FamilyGroupId = dto.FamilyGroupId });
        
        return await _dbContext.SaveChangesAsync() > 0;
    }

    private FamilyGroup CreateInstanceFamilyGroup(CreateGroupDto item)
    {
        return new FamilyGroup()
            { Id = Guid.NewGuid(), Name = item.Name, DateCreate = DateTime.Now };
    }
}