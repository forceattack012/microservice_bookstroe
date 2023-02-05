using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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