using DAL.Entities.Mono;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class ClientConfigure
{
    public static void ConfigureClient(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().ToTable("Clients").HasKey(account => account.Id);

        modelBuilder.Entity<Client>().Property(client => client.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<Client>().Property(client => client.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<Client>().Property(client => client.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<Client>().Property(client => client.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");

        modelBuilder.Entity<Client>().Property(client => client.Name).HasColumnName("Name").HasComment("Name");
        modelBuilder.Entity<Client>().Property(client => client.WebHookUrl).HasColumnName("WebHookUrl").HasComment("WebHookUrl");
        modelBuilder.Entity<Client>().Property(client => client.Permissions).HasColumnName("Permissions").HasComment("Permissions");
        
        modelBuilder.Entity<Client>().Property(client => client.UserId).HasColumnName("UserId").HasComment("UserId");
        
        modelBuilder.Entity<Client>()
            .HasKey(client => client.Id);

        modelBuilder.Entity<Client>().HasMany(client => client.Accounts).WithOne(account => account.Client);

    }
}