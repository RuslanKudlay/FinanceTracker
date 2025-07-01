namespace DAL.Entities;

public class UserFamilyGroup
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid FamilyGroupId { get; set; }
    public FamilyGroup FamilyGroup { get; set; }
}