using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.API.Dto;
using Productos.API.Interface;
using Productos.API.Services;
using Shared.Models.Dto;
using Shared.Models.Services.Interfaces;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _service;
        private readonly IStoredFileService _fileService;
        private IMapper _mapper;

        public ProductsController(
            IProductService service,
            IStoredFileService fileService,
            IMapper mapper)
        {
            _service = service;
            _fileService = fileService;
            _mapper = mapper;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll([FromQuery] string? filter = null)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(result);
        }


        [HttpGet("GetFilteredAsync")]
        public async Task<IActionResult> GetFilteredAsync([FromQuery] ProductFilterParams filters)
        {
            var result = await _service.GetFilteredAsync(filters);
            return Ok(result); 
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto request)
        {
            Guid? imageId = null;

            if (request.Image != null)
            {
                var file = await _fileService.SaveAsync(request.Image);
                imageId = file.Id;
            }

            var dto = _mapper.Map<ProductDto>(request);
            dto.ImageFileId = imageId;

            var response = await _service.CreateAsync(dto);
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateDto request)
        {
            Guid? imageId = null;

            if (request.Image != null)
            {
                var file = await _fileService.SaveAsync(request.Image);
                imageId = file.Id;
            }

            var dto = _mapper.Map<ProductDto>(request);
            dto.ImageFileId = imageId;

            var response = await _service.UpdateAsync(dto);
            return response.Success ? Ok(response) : NotFound(response);
        }


        [HttpPatch("ActualizarStock")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockDto dto)
        {
            var result = await _service.ActualizarStockAsync(dto.Id, dto.Cantidad);
            return result.Success ? Ok(result) : NotFound(result);
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }


    }
}
