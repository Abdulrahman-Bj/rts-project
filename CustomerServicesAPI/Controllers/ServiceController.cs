using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServiceController : BaseController
    {
        private readonly IServiceServices serviceServices;

        public ServiceController(IServiceServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var services = await serviceServices.GetAllAsync(queryParams);

            return ApiOk(services);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var service = await serviceServices.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return ApiOk(service);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBy(Guid id, [FromForm] UpdateServiceRequestDto dto)
        {
            var service = await serviceServices.UpdateByIdAsync(id, dto);
            if (service == null)
            {
                return NotFound();
            }

            return ApiOk(service);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AddServiceRequestDto dto)
        {

            var service = await serviceServices.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await serviceServices.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
