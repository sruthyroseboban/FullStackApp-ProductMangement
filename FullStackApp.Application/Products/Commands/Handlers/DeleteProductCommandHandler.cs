using MediatR;
using FullStackApp.Application.Interfaces;

namespace FullStackApp.Application.Products.Commands.Handlers;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _repo;

    public DeleteProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken ct)
    {
        await _repo.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
