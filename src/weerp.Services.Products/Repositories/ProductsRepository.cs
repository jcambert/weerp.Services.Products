using MicroS_Common.Mongo;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using weerp.Services.Products.Domain;
using weerp.Services.Products.Queries;

namespace weerp.Services.Products.Repositories
{
    public class ProductsRepository : BaseRepository<Product>,IProductsRepository
    {

        public ProductsRepository(IMongoRepository<Product> repository):base (repository)
        {
            
        }


        public async Task<bool> ExistsAsync(string name)
            => await Repository.ExistsAsync(p => p.Name.ToLowerInvariant() == name.ToLowerInvariant());

        
        public async Task<PagedResult<Product>> BrowseAsync(BrowseProducts query)
            => await Repository.BrowseAsync(p =>p.Price >= query.PriceFrom && p.Price <= query.PriceTo, query);


        
    }
}
