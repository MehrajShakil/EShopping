using Discount.Application.Interfaces;
using Discount.Core.Repositories;
using Discount.Infrastructure.Persistence.MongoDb;
using Discount.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Persistence
            services.AddScoped<IDatabaseClient, MongoDbClient>();

            // Repository
            services.AddScoped<ICouponRepository, CouponRepository>();
        }
    }
}
