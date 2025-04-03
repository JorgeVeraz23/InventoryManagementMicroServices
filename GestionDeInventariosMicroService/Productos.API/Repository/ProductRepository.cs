

using Microsoft.EntityFrameworkCore;
using Productos.API.Entity;
using Productos.API.Interface;
using Shared.Models.Repositories;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Repository
{
    public class ProductRepository : BaseCrudRepository<Product, int>, IProductRepository
    {
        private readonly new ApplicationDbContext _context;


        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

    

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Productss.AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.StoredFiles)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }


        public override async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Productss
                .Include(p => p.Category)
                .Include(p => p.StoredFiles)
                .Where (x => x.IsActive == true)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetFilteredAsync(ProductFilterParams filters)
        {
            var query = _context.Productss
                .Include(p => p.Category)
                .Include(p => p.StoredFiles)
                .AsNoTracking()
                .Where(p => p.IsActive);

            
            if (!string.IsNullOrWhiteSpace(filters.Search))
            {
                query = query.Where(p =>
                    p.Name.Contains(filters.Search) ||
                    (p.Description != null && p.Description.Contains(filters.Search)));
            }

           
            if (filters.FromDate.HasValue)
            {
                query = query.Where(p => p.CreatedAt >= filters.FromDate.Value);
            }

           
            if (filters.ToDate.HasValue)
            {
                query = query.Where(p => p.CreatedAt <= filters.ToDate.Value);
            }

           
            query = filters.SortBy?.ToLower() switch
            {
                "stock" => filters.Desc ? query.OrderByDescending(p => p.Stock) : query.OrderBy(p => p.Stock),
                "precio" => filters.Desc ? query.OrderByDescending(p => p.Precio) : query.OrderBy(p => p.Precio),
                _ => filters.Desc ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name)
            };

            
            return await query
                .Skip((filters.Page - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();
        }

    }
}
