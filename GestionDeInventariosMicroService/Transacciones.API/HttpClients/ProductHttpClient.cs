using Shared.Models.Dto;

namespace Transacciones.API.HttpClients
{
    public class ProductHttpClient : IProductHttpClient
    {

        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductHttpClient> _logger;

        public ProductHttpClient(HttpClient httpClient, ILogger<ProductHttpClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Products/{id}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }

        public async Task<bool> UpdateProductStockAsync(int productId, int newStock)
        {
            var payload = new UpdateStockDto
            {
                Id = productId,
                Cantidad = newStock
            };

            var response = await _httpClient.PatchAsJsonAsync("/api/Products/ActualizarStock", payload);

            return response.IsSuccessStatusCode;
        }

    }
}
