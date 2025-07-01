namespace DAL.DTOs.FamilyGroup;

public record FamilyGroupDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<UserDto> Members { get; set; }
}