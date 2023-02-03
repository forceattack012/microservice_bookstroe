using Bookstore.Domain.Entities.Interfaces;


namespace Bookstore.Domain.Entities
{
    public class Staff : Entity<long>, IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ActiveDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Level { get; set; }
        public string[] Permission { get; set; }
    }
}
