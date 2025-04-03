using Shared.Models.UtilitiesShared;
using Transacciones.API.Entity;

namespace Transacciones.API.Interface.ITransactionRepository
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(long id);
        Task<IEnumerable<Transaction>> GetFilteredAsync(TransactionFilterParams filters);
        Task SaveChangesAsync();
    }
}
