using FullStackApp.Application.Common.Interfaces;
using FullStackApp.Application.Users.Commands.DeleteUser;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            throw new Exception("User not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}
