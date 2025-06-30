using System.Text.Json.Serialization;

namespace DAL;

public class BaseEntity
{
    [JsonIgnore]
    public Guid Id { get; set; }
        
    public DateTime? DateCreate { get; set; } = DateTime.UtcNow;
    public DateTime? DateUpdate { get; set; }
    public bool? IsDeleted { get; set; } = false;
}