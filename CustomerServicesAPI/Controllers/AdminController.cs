using Application.DTOs;
using Application.Interfaces;
using Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {
        private readonly IAdminServices adminServices;

        public AdminController(IAdminServices adminServices)
        {
            this.adminServices = adminServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins([FromQuery] string? name, [FromQuery] string? username, [FromQuery] string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var admins = await adminServices.GetAllAsync(queryParams);
            return ApiOk(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var admin = await adminServices.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return ApiOk(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAdminRequestDto addAdminRequestDto)
        {
            var admin = await adminServices.CreateAsync(addAdminRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateAdminRequestDto updateAdminRequestDto)
        {
            var updatedAdmin = await adminServices.UpdateByIdAsync(id, updateAdminRequestDto);
            if (updatedAdmin == null)
            {
                return NotFound();
            }
            return ApiOk(updatedAdmin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await adminServices.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
