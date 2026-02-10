using MediatR;
using Microsoft.EntityFrameworkCore;
using FullStackApp.Application.Common.Interfaces;
using FullStackApp.Application.Users.DTOs;

namespace FullStackApp.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IApplicationDbContext _context;

    public GetUserByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(u => u.Id == request.Id)
            .Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Role = u.Role
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
            throw new Exception("User not found");

        return user;
    }
}
