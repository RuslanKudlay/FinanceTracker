namespace DAL;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
        
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public bool? IsDeleted { get; set; } = false;
}