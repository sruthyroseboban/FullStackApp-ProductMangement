using FullStackApp.Domain.Entities;

namespace FullStackApp.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(int userId);
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}
