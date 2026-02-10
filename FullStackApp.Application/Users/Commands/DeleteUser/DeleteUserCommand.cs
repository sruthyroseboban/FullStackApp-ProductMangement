using MediatR;

namespace FullStackApp.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(int Id) : IRequest;
