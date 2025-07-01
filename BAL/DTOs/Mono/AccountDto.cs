using System.Text.Json.Serialization;
using DAL.Entities.Mono;

namespace DAL.DTOs.Mono;

public class AccountDto
{
    [JsonPropertyName("currencyCode")]
    public int CurrencyCode { get; set; }

    [JsonPropertyName("cashbackType")]
    public string? CashbackType { get; set; }

    [JsonPropertyName("balance")]
    public int Balance { get; set; }

    [JsonPropertyName("creditLimit")]
    public int CreditLimit { get; set; }

    
    [JsonPropertyName("maskedPan")]
    public List<string> MaskedPansRaw { get; set; }

    [JsonIgnore]
    public List<CardMaskedPan> CardMaskedPans { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("iban")]
    public string Iban { get; set; }

    public Guid ClientId { get; set; }

    [JsonIgnore]
    public Client Client { get; set; }
}