using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class SettingConfigure
{
    public static void ConfigureSetting(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setting>().ToTable("Settings").HasKey(setting => setting.Id);

        modelBuilder.Entity<Setting>().Property(setting => setting.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<Setting>().Property(setting => setting.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<Setting>().Property(setting => setting.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<Setting>().Property(setting => setting.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");
        
        modelBuilder.Entity<Setting>().Property(setting => setting.Key).HasColumnName("Key").HasComment("Ключ налаштування");
        modelBuilder.Entity<Setting>().Property(setting => setting.Value).HasColumnName("Value").HasComment("Значення налаштування");
        modelBuilder.Entity<Setting>().Property(setting => setting.Description).HasColumnName("Description").HasComment("Опис");
        modelBuilder.Entity<Setting>()
            .Property(transaction => transaction.DataType)
            .HasColumnName("Type")
            .HasComment("Тип даних налаштування")
            .HasConversion<string>();

        modelBuilder.Entity<Setting>().HasData(new List<Setting>()
        {
            new ()
            {
                Id = Guid.NewGuid(),
                Key = "MonoToken",
                Value = "DefaultValue",
                Description = "Токен для інтеграції з монобанк",
                DataType = Enums.DataType.String,
                DateCreate = DateTime.Now,
                IsDeleted = false
            }
        });
    }
}