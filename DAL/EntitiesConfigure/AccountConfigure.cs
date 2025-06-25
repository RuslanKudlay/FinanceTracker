using System.Text.Json;
using DAL.Entities.Mono;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class AccountConfigure
{
    public static void ConfigureAccount(this ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Account>().ToTable("Accounts").HasKey(account => account.Id);

        modelBuilder.Entity<Account>().Property(account => account.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<Account>().Property(account => account.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<Account>().Property(account => account.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<Account>().Property(account => account.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");

        modelBuilder.Entity<Account>().Property(account => account.MonoId).HasColumnName("MonoId").HasComment("Id акаунту в mono");
        modelBuilder.Entity<Account>().Property(account => account.SendId).HasColumnName("SendId").HasComment("SendId");
        modelBuilder.Entity<Account>().Property(account => account.CurrencyCode).HasColumnName("CurrencyCode").HasComment("Код валюти");
        modelBuilder.Entity<Account>().Property(account => account.CashbackType).HasColumnName("CashbackType").HasComment("UAH, DOL, EURO...");
        modelBuilder.Entity<Account>().Property(account => account.Balance).HasColumnName("Balance").HasComment("Баланс");
        modelBuilder.Entity<Account>().Property(account => account.CreditLimit).HasColumnName("CreditLimit").HasComment("Кредитний ліміт");
        modelBuilder.Entity<Account>().Property(account => account.Type).HasColumnName("Type").HasComment("Тип карти");
        modelBuilder.Entity<Account>().Property(account => account.Iban).HasColumnName("Iban").HasComment("Номер IBAN");
        
        modelBuilder.Entity<Account>()
            .HasOne(account => account.Client)
            .WithMany(client => client.Accounts)
            .HasForeignKey(account => account.ClientId)
            .HasPrincipalKey(client => client.ClientId);

        modelBuilder.Entity<Account>()
            .Property(account => account.MaskedPan)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
            .HasColumnName("MaskedPan")
            .HasComment("Масковані номери карт");


    }
}