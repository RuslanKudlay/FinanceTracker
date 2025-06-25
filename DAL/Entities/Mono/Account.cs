using System.Text.Json.Serialization;

namespace DAL.Entities.Mono;

public class Account : BaseEntity
{
    [JsonPropertyName("id")]
    public string MonoId { get; set; }
    public string SendId { get; set; }
    public int CurrencyCode { get; set; }
    public string CashbackType { get; set; }
    public int Balance { get; set; }
    public int CreditLimit { get; set; }
    public List<string> MaskedPan { get; set; }
    public string Type { get; set; }
    public string Iban { get; set; }
    
    public Client Client { get; set; }
    public string ClientId { get; set; }
}