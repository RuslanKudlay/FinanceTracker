namespace DAL.Entities;

public class FamilyGroup : BaseEntity
{
    public string Name { get; set; }
    public List<User> Members { get; set; }
}