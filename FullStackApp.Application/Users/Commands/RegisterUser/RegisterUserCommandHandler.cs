using MediatR;
using Microsoft.EntityFrameworkCore;
using FullStackApp.Domain.Entities;
using FullStackApp.Application.Common.Interfaces;

namespace FullStackApp.Application.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, int>
{
    private readonly IApplicationDbContext _context;

    public RegisterUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var exists = await _context.Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);

        if (exists)
            throw new Exception("User already exists");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            PasswordHash = request.Password,
            Role = "User"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
