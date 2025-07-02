namespace DAL.DTOs.Mono;

public record BalanceClientDto
{
    public Guid Id { get; set; }//id client
    public double Balance { get; set; }
    public List<string> Cards { get; set; }
    public string ClientName { get; set; }
}