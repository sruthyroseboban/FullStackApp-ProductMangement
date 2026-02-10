using MediatR;
using FullStackApp.Application.Users.DTOs;

namespace FullStackApp.Application.Users.Queries.GetAllUsers;

public record GetAllUsersQuery : IRequest<List<UserDto>>;
