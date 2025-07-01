namespace DAL.Entities;

public class Setting: BaseEntity
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Description { get; set; }
    public Enums.DataType DataType { get; set; }
}