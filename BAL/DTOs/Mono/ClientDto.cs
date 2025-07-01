using System.Text.Json.Serialization;
using DAL.Entities;
using DAL.Entities.Mono;

namespace DAL.DTOs.Mono;

public class ClientDto
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("webHookUrl")]
    public string WebHookUrl { get; set; }
    
    [JsonPropertyName("permissions")]
    public string Permissions { get; set; }
    
    [JsonPropertyName("accounts")]
    public List<AccountDto> Accounts { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}