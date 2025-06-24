using DAL.Entities;
using DAL.EntitiesConfigure;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureCategory();
        modelBuilder.ConfigureTransaction();
            
        base.OnModelCreating(modelBuilder);
    }
}