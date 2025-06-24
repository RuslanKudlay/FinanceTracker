namespace DAL.DTOs.Auth;

public record AuthResponseDto
{
    public string Token { get; set; }
    public AuthResponseDto(string token)
    {
        Token = token;
    }
}