using Microsoft.AspNetCore.Http;
using System.Net;

namespace FourSix.Controllers.Middlewares
{
    public class CustomHttpContextMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHttpContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                httpContext.Request.EnableBuffering();
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                _ => (int)HttpStatusCode.InternalServerError,
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/text";
            return context.Response.WriteAsync(exception.Message);
        }

    }
}
