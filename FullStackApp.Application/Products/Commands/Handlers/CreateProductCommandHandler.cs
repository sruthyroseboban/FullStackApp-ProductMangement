using MediatR;
using FullStackApp.Application.Interfaces;
using FullStackApp.Domain.Entities;

namespace FullStackApp.Application.Products.Commands.Handlers;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repo;

    public CreateProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            DateOfManufacture = request.DateOfManufacture,
            DateOfExpiry = request.DateOfExpiry,
            CreatedByUserId = request.UserId
        };

        await _repo.AddAsync(product);
        return product.Id;
    }
}
