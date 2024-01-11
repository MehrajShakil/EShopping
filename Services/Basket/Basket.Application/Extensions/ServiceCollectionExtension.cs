
using Basket.Application.Commands;
using Basket.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(typeof(BasketProfile).Assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(CreateShoppingCartCommand));
        });
    }
}
