using Common.Core.Interfaces;

namespace Catalog.Api.Extensions
{
    public static class AppStartupEventExtension
    {
        public static async Task OnStartupEvent(this WebApplication app)
        {
            var appStartupEvents = app.Services.GetServices<IAppStartupEvent>();

            foreach (var appStartupEvent in appStartupEvents)
            {
                await appStartupEvent.HandleAsync();
            }
        }
    }
}
