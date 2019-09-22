using MicroS_Common.Mongo;
using MicroS_Common.Types;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using weerp.Services.Products.Domain;
using weerp.Services.Products.Queries;

namespace weerp.Services.Products.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoRepository<Product> _repository;

        public ProductsRepository(IMongoRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetAsync(Guid id)
            => await _repository.GetAsync(id);
        public async Task<Product> GetAsync(Expression<Func<Product, bool>> predicate)
            => await _repository.GetAsync(predicate);

        public async Task<bool> ExistsAsync(Guid id)
            => await _repository.ExistsAsync(p => p.Id == id);

        public async Task<bool> ExistsAsync(string name)
            => await _repository.ExistsAsync(p => p.Name.ToLowerInvariant() == name.ToLowerInvariant());

        public async  Task<bool> ExistsAsync(Expression<Func<Product, bool>> predicate)
            => await _repository.ExistsAsync(predicate);
      
        
        public async Task<PagedResult<Product>> BrowseAsync(BrowseProducts query)
            => await _repository.BrowseAsync(p =>
                p.Price >= query.PriceFrom && p.Price <= query.PriceTo, query);

        public async Task AddAsync(Product product)
            => await _repository.AddAsync(product);

        public async Task UpdateAsync(Product product)
            => await _repository.UpdateAsync(product);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);

        
    }
}
