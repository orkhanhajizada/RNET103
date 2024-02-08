using Microsoft.AspNetCore.Http.Extensions;

namespace MiddlewareApp.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        var response = context.Response;

        Console.WriteLine($"Request: {request.Method}, {request.Path}, {request.GetDisplayUrl()}");
        await _next(context);
        Console.WriteLine($"Response: {response.StatusCode}");
    }
}