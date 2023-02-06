using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Customer.API.Models
{
    public class CustomerRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string FristName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}