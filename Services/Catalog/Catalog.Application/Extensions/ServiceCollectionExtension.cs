using Catalog.Application.EventHandlers;
using Catalog.Application.Handlers;
using Catalog.Application.Mappers;
using Catalog.Application.Publishers;
using Common.Core.Interfaces;
using Common.Core.Logger;
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

        services.AddSingleton<IAppStartupEvent, AppStartupEventHandler>();
        services.AddSingleton<IResourcePublisher, ProductCategoryPublisher>();
        services.AddSingleton<ILogger, Logger>();
    }
}
