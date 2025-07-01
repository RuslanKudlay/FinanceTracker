using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntitiesConfigure;

public static class UserFamilyGroupConfigure
{
    public static void ConfigureUserFamilyGroup(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserFamilyGroup>().ToTable("mm_users_groups", "many_to_many").HasKey(uc => new {uc.UserId, uc.FamilyGroupId});
        modelBuilder.Entity<UserFamilyGroup>()
            .HasIndex(uc => new { uc.UserId, uc.FamilyGroupId })
            .IsUnique();
    }
}