using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Entities
{
    public class Order
    {
        public Int64 OrderId { get; set; }
        public Decimal TotalAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public String? PaymentStatus { get; set; }
        public Customer? Customer { get; set; }
        public List<BookOrder>? BookOrders { get; set; }
    }

    public class BookOrder
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public int Qty { get; set; }
        public Order Order { get; set; }
    }
}
