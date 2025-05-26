namespace DAL.Entities;

public class Transaction : BaseEntity
{
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    
    public Enums.TransactionType? Type { get; set; }
    public Enums.TransactionSource? Source { get; set; }
}