namespace DAL.DTOs;

public record UserDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string? FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public List<TransactionDto> Transactions { get; set; }
    public List<CategoryDto> Categories { get; set; }
}