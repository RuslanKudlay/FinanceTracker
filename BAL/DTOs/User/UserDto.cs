using DAL.DTOs.FamilyGroup;

namespace DAL.DTOs;

public record UserDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string? FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public List<TransactionDto> Transactions { get; set; }
    public List<CategoryDto> Categories { get; set; }
    
    public Guid? FamilyGroupId { get; set; }
    public FamilyGroupDto FamilyGroup { get; set; }
    public bool IsVisibleInGroup { get; set; }
}