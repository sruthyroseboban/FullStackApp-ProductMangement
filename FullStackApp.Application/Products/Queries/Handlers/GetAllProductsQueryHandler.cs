using MediatR;
using FullStackApp.Application.Products.Queries;
using FullStackApp.Application.Interfaces;
using FullStackApp.Application.DTOs;

namespace FullStackApp.Application.Products.Queries
{
    public class GetAllProductsQueryHandler
        : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(request.UserId);

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                DateOfManufacture = p.DateOfManufacture,
                DateOfExpiry = p.DateOfExpiry
            }).ToList();
        }
    }
}
