using Bookstore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Authen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            return Ok();
        }
    }
}
