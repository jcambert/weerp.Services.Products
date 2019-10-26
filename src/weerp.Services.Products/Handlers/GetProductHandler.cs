using MicroS_Common.Handlers;
using System.Threading.Tasks;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{
    public sealed class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;

        public async Task<ProductDto> HandleAsync(GetProduct query)
        {
            var product = await _productsRepository.GetAsync(query.Id);

            return product == null ? null : new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Vendor = product.Vendor,
                Price = product.Price
            };
        }
    }
}