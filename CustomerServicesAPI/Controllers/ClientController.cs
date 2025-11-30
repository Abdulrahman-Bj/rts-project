using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService )
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] string? phone, [FromQuery] string? name, [FromQuery] string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var clients = await clientService.GetAllAsync(queryParams);
            return ApiOk(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client = await clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return ApiOk(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddClientRequestDto addClientRequestDto)
        {
            var client = await clientService.CreateAsync(addClientRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateClientRequestDto updateClientRequestDto)
        {
            var updatedClient = await clientService.UpdateByIdAsync(id, updateClientRequestDto);
            if (updatedClient == null)
            {
                return NotFound();
            }
            return ApiOk(updatedClient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await clientService.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
