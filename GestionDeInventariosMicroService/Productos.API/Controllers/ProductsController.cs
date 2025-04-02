using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.API.Dto;
using Shared.Models.Services.Interfaces;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ICrudService<ProductDto, ProductResponseDto, int> _service;

        public ProductsController(ICrudService<ProductDto, ProductResponseDto, int> service)
        {
            _service = service;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll([FromQuery] string? filter = null)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(result);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] ProductDto dto)
        {
            var response = await _service.CreateAsync(dto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // PUT: api/products
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] ProductDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }


    }
}
