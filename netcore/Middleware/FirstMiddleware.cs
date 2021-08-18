using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().Any(char.IsDigit))
            {
                httpContext.Items[0] = "First middleware: Request contains digit";
            }
            else
            {
                httpContext.Items[0] = "First middleware: Request doesn't contain digit";
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FirstMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}
