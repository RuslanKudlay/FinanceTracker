namespace DAL.DTOs.Setting;

public record SettingDto
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string Description { get; set; }
    public Enums.DataType DataType { get; set; }
}