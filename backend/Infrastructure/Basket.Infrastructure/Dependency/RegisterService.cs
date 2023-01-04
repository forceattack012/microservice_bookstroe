using Basket.Infrastructure.Repositories;
using Bookstore.Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Dependency
{
    public static class RegisterService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddScoped<IBasketRepository, BasketRepository>();

            return serviceCollection;
        }
    }
}
