using MediatR;
using FullStackApp.Application.Products.Queries;
using FullStackApp.Application.Interfaces;
using FullStackApp.Application.DTOs;

namespace FullStackApp.Application.Products.Queries
{
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id)
                ?? throw new Exception("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                DateOfManufacture = product.DateOfManufacture,
                DateOfExpiry = product.DateOfExpiry
            };
        }
    }
}
