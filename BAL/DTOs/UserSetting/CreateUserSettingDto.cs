namespace DAL.DTOs.UserSetting;

public record CreateUserSettingDto
{
    public Guid UserId { get; set; }
    public Guid SettingId { get; set; }
    public string Value { get; set; }
}