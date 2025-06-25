namespace DAL.DTOs;

public record CategoryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
        
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public bool? IsDeleted { get; set; } = false;
    public string Name { get; set; }
    public Guid? UserId { get; set; }
    public UserDto? User { get; set; }
}