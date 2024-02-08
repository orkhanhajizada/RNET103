using MiddlewareApp.Middleware;

namespace MiddlewareApp;

public static class ConfigureMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }
    
    public static IApplicationBuilder UseCheckTenant(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CheckTenantMiddleware>();
    }
}