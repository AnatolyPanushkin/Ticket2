using Microsoft.AspNetCore.Builder;

namespace Ticket2.Middleware
{
    public static class MiddlewareExtantion
    {
        public static IApplicationBuilder UseJsonValid(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JsonValidMiddleware>();
        }
    }
}