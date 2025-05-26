using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class CategoryConfigure
{
    public static void ConfigureCategory(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("Categories").HasKey(category => category.Id);

        modelBuilder.Entity<Category>().Property(category => category.Id).HasColumnName("Id").HasComment("Первинний ключ");
        modelBuilder.Entity<Category>().Property(category => category.DateCreate).HasColumnName("DateCreate").HasComment("Дата створення");
        modelBuilder.Entity<Category>().Property(category => category.DateUpdate).HasColumnName("DateUpdate").HasComment("Дата оновлення");
        modelBuilder.Entity<Category>().Property(category => category.IsDeleted).HasColumnName("IsDeleted").HasComment("Прапор видалення");
        
        modelBuilder.Entity<Category>().Property(category => category.Name).HasColumnName("Name").HasComment("Назва категорії");

        modelBuilder.Entity<Category>().HasOne(category => category.User).WithMany(user => user.Categories);
    } 
}