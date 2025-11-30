using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyServices currencyServices;

        public CurrencyController(ICurrencyServices currencyServices)
        {
            this.currencyServices = currencyServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] string? code, [FromQuery] string? page, [FromQuery] string? limit, [FromQuery] string? sort)
        {
            var query = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var currencies = await currencyServices.GetAllAsync(query);
            return ApiOk(currencies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var currency = await currencyServices.GetByIdAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            return ApiOk(currency);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCurrencyRequestDto dto)
        {
            var currency = await currencyServices.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = currency.Id }, currency);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, UpdateCurrencyRequestDto dto)
        {
            var updatedCurrency = await currencyServices.UpdateByIdAsync(id, dto);
            if (updatedCurrency == null)
            {
                return NotFound();
            }
            return ApiOk(updatedCurrency);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var isDeleted = await currencyServices.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
