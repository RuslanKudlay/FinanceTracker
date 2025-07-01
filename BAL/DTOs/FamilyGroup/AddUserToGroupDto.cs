namespace DAL.DTOs.FamilyGroup;

public record AddUserToGroupDto
{
    public string Email { get; set; }
    public Guid FamilyGroupId { get; set; }
}