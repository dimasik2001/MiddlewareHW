using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace MiddlewareHomework
{
    public class MyMiddleware
    {
        private RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var attr = endpoint?.Metadata.GetMetadata<ExtraHeaderAttribute>();
            if(attr == null)
            {
                return;
            }
            var key = attr.Key;
            var value = attr.Value;
            context.Response.Headers.Add(key, value);
            await _next.Invoke(context);
        }
    }
}
