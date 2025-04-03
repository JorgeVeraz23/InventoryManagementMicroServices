using Productos.API.Entity;
using Shared.Models.Repositories.Interfaces;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Interface
{
    public interface IProductRepository : ICrudRepository<Product, int>
    {
        Task<IEnumerable<Product>> GetFilteredAsync(ProductFilterParams filters);
     
    }
}
