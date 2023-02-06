using Bookstore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Order.Infrastructure.Context;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;

namespace Order.Infrastructure.Dependency
{
	public static class RegisterService
	{
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<OrderContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("OrderContext"));
            });

            serviceCollection.AddSingleton<ISeedOrderContext>(new SeedOrderContext(configuration.GetConnectionString("OrderContext")));
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            
            return serviceCollection;
        }
    }
}

