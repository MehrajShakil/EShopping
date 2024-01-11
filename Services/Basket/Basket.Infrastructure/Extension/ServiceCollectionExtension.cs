using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Core.Repositories;
using Basket.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}
