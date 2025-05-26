using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class TransactionConfigure
{
    public static void ConfigureTransaction(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().ToTable("Transactions").HasKey(transaction => transaction.Id);

        modelBuilder.Entity<Transaction>().Property(transaction => transaction.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");
        
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.TransactionDate).HasColumnName("TransactionDate").HasComment("Дата транзакції");
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.Amount).HasColumnName("Amount").HasComment("Сума транзакції");
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.Note).HasColumnName("Note").HasComment("Коментар до транзакції");
        modelBuilder.Entity<Transaction>()
            .Property(transaction => transaction.Type)
            .HasColumnName("Type")
            .HasComment("Тип транзакції")
            .HasConversion<string>();
        
        modelBuilder.Entity<Transaction>()
            .Property(transaction => transaction.Source)
            .HasColumnName("Source")
            .HasComment("Джерело транзакції")
            .HasConversion<string>();
    }
}