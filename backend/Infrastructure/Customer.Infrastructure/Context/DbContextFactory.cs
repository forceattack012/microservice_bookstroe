using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Customer.Infrastructure.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CustomerContext>
    {
        public CustomerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=bookstore;Username=admin;Password=abcd1234");

            return new CustomerContext(optionsBuilder.Options);
        }
    }
}
