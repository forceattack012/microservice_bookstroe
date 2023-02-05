using System;
using Bookstore.Domain.Repositories;
using Customer.Infrastructure.Context;
using Customer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infrastructure.Dependency
{
	public static class RegisterService
	{
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<CustomerContext>(option =>
                option.UseNpgsql(configuration.GetConnectionString("CustomerContext")));

            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            
            return serviceCollection;
        }
    }
}

