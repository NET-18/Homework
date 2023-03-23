using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Data;

namespace ApiWithEF.Filters
{
    public class LastUserActivityActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<LastUserActivityActionFilter> _logger;
        private readonly StoreDbContext _context;

        public LastUserActivityActionFilter(ILogger<LastUserActivityActionFilter> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();
            var userId = -1;

            var key = context.RouteData.Values.Keys.FirstOrDefault(k => k.Contains("userid", StringComparison.OrdinalIgnoreCase)) ?? "";
            var exists = context.RouteData.Values.TryGetValue(key, out var userIdObj);

            if (exists)
            {
                userId = Convert.ToInt32(userIdObj);
            }
            else
            {
                using var ms = new MemoryStream();
                using var sr = new StreamReader(ms);

                await context.HttpContext.Request.Body.CopyToAsync(ms);
                ms.Position = 0;
                
                var json = await sr.ReadToEndAsync();
                if (json == "")
                {
                    return;
                }
                var dto = JToken.Parse(json);

                var idToken = dto["userId"];

                if (idToken != null)
                {
                    userId = Convert.ToInt32(idToken);
                }
            }

            if (userId == -1)
            {
                return;
            }
            
            _logger.LogInformation("last activity of user {0}: {1}", userId, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffff"));
            await _context.AddAsync(new LastAction()
            {
                UserId = userId,
                LastActionActivity = "last activity of user at "+ DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffff")
            });
            await _context.SaveChangesAsync();
        }

    }
}
