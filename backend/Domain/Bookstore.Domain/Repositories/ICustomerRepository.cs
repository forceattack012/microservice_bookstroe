using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Bookstore.Domain.Entities.Customer customer);
        Task DeleteCustomer(Bookstore.Domain.Entities.Customer customer);
        Task<Bookstore.Domain.Entities.Customer?> GetCustomerById(int id);
    }
}