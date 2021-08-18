using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace netcore.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecondMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.ToString().Contains("test"))
            {
                string outputText = $"{context.Items[0]}\nSecond middleware: Contains 'test' ";
                await context.Response.WriteAsync(outputText);
            }
            else
            {
                throw new Exception("Invalid URL");
            }

            await next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SecondMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecondMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecondMiddleware>();
        }
    }
}
