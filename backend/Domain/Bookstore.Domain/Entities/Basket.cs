

namespace Bookstore.Domain.Entities
{
    public class Basket
    {
        public string UsertName { get; set; }
        public List<Book> Books { get; set; }

        public int Count
        {
            get
            {
                int count = Books?.Sum(r => r.Qty) ?? 0;
                return count;
            }
        }

        private decimal total { 
            get
            {
                decimal _total = Books?.Sum(r => r.Price * r.Qty) ?? 0;
                return _total;
            } 
        }
        public decimal Total => total;
    }
}
