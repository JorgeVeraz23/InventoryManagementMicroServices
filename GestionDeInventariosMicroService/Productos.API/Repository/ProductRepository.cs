

using Microsoft.EntityFrameworkCore;
using Productos.API.Entity;
using Shared.Models.Repositories;

namespace Productos.API.Repository
{
    public class ProductRepository : BaseCrudRepository<Product, int>
    {
        private readonly ApplicationDbContext _context;


        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Productss.AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.StoredFiles)
                .ToListAsync();
        }


        public override async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Productss
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.StoredFiles)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
