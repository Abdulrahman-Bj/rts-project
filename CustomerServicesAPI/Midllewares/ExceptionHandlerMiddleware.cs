using Application.DTOs;
using Application.Exceptions;
using System.Net;

namespace CustomerServicesAPI.Midllewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (InputValidationException ex)
            {
                int code = 400;
                httpContext.Response.StatusCode = code;
                await httpContext.Response.WriteAsJsonAsync(new { Code = code, Status = "error", ex.Message });
            }
            catch (Exception ex)
            {
                int code = (int) HttpStatusCode.InternalServerError;
                httpContext.Response.StatusCode = code;
                await httpContext.Response.WriteAsJsonAsync(new { Code = code, Status = "error", Message = ex.Message });
            }
        }
    }
}
