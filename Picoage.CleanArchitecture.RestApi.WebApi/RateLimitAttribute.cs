using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net;

namespace Picoage.CleanArchitecture.RestApi.WebApi
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RateLimitAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }

        public double Seconds { get; set; }

        private readonly static MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            IPAddress iPAddress = context.HttpContext.Connection.RemoteIpAddress;

            string cacheKey = $"{Name}-{iPAddress}";

            if (!cache.TryGetValue(cacheKey, out bool result))
            {
                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
                options.SetAbsoluteExpiration(TimeSpan.FromSeconds(Seconds));
                cache.Set(cacheKey, true, options);
            }
            else
            {
                //TODO Log IP Address 
                context.Result = new ContentResult
                {
                    Content = "Too many request"
                };
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
            }
        }
    }
}
