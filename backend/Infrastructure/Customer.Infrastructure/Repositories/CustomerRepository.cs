using Bookstore.Domain.Repositories;
using Customer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(Bookstore.Domain.Entities.Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Bookstore.Domain.Entities.Customer customer)
        {
            _context.Entry(customer).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Bookstore.Domain.Entities.Customer> GetCustomerById(long id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateCustomer(Bookstore.Domain.Entities.Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}