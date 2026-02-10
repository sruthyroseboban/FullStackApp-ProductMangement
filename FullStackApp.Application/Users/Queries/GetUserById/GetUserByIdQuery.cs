using MediatR;
using FullStackApp.Application.Users.DTOs;

namespace FullStackApp.Application.Users.Queries.GetUserById;

public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
