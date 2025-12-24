using Microsoft.AspNetCore.Authentication;
using SalesManagement.Api.Authentication;
using SalesManagement.Api.Data;
using SalesManagement.Api.Middleware;
using SalesManagement.Api.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("X-ROLE", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "X-ROLE",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter role: admin or salesman"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
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
    .AddScheme<AuthenticationSchemeOptions, MockAuthenticationHandler>("Mock", _ => { });

builder.Services.AddAuthorization();
builder.Services.AddSingleton<DbConnectionFactory>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<MockAuthMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
