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
        
        modelBuilder.Entity<Account>().Property(account => account.CurrencyCode).HasColumnName("CurrencyCode").HasComment("Код валюти");
        modelBuilder.Entity<Account>().Property(account => account.CashbackType).HasColumnName("CashbackType").HasComment("UAH, DOL, EURO...");
        modelBuilder.Entity<Account>().Property(account => account.Balance).HasColumnName("Balance").HasComment("Баланс");
        modelBuilder.Entity<Account>().Property(account => account.CreditLimit).HasColumnName("CreditLimit").HasComment("Кредитний ліміт");
        modelBuilder.Entity<Account>().Property(account => account.Type).HasColumnName("Type").HasComment("Тип карти");
        modelBuilder.Entity<Account>().Property(account => account.Iban).HasColumnName("Iban").HasComment("Номер IBAN");
        
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Client)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.ClientId);

        modelBuilder.Entity<Account>().HasMany(account => account
            .CardMaskedPans).WithOne(card => card.Account);
    }
}