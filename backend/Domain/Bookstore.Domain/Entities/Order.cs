using Bookstore.Domain.Entities.Interfaces;

namespace Bookstore.Domain.Entities
{
    public class Order : Entity<long>
    {
        public long OrderId { get => Id; }
        public long CustomerId { get; set; }
        public Decimal TotalAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public bool IsPayment { get; set; }
        public List<BookOrder> BookOrders { get; set; }
    }

    public class BookOrder
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public int Qty { get; set; }
        public Order Order { get; set; }

    }
}
