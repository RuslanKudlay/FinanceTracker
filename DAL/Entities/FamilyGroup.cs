namespace DAL.Entities;

public class FamilyGroup : BaseEntity
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public bool IsEnabledGroup { get; set; } = false;
}