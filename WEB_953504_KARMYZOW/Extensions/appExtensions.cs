using Microsoft.AspNetCore.Builder;
using WEB_953504_KARMYZOW.Middleware;

namespace WEB_953504_KARMYZOW.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder
        UseFileLogging(this IApplicationBuilder app) =>
            app.UseMiddleware<LogMiddleware>();
    }
}
