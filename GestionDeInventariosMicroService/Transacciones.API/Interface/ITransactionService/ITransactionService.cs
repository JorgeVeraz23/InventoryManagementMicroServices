using Shared.Models.UtilitiesShared;
using Transacciones.API.Dto;

namespace Transacciones.API.Interface.ITransactionService
{
    public interface ITransactionService
    {
        Task<ApiResponse> RegisterAsync(TransactionCreateDTO dto);
        Task<IEnumerable<TransactionResponseDto>> GetAllAsync();
        Task<TransactionResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<TransactionResponseDto>> GetFilteredAsync(TransactionFilterParams filters);
        

    }

}
