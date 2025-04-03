using Productos.API.Dto;
using Shared.Models.Dto;
using Shared.Models.Services.Interfaces;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Interface
{
    public interface IProductService : ICrudService<ProductDto, ProductResponseDto, int>
    {
        Task<IEnumerable<ProductResponseDto>> GetFilteredAsync(ProductFilterParams filters);
        Task<ApiResponse> ActualizarStockAsync(int id, int cantidad);

    }
}
