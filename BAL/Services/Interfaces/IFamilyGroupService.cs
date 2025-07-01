using BAL.Services.Base;
using DAL.DTOs.FamilyGroup;
using DAL.Entities;

namespace BAL.Services.Interfaces;

public interface IFamilyGroupService
{
    Task<bool> CreateAsync(CreateGroupDto item);
    Task<bool> AddUserToGroupAsync(AddUserToGroupDto dto);
}