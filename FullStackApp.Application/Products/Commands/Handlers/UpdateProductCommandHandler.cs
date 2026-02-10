using MediatR;
using FullStackApp.Application.Interfaces;

namespace FullStackApp.Application.Products.Commands.Handlers;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _repo;

    public UpdateProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken ct)
    {
        var product = await _repo.GetByIdAsync(request.Id)
            ?? throw new Exception("Product not found");

        product.Name = request.Name;
        product.Price = request.Price;

        await _repo.UpdateAsync(product);
        return Unit.Value;
    }
}
