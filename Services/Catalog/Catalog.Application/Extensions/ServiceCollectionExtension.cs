using Catalog.Application.Handlers;
using Catalog.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(GetProductByIdQueryHandler));
        });
    }


}
