using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class UserCategoryConfigure
{
    public static void ConfigureUserCategory(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserCategory>().ToTable("mm_users_categories", "many_to_many").HasKey(uc => new {uc.UserId, uc.CategoryId});
        modelBuilder.Entity<UserCategory>()
            .HasIndex(uc => new { uc.UserId, uc.CategoryId })
            .IsUnique();
    }
}