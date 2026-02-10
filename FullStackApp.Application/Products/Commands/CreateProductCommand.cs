using MediatR;

namespace FullStackApp.Application.Products.Commands;

public record CreateProductCommand(
    string Name,
    decimal Price,
    DateTime DateOfManufacture,
    DateTime DateOfExpiry,
    int UserId
) : IRequest<int>;
