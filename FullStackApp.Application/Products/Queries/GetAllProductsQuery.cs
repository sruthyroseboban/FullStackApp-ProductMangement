using MediatR;
using FullStackApp.Application.DTOs;

namespace FullStackApp.Application.Products.Queries
{
    public record GetAllProductsQuery(int UserId)
        : IRequest<List<ProductDto>>;
}
