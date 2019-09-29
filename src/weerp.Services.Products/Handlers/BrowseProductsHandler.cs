using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Linq;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Dto;
using weerp.Services.Products.Queries;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{
    /*public abstract class BaseBrowseHandler<TDomain,TBrowse,TDto> : IQueryHandler<TBrowse,PagedResult<TDto>>
        where TBrowse : PagedQueryBase, IQuery<PagedResult<TDto>>
        where TDomain : BaseEntity
    {
        public BaseBrowseHandler(IBrowseRepository<TDomain, TBrowse, TDto> repo,IMapper mapper)
        {
            Repository = repo;
            Mapper = mapper;
        }
        public IBrowseRepository<TDomain, TBrowse, TDto> Repository { get; private set; }
        public IMapper Mapper { get; private set; }

        public async Task<PagedResult<TDto>> HandleAsync(TBrowse query)
        {
            var pagedResult = await Repository.BrowseAsync(query);
            var products = pagedResult.Items.Select(p => Mapper.Map<TDomain,TDto>(p)).ToList();

            return PagedResult<TDto>.From(pagedResult, products);
        }

    }*/
    /*
    public sealed class BrowseProductsHandler : IQueryHandler<BrowseProducts, PagedResult<ProductDto>>
    {
        private readonly IProductsRepository _productsRepository;

        public BrowseProductsHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;

        public async Task<PagedResult<ProductDto>> HandleAsync(BrowseProducts query)
        {
            var pagedResult = await _productsRepository.BrowseAsync(query);
            var products = pagedResult.Items.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Vendor = p.Vendor,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList();

            return PagedResult<ProductDto>.From(pagedResult, products);
        }
    }*/
    public sealed class BrowseProductsHandler : BaseBrowseHandler<Product, BrowseProducts, ProductDto, IProductsRepository>
    {
        public BrowseProductsHandler(IProductsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        
        
    }
}
