using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Ordering.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["IdentityServer:Authority"];
                options.Audience = configuration["IdentityServer:Audience"];
                options.RequireHttpsMetadata = false;
            });
    }
}
