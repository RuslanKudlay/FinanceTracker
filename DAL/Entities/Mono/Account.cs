namespace DAL.Entities.Mono;

public class Account : BaseEntity
{
    public int CurrencyCode { get; set; }
    public string? CashbackType { get; set; }
    public int Balance { get; set; }
    public int CreditLimit { get; set; }
    public List<CardMaskedPan> CardMaskedPans { get; set; }
    public string Type { get; set; }
    public string Iban { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}