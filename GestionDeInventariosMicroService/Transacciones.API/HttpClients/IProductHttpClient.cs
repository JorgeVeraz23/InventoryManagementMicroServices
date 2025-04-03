using Shared.Models.Dto;

namespace Transacciones.API.HttpClients
{
    public interface IProductHttpClient
    {
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<bool> UpdateProductStockAsync(int productId, int newStock);
    }
}
