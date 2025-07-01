using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class UserConfigure
{
    public static void ConfigureUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users").HasKey(user => user.Id);

        modelBuilder.Entity<User>().Property(user => user.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<User>().Property(user => user.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<User>().Property(user => user.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<User>().Property(user => user.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");
        
        modelBuilder.Entity<User>().Property(user => user.FullName).HasColumnName("FullName").HasComment("Повне ім'я");
        modelBuilder.Entity<User>().Property(user => user.Email).HasColumnName("Email").HasComment("Email");
        modelBuilder.Entity<User>().Property(user => user.PasswordHash).HasColumnName("PasswordHash").HasComment("Хеш паролю");

        modelBuilder.Entity<User>().HasMany(trns => trns.Transactions).WithOne(user => user.User);
        modelBuilder.Entity<User>().HasMany(trns => trns.UserCategories).WithOne(user => user.User);
    } 
}