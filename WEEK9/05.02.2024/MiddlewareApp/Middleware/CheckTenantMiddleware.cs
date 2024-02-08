namespace MiddlewareApp.Middleware;

public class CheckTenantMiddleware
{
    private readonly RequestDelegate _next;

    public CheckTenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        Console.WriteLine("CheckTenantMiddleware -> Request " + context.Request.Path);
        if (context.Request.Headers.TryGetValue("Tenant-Id", out var tenantId) ||
            string.IsNullOrWhiteSpace(tenantId))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Tenant-Id header is required");
        }

        Console.WriteLine($"Tenant-Id: {tenantId}");

        await _next(context);
        Console.WriteLine("CheckTenantMiddleware -> Response " + context.Response.StatusCode);
    }
}