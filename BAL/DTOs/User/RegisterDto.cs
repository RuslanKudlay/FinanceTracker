namespace DAL.DTOs;

public record RegisterDto
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
}