using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Entities.Interfaces
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string FristName { get; set; }
        string LastName { get; set; }
        bool IsActive { get; set; }
        DateTime? ActiveDate { get; set; }
        DateTime? CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
