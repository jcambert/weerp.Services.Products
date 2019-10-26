using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;

namespace weerp.Services.Products.Repositories
{

    public interface IProductsRepository: IBrowseRepository<Product,BrowseProducts,ProductDto>
    {

        Task<bool> ExistsAsync(string name);
        Task<PagedResult<Product>> BrowseAsync(BrowseProducts query);

    }
}
