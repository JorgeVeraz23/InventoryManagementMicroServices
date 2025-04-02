using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.UtilitiesShared;

namespace Shared.Models.Services.Interfaces
{
    public interface ICrudService<TDto, TResponse, TKey>
    {
        Task<IEnumerable<TResponse>> GetAllAsync(string? filter = null);
        Task<TResponse?> GetByIdAsync(TKey id);
        Task<ApiResponse> CreateAsync(TDto dto);
        Task<ApiResponse> UpdateAsync(TDto dto);
        Task<ApiResponse> DeleteAsync(TKey id);

    }
}
