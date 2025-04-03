using AutoMapper;
using Shared.Models.UtilitiesShared;
using Transacciones.API.Dto;
using Transacciones.API.Entity;
using Transacciones.API.HttpClients;
using Transacciones.API.Interface.ITransactionRepository;
using Transacciones.API.Interface.ITransactionService;

namespace Transacciones.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductHttpClient _productHttpClient;
        private readonly IMapper _mapper;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IProductHttpClient productHttpClient,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _productHttpClient = productHttpClient;
            _mapper = mapper;
        }

        public async Task<ApiResponse> RegisterAsync(TransactionCreateDTO dto)
        {
            
            var product = await _productHttpClient.GetProductByIdAsync(dto.ProductoId);
            if (product == null)
                return new ApiResponse(false, "Producto no encontrado");

            
            if (dto.TipoTransaccion == TransactionType.Venta && product.Stock < dto.Cantidad)
                return new ApiResponse(false, "Stock insuficiente");

            
            var nuevoStock = dto.TipoTransaccion == TransactionType.Compra
                ? product.Stock + dto.Cantidad
                : product.Stock - dto.Cantidad;

            
            var stockActualizado = await _productHttpClient.UpdateProductStockAsync(product.Id, nuevoStock);
            if (!stockActualizado)
                return new ApiResponse(false, "No se pudo actualizar el stock del producto");

           
            var transaction = _mapper.Map<Transaction>(dto);
            transaction.UnitPrice = product.Precio;
            transaction.Total = product.Precio * dto.Cantidad;

            await _transactionRepository.CreateAsync(transaction);

            return new ApiResponse(true, "Transacción registrada exitosamente");
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetAllAsync()
        {
            var list = await _transactionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransactionResponseDto>>(list);
        }

        public async Task<TransactionResponseDto?> GetByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            return transaction == null ? null : _mapper.Map<TransactionResponseDto>(transaction);
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetFilteredAsync(TransactionFilterParams filters)
        {
            var list = await _transactionRepository.GetFilteredAsync(filters);
            return _mapper.Map<IEnumerable<TransactionResponseDto>>(list);
        }

     
    }

}
