using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult ApiOk<T>(T data)
        {
            var result = new ApiResponse<T>()
            {
                Code = 200,
                Status = "sccuess",
                Data = data
            };

            return Ok(result);
        }
    }
}
