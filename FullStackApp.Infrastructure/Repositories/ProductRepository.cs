using FullStackApp.Application.Interfaces;
using FullStackApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FullStackApp.Infrastructure.Data;

namespace FullStackApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _ctx;

    public ProductRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Product>> GetAllAsync(int userId)
        => await _ctx.Products
            .Where(p => p.CreatedByUserId == userId)
            .ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _ctx.Products.FindAsync(id);

    public async Task AddAsync(Product product)
    {
        _ctx.Products.Add(product);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _ctx.Products.Update(product);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var p = await GetByIdAsync(id);
        if (p != null)
        {
            _ctx.Products.Remove(p);
            await _ctx.SaveChangesAsync();
        }
    }
}
