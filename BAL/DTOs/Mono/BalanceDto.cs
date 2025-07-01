namespace DAL.DTOs.Mono;

public record BalanceDto
{
    public double TotalBalance { get; set; }
    public List<BalanceClientDto> BalanceClients { get; set; }
};