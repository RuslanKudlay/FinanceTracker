namespace DAL.DTOs.Mono;

public record BalanceClientDto
{
    public Guid Id { get; set; }//id client
    public double Balance { get; set; }
    public string Card { get; set; }
    public string ClientName { get; set; }
}