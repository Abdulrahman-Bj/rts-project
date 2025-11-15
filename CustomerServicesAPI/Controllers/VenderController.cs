using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VenderController : ControllerBase
    {
        private readonly IVenderServices venderServices;

        public VenderController(IVenderServices venderServices)
        {
            this.venderServices = venderServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] string? name, [FromQuery] string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var venders = await venderServices.GetAllAsync(queryParams);
            return Ok(venders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vender = await venderServices.GetById(id);
            if (vender == null)
            {
                return NotFound();
            }
            return Ok(vender);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddVenderRequestDto addVenderRequestDto)
        {
            var vender = await venderServices.CreateAsync(addVenderRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = vender.Id }, vender);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateVenderRequestDto updateVenderRequest)
        {
            var updatedVender = await venderServices.UpdateByIdAsync(id, updateVenderRequest);
            if (updatedVender == null)
            {
                return NotFound();
            }
            return Ok(updatedVender);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await venderServices.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
