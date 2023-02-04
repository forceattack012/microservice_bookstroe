using Authen.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        [HttpPost("login/customer")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            return Ok();
        }

        [HttpPost("login/staff")]
        public IActionResult LoginStaff([FromBody] LoginRequest loginRequest)
        {
            return Ok();
        }
    }
}
