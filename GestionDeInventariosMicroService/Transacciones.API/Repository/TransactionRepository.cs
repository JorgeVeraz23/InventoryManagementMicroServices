using Microsoft.EntityFrameworkCore;
using Shared.Models.UtilitiesShared;
using Transacciones.API.Entity;
using Transacciones.API.Interface.ITransactionRepository;

namespace Transacciones.API.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;

        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transaction
            .AsNoTracking()
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(long id)
        {
            return await _context.Transaction
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Transaction>> GetFilteredAsync(TransactionFilterParams filters)
        {
            var query = _context.Transaction.AsQueryable();

            if (filters.ProductoId.HasValue)
            {
                query = query.Where(t => t.ProductId == filters.ProductoId.Value);
            }

            if (filters.TipoTransaccion.HasValue)
            {
                query = query.Where(t => t.Type == filters.TipoTransaccion.Value);
            }

            if (filters.FromDate.HasValue)
            {
                query = query.Where(t => t.CreatedAt >= filters.FromDate.Value);
            }

            if (filters.ToDate.HasValue)
            {
                query = query.Where(t => t.CreatedAt <= filters.ToDate.Value);
            }

            return await query
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public  async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
