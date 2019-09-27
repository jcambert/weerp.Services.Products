using MicroS_Common.Repository;
using MicroS_Common.Types;
using System;
using System.Threading.Tasks;
using weerp.Services.Products.Domain;
using weerp.Services.Products.Queries;

namespace weerp.Services.Products.Repositories
{
    public interface IProductsRepository:IRepository<Product>
    {

        Task<bool> ExistsAsync(string name);
        Task<PagedResult<Product>> BrowseAsync(BrowseProducts query);

    }
}
