using System.Text.Json.Serialization;

namespace DAL.Entities.Mono;

public class Client : BaseEntity
{
    [JsonPropertyName("clientId")]
    public string ClientId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("webHookUrl")]
    public string WebHookUrl { get; set; }
    
    [JsonPropertyName("permissions")]
    public string Permissions { get; set; }
    
    [JsonPropertyName("accounts")]
    public List<Account> Accounts { get; set; }
}