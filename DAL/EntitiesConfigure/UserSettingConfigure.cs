using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class UserSettingConfigure
{
    public static void ConfigureUserSetting(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserSetting>().ToTable("UserSettings").HasKey(user => user.Id);

        modelBuilder.Entity<UserSetting>().Property(setting => setting.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<UserSetting>().Property(setting => setting.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<UserSetting>().Property(setting => setting.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<UserSetting>().Property(setting => setting.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");
        
        modelBuilder.Entity<UserSetting>().Property(setting => setting.Key).HasColumnName("Key").HasComment("Ключ налаштування");
        modelBuilder.Entity<UserSetting>().Property(setting => setting.Value).HasColumnName("Value").HasComment("Значення налаштування");
        modelBuilder.Entity<UserSetting>().Property(setting => setting.Description).HasColumnName("Description").HasComment("Опис");
        modelBuilder.Entity<UserSetting>()
            .Property(transaction => transaction.DataType)
            .HasColumnName("Type")
            .HasComment("Тип даних налаштування")
            .HasConversion<string>();

        modelBuilder.Entity<UserSetting>().Property(setting => setting.UserId).HasColumnName("UserId").HasComment("Ключ користвача");
        modelBuilder.Entity<UserSetting>().Property(setting => setting.SettingId).HasColumnName("SettingId").HasComment("Ключ налаштування");
    }
}