using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Authen.API.Models
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
