using FullStackApp.Application.Common.Interfaces;
using MediatR;

namespace FullStackApp.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Id == request.Id);

        if (user == null)
            throw new Exception("User not found");

        user.UserName = request.UserName;
        user.Email = request.Email;
        user.Role = request.Role;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
