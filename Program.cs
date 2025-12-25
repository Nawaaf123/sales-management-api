using Microsoft.AspNetCore.Authentication;
using SalesManagement.Api.Authentication;
using SalesManagement.Api.Data;
using SalesManagement.Api.Middleware;
using SalesManagement.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// -------------------- SERVICES --------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("X-ROLE", new OpenApiSecurityScheme
    {
        Name = "X-ROLE",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Enter role: admin or salesman"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "X-ROLE"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<InvoicesService>();

builder.Services.AddAuthentication("Mock")
    .AddScheme<AuthenticationSchemeOptions, MockAuthenticationHandler>(
        "Mock", _ => { });

builder.Services.AddAuthorization();

// -------------------- APP --------------------

var app = builder.Build();

// Swagger (enabled for now)
app.UseSwagger();
app.UseSwaggerUI();

// Pipeline order matters
app.UseHttpsRedirection();

app.UseMiddleware<MockAuthMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

// 🔥 THIS IS THE MOST IMPORTANT LINE
app.MapControllers();

// 🔥 ONLY ONE Run(), AT THE END
app.Run();
