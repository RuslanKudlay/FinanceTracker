namespace DAL.Entities.Mono;

public class Client : BaseEntity
{
    public string ClientId { get; set; }
    public string Name { get; set; }
    public string WebHookUrl { get; set; }
    public string Permissions { get; set; }
    public List<Account> Accounts { get; set; }
}