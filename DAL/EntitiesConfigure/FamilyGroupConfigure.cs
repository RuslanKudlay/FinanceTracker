using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class FamilyGroupConfigure
{
    public static void ConfigureFamilyGroup(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FamilyGroup>().ToTable("FamilyGroups").HasKey(fg => fg.Id);

        modelBuilder.Entity<FamilyGroup>().Property(fg => fg.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<FamilyGroup>().Property(fg => fg.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<FamilyGroup>().Property(fg => fg.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<FamilyGroup>().Property(fg => fg.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");
        
        modelBuilder.Entity<FamilyGroup>().Property(fg => fg.Name).HasColumnName("Name").HasComment("Назва групи");
        modelBuilder.Entity<FamilyGroup>().Property(fg => fg.Code).HasColumnName("Code").HasComment("Код групи");
        modelBuilder.Entity<FamilyGroup>().Property(fg => fg.IsEnabledGroup).HasColumnName("IsEnabledGroup").HasComment("Чи ввімкнена група");
    }
}