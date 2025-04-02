

using Microsoft.EntityFrameworkCore;
using Productos.API.Entity;
using Shared.Models.Repositories;

namespace Productos.API.Repository
{
    public class ProductRepository : BaseCrudRepository<Product, int>
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
