using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Graph;

namespace ApiWithEF.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;


        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"something went wrong: {ex}");
                await HandlerExceptionAsync(context, ex);
            }
        }

        private async Task HandlerExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsync("");

        }
    }
}
