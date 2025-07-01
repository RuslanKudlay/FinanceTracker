namespace DAL.Entities.Mono;

public class CardMaskedPan : BaseEntity
{
    public string MaskedPan { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}