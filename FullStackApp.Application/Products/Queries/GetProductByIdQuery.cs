using MediatR;
using FullStackApp.Application.DTOs;

namespace FullStackApp.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id)
        : IRequest<ProductDto>;
}
