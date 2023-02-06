using System;
namespace Bookstore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Bookstore.Domain.Entities.Customer customer);
        Task UpdateCustomer(Bookstore.Domain.Entities.Customer customer);
        Task DeleteCustomer(Bookstore.Domain.Entities.Customer customer);
        Task<Bookstore.Domain.Entities.Customer> GetCustomerById(long id);
    }
}