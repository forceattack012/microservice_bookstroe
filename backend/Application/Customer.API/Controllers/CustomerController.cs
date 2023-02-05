using Microsoft.AspNetCore.Mvc;
using Bookstore.Domain.Repositories;
using Customer.API.Models;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository repo){
            _customerRepository = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest customerReq){
            Bookstore.Domain.Entities.Customer customer = new Bookstore.Domain.Entities.Customer();
            customer.Email = customerReq.Email;
            await _customerRepository.CreateCustomer(customer);
            return StatusCode(201, "created");
        }
    }
}