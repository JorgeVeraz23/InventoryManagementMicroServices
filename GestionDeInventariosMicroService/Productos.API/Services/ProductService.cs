﻿

using AutoMapper;
using Productos.API.Dto;
using Productos.API.Entity;
using Productos.API.Interface;
using Shared.Models.Dto;
using Shared.Models.Repositories;
using Shared.Models.Repositories.Interfaces;
using Shared.Models.Services.Interfaces;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> ActualizarStockAsync(int id, int cantidad)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ApiResponse(false, "Producto no encontrado");

            product.Stock = cantidad; 
            await _repository.UpdateAsync(product);

            return new ApiResponse(true, "Stock actualizado");
        }

        public async Task<ApiResponse> CreateAsync(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repository.CreateAsync(entity);
            return new ApiResponse(true, "Producto creado exitosamente.");
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            var succes = await _repository.DeleteAsync(id);
            return succes
                    ? new ApiResponse(true, "Producto eliminado.")
                    : new ApiResponse(false, "Producto no encontrado.");

        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(string? filter = null)
        {
            var products = await _repository.GetAllAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                products = products.Where(p => p.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }

            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);  
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<IEnumerable<ProductResponseDto>> GetFilteredAsync(ProductFilterParams filters)
        {
            var products = await _repository.GetFilteredAsync(filters);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<ApiResponse> UpdateAsync(ProductDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing == null)
                return new ApiResponse(false, "Producto no encontrado");

            _mapper.Map(dto, existing);

            
            
            await _repository.UpdateAsync(existing);

            return new ApiResponse(true, "Producto actualizado");

        }
    }
}
