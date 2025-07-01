namespace DAL.Entities;

public class User : BaseEntity
{
    public string? FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    
    public List<Transaction> Transactions { get; set; }
    public List<UserCategory> UserCategories { get; set; }
    public bool IsVisibleInGroup { get; set; } = false;
}