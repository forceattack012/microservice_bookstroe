using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Context
{
    public class CustomerContext : DbContext
    { 
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }
        public DbSet<Bookstore.Domain.Entities.Customer> Customers { get; set; }
    }
}