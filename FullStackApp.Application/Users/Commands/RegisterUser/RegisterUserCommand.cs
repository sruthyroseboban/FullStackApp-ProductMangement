using MediatR;

namespace FullStackApp.Application.Users.Commands.RegisterUser;

public record RegisterUserCommand(
    string UserName,
    string Email,
    string Password
) : IRequest<int>;
