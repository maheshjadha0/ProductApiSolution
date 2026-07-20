using Domain.Exceptions;
using System.Net;
using System.Text.Json;
namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DuplicateProductException ex)
            {
                await HandleExceptionAsync(context,
                    HttpStatusCode.Conflict,
                    ex.Message);
            }
            catch (Exception) 
            { 
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    "An unexpected error occurred");
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
