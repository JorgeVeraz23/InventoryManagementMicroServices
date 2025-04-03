using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.UtilitiesShared;
using Transacciones.API.Dto;
using Transacciones.API.Interface.ITransactionService;

namespace Transacciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionCreateDTO dto)
        {
            var result = await _transactionService.RegisterAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _transactionService.GetAllAsync();
            return Ok(result);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _transactionService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

       
        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] TransactionFilterParams filters)
        {
            var result = await _transactionService.GetFilteredAsync(filters);
            return Ok(result);
        }


    }
}
