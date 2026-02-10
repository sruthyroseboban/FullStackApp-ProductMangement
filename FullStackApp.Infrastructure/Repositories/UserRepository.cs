using FullStackApp.Application.Interfaces;
using FullStackApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FullStackApp.Infrastructure.Data;

namespace FullStackApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _ctx;

    public UserRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<User>> GetAllAsync()
        => await _ctx.Users.ToListAsync();

    public async Task<User?> GetByEmailAsync(string email)
        => await _ctx.Users.FirstOrDefaultAsync(x => x.Email == email);

    public async Task AddAsync(User user)
    {
        _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();
    }
}
