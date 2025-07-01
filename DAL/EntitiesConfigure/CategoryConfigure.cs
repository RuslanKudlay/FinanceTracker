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

        modelBuilder.Entity<Category>().HasData(new List<Category>()
        {
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Сплата громадського транспорту, таксі",
                Name = "Транспорт"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Сплата оренди за квартиру власнику",
                Name = "Оренда квартири"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Електроенергія, тепло, ОСББ/ЖЕК, дофомон, ліфт, вода...",
                Name = "Комунальні платежі"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Оплата за товари для харчування",
                Name = "Харчування"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Оплата за одяг, або інші речі (КОМФІ, ТА-ДА, АВРОРА)",
                Name = "Шопінг"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Ремонт, ТО, заправка...",
                Name = "Автомобіль"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Оплата тільки за одяг",
                Name = "Одяг"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = string.Empty,
                Name = "Краса та гігієна"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Лікарні, аптеки",
                Name = "Здоров'я"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                IsDeleted = false,
                Description = "Покупки для підвищення комфорту в житлі",
                Name = "Житло"
            }
        });
    } 
}