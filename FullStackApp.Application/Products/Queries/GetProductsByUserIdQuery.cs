using MediatR;
using FullStackApp.Application.DTOs;

namespace FullStackApp.Application.Products.Queries;

public record GetProductsByUserIdQuery(int UserId)
    : IRequest<List<ProductDto>>;
