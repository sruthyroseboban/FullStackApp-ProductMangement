using MediatR;
using Microsoft.EntityFrameworkCore;
using FullStackApp.Application.Common.Interfaces;

namespace FullStackApp.Application.Users.Commands.LoginUser;

public class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginUserCommandHandler(
        IApplicationDbContext context,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(
                u => u.Email == request.Email,
                cancellationToken);

        if (user == null)
            throw new Exception("Invalid credentials");

        // ⚠️ Plain text check for now (we'll hash later)
        if (user.PasswordHash != request.Password)
            throw new Exception("Invalid credentials");

        var token = _jwtTokenGenerator.GenerateToken(
            user.Id,
            user.Email,
            user.Role
        );

        return token;
    }
}
