using Basket.Application.Extensions;
using Basket.Infrastructure.Extension;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApiVersioning();

// Set Redis Connection Strnig.

builder.Services.AddStackExchangeRedisCache(redisCacheOptions =>
{

    redisCacheOptions.Configuration = builder.Configuration.GetSection("RedisConnectionString").Value;
});

builder.Services.AddHealthChecks()
    .AddRedis(builder.Configuration.GetSection("RedisConnectionString").Value, "Redis Health", HealthStatus.Degraded);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
