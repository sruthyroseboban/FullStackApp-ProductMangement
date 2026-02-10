using MediatR;
using Microsoft.EntityFrameworkCore;
using FullStackApp.Application.Common.Interfaces;
using FullStackApp.Application.Users.DTOs;

namespace FullStackApp.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler
    : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllUsersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Role = u.Role
            })
            .ToListAsync(cancellationToken);
    }
}
