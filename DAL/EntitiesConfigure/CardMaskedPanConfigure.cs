using DAL.Entities.Mono;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class CardMaskedPanConfigure
{
    public static void ConfigureCardMaskedPan(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardMaskedPan>().ToTable("CardMaskedPans").HasKey(card => card.Id);
        
        modelBuilder.Entity<CardMaskedPan>().Property(card => card.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<CardMaskedPan>().Property(card => card.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<CardMaskedPan>().Property(card => card.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<CardMaskedPan>().Property(card => card.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");
        
        modelBuilder.Entity<CardMaskedPan>().Property(card => card.MaskedPan).HasColumnName("MaskedPan").HasComment("Маска карти");

        modelBuilder.Entity<CardMaskedPan>().HasOne(card => card.Account).WithMany(account => account.CardMaskedPans);
    }
}