

namespace Bookstore.Domain.Entities
{
    public class Basket 
    {
        public string UsertName { get; set; }
        public List<Book> Books { get; set; }

        public int Count => Books?.Count == null ? 0 : Books.Count;

        private decimal total { 
            get
            {
                decimal _total = 0;

                foreach(var book in Books)
                {
                    _total += book.Price;
                }
                return _total;
            } 
        }
        public decimal Total => total;
    }
}
