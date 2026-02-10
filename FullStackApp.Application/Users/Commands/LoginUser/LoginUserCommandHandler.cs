using MediatR;
using FullStackApp.Application.Common.Interfaces;

namespace FullStackApp.Application.Users.Commands.LoginUser;

public class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, string>
{
    private readonly IApplicationDbContext _context;

    public LoginUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users
    .FirstOrDefault(u => u.Email == request.Email && u.PasswordHash == request.Password);

        if (user == null)
            throw new Exception("Invalid credentials");


        return "JWT_TOKEN_PLACEHOLDER";
    }
}


