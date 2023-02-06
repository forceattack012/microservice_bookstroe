using Microsoft.AspNetCore.Mvc;
using Bookstore.Domain.Repositories;
using Customer.API.Models;
using System.Net;
using Bookstore.Api.Helper;
using Bookstore.Domain.Responses;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository repo)
        {
            _customerRepository = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest customerReq){
            Bookstore.Domain.Entities.Customer customer = new Bookstore.Domain.Entities.Customer();
            customer.Email = customerReq.Email;
            customer.CreateDate = DateTime.Now.SetKindUtc();
            customer.IsActive = false;
            customer.FristName = customerReq.FristName;
            customer.LastName = customerReq.LastName;
            customer.Phone = customerReq.Phone;
            customer.Username = customerReq.Username;
            customer.Password = customerReq.Password;
            
            await _customerRepository.CreateCustomer(customer);
            return StatusCode((int)HttpStatusCode.Created, customer.Id);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCustomer(long id, [FromBody] CustomerRequest customerReq)
        {
            var existCustomer = await _customerRepository.GetCustomerById(id);
            if(existCustomer == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "not found");
            }

            existCustomer.Email = customerReq.Email;
            existCustomer.FristName = customerReq.FristName;
            existCustomer.LastName = customerReq.LastName;
            existCustomer.Phone = customerReq.Phone;
            existCustomer.Username = customerReq.Username;
            existCustomer.Password = customerReq.Password;
            existCustomer.UpdateDate = DateTime.Now.SetKindUtc();

            await _customerRepository.UpdateCustomer(existCustomer);
            return StatusCode((int)HttpStatusCode.OK, "updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var existCustomer = await _customerRepository.GetCustomerById(id);
            if (existCustomer == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "not found");
            }

            await _customerRepository.DeleteCustomer(existCustomer);
            return StatusCode((int)HttpStatusCode.OK, "deleted");
        }
    }
}