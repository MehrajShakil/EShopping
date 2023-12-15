using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepositories, ProductRepository>();
        services.AddScoped<IProductBrandRepository, ProductRepository>();
        services.AddScoped<IProductTypeRepository, ProductRepository>();
        services.AddSingleton<ICatalogContext, CatalogContext>();
    }
}
