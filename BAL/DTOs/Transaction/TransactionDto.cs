namespace DAL.DTOs;

public record TransactionDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
        
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public bool? IsDeleted { get; set; } = false;
    
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    
    public Guid? UserId { get; set; }
    public UserDto? User { get; set; }
    
    public Enums.TransactionType? Type { get; set; }
    public Enums.TransactionSource? Source { get; set; }
}