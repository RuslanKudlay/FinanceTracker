using DAL.Entities;
using DAL.Entities.Mono;
using DAL.EntitiesConfigure;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureCategory();
        modelBuilder.ConfigureTransaction();
        modelBuilder.ConfigureSetting();
        modelBuilder.ConfigureAccount();
        modelBuilder.ConfigureClient();
        modelBuilder.ConfigureUserCategory();
            
        base.OnModelCreating(modelBuilder);
    }
}