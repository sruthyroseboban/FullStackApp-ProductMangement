using MediatR;

namespace FullStackApp.Application.Products.Commands;

public record UpdateProductCommand(
    int Id,
    string Name,
    decimal Price
) : IRequest;
