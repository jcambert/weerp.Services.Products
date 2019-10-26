using AutoMapper;
using MicroS_Common.Handlers;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{

    public sealed class BrowseProductsHandler : BaseBrowseHandler<Product, BrowseProducts, ProductDto, IProductsRepository>
    {
        public BrowseProductsHandler(IProductsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        
        
    }
}
