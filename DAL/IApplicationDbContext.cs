using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}