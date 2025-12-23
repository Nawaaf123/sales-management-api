using System.Security.Claims;

namespace SalesManagement.Api.Middleware;

public class MockAuthMiddleware
{
    private readonly RequestDelegate _next;

    public MockAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Read role from header
        var role = context.Request.Headers["X-ROLE"].FirstOrDefault()
                   ?? "salesman"; // default role

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "mock-user"),
            new Claim(ClaimTypes.Role, role)
        };

        var identity = new ClaimsIdentity(claims, "Mock");
        context.User = new ClaimsPrincipal(identity);

        await _next(context);
    }
}
