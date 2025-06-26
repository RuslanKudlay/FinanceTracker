using System.Text.Json.Serialization;

namespace DAL.Entities.Mono;

public class Account : BaseEntity
{
    [JsonPropertyName("id")]
    public string MonoId { get; set; }
    
    
    [JsonPropertyName("sendId")]
    public string SendId { get; set; }
    
    
    [JsonPropertyName("currencyCode")]
    public int CurrencyCode { get; set; }
    
    [JsonPropertyName("cashbackType")]
    public string CashbackType { get; set; }
    
    [JsonPropertyName("balance")]
    public int Balance { get; set; }
    
    [JsonPropertyName("creditLimit")]
    public int CreditLimit { get; set; }
    
    [JsonPropertyName("maskedPan")]
    public List<string> MaskedPan { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    
    [JsonPropertyName("iban")]
    public string Iban { get; set; }
    
    public Client Client { get; set; }
    
    public string ClientId { get; set; }
}