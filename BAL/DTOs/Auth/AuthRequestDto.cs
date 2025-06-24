namespace DAL.DTOs.Auth;

public record AuthRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}