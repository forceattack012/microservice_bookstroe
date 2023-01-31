using Book.Infrastructure.Context;
using Book.Infrastructure.Repositories;
using Bookstore.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Infrastructure.Dependency
{
    public static class RegisterService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, string connection, string database) 
        {
            serviceCollection.AddSingleton<IMongoContext>(new MongoContext(connection, database));
            serviceCollection.AddScoped<IBookRepository, BookRepository>();

            return serviceCollection;
        }
    }
}
