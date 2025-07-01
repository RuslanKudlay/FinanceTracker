namespace DAL.Entities.Mono;

public class Client : BaseEntity
{
    public string Name { get; set; }
    public string WebHookUrl { get; set; }
    public string Permissions { get; set; }
    public List<Account> Accounts { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}