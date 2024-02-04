using Basket.Application.Extensions;
using Basket.Core.Repositories;
using Basket.Infrastructure.Extension;
using Basket.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


#region necessary objects provider by builder to configure the bootstrap of the web app.

var configuration = builder.Configuration;
var services = builder.Services;
var environment = builder.Environment;
var host = builder.Host;
var webHost = builder.WebHost;
var metrics = builder.Metrics;
var logging = builder.Logging;

#endregion


#region take necessary configuration

var redisConnectionString = configuration["RedisConnectionString"];

if (string.IsNullOrEmpty(redisConnectionString))
{
    throw new ArgumentNullException(nameof(redisConnectionString));
}

#endregion


// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddApplicationServices(builder.Configuration);
services.AddInfrastructureServices();
services.AddApiVersioning();
builder.Services.AddStackExchangeRedisCache(redisCacheOptions =>
{
    redisCacheOptions.Configuration = redisConnectionString;
});

builder.Services.AddHealthChecks()
    .AddRedis(redisConnectionString, "Redis Health", HealthStatus.Degraded);


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
