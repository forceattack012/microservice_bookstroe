using Bookstore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateStaff([FromBody] Staff staff)
        {
            return Ok();
        }
    }
}
