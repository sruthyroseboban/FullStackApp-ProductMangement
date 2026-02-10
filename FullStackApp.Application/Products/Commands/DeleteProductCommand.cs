using MediatR;

namespace FullStackApp.Application.Products.Commands;

public record DeleteProductCommand(int Id) : IRequest;
