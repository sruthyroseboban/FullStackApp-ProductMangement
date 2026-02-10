using Microsoft.EntityFrameworkCore;
using FullStackApp.Domain.Entities;

namespace FullStackApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
