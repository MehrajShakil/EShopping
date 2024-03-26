using Common.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application.EventHandlers;

public class AppStartupEventHandler : IAppStartupEvent
{
    private readonly IServiceProvider _serviceProvider;

    public AppStartupEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleAsync()
    {
        var resourcePublishers = _serviceProvider.GetServices<IResourcePublisher>();
        foreach (var resource in resourcePublishers)
        {
            if (resource.Enabled)
            {
                await resource.PublishAsync();
            }
        }
    }
}
